using bebekbezidunyasi.Models;
using OpenQA.Selenium;
using bebekbezidunyasi.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using bebekbezidunyasi.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace bebekbezidunyasi
{
    public class Brands
    {
        public void brand_added()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bebekbezidunyasi.com/markalar");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> Brandis2 = driver.FindElements(By.ClassName("brandsList"));

            List<Brand> brand = new List<Brand>();

            foreach (IWebElement Brandii in Brandis2)
            {
                IReadOnlyCollection<IWebElement> Brandis = Brandii.FindElements(By.XPath("li"));

                foreach (IWebElement Brandii2 in Brandis)
                {
                    IWebElement BrandPath = Brandii2.FindElement(By.XPath("a"));

                    string brandurl = Brandii2.GetAttribute("href");

                    string brandname = Brandii2.FindElement(By.TagName("strong")).GetAttribute("innerHTML");

                    Regex r4 = new Regex(@".*\/(?<katCode>.*$)");

                    string CatgoryCode = null;
                    if (r4.Match(brandurl).Success)
                    {
                        CatgoryCode = r4.Match(brandurl).Groups["katCode"].Value;
                    }
                    Console.WriteLine(brandname);

                    Brand branda = new Brand();
                    branda.Name = brandname;
                    branda.State = true;
                    branda.Source = 5;//bebekbezidunyasi,
                    branda.Description = CatgoryCode;

                    //using (var context = new ProductContext())
                    //{
                    //    context.Brands.AddRange(branda);

                    //    context.SaveChanges();
                    //}
                }
            }
        }
    }

}

