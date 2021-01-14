using System;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace API.NET.Data.Collections
{
    public class Infected
    {
        public Infected(DateTime birth, string gender, double latitude, double longitude)
        {
            this._id = ObjectId.GenerateNewId().ToString();
            this.Birth = birth;
            this.Gender = gender;
            this.Location = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        public string _id { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public GeoJson2DGeographicCoordinates Location { get; set; }
    }
}