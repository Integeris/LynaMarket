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
        /// Минимальное количество.
        /// </summary>
        private int? fromAmount;

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
        /// Максимальное количество.
        /// </summary>
        private int? toAmount;

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
        /// Максимальное растояние для отдельного слова.
        /// </summary>
        private int maxWordLen;

        /// <summary>
        /// Максимальное растояние для всего предложения.
        /// </summary>
        private int? maxStringLen;

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
                if (value != null && value.All(chr => Char.IsWhiteSpace(chr)))
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
        /// Минимальное количество.
        /// </summary>
        public int? FromAmount
        {
            get => fromAmount;
            set
            {
                if (value > toAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                fromAmount = value;
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
        /// Максимальное количество.
        /// </summary>
        public int? ToAmount
        {
            get => toAmount;
            set
            {
                if (value < fromAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                toAmount = value;
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                take = value;
            }
        }

        /// <summary>
        /// Максимальное растояние для отдельного слова.
        /// </summary>
        public int MaxWordLen
        {
            get => maxWordLen;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Степень совпадения слов не может быть меньше 1.");
                }

                maxWordLen = value;
            }
        }

        /// <summary>
        /// Максимальное растояние для всего предложения.
        /// </summary>
        public int? MaxStringLen
        {
            get => maxStringLen;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Степень совпадения предложения не может быть меньше 1.");
                }

                maxStringLen = value;
            }
        }

        /// <summary>
        /// Свйоство растояния Ливенштейна.
        /// </summary>
        public LivensgtainProperty LivensgtainProperty
        {
            get
            {
                if (title != null)
                {
                    return new LivensgtainProperty("Cost", "Title", title, maxWordLen, MaxStringLen);
                }

                return null;
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
        /// Получение статических свойств.
        /// </summary>
        public List<StaticProperty> GetStaticProperties
        {
            get
            {
                List<StaticProperty> properties = new List<StaticProperty>();

                if (deleted != null)
                {
                    properties = new List<StaticProperty>
                    {
                        new StaticProperty("Deleted", deleted)
                    };
                }

                return properties;
            }
        }

        /// <summary>
        /// Получение свойств с диапазоном.
        /// </summary>
        public List<BetweenProperty> GetBetweenProperties
        {
            get
            {
                List<BetweenProperty> properties = null;

                if (AnyNotNull(fromHeight, toHeight, fromWidth, toWidth, fromDepth, toDepth, fromPrice, toPrice, fromAmount, toAmount))
                {
                    properties = new List<BetweenProperty>();

                    if (AnyNotNull(fromHeight, toHeight))
                    {
                        properties.Add(new BetweenProperty("Height", fromHeight, toHeight));
                    }

                    if (AnyNotNull(fromWidth, toWidth))
                    {
                        properties.Add(new BetweenProperty("Width", fromWidth, toWidth));
                    }

                    if (AnyNotNull(fromDepth, toDepth))
                    {
                        properties.Add(new BetweenProperty("Depth", fromDepth, toDepth));
                    }

                    if (AnyNotNull(fromPrice, toPrice))
                    {
                        properties.Add(new BetweenProperty("Price", fromPrice, toPrice));
                    }

                    if (AnyNotNull(fromAmount, toAmount))
                    {
                        properties.Add(new BetweenProperty("Amount", fromAmount, toAmount));
                    }
                }

                return properties;
            }
        }

        /// <summary>
        /// Получение свойств с множеством значений.
        /// </summary>
        public List<MultiProperty> GetMultiProperties
        {
            get
            {
                List<MultiProperty> properties = null;

                if (AnyNotNull(manufacturers, productCategories, colors, materials))
                {
                    properties = new List<MultiProperty>();

                    if (manufacturers != null)
                    {
                        properties.Add(new MultiProperty("IdManufacturer",
                            manufacturers.Select(manufacturer => (object)manufacturer.IdManufacturer).ToList()));
                    }

                    if (productCategories != null)
                    {
                        properties.Add(new MultiProperty("IdProductCategory",
                            productCategories.Select(productCategory => (object)productCategory.IdProductCategory).ToList()));
                    }

                    if (colors != null)
                    {
                        properties.Add(new MultiProperty("IdColor",
                            colors.Select(color => (object)color.IdColor).ToList()));
                    }

                    if (materials != null)
                    {
                        properties.Add(new MultiProperty("IdMaterial",
                            materials.Select(material => (object)material.IdMaterial).ToList()));
                    }
                }

                return properties;
            }
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
            List<StaticProperty> staticProperties = GetStaticProperties;
            List<BetweenProperty> betweenProperties = GetBetweenProperties;
            List<MultiProperty> multiProperties = GetMultiProperties;
            LivensgtainProperty livensgtainProperty = LivensgtainProperty;

            List<Product> products = await Core.GetProductsAsync(staticProperties, betweenProperties, multiProperties, 
                skip, take, sortingProperties, livensgtainProperty);

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
    }
}