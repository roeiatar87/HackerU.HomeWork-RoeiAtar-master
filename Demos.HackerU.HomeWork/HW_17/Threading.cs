using Microsoft.VisualBasic;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demos.HackerU.HomeWork.HW_17
{
    public class Threading
    {
       public static string downloadAndSave(string url,string name)
        {
            Console.WriteLine($"Starting Connection....{name}"); 
            string contents;
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString(url);
            Console.WriteLine($"{name} :is runing");
            for (int i = 0; i < 4; i++)
            {
                Task.Delay(700).Wait();
                Console.Write(".");  
            }
            Console.WriteLine($"Finish Connection....{name}");
            File.WriteAllText(name+".txt", contents);
            return contents;

        }


        public static  void Run()
        {
            Task<string> t1 = Task.Factory.StartNew<string>(() => downloadAndSave("http://www.walla.co.il","T1"));
            Task<string> t2 = Task.Factory.StartNew<string>(() => downloadAndSave("http://www.google.co.il","T2"));
            Task<string> t3 = Task.Factory.StartNew<string>(() => downloadAndSave("http://www.youtube.com","T3"));
            Task<string> t4 = Task.Factory.StartNew<string>(() => downloadAndSave("https://translate.google.com", "T4"));
            Task<string> t5 = Task.Factory.StartNew<string>(() => downloadAndSave("https://www.hackampus.com", "T5"));
            Console.WriteLine($"Finish read:\n{t1.Result.Length}\n{t2.Result.Length}\n{t3.Result.Length}\n{t4.Result.Length}\n{t5.Result.Length}");

        }
    }
}
