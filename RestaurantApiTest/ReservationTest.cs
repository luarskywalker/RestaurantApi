using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantApi.Business;
using RestaurantApi.Model;
using System;

namespace RestaurantApiTest
{
    [TestClass]
    public class ReservationTest
    {
        [TestMethod]
        [DataRow(1, 1, 1, "2022/01/20 20:00:00", "Notes", "300-00000000", "John Doe")]
        public void CreateUpdateDeleteReservation(int idRestaurant, int idReservationStatus, int idUser, string reservationHour, string reservationNotes, string contactNumber, string reservationName)
        {
            var reservation = new ReservationModel()
            {
                IdRestaurant = idRestaurant,
                IdReservationStatus = idReservationStatus,
                IdUser = idUser,
                ReservationHour = DateTime.ParseExact(reservationHour, "yyyy/MM/dd HH:mm:ss", null),
                ReservationNotes = reservationNotes,
                ContactNumber = contactNumber,
                ReservationName = reservationName
            };
            var res = ReservationBusiness.Create(reservation);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success);

            res.Reservation.IdReservationStatus = 2;
            res.Reservation.ReservationName = "Name Edited";
            res.Reservation.ReservationNotes = "Note Edited";
            try
            {
                ReservationBusiness.Update(res.Reservation);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
            try
            {
                ReservationBusiness.Delete(res.Reservation.Id);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }        
    }
}
