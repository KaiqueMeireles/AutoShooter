using System;

namespace PuppeteerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string url;
            Console.WriteLine("Digite a URL do site que deseja testar:");
            url = Console.ReadLine();

            Console.WriteLine(@"Serão feitas screenshots nas seguintes resoluções (altura x largura):

1. 640x360
2. 768x1366
3. 1080x1920
4. 667x375
5. 900x1440
6. 1024x768
7. 720x360
8. 864x1536
9. 736x414
10. 900x1600
11. 800x1280
12. 768x1024
13. 1280x720
");
            //opcao = int.Parse(Console.ReadLine());
            System.Threading.Thread.Sleep(2500);

            StartShooting shooter = new StartShooting();
            Console.WriteLine("Salvando...");
            shooter.Snapshot(url, (s) => {
                Console.Write(s);
            });

            Console.ReadKey();
        }
    }
}
