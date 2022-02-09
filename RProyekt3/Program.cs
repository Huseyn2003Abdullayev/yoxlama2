using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RProyekt3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cavab = "0";

            do
            {
                cavab = ShowList();
                if (cavab == "1")
                {
                    cavab = ShowList();
                }
                else if (cavab == "2")
                {
                    cavab = ShowInsert();
                }

            } while (cavab != "5");









        }




        private static string ShowList()
        {

            Console.Clear();
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10} | {3, -10} | {4, -10} ", "[1] refresh", "[2] insert", "[3] update", "[4] delete", "[5] exit"));


            List<Product> products = new ProductDataService().GetAllProduct();
            Console.WriteLine("==================================================");
            Console.WriteLine("Code       |Name        |Price       |Quantity    |");
            Console.WriteLine("==================================================");
            foreach (Product product in products)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10} | {3, -10} | ", product.Code, product.Name, product.Price.ToString(), product.Quantity.ToString()));
            }
            Console.WriteLine("==================================================");

            Console.Write("sisizn seciminiz   ");
            return Console.ReadLine();
        }

        private static string ShowInsert()
        {
            string cavab = "0";
            Product product = new Product();
            do
            {
                Console.Clear();
                // Console.WriteLine(String.Format("{0,-10} | {1,-10} ", "[1] save", "[2] cancel"));
                Console.WriteLine("========================================");
                Console.WriteLine("type 'exit' for exit from menu");
                Console.WriteLine("========================================");


                Console.Write("code: ");
                string code = Console.ReadLine();
                if (string.IsNullOrEmpty(code))
                {
                    Console.WriteLine("code mutelqdi");
                }
                else if (code == "exit")
                {

                }
                else
                {
                    Product searched_product = new ProductDataService().GetProductByCode(code);
                    if (searched_product == null)
                    {
                        product.Code = code;


                        Console.Write("name: ");
                        string name = Console.ReadLine();
                        if (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("name mutelqdi");
                        }
                        else if (name == "exit")
                        {

                        }
                        else
                        {
                            product.Name = name;
                        }

                        Console.Write("price: ");
                        string price = Console.ReadLine();
                        if (string.IsNullOrEmpty(price))
                        {
                            Console.WriteLine("price mutelqdi");
                        }
                        else if (price == "exit")
                        {

                        }
                        else
                        {
                            product.Price = Convert.ToDouble(price);
                        }

                        Console.Write("quantity: ");
                        string quantity = Console.ReadLine();
                        if (string.IsNullOrEmpty(quantity))
                        {
                            Console.WriteLine("quantity mutelqdi");
                        }
                        else if (quantity == "exit")
                        {

                        }
                        else
                        {
                            product.Quantity = Convert.ToInt32(quantity);
                        }


                    }
                    else
                    {
                        code = "";
                        Console.WriteLine("bele code da product var ");
                        Console.WriteLine("davam etmek ucun Enter");
                        Console.WriteLine("cixmaq ucun exit");
                        code = Console.ReadLine();
                    }


                }




                if (code == "exit")
                {
                    cavab = "-1";
                }
                else if (code == "")
                {
                }
                else
                {

                    new ProductDataService().AddProduct(product);
                    cavab = "-1";
                }


            } while (cavab != "-1");

            if (cavab == "-1")
            {
                cavab = "1";
            }
            return cavab;
        }


    }
}
