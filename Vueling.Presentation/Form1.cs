using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Presentation.Entities.Interface;
using Vueling.Presentation.ServiceReference;

namespace Vueling.Presentation
{
    public partial class Form1 : Form
    {
        public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ServiceReference.WebServiceSoapClient ClienteSOAP = new WebServiceSoapClient();

        public Form1()
        {
            InitializeComponent();
            ClienteSOAP.Create();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Directory.GetCurrentDirectory(); ;


                Rebel rebel = new Rebel();
                rebel._planet = comboBox1.Text;
                rebel._name = textBox1.Text;
                
                ClienteSOAP.Add(rebel);
                var rebels = ClienteSOAP.GetAll();
                foreach (var line in rebels)
                {
                    this.listBox1.Items.Add(line._planet+","+line._name);
                }
            }
            catch (Exception exception)
            {
                log.Fatal(exception.Message);
            }
        }
    }
}
