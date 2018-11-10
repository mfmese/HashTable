using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashTable
{
    struct Info
    {
        public int id;
        public string name;

        public Info(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    class Program
    {
        static Hashtable infoHash;
        static List<Info> infoList;
        static Stopwatch sw;

        static void Main(string[] args)
        {
            infoHash = new Hashtable();
            infoList = new List<Info>();
            sw = new Stopwatch();

            //Adding
            for (int i = 0; i < 5000000; i++)
            {
                infoHash.Add(i, "info" + i);
                infoList.Add(new Info(i, "info" + i));
            }

            //Removing
            if(infoHash.ContainsKey(0))
            {
                infoHash.Remove(0);
            }

            //Setting
            if (infoHash.ContainsKey(1))
            {
                infoHash[1] = "replaced";
            }

            //displaying
            //foreach (DictionaryEntry item in infoHash)
            //{
            //    Console.WriteLine("Key: " + item.Key + " / Value: " + item.Value);
            //}

            //Access
            Random randomInfo = new Random();
            int random = -1;

            sw.Start();
            float startTime = 0;
            float endTime = 0;
            float deltaTime = 0;

            int cycles = 5;
            int cycle = 0;
            string info = string.Empty;

            while(cycle < cycles)
            {
                random = randomInfo.Next(2000000, 5000000);
                
                startTime = sw.ElapsedMilliseconds;
                //access from List
                info = GetInfoFromList(random);
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine("Time to retrieve  " + info + " from List take " + string.Format("{0:0.##}", deltaTime) + "ms");

                               
                startTime = sw.ElapsedMilliseconds;
                //access from Hashtable
                info = (string)infoHash[random];
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;
                Console.WriteLine("Time to retrieve  " + info + " from hashTable take " + string.Format("{0:0.##}", deltaTime) + "ms");

                cycle++;
            }
            Console.Read();
        }

        static string GetInfoFromList(int id)
        {
            for (int i = 0; i < infoList.Count; i++)
            {
                if(infoList[i].id == id)
                {
                    return infoList[i].name;
                }
            }
            return string.Empty;
        }
    }
}
