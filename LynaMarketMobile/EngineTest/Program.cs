using LunaMarketEngine;
using LunaMarketEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTest
{
    internal class Program
    {
        static void Main()
        {
            News news = new News
            {
                Title = "asdasdas",
                Description = "dasdas",
                Date = DateTime.Now,
                Photo = new byte[] { 1, 3, 5, 2 }
            };

            Core.AddNews(news.Title, news.Date, news.Photo, news.Description);

            Console.WriteLine();
        }
    }
}
