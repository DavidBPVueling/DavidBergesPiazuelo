using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using log4net;
using Vueling.Presentation.Entities.Class;
using Vueling.Presentation.Entities.Interface;

namespace Vueling.Presentation
{
    static class Program
    {
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IContainer Container { get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Rebel>().As<IRebel>();
            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
