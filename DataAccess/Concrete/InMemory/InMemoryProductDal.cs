using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
                _products = new List<Product>()
                {
                    new Product{ProductId=1,CategoryId=4,ProductName="florida",Description="Jean",UnitPrice=299,UnitsInStock=24},
                    new Product{ProductId=2,CategoryId=4,ProductName="plural",Description="shirt",UnitPrice=399,UnitsInStock=61},
                    new Product{ProductId=3,CategoryId=5,ProductName="wheels",Description="toys",UnitPrice=69,UnitsInStock=12},
                    new Product{ProductId=4,CategoryId=5,ProductName="soap",Description="cosmetics",UnitPrice=29,UnitsInStock=27}
                };
        }
        public void Add(Product product)
        {
           _products.Add(product) ;
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;
            //foreach (Product p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //        productToDelete = p;
            //}
            //_products.Remove(productToDelete) ;

            // LINQ is more efficient way to delete    Language integrated Query
            Product productToDelete =_products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete) ;
            
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return _products.Where(p=> p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName= product.ProductName;
            productToUpdate.Description= product.Description; 
            productToUpdate.UnitPrice= product.UnitPrice;
            productToUpdate.UnitsInStock= product.UnitsInStock;
            productToUpdate.CategoryId= product.CategoryId;
            
        }
    }
}
