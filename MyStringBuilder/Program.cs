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
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = i + "AAABBB";
            }

            int n = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var s in words)
            {
                sb.Append(s);
            }

            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }

    public class StringBuilder : ResizableArray
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
                if (s != "" && s != null)
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
            if (count == curArray.Length)
            {
                string[] newArray = new string[curArray.Length * ResizeFactor];
                for (int i = 0; i < curArray.Length; i++)
                {
                    newArray[i] = curArray[i];
                }
                curArray = newArray;
                curArray[count] = inStr;
                count += 1;
            }
            else
            {
                curArray[count] = inStr;
                count += 1;
            }
        }
    }
}
