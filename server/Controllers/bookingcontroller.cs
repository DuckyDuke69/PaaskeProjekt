using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Repositories;
using sheltermini.server.Repositories;
using sheltermini.Shared;

namespace server.Controllers
{
    public class bookingcontroller : ControllerBase
    {
        private IBookingRepos mRepo;
        public bookingcontroller(IBooking repo)
        {
            mRepo = repo;
        }

        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            Console.WriteLine("get ");
            return mRepo.getAll();
        }
        [EnableCors("policy")]
        [HttpPost]
        public void AddBook(Booking booking, Shelter s)
        {
            Console.WriteLine("post " + b.FullName);
            mRepo.AddBook(s, booking);
        }
  /*      [EnableCors("policy")]
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            mRepo.Delete(id);
        }   
  */
    }
}
