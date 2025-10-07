﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Repository;

namespace Vask_En_Tid_Library.Service
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public void Add(Booking booking)
        {
            List<Booking> all = _bookingRepo.GetAll();

            foreach (Booking existing in all)
            {
                bool sameResident = existing.ResidentID == booking.ResidentID;
                bool futureOrSameDay = existing.BookingDate >= DateTime.Today;

                if (sameResident && futureOrSameDay)
                {
                    throw new Exception("Denne beboer har allerede en aktiv booking.");
                }
            }


            foreach (Booking existing in all)
            {
                bool sameMachine = existing.MachineID == booking.MachineID;
                bool sameDate = existing.BookingDate.Date == booking.BookingDate.Date;
                bool sameSlot = existing.TimeSlot == booking.TimeSlot;

                if (sameMachine && sameDate && sameSlot)
                {
                    throw new Exception("Denne maskine er allerede booket i dette tidsrum.");
                }
            }


            _bookingRepo.Add(booking);
        }


        public void Delete(int id)
        {
            _bookingRepo.Delete(id);
        }

        public List<Models.Booking> GetAll()
        {
            return _bookingRepo.GetAll();
        }
        public void Update(Models.Booking booking)
        {
            _bookingRepo.Update(booking);
        }
    }
}
