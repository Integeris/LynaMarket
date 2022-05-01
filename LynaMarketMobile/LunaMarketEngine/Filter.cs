using LunaMarketEngine.Entities;
using LunaMarketEngine.QueryConstructors.PropertiesTypes;
using MySqlConnector;
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
        /// Минимальная высота.
        /// </summary>
        private int? fromHeight;

        /// <summary>
        /// Минимальная ширина.
        /// </summary>
        private int? fromWidth;

        /// <summary>
        /// Минимальная глубина.
        /// </summary>
        private int? fromDepth;

        /// <summary>
        /// Минимальная цена.
        /// </summary>
        private decimal? fromPrice;

        /// <summary>
        /// Максимальная высота.
        /// </summary>
        private int? toHeight;

        /// <summary>
        /// Максимальная ширина.
        /// </summary>
        private int? toWidth;

        /// <summary>
        /// Максимальная глубина.
        /// </summary>
        private int? toDepth;

        /// <summary>
        /// Максимальная цена.
        /// </summary>
        private decimal? toPrice;

        /// <summary>
        /// Удалён?
        /// </summary>
        private bool? deleted;

        /// <summary>
        /// Пропустить.
        /// </summary>
        private int skip;

        /// <summary>
        /// Получить.
        /// </summary>
        private int take = Int32.MaxValue;

        /// <summary>
        /// Категории стоваров.
        /// </summary>
        private List<ProductCategory> productCategories;

        /// <summary>
        /// Список производителей.
        /// </summary>
        private List<Manufacturer> manufacturers;

        /// <summary>
        /// Цвета.
        /// </summary>
        private List<Color> colors;

        /// <summary>
        /// Список материалов.
        /// </summary>
        private List<Material> materials;

        /// <summary>
        /// Свойства для сортировки (по порядку).
        /// </summary>
        private List<SortingProperty> sortingProperties;

        /// <summary>
        /// Название.
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                if (value != null && value.Any(chr => Char.IsWhiteSpace(chr)))
                {
                    throw new ArgumentNullException(nameof(title), "Название не может быть пустым.");
                }

                title = value;
            }
        }

        /// <summary>
        /// Минимальная высота.
        /// </summary>
        public int? FromHeight
        {
            get => fromHeight;
            set
            {
                if (value > toHeight)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                fromHeight = value;
            }
        }

        /// <summary>
        /// Минимальная ширина.
        /// </summary>
        public int? FromWidth
        {
            get => fromWidth;
            set
            {
                if (value > toWidth)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                toWidth = value;
            }
        }

        /// <summary>
        /// Минимальная глубина.
        /// </summary>
        public int? FromDepth
        {
            get => fromDepth;
            set
            {
                if (value > toDepth)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                toDepth = value;
            }
        }

        /// <summary>
        /// Минимальная цена.
        /// </summary>
        public decimal? FromPrice
        {
            get => fromPrice;
            set
            {
                if (value > toPrice)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                fromPrice = value;
            }
        }

        /// <summary>
        /// Максимальная высота.
        /// </summary>
        public int? ToHeight
        {
            get => toHeight;
            set
            {
                if (value < fromHeight)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                toHeight = value;
            }
        }

        /// <summary>
        /// Максимальная ширина.
        /// </summary>
        public int? ToWidth
        {
            get => toWidth;
            set
            {
                if (value < fromWidth)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                fromWidth = value;
            }
        }

        /// <summary>
        /// Максимальная глубина.
        /// </summary>
        public int? ToDepth
        {
            get => toDepth;
            set
            {
                if (value < fromDepth)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                fromDepth = value;
            }
        }

        /// <summary>
        /// Максимальная цена.
        /// </summary>
        public decimal? ToPrice
        {
            get => toPrice;
            set
            {
                if (value < fromPrice)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                toPrice = value;
            }
        }

        /// <summary>
        /// Удалён?
        /// </summary>
        public bool? Deleted
        {
            get => deleted;
            set => deleted = value;
        }

        /// <summary>
        /// Пропустить.
        /// </summary>
        public int Skip
        {
            get => skip;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.skip = value;
            }
        }

        /// <summary>
        /// Получить.
        /// </summary>
        public int Take
        {
            get => take;
            set
            {
                if (take <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                take = value;
            }
        }

        /// <summary>
        /// Категории стоваров.
        /// </summary>
        public List<ProductCategory> ProductCategories
        {
            get => productCategories;
            set => productCategories = value;
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
        /// Цвета.
        /// </summary>
        public List<Color> Colors
        {
            get => colors;
            set => colors = value;
        }

        /// <summary>
        /// Список материалов.
        /// </summary>
        public List<Material> Materials
        {
            get => materials;
            set => materials = value;
        }

        /// <summary>
        /// Свойства для сортировки (по порядку).
        /// </summary>
        public List<SortingProperty> SortingProperties
        {
            get => sortingProperties;
            set => sortingProperties = value;
        }

        /// <summary>
        /// Создание фильтра.
        /// </summary>
        /// <param name="products">Список товаров.</param>
        public Filter()
        {

        }

        /// <summary>
        /// Получение списка товаров.
        /// </summary>
        /// <returns>Список товаров.</returns>
        public async Task<List<Product>> GetProducts()
        {
            List<StaticProperty> staticProperties = null;
            List<BetweenProperty> betweenProperties = null;
            List<MultiProperty> multiProperties = null;

            if (deleted != null)
            {
                staticProperties = new List<StaticProperty>
                {
                    new StaticProperty("Deleted", deleted)
                };
            }

            if (AnyNotNull(fromHeight, toHeight, fromWidth, toWidth, fromDepth, toDepth, fromPrice, toPrice))
            {
                betweenProperties = new List<BetweenProperty>();

                if (AnyNotNull(fromHeight, toHeight))
                {
                    betweenProperties.Add(new BetweenProperty("Height", fromHeight, toHeight));
                }

                if (AnyNotNull(fromWidth, toWidth))
                {
                    betweenProperties.Add(new BetweenProperty("Width", fromWidth, toWidth));
                }

                if (AnyNotNull(fromDepth, toDepth))
                {
                    betweenProperties.Add(new BetweenProperty("Depth", fromDepth, toDepth));
                }
            }

            if (AnyNotNull(manufacturers, productCategories, colors))
            {
                multiProperties = new List<MultiProperty>();

                if (manufacturers != null)
                {
                    multiProperties.Add(new MultiProperty("IdManufacturer", 
                        manufacturers.Select(manufacturer => (object)manufacturer.IdManufacturer).ToList()));
                }

                if (productCategories != null)
                {
                    multiProperties.Add(new MultiProperty("IdProductCategory", 
                        productCategories.Select(productCategory => (object)productCategory.IdProductCategory).ToList()));
                }

                if (AnyNotNull(colors, materials))
                {
                    List<MultiProperty> innerMultiProperty = new List<MultiProperty>();
                    List<BetweenProperty> innerBetweenProperties = new List<BetweenProperty>();

                    if (colors != null)
                    {
                        innerMultiProperty.Add(new MultiProperty("IdColor", colors.Select(color => (object)color.IdColor).ToList()));
                    }

                    if (materials != null)
                    {
                        innerMultiProperty.Add(new MultiProperty("IdMaterial", materials.Select(material => (object)material.IdMaterial).ToList()));
                    }

                    if (AnyNotNull(fromPrice, toPrice))
                    {
                        innerBetweenProperties.Add(new BetweenProperty("Price", fromPrice, toPrice));
                    }

                    List<ProductInfo> productInfos = await Core.GetProductInfosAsync(default, default, innerMultiProperty);
                    multiProperties.Add(new MultiProperty("IdProduct", productInfos.Select(productInfo => (object)productInfo.IdProduct).ToList()));
                }
            }

            List<Product> products = await Core.GetProductsAsync(staticProperties, betweenProperties, multiProperties, skip, take, sortingProperties);

            if (title != null)
            {
                products = products.Where(product => LivenshtainLen(title, product.Title)).ToList();
            }

            return products;
        }

        /// <summary>
        /// Проверка на пустоту.
        /// </summary>
        /// <param name="objects">Список оюъектов.</param>
        /// <returns>Не пуст ли хотябы один элемент.</returns>
        private bool AnyNotNull(params object[] objects)
        {
            if (objects == null)
            {
                return false;
            }

            return objects.Any(x => x != null);
        }

        /// <summary>
        /// Проверяет строку на сходство.
        /// </summary>
        /// <param name="searchTemlate">Строка для сравнения.</param>
        /// <param name="text">Сравниваемая строка.</param>
        /// <returns>Совпадают ли строки.</returns>
        private bool LivenshtainLen(string searchTemlate, string text)
        {
            const int maxCount = 3;

            int[,] matrix = new int[searchTemlate.Length + 1, text.Length + 1];

            for (int i = 0; i <= text.Length; i++)
            {
                matrix[0, i] = i;
            }

            for (int i = 1; i <= searchTemlate.Length; i++)
            {
                matrix[i, 0] = i;
            }

            for (int i = 0; i < searchTemlate.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    int minSteps = Math.Min(matrix[i, j], matrix[i, j + 1]);
                    minSteps = Math.Min(minSteps, matrix[i + 1, j]);

                    if (searchTemlate[i] != text[j])
                    {
                        minSteps++;
                    }

                    matrix[i + 1, j + 1] = minSteps;
                }
            }

            return matrix[searchTemlate.Length, text.Length] <= maxCount;
        }
    }
}