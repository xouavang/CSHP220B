﻿using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Test
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                var items = new[]
                {
                    new Product{ Name="Baseball", Price=11},
                    new Product{ Name="Football", Price=8},
                    new Product{ Name="Tennis ball", Price=13} ,
                    new Product{ Name="Golf ball", Price=3},
                    new Product{ Name="Ping pong ball", Price=12}
                };
                return items;
            }
        }
    }
}

