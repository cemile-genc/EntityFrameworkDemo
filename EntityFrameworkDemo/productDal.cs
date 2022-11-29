using ADONetDemo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            //verileri liste halinde çekme 
            using (ETradeContext context = new ETradeContext())
            {
               return context.Products.ToList();

            }

        }
        public List<Product> GetByName(string key)
        {
            //verileri ismine göre çekme 
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();

            }

        }
        public List<Product> GetByUnitPrice(decimal price)
        {
            //verileri yüksek fiyatlı olana göre çekme
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=price).ToList();

            }

        }
        //Product ürün ekleme
        public void Add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                //context.Products.Add(product);
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();  
            }
        }
        //Product ürün güncelleme
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Product ürün silme
        public void Delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
