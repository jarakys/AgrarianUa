using System.Collections.Generic;
using AgrarianUa.ViewModels;

namespace AgrarianUa.Services
{
    public interface ILocationService
    {
        void Add(string name);
        bool Delete(int id);
        LocationViewModel Location(int id);
        List<LocationViewModel> Locations();
        void Update(int id, string name);
    }
}