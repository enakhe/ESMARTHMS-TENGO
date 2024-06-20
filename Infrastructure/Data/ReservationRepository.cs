using ESMART_HMS.Domain.Entities;
using ESMART_HMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESMART_HMS.Infrastructure.Data
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ESMART_HMSDBEntities _db;

        public ReservationRepository(ESMART_HMSDBEntities db)
        {   
            _db = db;
        }

        public void AddReservation(Reservation reservation)
        {
            try
            {
                _db.Reservations.Add(reservation);
                _db.SaveChanges();
                MessageBox.Show("Successfully added reservation information", "Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Exception Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }   
    }
}
