using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Infraestructure.Repositories.Interface
{
    public interface IRepository
    {
        void SetRoute(string route);
        bool Create();
        bool DeleteAll();
        bool Add(string line);
        List<string> GetAll();
        bool Delete(string name, string planet);
        bool Update(string name, string planet, string newName, string newPlanet);
        string GetById(string name, string planet);

    }
}
