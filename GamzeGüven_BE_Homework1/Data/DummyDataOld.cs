using System;
using FirstHomework.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstHomework.Data
{
	public class DummyDataOld
	{
        private static volatile DummyDataOld _instance = null;
        private static readonly object padLock = new object();

        public static DummyDataOld Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DummyDataOld();
                    }
                }
                return _instance;
            }
        }

        private DummyDataOld()
        {
            FillData();
        }

        private void FillData()
        {
            for (int i = 1; i <= 10; i++)
            {
                Products.Add(new ProductModel { Id = i, Name = "Product_" + i, Price = 100 + (i * 10) });
            }
        }

        public List<ProductModel> Products = new List<ProductModel>();

    }
}
 