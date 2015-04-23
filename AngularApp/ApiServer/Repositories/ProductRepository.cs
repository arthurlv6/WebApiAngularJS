using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiServer.DataContext;
using ApiServer.DataContext.Models;

namespace ApiServer.Repositories
{
    public class ProductRepository
    {
        internal Product GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products.Find(id);
            }
        }
        internal List<Product> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                var data = db.Products.ToList();
                return data;
            }
        }

        internal Product Add()
        {
            return new Product(){CreateDate = DateTime.Now};
        }
        internal void Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var removeEntity = db.Products.Find(id);
                db.Products.Remove(removeEntity);
                db.SaveChanges();
            }
        }
        internal Product Save(Product product)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            return product;
        }

        internal Product Save(int id, Product product)
        {
            using (var db = new ApplicationDbContext())
            {
                var updateItem=db.Products.Find(id);
                updateItem.Name = product.Name;
                updateItem.Cost = product.Cost;
                updateItem.Price = product.Price;
                updateItem.Profile = product.Profile;
                updateItem.ProductCode = product.ProductCode;
                updateItem.CreateDate = DateTime.Now;
                db.SaveChanges();
            }
            return product;
        }
    }
}
