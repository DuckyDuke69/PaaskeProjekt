using sheltermini.Shared;
using System;

namespace sheltermini.server.Repositories
{
    public interface IShelterRepository
    {
        Shelter[] getAll();
        void Add(Shelter shelter);
    
    }
}
