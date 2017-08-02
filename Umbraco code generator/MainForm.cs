using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umbraco_code_generator
{
    public partial class MainForm : Form
    {
        int i = 1;
        int yPosition = 25;
        Stack<ComboBox> types = new Stack<ComboBox>();
        Stack<TextBox> names = new Stack<TextBox>();
        Stack<CheckBox> cbuttons = new Stack<CheckBox>();
        public MainForm()
        {
            InitializeComponent();
            types.Push(cmbType1);
            names.Push(txtName1);
            cbuttons.Push(chcIEnum1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ii = ++i;

            ComboBox cmbType = new ComboBox();
            cmbType.Name = "txtType" + ii;
            cmbType.Width = cmbType.Width;
            cmbType.Height = cmbType.Height;
            cmbType.Items.Add("string");
            cmbType.Items.Add("int");
            cmbType.Items.Add("bool");
            cmbType.Items.Add("char");
            cmbType.Items.Add("Link");
            cmbType.Items.Add("ImageModel");
            cmbType.Items.Add("INestedContent");

            cmbType.Location = new Point(cmbType1.Location.X, cmbType1.Location.Y + yPosition);
            

            TextBox txtName = new TextBox();
            txtName.Name = "txtName" + ii;
            txtName.Width = txtName1.Width;
            txtName.Height = txtName1.Height;
            txtName.Location = new Point(txtName1.Location.X, txtName1.Location.Y + yPosition);


            CheckBox chc = new CheckBox();
            chc.Text = "IEnum<>";
            chc.Width = chcIEnum1.Width;
            chc.Height = chcIEnum1.Height;
            chc.Location = new Point(chcIEnum1.Location.X, chcIEnum1.Location.Y + yPosition);
            

            yPosition = yPosition + 25;

            this.Controls.Add(cmbType);
            this.Controls.Add(txtName);
            this.Controls.Add(chc);
            types.Push(cmbType);
            names.Push(txtName);
            cbuttons.Push(chc);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.Controls.Count > 14)
            {
                this.Controls.RemoveAt(this.Controls.Count - 1);
                this.Controls.RemoveAt(this.Controls.Count - 1);
                this.Controls.RemoveAt(this.Controls.Count - 1);
                types.Pop();
                names.Pop();
                cbuttons.Pop();
                yPosition = yPosition - 25;
            }
          
        }

        private void btnGenCode_Click(object sender, EventArgs e)
        {
            Code c = new Code(types, names, cmbBaseClass, txtClass, cbuttons, txtProjectName);
            c.ShowDialog();
        }

 
    
    }
}
