using System.Collections.Generic;

namespace UI_test.Products
{
    class CProducts
    {
        public static List<MProduct> products = new();

        public void Add(int id, string name, string manuf, int count, float price )
        {
            Add(new MProduct()
            {
                Id = id,
                ProductName = name,
                Manufacture = manuf,
                ProductCount = count,
                Price = price
            });
        }
        public void Add(MProduct product)
        {
            products.Add(product);
        }
    }
}
