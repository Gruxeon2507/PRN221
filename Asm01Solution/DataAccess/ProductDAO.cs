using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instancelock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> productList;
            try
            {
                using (var ctx = new Assignment01Context())
                {
                    productList = ctx.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public IEnumerable<Product> GetProductsByPrice(decimal price)
        {
            List<Product> productList;
            try
            {
                using (var ctx = new Assignment01Context())
                {
                    productList = ctx.Products.Where(p => p.UnitPrice == price).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public IEnumerable<Product> GetProductsByUnitInStock(int unit)
        {
            List<Product> productList;
            try
            {
                using (var ctx = new Assignment01Context())
                {
                    productList = ctx.Products.Where(p => p.UnitsInStock == unit).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public Product getProductById(int id)
        {
            Product product = null;
            try
            {
                using (var ctx = new Assignment01Context())
                {
                    product = ctx.Products.SingleOrDefault(m => m.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddProduct(Product product)
        {
            try
            {
                Product m = getProductById(product.ProductId);
                if (m == null)
                {
                    using (var ctx = new Assignment01Context())
                    {
                        ctx.Products.Add(product);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Product is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var ctx = new Assignment01Context())
                    {
                        ctx.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Product does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var ctx = new Assignment01Context())
                    {
                        ctx.Products.Remove(product);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Product does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
