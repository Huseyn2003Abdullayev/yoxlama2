using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RProyekt3
{
    public class ProductDataService
    {
        readonly string filepath = @"2.txt";
        public List<Product> GetAllProduct()
        {
            List<Product> products = new List<Product>();
            string[] lines = File.ReadAllLines(filepath);
            if (lines.Any())
            {
                foreach (string line in lines)
                {
                    string[] line_parts = line.Split('|');
                    if (line_parts.Length == 4)
                    {
                        Product product = new Product()
                        {
                            Code = line_parts[0],
                            Name = line_parts[1],
                            Price = Convert.ToDouble(line_parts[2].ToString()),
                            Quantity = Convert.ToInt32(line_parts[3].ToString())

                        };
                        products.Add(product);
                    }
                }
            }
            else
            {
                products = null;
            }
            return products;
        }
        public Product GetProductByCode(string code)
        {
            Product search_result = new Product();
            List<Product> products = this.GetAllProduct();
            if (products != null)
            {
                if (products.Any(x => x.Code == code))
                {
                    search_result = products.FirstOrDefault(x => x.Code == code);
                }
                else
                {
                    search_result = null;
                }
            }
            return search_result;
        }
        public void AddProduct(Product product)
        {
            using (StreamWriter sw = File.AppendText(filepath))
            {
                sw.Write(product.Code + "|");
                sw.Write(product.Name + "|");
                sw.Write(product.Price.ToString() + "|");
                sw.Write(product.Quantity.ToString());
            }
        }
        public void UpdateProduct(Product product)
        {
            List<Product> products = this.GetAllProduct();
            foreach (Product item in products)
            {
                if (item.Code == product.Code)
                {
                    item.Name = product.Name;
                    item.Price = product.Price;
                    item.Quantity = product.Quantity;
                }
            }
            this.FileiMuveqqetiTemizleVeYeniListiOraElaveEt(products);
        }
        public void DeleteProduct(Product product)
        {
            List<Product> products = this.GetAllProduct();
            products.Remove(product);
            this.FileiMuveqqetiTemizleVeYeniListiOraElaveEt(products);

        }


        private void FileiMuveqqetiTemizleVeYeniListiOraElaveEt(List<Product> yeni_list)
        {
            File.Delete(filepath);
            File.Create(filepath);
            foreach (Product product in yeni_list)
            {
                this.AddProduct(product);
            }
        }

    }
}
