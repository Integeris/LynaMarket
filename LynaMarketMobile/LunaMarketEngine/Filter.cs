using LunaMarketEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaMarketEngine
{
    /// <summary>
    /// Фильтр товаров.
    /// </summary>
    public sealed class Filter
    {
        /// <summary>
        /// Название.
        /// </summary>
        private string title;

        /// <summary>
        /// Высота.
        /// </summary>
        private int? height;

        /// <summary>
        /// Ширина.
        /// </summary>
        private int? width;

        /// <summary>
        /// Глубина.
        /// </summary>
        private int? depth;

        /// <summary>
        /// Список товаров.
        /// </summary>
        private List<Product> products;

        /// <summary>
        /// Список производителей.
        /// </summary>
        private List<Manufacturer> manufacturers;

        /// <summary>
        /// Название.
        /// </summary>
        public string Title
        {
            get => title;
            set => title = value;
        }

        /// <summary>
        /// Высота.
        /// </summary>
        public int? Height
        {
            get => height;
            set => height = value;
        }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int? Width
        {
            get => width;
            set => width = value;
        }

        /// <summary>
        /// Глубина.
        /// </summary>
        public int? Depth
        {
            get => depth;
            set => depth = value;
        }

        /// <summary>
        /// Список товаров.
        /// </summary>
        public List<Product> Products
        {
            get => products;
            set => products = value;
        }

        /// <summary>
        /// Список производителей.
        /// </summary>
        public List<Manufacturer> Manufacturers
        {
            get => manufacturers;
            set => manufacturers = value;
        }

        /// <summary>
        /// Создание фильтра.
        /// </summary>
        /// <param name="products">Список товаров.</param>
        public Filter(List<Product> products)
        {
            this.products = products;
        }

        /// <summary>
        /// Получение списка товаров.
        /// </summary>
        /// <returns>Список товаров.</returns>
        public async Task<List<Product>> GetProducts()
        {
            Dictionary<string, (MySqlConnector.MySqlDbType, object)> properties = new Dictionary<string, (MySqlConnector.MySqlDbType, object)>();



            return await Core.GetProductsAsync(properties);
        }
    }
}
