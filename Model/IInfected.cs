using System;

namespace API.NET.Model
{
    public class IInfected
    {
        public string _id { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}