using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Concrete
{
    public class EFReservationRepository : I_ReservationRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Reservation> Reservations
        {
            get { return context.Reservations; }
        }
        
        public void AddReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }

        public void SaveReservation(Reservation reservation)
        {
            if (reservation.ReservationID == 0)
            {
                context.Reservations.Add(reservation);
            }
            else
            {
                Reservation dbEntry = context.Reservations.Find(reservation.ReservationID);
                if (dbEntry != null)
                {
                    dbEntry.MemberID = reservation.MemberID;
                    dbEntry.ItemID = reservation.ItemID;
                    dbEntry.StartDate = reservation.StartDate;
                    dbEntry.DueDate = reservation.DueDate;
                }
            }
            context.SaveChanges();
        }

        public Reservation DeleteReservation(int reservationID)
        {
            Reservation dbEntry = context.Reservations.Find(reservationID);
            if (dbEntry != null)
            {
                context.Reservations.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
