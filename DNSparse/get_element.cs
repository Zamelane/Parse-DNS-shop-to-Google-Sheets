using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DNSparse
{
    internal class get_element
    {
        public static string? title(IWebDriver driver, string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);

                int count = 0;
                while (count < 10)
                {
                    count++;
                    try
                    {
                        var element = driver.FindElement(By.XPath("//div[@class='product-card-top__name']"));
                    
                    if (element != null)
                        return element.Text;
                    } catch { }
                    Thread.Sleep(count * 1000);
                }
                throw new Exception();
            } catch
            {
                return "Нет названия";
            }
        }
        public static IWebDriver Driver()
        {
            // Настройки
            string pathToFile = AppDomain.CurrentDomain.BaseDirectory + '\\';
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(pathToFile);
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            // Прячет браузер
            ChromeOptions options = new ChromeOptions();
            var chromeDriverService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            chromeDriverService.HideCommandPromptWindow = true;
            chromeDriverService.SuppressInitialDiagnosticInformation = true;
            options.AddArgument("--disable-extensions");
            options.AddArgument("test-type");
            options.AddArgument("headless");
            options.AddArgument("--silent");
            options.AddArgument("log-level=3");
            return new ChromeDriver(service, options);
        }
    }
}
