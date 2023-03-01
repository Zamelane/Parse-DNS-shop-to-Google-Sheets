using Carret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSparse
{
    internal class DNS
    {
        private string url_api_products = "https://www.dns-shop.ru/product/microdata/";
        private string url_list_product = "https://www.dns-shop.ru/catalog/17a892f816404e77/noutbuki/?p=";
        private List<string> lists = new List<string>();
        public DNS() { }

        public async Task ParseAsync()
        {
            HttpClient client = new HttpClient();

            UpdateString status = new UpdateString("", " Модуль парсинга DNS: ", "[", "???", " из ", "???", "]" , " [", "Сбор страниц...", "]");
            status.Write();

            int page = 1;
            string result = "";
            bool search = true;

            do
            {
                await Task.Run(async () =>
                {
                    HttpResponseMessage response = await client.GetAsync(url_list_product + page);
                    HttpContent content = response.Content;
                    result = await content.ReadAsStringAsync();
                });
                status[3] = page.ToString();

                if (result.Contains("catalog-product__discount-vobler w-product-discount-voblers"))
                {
                    lists.Add(result);
                    page++;
                    status[5] = page.ToString();
                }
                else
                {
                    search = false;
                    status[5] = (page - 1).ToString();
                    status[8] = "Сбор страниц завершён";
                    status[0] = "[ОК]";
                    //Console.WriteLine(result);
                }

                status.Write();

            } while(search);

        }
    }
}
