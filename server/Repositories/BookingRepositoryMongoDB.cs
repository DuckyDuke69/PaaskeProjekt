using sheltermini.Shared;
using MongoDB.Bson;
using MongoDB.Driver;

namespace sheltermini.server.Repositories
{
    public class BookingRepositoryMongoDB : IBookingRepository
    {
        private List<Booking> bookings;

        public BookingRepositoryMongoDB()
        {
            bookings = new();
        }

        public Booking[] getAll()
        {
            bookings.Clear();
            var client = new MongoClient("mongodb+srv://eaajakhj:kajkage02@sheltermini.f1ql71j.mongodb.net/test");
            var database = client.GetDatabase("sheltermini");
            var collection = database.GetCollection<BsonDocument>("aarhus_shelters");
            var documents = collection.Find($"{{}}").ToList();

            foreach (var doc in documents)
            {
                var Name = doc["properties"]["navn"].ToString();
                var KommuneName = doc["properties"]["cvr_navn"].ToString();
                var Description = doc["properties"]["beskrivels"].ToString();
                var Capacity = doc["properties"]["antal_pl"].ToInt32();
                var Contact = doc["properties"]["kontak_ved"].ToString();
                var lat = doc["geometry"]["coordinates"][0][0].ToDecimal();
                var longitude = doc["geometry"]["coordinates"][0][1].ToDecimal();
                var mbook = new Booking { Name = Name, KommuneName = KommuneName, Description = Description, Capacity = Capacity, Contact = Contact, lat = lat, longitude = longitude };
                
            
                
                bookings.Add(mbook);
            }

            return bookings.ToArray();
        }
        
         public void Add(Booking shelter)
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
