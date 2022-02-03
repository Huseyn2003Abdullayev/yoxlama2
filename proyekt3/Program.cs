using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace proyekt3
{

    // test comment 

    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        internal string[] Split(char v)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductDataServer
    {
        public List<string> GetAllProduct()
        {
             List<string> products = new List<string>();
            string filepath = @"2.txt";
            var line = File.ReadAllLines(filepath);
           // products.Add(line);
            //string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "2.txt");
            foreach (var item in line)
            {
                
                Console.WriteLine(item);
                products.Add(item);
            }
            return products;
        }
        public Product GetProductByCode(string code)
        {
            Product product = new Product();
            List<string> list = GetAllProduct();
            
            foreach (var item in list)
            {
                string[] words = item.Split('|');
                foreach (var word in words)
                {
                   // var products = list.Find(products => product.Code == code);
                    var mallar = list.Find(mallar =>product.Code.Contains(code));
                    if(word == code)
                    {
                        goto cixisa;
                    }
                }
            }
        // var products = list.Find(products => product.Code == code);
        cixisa:
            {
                return product;
            }
        }
        public void AddProduct(Product product)
        {
            #region product elave ele
            Console.WriteLine("malin adin daxil ele");
            product.Name = Console.ReadLine();
            Console.WriteLine("malin qiymetin daxil");
            string inputprice = Console.ReadLine();
            product.Price = Convert.ToInt32(inputprice);
            Console.WriteLine("malin sayin daxil edin");
            string quantityInput = Console.ReadLine();
            product.Quantity = Convert.ToInt32(quantityInput);
            Console.WriteLine("malin kodun daxil edin");
            product.Code = Console.ReadLine();
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"/2.txt"))
            {
                sw.Write("malin adi|");
                sw.Write("malin qiymeti| " );
                sw.Write("malin sayi| "  );
                sw.WriteLine("malin kodu| " );
                sw.Write(product.Name + "|");
                sw.Write(product.Price + "|");
                sw.Write(product.Quantity + "|");
                sw.WriteLine(product.Code + "|");

            }
            ///Product.Add(product);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.Quantity);
            Console.WriteLine(product.Code);
            Console.WriteLine("mal ugurla elave edildi");
            #endregion
        }
        public void UpdateProduct()
        {
            #region update product
            string filepath = @"2.txt";
            var lines = File.ReadAllLines(filepath);
            Console.WriteLine("mehsulun kodun yazin");
            string code = Console.ReadLine();
            var product = GetProductByCode(code);
            #region change name
            Console.WriteLine("mehsulun yeni adini daxil edin");
            string itemname = Console.ReadLine();
            var newLines = lines.Select(line => Regex.Replace(line, product.Name, itemname, RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
            #endregion
            #region change price
            Console.WriteLine("mehsulun yeni qiymetin daxil edin");
            string itemprice = Console.ReadLine();
            newLines = lines.Select(line => Regex.Replace(line, product.Price.ToString(), itemprice, RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
            #endregion
            #region change quantity
            Console.WriteLine("mehsulun yeni sayin daxil edin");
            string itemquantity = Console.ReadLine();
            newLines = lines.Select(line => Regex.Replace(line, product.Quantity.ToString(), itemquantity, RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
            #endregion
            #endregion
        }
        public void DeleteProduct()
        {
            #region delete product
            string filepath = @"2.txt";
            var lines = File.ReadAllLines(filepath);
            Console.WriteLine("mehsulun kodun yazin");
            string code = Console.ReadLine();
            var product = GetProductByCode(code);
            string itemcode = product.ToString();
            var newLines = lines.Select(line => Regex.Replace(line, itemcode, string.Empty, RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
            string itemname = product.Name;
            newLines = lines.Select(line => Regex.Replace(line, itemname, string.Empty, RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
            string itemprice = product.Price.ToString();
            newLines = lines.Select(line => Regex.Replace(line, itemprice, string.Empty, RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
            string itemquantity = product.Quantity.ToString();
            newLines = lines.Select(line => Regex.Replace(line, itemquantity, string.Empty, RegexOptions.IgnoreCase));
            File.WriteAllLines(filepath, newLines);
            #endregion
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();

            ProductDataServer productDataService = new ProductDataServer();
        Bas:
            Console.WriteLine("yeni mehsul elave etmek isteyirsinizse 1 yazin");
            Console.WriteLine("mehsulu deyisdirmek isteyirsinizse 2 yazin");
            Console.WriteLine("mehsulu silmek isteyirsinizse 3 yazin");
            Console.WriteLine("elave etdiyiviz mallarin siyahisin gormek isteyirsinizse 4 yazin");
            string select = Console.ReadLine();
            int selectint = Convert.ToInt32(select);
            switch (selectint)
            {
                case 1:
                    productDataService.AddProduct(product);
                    break;
                case 2:
                    productDataService.UpdateProduct();
                    break;
                case 3:
                    productDataService.DeleteProduct();
                    break;
                case 4:
                    productDataService.GetAllProduct();

                    break;
            }
            Console.WriteLine("emaliyyat bitdikden sora bitdi yazin");
            Console.WriteLine("Devam etmek isteyirsizse devam yazin");
            string emeliyyat = Console.ReadLine();
            if (emeliyyat == "bitdi")
            {
                goto son;
            }
            else if (emeliyyat == "devam")
            {
                goto Bas;
            }
            else
            {
                goto Bas;
            }
        son:
            Console.ReadKey();
        }
    }
}
