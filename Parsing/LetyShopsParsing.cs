using BLL;
using Entity;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    /// <summary>
    /// Класс, предназначенный для парсинга сайта LetyShops.
    /// Реализовывает интерфейс ISiteParsing <see cref="ISiteParsing"/>
    /// </summary>
    public class LetyShopsParsing : ISiteParsing
    {
        #region Fields
        private List<string> names;
        private List<string> discounts;
        private List<int> pages;
        private List<string> urls;
        private List<string> images;
        private int? maxPage;
        HtmlWeb webGet;
        private List<LetyShops> letyShops;
        private ILetyShopsLogic letyShopsLogic;
        #endregion

        #region Properties
        public int? MaxPage { get => maxPage; set => maxPage = value; }
        public HtmlWeb WebGet { get => webGet; set => webGet = value; }
        public List<string> Names { get => names; set => names = value; }
        public List<string> Discounts { get => discounts; set => discounts = value; }
        public List<int> Pages { get => pages; set => pages = value; }
        public List<string> Urls { get => urls; set => urls = value; }
        public List<string> Images { get => images; set => images = value; }
        public List<LetyShops> LetyShops { get => letyShops; set => letyShops = value; }
        #endregion

        #region Constructors
        public LetyShopsParsing()
        {
            WebGet = new HtmlWeb();
            Names = new List<string>();
            Discounts = new List<string>();
            Pages = new List<int>();
            Urls = new List<string>();
            Images = new List<string>();
            LetyShops = new List<LetyShops>();
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Метод для парсинга сайта LetyShops
        /// </summary>
        public void Parsing()
        {

            MaxPage = MaxPageOnSite(webGet);

            for (int i = 1; i <= 1; i++)
            {

                var url = $"https://letyshops.com/shops?page=1";

                if (WebGet.Load(url) is HtmlDocument document)
                {
                    var nodes = document.DocumentNode.CssSelect("div.b-teaser");

                    ListOfNames(nodes);

                    ListOfDiscount(nodes);

                    ListOfUrls(nodes);

                    ListOfImages(nodes);

                }
            }
        }

        /// <summary>
        /// Метод, возвращающий список данных с сайта LetyShops
        /// </summary>
        /// <returns>Список LetyShops</returns>
        public IEnumerable ShowData()
        {
            List<LetyShops> letyShops = new List<LetyShops>();
            for (int i = 0; i < Names.Count; i++)
            {
                letyShops.Add(new LetyShops(Names[i], Discounts[i], Urls[i], Images[i], DateTime.Now.ToString()));
            }
            return letyShops.ToList();
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Метод, заполняющий список кэшбеков с сайта LetyShops
        /// </summary>
        /// <param name="nodes">Список html данных</param>
        private void ListOfDiscount(IEnumerable<HtmlNode> nodes)
        {
            foreach (var node in nodes)
            {
                // /html/body/div//*/div[@class='b-shop-teaser__cash-value-row']//span[@class='b-shop-teaser__cash']|//span[@class='b-shop-teaser__new-cash']
                foreach (var cashValues in node.SelectNodes("/html/body/div//*/div[@class='b-shop-teaser__cash-value-row']"))
                {
                    //Console.WriteLine(cashValues.InnerText.CleanInnerText());
                    Discounts.Add(cashValues.InnerText.CleanInnerText());
                }
            }
        }

        /// <summary>
        /// Метод, заполняющий список с именами магазинов с сайта LetyShops
        /// </summary>
        /// <param name="nodes">Список html данных</param>
        private void ListOfNames(IEnumerable<HtmlNode> nodes)
        {
            foreach (var item in nodes)
            {
                foreach (var item2 in item.CssSelect("div.b-teaser__title"))
                {
                    Names.Add(item2.InnerText.CleanInnerText());
                }
            }
        }

        /// <summary>
        /// Метод, заполняющий список с url магазинов с сайта LetyShops
        /// </summary>
        /// <param name="nodes">Список html данных</param>
        private void ListOfUrls(IEnumerable<HtmlNode> nodes)
        {
            foreach (var item in nodes)
            {
                foreach (var item2 in item.CssSelect("a.b-teaser__inner"))
                {
                   foreach(var item3 in item2.SelectNodes("/html/body//*/div[@class='b-teaser']/a/@href"))
                    {
                        foreach (var item4 in item3.Attributes)
                        {
                            Urls.Add(item4.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод, заполняющий список с url картинок магазинов с сайта LetyShops
        /// </summary>
        /// <param name="nodes">Список html данных</param>
        private void ListOfImages(IEnumerable<HtmlNode> nodes)
        {
            foreach (var item in nodes)
            {
                foreach (var item2 in item.CssSelect("div.b-teaser__cover"))
                {
                    foreach (var item3 in item2.SelectNodes("/html/body//*/div[@class='b-teaser']/a//*/div[@class='b-teaser__cover']/img/@src"))
                    {
                        foreach(var item4 in item3.Attributes)
                        {
                            Images.Add(item4.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для подсчёта страниц на сайте
        /// </summary>
        /// <param name="WebGet">Переменная для подключения</param>
        /// <returns></returns>
        private int? MaxPageOnSite(HtmlWeb WebGet)
        {
            var url = "https://letyshops.com/shops?page=1";

            if (WebGet.Load(url) is HtmlDocument document)
            {
                var maxPage = document.DocumentNode.CssSelect("ul.b-pagination").CssSelect("li.b-pagination__item").CssSelect("a.b-pagination__link");

                foreach (var item in maxPage)
                {
                    if (Int32.TryParse(item.InnerText, out int result))
                    {
                        Pages.Add(result);
                    }
                }

                return Pages.Max();

            }

            return null;
        } 
        #endregion

    }
}
