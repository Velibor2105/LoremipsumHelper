using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleHotKey
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            HotKeyManager.RegisterHotKey(Keys.Z, KeyModifiers.Alt);
            HotKeyManager.RegisterHotKey(Keys.X, KeyModifiers.Alt);
            HotKeyManager.RegisterHotKey(Keys.C, KeyModifiers.Alt);
            HotKeyManager.RegisterHotKey(Keys.V, KeyModifiers.Alt);
            HotKeyManager.RegisterHotKey(Keys.Space, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
            Console.ReadLine();
        }

        static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
        {
            if (e.Key.ToString() == "Z")
            {
                var n = e.Key.GetType();
                string text = CallRestMethod("http://loripsum.net/api/1/short/plaintext").ToString();
                var thread = new Thread(new ParameterizedThreadStart(param => { Clipboard.SetText(text); }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            if (e.Key.ToString() == "X")
            {
                var n = e.Key.GetType();
                string text = CallRestMethod("http://loripsum.net/api/3/long/plaintext").ToString();
                var thread = new Thread(new ParameterizedThreadStart(param => { Clipboard.SetText(text); }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            if (e.Key.ToString() == "C")
            {
                var n = e.Key.GetType();
                string text = CallRestMethod("http://loripsum.net/api/6/long/plaintext").ToString();
                var thread = new Thread(new ParameterizedThreadStart(param => { Clipboard.SetText(text); }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            if (e.Key.ToString() == "V")
            {
                string text = CallRestMethod("http://loripsum.net/api/12/long/plaintext").ToString();
                var thread = new Thread(new ParameterizedThreadStart(param => { Clipboard.SetText(text); }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            if (e.Key.ToString() == "Space")
            {
                char[] delimiterChars = {'.',';',':','?','!',','};
                string text = CallRestMethod("http://loripsum.net/api/10/long/plaintext").ToString();
                string[] words = text.Split(delimiterChars);
                string finalWord = words.Length > 1 ? words[1] : string.Empty;
                string word = null;
                if (words.Length > 1)
                {
                    char[] delimChar = { ' ' };
                    for (int i = 1; i < words.Length; i++)
			        {
                        var nesto = words[i];
                        if (char.IsUpper(nesto[1]))
	                    {
                            if (words[i].Split(delimChar)[1].Length > 6)
                            {
                                word = words[i].Split(delimChar)[1];
                                break;
                            }
                            else
                            {
                                if (words[i].Split(delimChar).Length > 2)
                                {
                                    word = words[i].Split(delimChar)[1] + " " + words[i].Split(delimChar)[2];
                                    break;
                                }
                            }
	                    } 
			        }
                  
                }
                var thread = new Thread(new ParameterizedThreadStart(param => { Clipboard.SetText(word); }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
           
        }


        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }

        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }

    
}