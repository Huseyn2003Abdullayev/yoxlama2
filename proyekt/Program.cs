using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace proyekt
{
    class Properties
    {
        private static marketable servis = new marketable();
        Product product = new Product();
      public void Addproduct()
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
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"/log.txt"))
            {
                sw.WriteLine("malin adi " + product.Name);
                sw.WriteLine("malin qiymeti " + product.Price);
                sw.WriteLine("malin sayi " + product.Quantity);
                sw.WriteLine("malin kodu " + product.Code);
            }
            servis.AddProduct(product);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.Quantity);
            Console.WriteLine(product.Code);
            Console.WriteLine("mal ugurla elave edildi");
            #endregion
        }
        public void Updateproduct()
        {
            Console.WriteLine("mali deyismek ucun kodun daxil edin");
            string code = Console.ReadLine();
           servis.GetProductByCode(code);
            #region Change Name
            Console.WriteLine("Mehsulun yeni adini daxil edin :");
            string name = Console.ReadLine();
            #endregion

            #region Change Quantity
            Console.WriteLine("Mehsulun yeni sayini daxil edin :");
            string quantityInput = Console.ReadLine();
            int quantity = Convert.ToInt32(quantityInput);
            #endregion
            #region change price
            Console.WriteLine("Mehsulun yeni qiymetini daxil edin :");
            string priceInput = Console.ReadLine();
            int price = Convert.ToInt32(priceInput);
            #endregion
            servis.ChangeProductNameQuantityPriceCategoryByCode(code, name,quantity,price);
            Console.WriteLine("mal ugurla deyisildi");
        }
        public void deleteproduct()
        {
            Console.WriteLine("\nLegv etmek uchun mehsulun kodunu daxil edin:");
            string removeCode = Console.ReadLine();
           
                servis.RemoveProduct(removeCode);
                Console.WriteLine("-------------- Mehsul ugurla legv edildi --------------");
            
        }
    }
    class Program 
    {
        static void Main()
        {
            Bas:
            Properties instance = new Properties();
            marketable instance2 = new marketable();
            Console.WriteLine("yeni mehsul elave etmek isteyirsinizse 1 yazin");
            Console.WriteLine("mehsulu deyisdirmek isteyirsinizse 2 yazin");
            Console.WriteLine("mehsulu silmek isteyirsinizse 3 yazin");
            Console.WriteLine("elave etdiyiviz mallarin siyahisin gormek isteyirsinizse 4 yazin");
            string select = Console.ReadLine();
            int selectint = Convert.ToInt32(select);
            switch (selectint)
            {
                case 1:
                    instance.Addproduct();
                    break;
                case 2:
                    instance.Updateproduct();
                    break;
                case 3:
                    instance.deleteproduct();
                    break;
                case 4:
                    instance2.array();
                    break;
            }
            Console.WriteLine("emaliyyat bitdikden sora bitdi yazin");
            Console.WriteLine("Devam etmek isteyirsizse devam yazin");
            string emeliyyat = Console.ReadLine();
            if(emeliyyat == "bitdi")
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
