using Carret;

namespace DNSparse
{
    internal class Program
    {
        // Настройки


        static async Task Main(string[] args)
        {
            Console.WriteLine("Парсер DNS запущен...");
            UpdateString LoadingStr = new UpdateString("\tЗагрузка => ", "[", "Чтение параметров...", "]");
            LoadingStr.Write();

            DNS dns = new DNS();

            await dns.ParseAsync();

            Console.ReadKey();
        }
    }
}