using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace deliminet
{
    class Program
    {

        static void Main()
        {

            List<string> list = new List<string>();
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "24.txt"))
            {
                sw.WriteLine("deyisilmeli|olan|hisse|");
            }

            string filepath = @"24.txt";
            var lines = File.ReadAllLines(filepath);
            string itemcode = "deyisilmeli";
            var newLines = lines.Select(line => Regex.Replace(line, itemcode, "deyisdi", RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
           // string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "24.txt");

            foreach (var item in lines)
            {
                list.Add(item);
                Console.WriteLine(item);

                string[] words = item.Split('|');
                foreach (var word in words)
                {
                    list.Add(word + " deneme");
                    foreach (var items in list)
                    {
                        Console.WriteLine(items);
                    }
                    //if (word == "deyisilmeli")
                    //{
                    //    // Console.WriteLine($"<{word}>");
                    //    //using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "24.txt"))
                    //    //{

                    //    //    sw.WriteLine("original {0}", word);
                    //    //    sw.WriteLine("change {0}", word.Replace("deyisilmeli", "deyisildi"));

                    //    //}
                    //    Console.WriteLine("original {0}", word);
                    //    Console.WriteLine("change {0}", word.Replace("deyisilmeli", "deyisildi"));
                    //}

                    // Console.WriteLine($"<{word}>");
                }





















                //string phrase = "The|quick|brown   | fox   |  jumps |over|the|lazy|dog.|";
                //string[] words = phrase.Split('|');

                //foreach (var word in words)
                //{
                //    Console.WriteLine($"<{word}>");
                //   if(word == "brown")
                //    {
                //        Console.WriteLine("original {0}",word);
                //        Console.WriteLine("change {0}",word.Replace("brown","thee"));
                //    }
                //}
                // Console.WriteLine("{0}",phrase.Replace("The","thee"));
                //String str = "1 2 3 4 5 6 7 8 9";
                //Console.WriteLine("Original string: \"{0}\"", str);
                //Console.WriteLine("CSV string:      \"{0}\"", str.Replace(' ', ','));

                // This example produces the following output:
                // Original string: "1 2 3 4 5 6 7 8 9"
                // CSV string:      "1,2,3,4,5,6,7,8,9"
                Console.ReadKey();
            }
        }
       
    }
}
