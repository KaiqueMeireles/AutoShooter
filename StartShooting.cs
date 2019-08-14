using PuppeteerSharp;
using System;
using System.IO;

namespace PuppeteerConsole
{
    public class StartShooting
    {
        public async void Snapshot(string url, Action<string> msg)
        {
            var download = await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            int altura = 0;
            int largura = 0;
            int opcao = 1;

            if (download.Downloaded)
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = "http://" + url;

                //Verifica se o diretório de destino já existe e cria caso não haja
                if (!Directory.Exists($@"C:\AutoShooter Screenshots"))
                    Directory.CreateDirectory($@"C:\AutoShooter Screenshots");

                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });
                var page = await browser.NewPageAsync();

                while (opcao < 14)
                {
                    //Aqui ele altera o parâmetro da viewport para as resoluções mais utilizadas
                    switch (opcao)
                    {
                        case 1:
                            altura = 640;
                            largura = 360;
                            break;
                        case 2:
                            altura = 768;
                            largura = 1366;
                            break;
                        case 3:
                            altura = 1080;
                            largura = 1920;
                            break;
                        case 4:
                            altura = 667;
                            largura = 375;
                            break;
                        case 5:
                            altura = 900;
                            largura = 1440;
                            break;
                        case 6:
                            altura = 1024;
                            largura = 768;
                            break;
                        case 7:
                            altura = 720;
                            largura = 360;
                            break;
                        case 8:
                            altura = 864;
                            largura = 1536;
                            break;
                        case 9:
                            altura = 736;
                            largura = 414;
                            break;
                        case 10:
                            altura = 900;
                            largura = 1600;
                            break;
                        case 11:
                            altura = 800;
                            largura = 1280;
                            break;
                        case 12:
                            altura = 768;
                            largura = 1024;
                            break;
                        case 13:
                            altura = 1280;
                            largura = 720;
                            break;
                    }

                    //Altera o tamanho da viewport
                    await page.SetViewportAsync(new ViewPortOptions
                    {
                        Width = largura,
                        Height = altura
                    });

                    await page.GoToAsync(url);

                    //Guid do final do nome do arquivo 
                    var codigo = Guid.NewGuid().ToString().Substring(0, 6);

                    string filename = $"screenshot_{altura}x{largura}_{codigo}.png";

                    //Método para definir as propriedades da screenshot utilizando um objeto como parâmetro (para alterar a propriedade FullPage)
                    await page.ScreenshotAsync($@"C:\AutoShooter Screenshots\{filename}", new ScreenshotOptions() { FullPage = true });
                    opcao++;
                }
                browser.Dispose();
            }
            else
            {
                msg($@"Erro: não foi possível atualizar/baixar o Chromium. Verifique sua conexão e reinicie o programa.");
                System.Threading.Thread.Sleep(7000);
                System.Environment.Exit(1);
            }
            msg($@"Screenshots salvas com sucesso em: C:\AutoShooter Screenshots");
            System.Threading.Thread.Sleep(7000);
            System.Environment.Exit(1);
        }
    }
}

