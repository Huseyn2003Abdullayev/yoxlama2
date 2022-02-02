using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.IO;

namespace proyekt
{
    class marketable 
    {
        //  private readonly List<Product> _products;
        //  public List<Product> Products => _products;
        List<Product> mallar = new List<Product>();
        public void ChangeProductNameQuantityPriceCategoryByCode(
                                                                string code,
                                                                string name,
                                                                int quantity,
                                                                double price)

        {
            var product = GetProductByCode(code);
            product.Name = name;
            product.Quantity = quantity;
            product.Price = price;
            product.Code = code;

        }
        public void AddProduct(Product product)
        {
            mallar.Add(product);
        }
        public Product GetProductByCode(string code)
        {
             var product = mallar.Find(product => product.Code == code);


            return product;
        }
        public Product RemoveProduct(string productCode)
        {
            var product = GetProductByCode(productCode);
            mallar.Remove(product);
            return product;
        }
        public void array()
        {
           // var i3 = mallar[0];
            for (int i = 0; i <mallar.Count; i++)
            {
                Console.WriteLine(mallar[i]);
            }
            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + @"/log.txt"))
            {
                for (int i = 0; i < mallar.Count; i++)
                {
                   sw.WriteLine(mallar[i]);
                }
            }
        }
    }
}
