using System;
using System.Collections.Generic;
using System.Linq;
using FirstHomework.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FirstHomework.Data
{
	public class Database : IDatabase
	{
        public ObservableColleciton<ProductModel> Products { get; set; }

		public Database()
		{
            var jsonData = File.ReadAllText(@"C:\GitRepos\HBK\Kodluyoruz\YemekSepeti-WebAPI\FirstApplication" + "\\db.json");
            var data = JsonConvert.DeserializeObject<List<ProductModel>>(jsonData);
            this.Products = new ObservableCollection<ProductModel>(data ?? new List<ProductModel>());
            this.Products.CollectionChanged += Products_CollectionChanged;
        }

        private void Products_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // async update file
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                // async update file
            }
        }
    }

    public interface IDatabase
    {
        ObservableCollection<ProductModel> Products { get; set; }
    }
}
