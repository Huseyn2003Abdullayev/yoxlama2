using System;
using System.Collections.Generic;
using System.IO;

namespace read
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    class tapma
    {
        //Product product = new Product();
        //List<Product> list = new List<Product>();
        //public Product GetProductByCode(string code)
        //{
        //    var products = list.Find(products => product.Code == code);
        //    return product;
        //}
        public void change()
        {
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "48.txt"))
            {
                sw.WriteLine("deyis");

            }
            string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "48.txt");
            string oxu = Console.ReadLine();
            foreach (var item in lines)
            {
                if(oxu == item)
                {
                    Console.WriteLine("girdi");
                    int item1 = Convert.ToInt32(item);
                    item.Remove(item1);
                }
            }
                
                
                
        }
    }

    class Program
    {
        
        static void Main()
        {
            tapma instance = new tapma();
            instance.change();
            Console.ReadKey();
        }
        
    }
}
