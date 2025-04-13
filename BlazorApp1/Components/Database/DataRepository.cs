using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Components.Class;
using System.Transactions;

namespace BlazorApp1.Components.Database
{
    public class DataRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        public readonly AppDbContext dbContext;
        private readonly ILogger<DataRepository> logger;
        public DataRepository(IDbContextFactory<AppDbContext> contextFactory, ILogger<DataRepository> logger)
        {
            _contextFactory = contextFactory;
            this.logger = logger;
            dbContext = _contextFactory.CreateDbContext();
        }

        public async Task<int> AddProduct(Product product)
        {
            try
            {
                await dbContext.Products.AddAsync(product);
                await dbContext.SaveChangesAsync();
                return product.Id;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public async Task<List<Product>> GetProductList()
        {
            List<Product> products = [];
            try
            {
                products = await dbContext.Products
                    .ToListAsync();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return products;

        }
        public async Task<Product> GetProductById(int productId)
        {
            Product product;
            try
            {
                product = await dbContext.Products.Where(i => i.Id == productId).FirstOrDefaultAsync();
                await dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return product;
        }

     

    }
}

