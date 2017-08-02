namespace Umbraco_code_generator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBaseClass = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnGenCode = new System.Windows.Forms.Button();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType1 = new System.Windows.Forms.ComboBox();
            this.chcIEnum1 = new System.Windows.Forms.CheckBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(169, 132);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(313, 133);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName1
            // 
            this.txtName1.Location = new System.Drawing.Point(316, 149);
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(123, 20);
            this.txtName1.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(492, 145);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add prop";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select base class:";
            // 
            // cmbBaseClass
            // 
            this.cmbBaseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaseClass.FormattingEnabled = true;
            this.cmbBaseClass.Items.AddRange(new object[] {
            "PageModel",
            "DocumentTypeModelBase"});
            this.cmbBaseClass.Location = new System.Drawing.Point(175, 30);
            this.cmbBaseClass.Name = "cmbBaseClass";
            this.cmbBaseClass.Size = new System.Drawing.Size(264, 21);
            this.cmbBaseClass.TabIndex = 6;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(589, 145);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnGenCode
            // 
            this.btnGenCode.Location = new System.Drawing.Point(492, 28);
            this.btnGenCode.Name = "btnGenCode";
            this.btnGenCode.Size = new System.Drawing.Size(172, 23);
            this.btnGenCode.TabIndex = 8;
            this.btnGenCode.Text = "Generate";
            this.btnGenCode.UseVisualStyleBackColor = true;
            this.btnGenCode.Click += new System.EventHandler(this.btnGenCode_Click);
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(172, 86);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(267, 20);
            this.txtClass.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Class:";
            // 
            // cmbType1
            // 
            this.cmbType1.FormattingEnabled = true;
            this.cmbType1.Items.AddRange(new object[] {
            "string",
            "int",
            "bool",
            "char",
            "Link",
            "ImageModel",
            "INestedContent"});
            this.cmbType1.Location = new System.Drawing.Point(172, 149);
            this.cmbType1.Name = "cmbType1";
            this.cmbType1.Size = new System.Drawing.Size(121, 21);
            this.cmbType1.TabIndex = 11;
            // 
            // chcIEnum1
            // 
            this.chcIEnum1.AutoSize = true;
            this.chcIEnum1.Location = new System.Drawing.Point(98, 151);
            this.chcIEnum1.Name = "chcIEnum1";
            this.chcIEnum1.Size = new System.Drawing.Size(68, 17);
            this.chcIEnum1.TabIndex = 12;
            this.chcIEnum1.Text = "IEnum<>";
            this.chcIEnum1.UseVisualStyleBackColor = true;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(12, 31);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(153, 20);
            this.txtProjectName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Project name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(685, 545);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.chcIEnum1);
            this.Controls.Add(this.cmbType1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.btnGenCode);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cmbBaseClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtName1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblType);
            this.Name = "MainForm";
            this.Text = "Umbraco code generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBaseClass;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnGenCode;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType1;
        private System.Windows.Forms.CheckBox chcIEnum1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label3;
    }
}

