using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Vueling.Infraestructure.Repositories.Entities;
using Vueling.Presentation.Entities.Class;


namespace VuelingExamen
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //protected string route = @"C:\Users\dberges\Desktop\MyTest.txt";
        protected string route = AppDomain.CurrentDomain.BaseDirectory + @"\\MyTest.txt";
        protected Repository repository = Repository.Instance();

        [WebMethod]
        public bool Create()
        {
            try
            {
                repository.SetRoute(route);
                repository.Create();
                return true;
            }
            catch(Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }

        }

        [WebMethod]
        public bool Add(Rebel rebel)
        {
            try
            {
                repository.SetRoute(route);
                repository.Add(rebel._name +","+ rebel._planet);
                return true;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }

        }

        [WebMethod]
        public Rebel GetById(Rebel rebel)
        {
            try
            {
                repository.SetRoute(route);
                string text = repository.GetById(rebel._name, rebel._planet);
                char[] delimiterChars = { ';', ',' };
                string[] words = text.Split(delimiterChars);
                Rebel rebelsearch = new Rebel(words[0], words[1]);

                return rebelsearch;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return null;
            }

        }

        [WebMethod]
        public List<Rebel> GetAll()
        {
            try
            {
                string[] words;
                char[] delimiterChars = { ';', ',' };
                var rebels = new List<Rebel>();

                repository.SetRoute(route);
                List<string> list = repository.GetAll();
                foreach (var line in list)
                {
                    words = line.Split(delimiterChars);
                    var rebel = new Rebel(words[0], words[1]);
                    rebels.Add(rebel);
                }


                return rebels;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return null;
            }

        }

        [WebMethod]
        public bool Update(Rebel rebel, string newName, string newPlanet)
        {
            try
            {
                repository.SetRoute(route);
                repository.Update(rebel._name, rebel._planet, newName, newPlanet);
                return true;
            }
            catch(Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }

        }

        [WebMethod]
        public bool Delete(Rebel rebel)
        {
            try
            {
                repository.SetRoute(route);
                repository.Delete(rebel._name, rebel._planet);
                return true;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }

        }

        [WebMethod]
        public bool DeleteAll()
        {
            try
            {
                repository.SetRoute(route);
                repository.DeleteAll();
                return true;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }

        }
    }
}
