using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Abstract
{
    public interface I_ReservationRepository
    {
        IQueryable<Reservation> Reservations { get; }
        void SaveReservation(Reservation Reservation);
        Reservation DeleteReservation(int ReservationID);
        //Member GetReservation(int ReservationID);
        //Member GetReservation(DateTime DueDate);
    }
}
