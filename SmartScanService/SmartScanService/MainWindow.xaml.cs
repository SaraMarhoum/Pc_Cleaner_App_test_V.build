using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.IO;
using System.IO.Compression;
using System;

namespace SmartScanService
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

        private void bar_progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

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

                            string[] files = Directory.GetFiles(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release");

                                foreach (string file in files)
                                {
                                    File.Delete(file);

                                }                           

                                //File.Delete(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release\brief 3.exe");
                                client.DownloadFile("https://docs.google.com/uc?export=download&id=1sQCDn34gwqCS62qznlVi21Vr4Tq5rQFP", @"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release\brief 3.zip");
                                string zipPath = @"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release\brief 3.zip";
                                string extractPath = @"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release";
                                ZipFile.ExtractToDirectory(zipPath, extractPath);
                                File.Delete(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release\brief 3.zip");
                                Process.Start(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release\brief 3.exe");
                                this.Close();



                            btn_quiter.Visibility = Visibility.Visible;
                            txt_status.Text = "La mise à jour à été effectuée avec succès !";
                        }
                        //lbl_CountDownTimer.Text = i.ToString();

                    });
                }
            });
        }

        private void btn_quiter_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Process.Start(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\Release\brief 3.exe");
        }
    }
}
