using System;

namespace API.Entities
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime time { get; set; }
        public int Platelets { get; set; }
        public float Albumin { get; set; }
    }
}