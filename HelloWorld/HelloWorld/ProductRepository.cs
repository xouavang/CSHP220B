using HelloWorld.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        private IMemoryCache memoryCache;

        public ProductRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                Product[] items;

                // Check if already cache, if not, then go get the data
                if (!memoryCache.TryGetValue("MyProducts", out items))
                {
                    items = new[]
                        {
                        new Product{ ProductId=101, Name = "Baseball", Description="balls", Price=14.20m},
                        new Product{ ProductId=102, Name="Football", Description="nfl", Price=9.24m},
                        new Product{ Name="Tennis ball"} ,
                        new Product{ Name="Golf ball"},
                    };

                    // save it in the cache
                    // This is an absolute cache. Will only cache for the specified time.
                    //memoryCache.Set("MyProducts", items,
                    //    new MemoryCacheEntryOptions()
                    //    .SetAbsoluteExpiration(System.TimeSpan.FromSeconds(30)));
                    // Sliding cache. As long as the cache is access, it will store it in cache for the specified duration
                    memoryCache.Set("MyProducts", items,
                        new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(System.TimeSpan.FromSeconds(5)));
                }

                // Return data from the cache. Can easily use "items", but good practice to pull from cache.
                return (Product[])memoryCache.Get("MyProducts");
            }
        }
    }
}
