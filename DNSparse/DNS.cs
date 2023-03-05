using Carret;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium.DevTools.V108.Profiler;
using System.Collections.ObjectModel;

namespace DNSparse
{
    internal class DNS
    {
        // Чисто набросок! Нужно менять концепцию...
        private string url_list_product = "https://www.dns-shop.ru/catalog/17a892f816404e77/noutbuki/" +
            "?f[676]=26o9-26ob-c525&f[66c]=9mkqp-2681-2680-rouuc-3lh5p-4bpxa&f[67l]=14f68l-13kkd2-yurhl-" +
            "y8tpu-1d28a9-l5bba-yurrt-1d2gze-1s0fja-1s0fjw-1rvscm-1rvsey-1rvsgo&f[lqdk]=15vd1d-r09q0-qgknr-" +
            "qkmqt-qgkol";
        private List<string> lists = new List<string>();
        public DNS() { }

        public async Task ParseAsync()
        {
            List<laptop> laptops = new List<laptop>();

            UpdateString status = new UpdateString("\t", "DNS [", "Загрузка списка...", "]");
            status.Write();
            Console.WriteLine("\n\n"); // Чтобы не перекрывал

            // Выполнение
            IWebDriver driver = get_element.Driver();
            driver.Navigate().GoToUrl(url_list_product);
            //Thread.Sleep(5000);
            //var links = driver.FindElements(By.XPath("//a[@class='catalog-product__name ui-link ui-link_black']"));
            //foreach (IWebElement link in links)
            //    Console.WriteLine("\t{0} - {1}\n\n", link.Text, link.GetAttribute("href"));

            status[2] = "Прокручивание списка...";
            status.Write();
            int last_count = 0;
            int eterations = 0;
            try
            {
                Thread.Sleep(5000); // Даём время прогрузиться. Нужно изменить метод проверки для работы с медленным интернетом
                var button = driver.FindElement(By.ClassName("pagination-widget__show-more-btn"));
                while (button != null)
                {
                    last_count = driver.FindElements(By.XPath("//a[@class='catalog-product__name ui-link ui-link_black']")).Count;
                    Thread.Sleep(1000);
                    eterations = 0;
                    button.Click();
                    while (last_count >= driver.FindElements(By.XPath("//a[@class='catalog-product__name ui-link ui-link_black']")).Count && eterations < 10)
                    {
                        eterations++;
                        Thread.Sleep(7000);
                    }
                    last_count = driver.FindElements(By.XPath("//a[@class='catalog-product__name ui-link ui-link_black']")).Count;
                    button = driver.FindElement(By.ClassName("pagination-widget__show-more-btn"));
                }
            }
            catch { }

            status[2] = "Сбор ссылок";
            status.Write();


            int count_eterations = 0;
            IReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//a[@class='catalog-product__name ui-link ui-link_black']"));
            while (count_eterations < 10)
            {
                count_eterations++;
                if (links.Count <= 0) Thread.Sleep(1000);
                else break;
                links = driver.FindElements(By.XPath("//a[@class='catalog-product__name ui-link ui-link_black']"));
                
            }

            List<string> urls = new List<string>();

            foreach (IWebElement link in links)
            {
                string? url = link.GetAttribute("href");
                if (url != null) urls.Add(url);
            }

            Console.WriteLine("Число: " + urls.Count);

                int count = 0;
            try
            {
                foreach (string link in urls)
                {
                    status[2] = "Сбор элемента " + ++count;
                    status.Write();

                    laptop Laptop = new laptop();

                    Laptop.title = get_element.title(driver, link);

                    Console.WriteLine($"[{count}] " + Laptop.title);

                    laptops.Add(Laptop);

                    status[2] += "; Пауза...";
                    status.Write();

                    Thread.Sleep(5000);
                }
            } catch { }

            driver.Close();
            driver.Quit();
        }
    }
}
