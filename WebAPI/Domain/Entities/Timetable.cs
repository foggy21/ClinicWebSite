﻿namespace Domain.Entities
{
    class Timetable
    {
        public int DoctorId { get; set; }
        public DateTime StartWorkDay { get; set; }
        public DateTime EndWorkDay { get; set; }
    }
}