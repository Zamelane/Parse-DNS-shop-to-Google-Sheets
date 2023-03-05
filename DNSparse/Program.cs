using Carret;

namespace DNSparse
{
    internal class Program
    {
        // Настройки


        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Парсер DNS запущен...");
                UpdateString LoadingStr = new UpdateString("\tЗагрузка => ", "[", "Чтение параметров...", "]");
                LoadingStr.Write();

                DNS dns = new DNS();

                await dns.ParseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Непредвиденная ошибка: " + ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {

                Console.WriteLine("\n\n\nПрограмма завершена!");
                Console.ReadKey();
            }
        }
    }
}