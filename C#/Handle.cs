using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HighscoreSys
{
    class Handle
    {
        private string url;
        private string First;
        private string Second;
        private string Third;
        private WebClient wb = new WebClient();
        public Handle(string url)
        {
            this.url = url;
            WebClient wb = new WebClient();
            UpdateValues();
        }
        public void ToConsole()
        {
            Console.Write("1: " + First);
            Console.Write("2: " + Second);
            Console.Write("3: " + Third);
        }
        public void AddValue(int value)
        {
            string val = value.ToString();
            NameValueCollection values = new NameValueCollection();
            values["type"] = "add";
            values["val"] = val;
            string back = Encoding.Default.GetString(wb.UploadValues(url, values));
        }
        public void UpdateValues()
        {
            try
            {
                NameValueCollection values = new NameValueCollection();
                values["type"] = "get";
                values["val"] = "";
                string back = Encoding.Default.GetString(wb.UploadValues(url, values));
                string[] sep = { "3:" };
                string third = back.Split(sep, StringSplitOptions.RemoveEmptyEntries)[1];
                this.Third = third;
                string tmp = back.Split(sep, StringSplitOptions.RemoveEmptyEntries)[0];
                sep[0] = "2:";
                string second = tmp.Split(sep, StringSplitOptions.RemoveEmptyEntries)[1];
                this.Second = second;
                tmp = tmp.Split(sep, StringSplitOptions.RemoveEmptyEntries)[0];
                sep[0] = "1:";
                string first = tmp.Split(sep, StringSplitOptions.RemoveEmptyEntries)[1];
                this.First = first;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }
        }
        public int getFirst() { return int.Parse(this.First); }
        public int getSecond() { return int.Parse(this.Second); }
        public int getThird() { return int.Parse(this.Third); }
    }
}
