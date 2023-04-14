﻿using sheltermini.Shared;
using MongoDB.Bson;
using MongoDB.Driver;


namespace sheltermini.server.Repositories
{         
    public class ShelterRepositoryMongoDB : IShelterRepository
    {
        private List<Shelter> shelters;
        
        public ShelterRepositoryMongoDB()
        {
            shelters = new();
        }

        public Shelter[] getAll()
        {
            shelters.Clear();
            var client = new MongoClient("mongodb+srv://eaajakhj:kajkage02@sheltermini.f1ql71j.mongodb.net/test");
            var database = client.GetDatabase("sheltermini");
            var collection = database.GetCollection<BsonDocument>("aarhus_shelters");
            var documents = collection.Find($"{{}}").ToList();

            var Emails = new List<string>
            {
                "larsen@nyborg.dk, 52926786",
                "christoffersen@stevns.dk, 20156877",
                "pedersen@helsinge.dk, 67607831",
                "nielsen@ringkobing.dk, 53866618",
                "madsen@hjorring.dk, 98889880",
                "jensen@rebild.dk, 29815248",
                "thomsen@fano.dk, 76885802",
                "andersen@assens.dk, 35761798",
                "rasmussen@vordingborg.dk, 55383753",
                "olsen@bronderslev.dk, 96561863",
                "moller@kalundborg.dk, 44988255",
                "bach@kerteminde.dk, 54815690",
                "hansen@ringsted.dk, 62108972",
                "knudsen@esbjerg.dk, 61893270",
                "mortensen@randers.dk, 22538461",
                "petersen@albertslund.dk, 23179604",
                "thorup@fredericia.dk, 46106254",
                "fischer@horsens.dk, 34458447",
                "lund@fredensborg.dk, 30552462",
                "svendsen@furesoe.dk, 56951026",
                "kristensen@silkeborg.dk, 22938609",
                "johansen@skanderborg.dk, 53639002",
                "mogensen@kolding.dk, 71494092",
                "schmidt@soro.dk, 40932550",
                "lykke@viborg.dk, 85872986",
                "laursen@sonderborg.dk, 87486561",
                "hald@roskilde.dk, 42929362",
                "jakobsen@assens.dk, 53862573",
                "bentzen@tarnby.dk, 66168476",
                "sorensen@lejre.dk, 30865460",
            };

            foreach (var doc in documents)
            {
                var Name = doc["properties"]["navn"].ToString();
                var KommuneName = doc["properties"]["cvr_navn"].ToString();
                var Description = doc["properties"]["beskrivels"].ToString();
                var Capacity = doc["properties"]["antal_pl"].ToInt32();
                var Contact = doc["properties"]["kontak_ved"].ToString();

                if (Contact == "BsonNull")  
                {
                    Contact = Emails[new Random().Next(0, Emails.Count)];
                };
                var lat = doc["geometry"]["coordinates"][0][0].ToDecimal();
                var longitude = doc["geometry"]["coordinates"][0][1].ToDecimal();
                var mbook = new Shelter { Name = Name, KommuneName = KommuneName, Description = Description, Capacity = Capacity, Contact = Contact, lat = lat, longitude = longitude };
                
            
                
                shelters.Add(mbook);
            }

            return shelters.ToArray();
        }
        
         public void Add(Shelter shelter)
        {
            var client = new MongoClient("mongodb+srv://eaajakhj:kajkage02@sheltermini.f1ql71j.mongodb.net/test");
            var database = client.GetDatabase("sheltermini");
            var collection = database.GetCollection <BsonDocument>("aarhus_shelters");
            var document = new BsonDocument
            {
                { "properties.navn", shelter.Name},
            };

            collection.InsertOne(document);
        }
    }

}
