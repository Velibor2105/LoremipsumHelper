using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
namespace LoremHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            WebRequest req = HttpWebRequest.Create("https://polaris.brighterir.com/public/silence_therapeutics/price_feed/xml_feed?key=5jvklr8w");
            WebResponse res = req.GetResponse();

            XmlDocument doc = new XmlDocument();
            doc.Load(res.GetResponseStream());



            var xdoc = XDocument.Load("https://polaris.brighterir.com/public/silence_therapeutics/price_feed/xml_feed?key=5jvklr8w");


            string word1 = (string)xdoc.XPathSelectElement("//item[@id='current']/data");


            CultureInfo culture = new System.Globalization.CultureInfo("en-GB");
         



            InitializeComponent();

            timer1.Start();

        }

        int count = 0;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = count.ToString();
            count++;
        }
    }
}
