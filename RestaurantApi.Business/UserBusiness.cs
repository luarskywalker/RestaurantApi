
using RestaurantApi.Data;
using RestaurantApi.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RestaurantApi.Business
{
    public static class UserBusiness
    {
        public static LoginResponse Login(string email, string password)
        {
            if (ValidateEmail(email) && ValidatePassword(password))
            {
                var user = new UserDataMapper().LoginUser(email, password);
                LoginResponse response = new LoginResponse();
                if (user != null)
                {
                    response.Success = true;
                    response.IdUser = user.Id;
                    response.Message = null;
                    response.SessionKey = CreateSessionKey(user, DateTime.Now);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Username or password incorrect";
                }
                return response;
            }
            else
            {
                var Message = "Please verify:";
                if (!ValidateEmail(email))
                    Message += "\nEmail has not the right format";
                if (!ValidatePassword(password))
                    Message += "\nPassword must be at least 10 characters long, must have at least one upper case, one lower case, one number and one special character(@!#?)";
                return new LoginResponse()
                {
                    Success = false,
                    Message = Message
                };
            }
        }
        public static Response Create(UserModel item)
        {
            if (ValidateEmail(item.Email) && ValidatePassword(item.Password))
            {
                var UsrB = new UserDataMapper();
                var exists = UsrB.GetByEmail(item.Email);
                if (exists != null)
                {
                    return new Response()
                    {
                        Success = false,
                        Message = "The email address is already registered"
                    };
                }
                var newuser = new UserDataMapper().Create(item);
                if (newuser != null)
                {
                    return new Response()
                    {
                        Success = true
                    };
                }
                else
                {
                    return new Response()
                    {
                        Success = false,
                        Message = "It could not be possible to create the new user. Please check your information and retry."
                    };
                }
            }
            else
            {
                var Message = "Please verify:";
                if (!ValidateEmail(item.Email))
                    Message += "\nEmail has not the right format";
                if (!ValidatePassword(item.Password))
                    Message += "\nPassword must be at least 10 characters long, must have at least one upper case, one lower case, one number and one special character(@!#?)";
                return new Response()
                {
                    Success = false,
                    Message = Message
                };
            }
        }

        public static void Update(UserModel item)
        {
            UserDataMapper UserDM = new UserDataMapper();
            UserDM.Update(item);
        }

        public static List<UserModel> GetAll()
        {
            return new UserDataMapper().GetAll();
        }

        public static UserModel GetById(int Id)
        {
            return new UserDataMapper().GetById(Id);
        }

        public static ValidationResult ValidateUser(string token)
        {
            ValidationResult toReturn = new ValidationResult();
            string decripted = Utils.Decrypt(token);
            string[] parts = decripted.Split('|');
            if (parts.Length == 3)
            {
                var user = new UserDataMapper().GetById(int.Parse(parts[1]));
                if (user != null)
                {
                    if (user.Email == parts[0])
                    {
                        var diff = DateTime.Now - DateTime.Parse(parts[2]);
                        if (diff.Minutes <= 20)
                        {
                            toReturn.Status = true;
                            toReturn.IdUser = user.Id;
                        }
                        else
                            toReturn.Status = false;
                    }
                    else
                        toReturn.Status = false;
                }
                else
                    toReturn.Status = false;
            }
            else
                toReturn.Status = false;
            return toReturn;
        }

        private static bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            else
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                return match.Success;
            }
        }

        public static bool ValidatePassword(string password)
        {
            string patternPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@!#?])[A-Za-z\d@!#?]{10,100}$";
            if (!string.IsNullOrEmpty(password))
            {
                if (!Regex.IsMatch(password, patternPassword))
                {
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

        public static string CreateSessionKey(UserModel user, DateTime time)
        {
            return Utils.Encrypt("" + user.Email + "|" + user.Id + "|" + time);
        }
    }
}

