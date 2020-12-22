using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;



namespace brief_3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WebClient webClient = new WebClient();

            try
            {
                if (webClient.DownloadString("https://pastebin.com/WEtPgrhF").Contains("v1.1.0"))
                {
                    if (System.Windows.Forms.MessageBox.Show("Looks like there is an update! Do you want to download it?", "Demo", MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) using (var client = new WebClient())

                        {
                            Process.Start(@"C:\Users\Youcode\source\repos\SmartScanService\SmartScanService\bin\Release\SmartScanService.exe");
                            this.Close();
                        }
                }
            }
            catch
            {

            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        //Bouton analyser 1 /////////////////////////////////////////////////////
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.MessageBox.Show("Commencer l'analyse ?");
            txt_analyse.Text = "Analyse en cours";
            btn_vue.IsEnabled = false;
            btn_analyse1.IsEnabled = false;
            btn_histo1.IsEnabled = false;
            btn_option.IsEnabled = false;
            txt_info.Visibility = Visibility.Hidden;
            btn_analyse.Content = "Analyse en cours";
            btn_analyse.IsEnabled = false;

            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;


            bar_progress.Visibility = Visibility.Visible;
            txt_output.Visibility = Visibility.Visible;

            Thread.Sleep(1000);
            bar_progress.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        bar_progress.Value = i;
                        if (i == 99)
                        {


                            // Make a reference to a directory.
                            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\java");

                            // Get a reference to each file in that directory.
                            FileInfo[] fiArr = di.GetFiles();

                            if (Directory.GetFileSystemEntries(@"C:\Users\Youcode\Desktop\java").Length == 0)
                            {
                                txt_output.Items.Add("There is no files ! ");
                            }
                            else
                            {
                                // Display the names and sizes of the files.
                                txt_output.Items.Add($"The directory {di.Name} contains the following files:\n");

                                foreach (FileInfo f in fiArr)
                                {

                                    txt_output.Items.Add($"The size of {f.Name}  is {f.Length} bytes. \n");
                                }
                            }

                            txt_analyse.Text = "Analyse terminée !";
                            btn_analyse.Visibility = Visibility.Hidden;
                            btn_back__db.Visibility = Visibility.Visible;
                            btn_vue.IsEnabled = true;
                            btn_analyse1.IsEnabled = true;
                            btn_histo1.IsEnabled = true;
                            btn_option.IsEnabled = true;
                            txt_info.Visibility = Visibility.Visible;
                            bar_progress.Visibility = Visibility.Hidden;

                            System.Windows.Forms.MessageBox.Show("Analyse finie !");
                        }
                        //lbl_CountDownTimer.Text = i.ToString();


                    });
                }
            });
        }



        //Bouton netoyer ( suprimer ) ////////////////////////////////////////////////
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Commencer le nettoyage ?");


            txt_analyse.Text = "Nettoyage en cours";
            btn_vue.IsEnabled = false;
            btn_analyse1.IsEnabled = false;
            btn_histo1.IsEnabled = false;
            btn_option.IsEnabled = false;
            txt_info.Visibility = Visibility.Hidden;
            btn_analyse.Visibility = Visibility.Hidden;

            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;


            bar_progress.Visibility = Visibility.Visible;
            txt_output.Visibility = Visibility.Visible;

            Thread.Sleep(1000);
            bar_progress.Value = 0;

            txt_output.Visibility = Visibility.Visible;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        bar_progress.Value = i;
                        if (i == 99)
                        {

                            string[] files = Directory.GetFiles(@"C:\Users\Youcode\Desktop\java");

                            if (Directory.GetFileSystemEntries(@"C:\Users\Youcode\Desktop\java").Length == 0)
                            {
                                txt_output.Items.Add("There is no file to delate ! ");
                            }
                            else
                            {
                                foreach (string file in files)
                                {
                                    File.Delete(file);

                                }

                                txt_output.Items.Add($" The folder is empty ! \n");
                            }

                            

                            txt_analyse.Text = "Nettoyage terminé !";
                            btn_analyse.Visibility = Visibility.Hidden;
                            btn_back__db.Visibility = Visibility.Visible;
                            btn_vue.IsEnabled = true;
                            btn_analyse1.IsEnabled = true;
                            btn_histo1.IsEnabled = true;
                            btn_option.IsEnabled = true;
                            txt_info.Visibility = Visibility.Visible;
                            bar_progress.Visibility = Visibility.Hidden;

                            System.Windows.Forms.MessageBox.Show("Nettoyage términé !");
                        }
                        //lbl_CountDownTimer.Text = i.ToString();


                    });
                }
            });


            /*string path = @"C:\Windows\TestBrief3";
            FileInfo fi1 = new FileInfo(path);

          fi1.Delete();
            
            txt_output.Items.Add("The files has been delated");*/
        }




        //Bouton analyser 2 //////////////////////////////////////////////////////////
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Commencer l'analyse ?");
            txt_analyse.Text = "Analyse en cours";
            btn_vue.IsEnabled = false;
            btn_analyse1.IsEnabled = false;
            btn_histo1.IsEnabled = false;
            btn_option.IsEnabled = false;
            txt_info.Visibility = Visibility.Hidden;
            btn_analyse.Content = "Analyse en cours";
            btn_analyse.IsEnabled = false;

            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;


            bar_progress.Visibility = Visibility.Visible;
            txt_output.Visibility = Visibility.Visible;

            Thread.Sleep(1000);
            bar_progress.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        bar_progress.Value = i;
                        if (i == 99)
                        {

                            // Make a reference to a directory.
                            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\java");

                            // Get a reference to each file in that directory.
                            FileInfo[] fiArr = di.GetFiles();

                            if (Directory.GetFileSystemEntries(@"C:\Users\Youcode\Desktop\java").Length == 0)
                            {
                                txt_output.Items.Add("There is no files ! ");
                            }
                            else
                            {
                                // Display the names and sizes of the files.
                                txt_output.Items.Add($"The directory {di.Name} contains the following files:\n");

                                foreach (FileInfo f in fiArr)
                                {
                                    txt_output.Items.Add($"The size of {f.Name}  is {f.Length} bytes. \n");
                                }

                            }


                            File.AppendAllText(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\History\Test.txt", "Analyse réalisée le : " + DateTime.Now.ToString() + Environment.NewLine);

                            //Close the file
                            //sw.Close();

                            txt_analyse.Text = "Analyse terminée !";
                            btn_analyse.Visibility = Visibility.Hidden;
                            btn_back__db.Visibility = Visibility.Visible;
                            btn_vue.IsEnabled = true;
                            btn_analyse1.IsEnabled = true;
                            btn_histo1.IsEnabled = true;
                            btn_option.IsEnabled = true;
                            txt_info.Visibility = Visibility.Visible;
                            bar_progress.Visibility = Visibility.Hidden;

                            System.Windows.Forms.MessageBox.Show("Analyse finie !");
                        }
                        //lbl_CountDownTimer.Text = i.ToString();


                    });
                }
            });

        }

        //Bouton retourner à l'accueil //////////////////////////////////////////
        private void btn_back__db_Click(object sender, RoutedEventArgs e)
        {
            txt_output.Visibility = Visibility.Hidden;

            img_nett_grid.Visibility = Visibility.Visible;
            img_histo_grid.Visibility = Visibility.Visible;
            img_maj_grid.Visibility = Visibility.Visible;
            btn_netoyerGrid.Visibility = Visibility.Visible;
            btn_histoGrid.Visibility = Visibility.Visible;
            btn_majGrid.Visibility = Visibility.Visible;
            btn_back__db.Visibility = Visibility.Hidden;
            btn_analyse.Visibility = Visibility.Visible;
            btn_analyse.Content = "Analyser";
            btn_analyse.IsEnabled = true;

            txt_output.Items.Clear();

        }


        //Bouton Historique 2 grid //////////////////////////////////////////
        private void btn_histoGrid_Click(object sender, RoutedEventArgs e)
        {
            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;

            txt_output.Visibility = Visibility.Visible;


            String line;

            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\History\Test.txt");

            //Read the first line of text
            line = sr.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                txt_output.Items.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();


        }

        private void btn_vue_Click(object sender, RoutedEventArgs e)
        {
            txt_output.Visibility = Visibility.Hidden;

            img_nett_grid.Visibility = Visibility.Visible;
            img_histo_grid.Visibility = Visibility.Visible;
            img_maj_grid.Visibility = Visibility.Visible;
            btn_netoyerGrid.Visibility = Visibility.Visible;
            btn_histoGrid.Visibility = Visibility.Visible;
            btn_majGrid.Visibility = Visibility.Visible;
            btn_back__db.Visibility = Visibility.Hidden;
            btn_analyse.Visibility = Visibility.Visible;
            btn_analyse.Content = "Analyser";
            btn_analyse.IsEnabled = true;

            txt_output.Items.Clear();

        }


        //Bouton historique 1 //////////////////////////////////////////
        private void btn_histo1_Click(object sender, RoutedEventArgs e)
        {
            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;

            txt_output.Visibility = Visibility.Visible;


            String line;

            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\History\Test.txt");

            //Read the first line of text
            line = sr.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                txt_output.Items.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
        }
    }
}
