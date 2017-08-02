using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umbraco_code_generator
{
    public partial class TypeName : UserControl
    {

        public TypeName()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TypeName tn = new TypeName();
            tn.Location = new Point(Utility.Point.X, Utility.Point.Y + 25);
            Utility.Point = tn.Location;
            Utility.MainForm.Controls.Add(tn);
        }
    }
}
