using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            Product DbReturnedProduct = _context.products.FirstOrDefault(u => u.Id == product.Id);
            DbReturnedProduct.Title = product.Title;
            DbReturnedProduct.ISBN = product.ISBN;
            DbReturnedProduct.Author = product.Author;
            DbReturnedProduct.Description = product.Description;
            DbReturnedProduct.ListPrice = product.ListPrice;
            DbReturnedProduct.Price = product.Price;
            DbReturnedProduct.Price50 = product.Price50;
            DbReturnedProduct.Price100 = product.Price100;
            DbReturnedProduct.CategoryId = product.CategoryId;
            if (DbReturnedProduct.ImageUrl != null)
            {
                DbReturnedProduct.ImageUrl = product.ImageUrl;
            }

        }
    }
}
