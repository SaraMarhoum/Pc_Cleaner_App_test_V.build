using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace SmartScanUpdater
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            btn_start.Visibility = Visibility.Hidden;

            bar_progress.Visibility = Visibility.Visible;

            txt_status.Visibility = Visibility.Visible;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        bar_progress.Value = i;
                        if (i == 100)
                        {

                            WebClient webClient = new WebClient();
                            var client = new WebClient();

                            //Thread.Sleep(5000);
                            string[] files = Directory.GetFiles(@".\");

                            try
                            {
                                foreach (string file in files)
                                {
                                    try
                                    {
                                        File.Delete(file);

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);

                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                        //if crash , everything lost , best not delate and replace directly 
                            client.DownloadFile("https://docs.google.com/uc?export=download&id=1ZZLFZEPnC15oMSm2dAHwUNPEhdJohhbO", @"Release.zip");
                            string zipPath = @".\Release.zip";
                            //. pour racourcir 
                            string extractPath = @".\";
                            ZipFile.ExtractToDirectory(zipPath, extractPath);

                            // not delate the zip file and leave it as backup by rename
                            File.Delete(@".\Release.zip");
                            //Process.Start(@"..\..\..\brief 3\bin\Release\brief 3.exe");
                            //this.Close();

                            btn_quiter.Visibility = Visibility.Visible;
                            txt_status.Text = "Mise à jour terminée !";
                        }

                    });
                }
            });
        }

        private void btn_quiter_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Process.Start(@".\brief 3.exe");
        }


    }
}
