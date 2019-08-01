using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Infraestructure.Repositories.Interface;

namespace Vueling.Infraestructure.Repositories.Entities
{
    public class Repository : IRepository
    {
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static Repository _repository;
        private string _route;


        public static Repository Instance()
        {
            return _repository ?? (_repository = new Repository());
        }

        public void SetRoute(string route)
        {
            this._route = route;
        }

        public bool Create()
        {
            try
            {

                if (File.Exists(_route))
                {
                    File.Delete(_route);
                }
                else
                {
                    using (FileStream fileWrite = File.Create(_route))
                    {
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }
        }

        public bool Add(string line)
        {
            try
            {
                if (File.Exists(_route))
                {
                    using (StreamWriter fileWrite = File.AppendText((_route)))
                    {
                        fileWrite.WriteLine(line + "," + DateTime.Now + ";");
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }
        }

        public bool Delete(string name, string planet)
        {
            string filetemp = @"C:\Temp.txt";
            string line = "";
            try
            {
                if (File.Exists(_route))
                {
                    using (StreamWriter fileWrite = new StreamWriter(filetemp))
                    {
                        using (StreamReader fielRead = new StreamReader(_route))
                        {
                            while ((line = fielRead.ReadLine()) != null)
                            {

                                if (!(line.Contains(name) && line.Contains(planet)))
                                {
                                    fileWrite.WriteLine(line);
                                }
                            }
                        }
                    }

                    File.Delete(filetemp);
                    File.Move(filetemp, _route);
                }

                return true;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }
        }

        public List<string> GetAll()
        {
            List<string> list = new List<string>();

            try
            {
                if (File.Exists(_route))
                {
                    using (StreamReader sr = File.OpenText(_route))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            list.Add(line);

                        }
                    }

                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return null;
            }

        }

        public string GetById(string name, string planet)
        {
            string line = "";
            string search = "";
            try
            {
                if (File.Exists(_route))
                {
                    using (StreamReader fileRead = new StreamReader(_route))
                    {
                        while ((line = fileRead.ReadLine()) != null)
                        {

                            if (line.Contains(name) && line.Contains(planet))
                            {
                                search = line;
                                break;
                            }

                        }
                    }
                }

                return search;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return null;
            }
        }

        public bool Update(string name, string planet, string newName, string  newPlanet)
        {
            string filetemp = @"C:\Temp.txt";
            string line = "";
            try
            {
                if (File.Exists(_route))
                {
                    using (StreamWriter fileWrite = new StreamWriter(filetemp))
                    {
                        using (StreamReader fielRead = new StreamReader(_route))
                        {
                            while ((line = fielRead.ReadLine()) != null)
                            {

                                if (line.Contains(name) && line.Contains(planet))
                                {
                                    fileWrite.WriteLine(newName + "," + newPlanet + "," + DateTime.Now);
                                }
                                else
                                {
                                    fileWrite.WriteLine(line);
                                }
                            }
                        }
                    }

                    File.Delete(filetemp);
                    File.Move(filetemp, _route);
                }

                return true;
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
                return false;
            }
        }

        public bool DeleteAll()
        {
            try
            {
                if (File.Exists(_route))
                {
                    File.Delete(_route);
                }

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
