using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[500];
            for (int i=0; i< words.Length; i++)
            {
                words[i] = "AAABBB";
            }

            int n = 0;
            StringBuilder sb = new StringBuilder();
            foreach(var s in words)
            {
                sb.Append(s);
            }

            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }

    public class StringBuilder: ResizableArray
    {
        public void Append(string s)
        {
            this.Add(s);
        }

        public override string ToString()
        {
            int n = 0;
            string output = "";
            foreach (string s in this.curArray)
            {
                if (s != "")
                {
                    n += 1;
                    output += "[" + n + ":" + s + "]";
                }
                else
                {
                    break;
                }
            }
            return output;
        }
    }

    public class ResizableArray
    {
        int Size { get; set; }
        int ResizeFactor { get; set; }
        int count = 0;
        public string[] curArray { get; set; }

        public ResizableArray()
        {
            this.ResizeFactor = 2;
            this.count = 0;
            this.curArray = new string[100];
        }

        public void Add(string inStr)
        {
            if (this.count == this.curArray.Length)
            {
                string[] newArray = new string[this.curArray.Length * 2];
                for (int i = 0; i < this.curArray.Length; i++)
                {
                    newArray[i] = this.curArray[i];
                }
                this.curArray = newArray;
            }
            else
            {
                this.curArray[count] = inStr;
                count += 1;
            }
        }
    }
}
