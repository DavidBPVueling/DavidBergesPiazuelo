using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Presentation.Entities.Interface;

namespace Vueling.Presentation.Entities.Class
{
    public class Rebel: IRebel
    {
        public string _name;
        public string _planet;

        public Rebel()
        {

        }
        public Rebel(string name, string planet)
        {
            this._name = name;
            this._planet = planet;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetPlanet()
        {
            return _planet;
        }
    }
}
