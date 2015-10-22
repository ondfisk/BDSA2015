using System;
using System.Collections.Generic;

namespace BDSA2015.Lecture03
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> Read();
        Product Read(int productId);
        int Create(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}