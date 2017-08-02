using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Umbraco_code_generator
{
    public partial class Code : Form
    {
        private Stack<TextBox> names;
        private ComboBox cmbBaseClass;
        public string CodeText = null;
        private TextBox txtClass;
        public StringBuilder MainContentPrivate = new StringBuilder();
        public StringBuilder MainContentPublic = new StringBuilder();
        public StringBuilder MainNewContent = new StringBuilder();
        private Stack<ComboBox> types;
        private Stack<CheckBox> cbuttons;
        private TextBox txtProjectName;

        public Code()
        {
            InitializeComponent();
        }

        public Code(Stack<ComboBox> types, Stack<TextBox> names, ComboBox cmbBaseClass, TextBox txtClass, Stack<CheckBox> cbuttons)
        {
            InitializeComponent();
            this.types = types;
            this.names = names;
            this.cmbBaseClass = cmbBaseClass;
            this.txtClass = txtClass;
            this.cbuttons = cbuttons;
            MainNewCode();
            MainCodeContentPrivate();
            CodeGenerator();
        }

        public Code(Stack<ComboBox> types, Stack<TextBox> names, ComboBox cmbBaseClass, TextBox txtClass, Stack<CheckBox> cbuttons, TextBox txtProjectName)
        {
            InitializeComponent();
            this.types = types;
            this.names = names;
            this.cmbBaseClass = cmbBaseClass;
            this.txtClass = txtClass;
            this.cbuttons = cbuttons;
            this.txtProjectName = txtProjectName;
            MainNewCode();
            MainCodeContentPrivate();
            CodeGenerator();
        }

        public void MainCodeContentPrivate()
        {
            string type = null;
            string name = null;

            if (types.Any() && names.Any())
            {
                MainContentPrivate.Append("#region [Fields]\n\n");
                for (int i = types.Count - 1; i >= 0; i--)
                {
                    type = types.ElementAt(i).Text;
                    name = names.ElementAt(i).Text;

                    if (types.ElementAt(i).Text == "INestedContent" && cbuttons.ElementAt(i).Checked)
                    {
                        MainContentPrivate.Append("    private IEnumerable<INestedContent> " + AppendUnderscore(name) + ";\n");
                    }
                }
            }
            MainContentPrivate.Append("\n#endregion");
        }

        public void MainCodeContentPublic()
        {
            if (types.Any() && names.Any())
            {
                MainContentPublic.Append("#region [Properties]\n\n");
                for (int i = types.Count - 1; i >= 0; i--)
                {
                    if (types.ElementAt(i).Text == "string")
                    {
                        MainContentPublic.Append("\npublic string ").Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(names.ElementAt(i).Text)).Append("\n{").Append("\n   get\n{\n ").Append("return !_").Append(names.ElementAt(i).Text).Append(".IsNullOrEmpty() ? ").Append("_").Append(names.ElementAt(i).Text).Append(" : _").Append(names.ElementAt(i).Text).Append(" = Content.GetPropertyValue<string>(Constants.DocumentTypeProperties.").Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(names.ElementAt(i).Text)).Append(", string.Empty);\n}\n}");
                    }
                }
            }
            MainContentPublic.Append("\n#endregion");
        }

        public void MainNewCode()
        {
            const string quote = "\"";
            string type = null;
            string name = null;

            if (types.Any() && names.Any())
            {
                MainNewContent.Append("#region [Properties]\n\n");
                for (int i = types.Count - 1; i >= 0; i--)
                {
                    type = types.ElementAt(i).Text;
                    name = names.ElementAt(i).Text;

                    if (type == "string" || type == "bool" || type == "int")
                    {
                        MainNewContent.Append("    public " + type + " " + ToCase(name) + "  => Cache.GetValue<" + type + ">(" + quote + name + quote + ");\n");
                    }
                    if (type == "Link")
                    {
                        MainNewContent.Append("    public Link " + ToCase(name) + " => Cache.GetValue<MultiUrls>(" + quote + name + quote + ").FirstOrDefaultWithNullCheck();\n");
                    }
                    if (type == "ImageModel")
                    {
                        MainNewContent.Append("    public ImageModel " + ToCase(name) + " => Cache.GetValue<IEnumerable<IPublishedContent>>(" + quote + name + quote + ").FirstOrDefaultWithNullCheck()?.GetTypedContent<ImageModel>();\n");
                    }
                    if (type == "INestedContent" && cbuttons.ElementAt(i).Checked)
                    {
                        MainNewContent.Append("    public IEnumerable<" + type + "> Modules\n")
                                      .Append("    {\n")
                                      .Append("        get\n")
                                      .Append("        {\n")
                                      .Append("            if (" + AppendUnderscore(name) + " == null)\n")
                                      .Append("            {\n")
                                      .Append("                " + AppendUnderscore(name) + " = Cache.GetValue<IEnumerable<IPublishedContent>>(" + quote + "mainContent" + quote + ").EmptyIfNull().Select(m => m.GetTypedContent<" + ToCase(name) + ">(NestedContentBaseModel.NestedContentNamespace));\n")
                                      .Append("            }\n")
                                      .Append("            return " + AppendUnderscore(name) + ";\n")
                                      .Append("        }\n")
                                      .Append("    }\n");
                    }
                }
            }
            MainNewContent.Append("\n#endregion");
        }

        public string CodeGenerator()
        {
            if (cmbBaseClass.SelectedItem == "PageModel")
            {
                CodeText = "public class " + txtClass.Text + " : PageModel\n{\n #region [Construtors]\n\n public " + txtClass.Text + "() \n   : this(ContentHelper.UmbracoHelperInstance().TypedContent(UmbracoContext.Current.PageId))\n{\n}\n\n public " + txtClass.Text + "(IPublishedContent content)\n   : base(content)\n{\n}\n\npublic " + txtClass.Text + "(IPublishedContent content, CultureInfo culture) : base(content, culture)\n{\n}\n\n #endregion \n\n" + MainContentPrivate.ToString() + "\n" + MainNewContent.ToString() + "\n}";
                richTextBox1.Text = NamespaceCode(CodeText, this.txtProjectName.Text);
            }

            return null;
        }

        public string NamespaceCode(string text, string projectName)
        { 
          StringBuilder sb = new StringBuilder();
          sb.Append("namespace " + projectName + ".Models.DocumentTypes.Pages\n")
            .Append("{\n")
            .Append("   using " + projectName + ".Common;\n")
            .Append("   using " + projectName + ".Common.Extensions;\n")
            .Append("   using " + projectName + ".Models.DocumentTypes.Compositions;\n")
            .Append("   using " + projectName + ".Models.Extensions;\n")
            .Append("   using System.Collections.Generic;\n")
            .Append("   using System.Globalization;\n")
            .Append("   using System.Linq;\n")
            .Append("   using Umbraco.Core.Models;\n")
            .Append("   using Umbraco.Web;\n")
            .Append("   " + text + "\n")
            .Append("}");
          return sb.ToString();
        }
        public string AppendUnderscore(string text)
        {
            return "_" + text;
        }

        public string ToCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }
    }
}