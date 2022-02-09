using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace proyekt_2
{

    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductDataService
    {
        Product product = new Product();
        List<Product> list = new List<Product>();

        public List<Product> GetProductList()
        {
            // List<Product> list = new List<Product>();

            // text file dan setir be setir productlari oxuyub liste elave edecek
            string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "log.txt");
            foreach (var item in lines)
            {
                //list.Add(item);
                Console.WriteLine(item);
            }
            //while (a != -1)
            //{
            //    Console.WriteLine((byte)a);
            //    a = source.ReadByte();
            //}
            //Console.WriteLine(list);

            return list;
        }

        public Product GetProductByCode(string code)
        {
            List<Product> list = GetProductList();
            // Product product = new Product();

            // text file da product u coda gore axtaracaq 
            // eger  tapsa 
            //product.Code = code;
            //product.Name = name;
            //product.Price  = price
            // tapmasa null;
            var products = list.Find(products => product.Code == code);



            return product;
        }
        public void AddProduct(Product product)
        {
            // text file a product u elave elesin 
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
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"/log.txt"))
            {
                sw.WriteLine("malin adi " + product.Name);
                sw.WriteLine("malin qiymeti " + product.Price);
                sw.WriteLine("malin sayi " + product.Quantity);
                sw.WriteLine("malin kodu " + product.Code);

            }
            list.Add(product);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.Quantity);
            Console.WriteLine(product.Code);
            Console.WriteLine("mal ugurla elave edildi");
            #endregion
        }
        public void UpdateProductByCode(Product _product)
        {
            // text file da product u coda gore axtaracaq 
            // eger  tapsa 

            //product.Code = _product.Code;
            //product.Name = _product.Name;
            //product.Price  = _product.Price

            // bu product u text file da da deyish

            // tapmasa null;
            Console.WriteLine("mali deyismek ucun kodun daxil edin");
            string code = Console.ReadLine();
            GetProductByCode(code);
            #region Change Name
            Console.WriteLine("Mehsulun yeni adini daxil edin :");
            _product.Name = Console.ReadLine();
            #endregion

            #region Change Quantity
            Console.WriteLine("Mehsulun yeni sayini daxil edin :");
            string quantityInput = Console.ReadLine();
            _product.Quantity = Convert.ToInt32(quantityInput);
            #endregion
            #region change price
            Console.WriteLine("Mehsulun yeni qiymetini daxil edin :");
            string priceInput = Console.ReadLine();
            _product.Price = Convert.ToInt32(priceInput);
            #endregion
            string text = File.ReadAllText("log.txt");
            text.Replace(product.Name, _product.Name);
            text.Replace(product.Price.ToString(), _product.Price.ToString());
            text.Replace(product.Quantity.ToString(), _product.Quantity.ToString());
            File.WriteAllText("log.txt", text);
            product.Name = _product.Name;
            product.Price = _product.Price;
            product.Quantity = _product.Quantity;
            product.Code = _product.Code;




            Console.WriteLine("mal ugurla deyisildi");
        }
        public void DeleteProductByCode()
        {
            // text file da product u coda gore axtaracaq 
            // eger  tapsa silecek
            Console.WriteLine("mehsulun kodun yazin");
            string code = Console.ReadLine();
            var product = GetProductByCode(code);
            list.Remove(product);
            Console.WriteLine("Mehsul ugurla silindi");
        }

    }

    internal class Program
    {
        static void Main()
        {
            Product product = new Product();

            ProductDataService productDataService = new ProductDataService();
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
                    productDataService.UpdateProductByCode(product);
                    break;
                case 3:
                    productDataService.DeleteProductByCode();
                    break;
                case 4:
                    productDataService.GetProductList();

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
