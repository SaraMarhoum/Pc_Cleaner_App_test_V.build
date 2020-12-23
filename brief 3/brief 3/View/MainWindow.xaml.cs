using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

            // Make a reference to a directory.
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\java");

            // Get a reference to each file in that directory.
            FileInfo[] fiArr = di.GetFiles();

            var size = di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);

            txt_espace_a_nett.Text = $"Espace à nettoyer :  {size} Bytes";
            txt_last_analyse.Text = "Dernière analyse   : " + DateTime.Now.ToString();
            txt_last_maj.Text = "Dernier nettoyage : " + DateTime.Now.ToString();

        }



        //Bouton analyser 1 /////////////////////////////////////////////////////
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt_output.Items.Clear();
            System.Windows.Forms.MessageBox.Show("Commencer l'analyse ?");
            txt_analyse.Text = "Analyse en cours";
            btn_vue.IsEnabled = false;
            btn_analyse1.IsEnabled = false;
            btn_histo1.IsEnabled = false;
            btn_option.IsEnabled = false;
            btn_analyse.Content = "Analyse en cours";
            btn_analyse.IsEnabled = false;

            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;
            btn_clear__histo.Visibility = Visibility.Hidden;
            txt_espace_a_nett.Visibility = Visibility.Hidden;
            txt_last_analyse.Visibility = Visibility.Hidden;
            txt_last_maj.Visibility = Visibility.Hidden;


            bar_progress.Visibility = Visibility.Visible;


            // Make a reference to a directory.
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\java");
            double fileCount = di.GetFiles().Count();
            bar_progress.Value = 0;
            bar_progress.Maximum = fileCount;



            Task.Run(() =>
            {
                
                for (int i = 0; i <= fileCount+1; i++)
                {
                    Thread.Sleep(500);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {

                        double percent = (i / bar_progress.Maximum) * 100;

                        txt_pb_percent.Visibility = Visibility.Visible;
                        txt_pb_percent.Text = percent.ToString() + "%";

                        bar_progress.Value = i;
                        if (i == (fileCount+1))
                        {
                            txt_output.Visibility = Visibility.Visible;

                            // Get a reference to each file in that directory.
                            FileInfo[] fiArr = di.GetFiles("*.*", SearchOption.AllDirectories);

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

                            var size = di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);
                            txt_espace_a_nett.Text = $"Espace à nettoyer :  {size} Bytes";

                            txt_last_analyse.Text = "Dernière analyse   : " + DateTime.Now.ToString();

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
                            bar_progress.Visibility = Visibility.Hidden;

                            txt_pb_percent.Visibility = Visibility.Hidden;

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
            txt_output.Items.Clear();
            System.Windows.Forms.MessageBox.Show("Commencer le nettoyage ?");

            txt_analyse.Text = "Nettoyage en cours";
            btn_vue.IsEnabled = false;
            btn_analyse1.IsEnabled = false;
            btn_histo1.IsEnabled = false;
            btn_option.IsEnabled = false;
            btn_analyse.Visibility = Visibility.Hidden;

            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;
            btn_clear__histo.Visibility = Visibility.Hidden;
            txt_espace_a_nett.Visibility = Visibility.Hidden;
            txt_last_analyse.Visibility = Visibility.Hidden;
            txt_last_maj.Visibility = Visibility.Hidden;


            bar_progress.Visibility = Visibility.Visible;


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
                            txt_output.Visibility = Visibility.Visible;

                            string[] files = Directory.GetFiles(@"C:\Users\Youcode\Desktop\java", "*.*", SearchOption.AllDirectories);

                            if (Directory.GetFileSystemEntries(@"C:\Users\Youcode\Desktop\java", "*.*", SearchOption.AllDirectories).Length == 0)
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

                            // Make a reference to a directory.
                            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\java");
                            // Get a reference to each file in that directory.
                            FileInfo[] fiArr = di.GetFiles();
                            var size = di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);

                            txt_espace_a_nett.Text = $"Espace à nettoyer :  {size} Bytes";

                            txt_last_maj.Text = "Dernier nettoyage : " + DateTime.Now.ToString();


                            File.AppendAllText(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\History\Test.txt", "Nettoyage réalisé le : " + DateTime.Now.ToString() + Environment.NewLine);


                            txt_analyse.Text = "Nettoyage terminé !";
                            btn_analyse.Visibility = Visibility.Hidden;
                            btn_back__db.Visibility = Visibility.Visible;
                            btn_vue.IsEnabled = true;
                            btn_analyse1.IsEnabled = true;
                            btn_histo1.IsEnabled = true;
                            btn_option.IsEnabled = true;
                            bar_progress.Visibility = Visibility.Hidden;

                            System.Windows.Forms.MessageBox.Show("Nettoyage términé !");
                        }
                        //lbl_CountDownTimer.Text = i.ToString();


                    });
                }
            });
        }




        //Bouton analyser 2 //////////////////////////////////////////////////////////
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txt_output.Items.Clear();
            System.Windows.Forms.MessageBox.Show("Commencer l'analyse ?");
            txt_analyse.Text = "Analyse en cours";
            btn_vue.IsEnabled = false;
            btn_analyse1.IsEnabled = false;
            btn_histo1.IsEnabled = false;
            btn_option.IsEnabled = false;
            btn_analyse.Content = "Analyse en cours";
            btn_analyse.IsEnabled = false;

            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;
            btn_clear__histo.Visibility = Visibility.Hidden;
            txt_espace_a_nett.Visibility = Visibility.Hidden;
            txt_last_analyse.Visibility = Visibility.Hidden;
            txt_last_maj.Visibility = Visibility.Hidden;


            bar_progress.Visibility = Visibility.Visible;


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
                            txt_output.Visibility = Visibility.Visible;
                            // Make a reference to a directory.
                            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\java");

                            // Get a reference to each file in that directory.
                            FileInfo[] fiArr = di.GetFiles("*.*", SearchOption.AllDirectories);

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

                            var size = di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);

                            txt_espace_a_nett.Text = $"Espace à nettoyer :  {size} Bytes";

                            txt_last_analyse.Text = "Dernière analyse   : " + DateTime.Now.ToString();

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
                            bar_progress.Visibility = Visibility.Hidden;

                            System.Windows.Forms.MessageBox.Show("Analyse finie !");
                        }
                        //lbl_CountDownTimer.Text = i.ToString();


                    });
                }
            });

        }



        //Bouton historique 1 //////////////////////////////////////////
        private void btn_histo1_Click(object sender, RoutedEventArgs e)
        {
            txt_output.Items.Clear();
            btn_netoyerGrid.Visibility = Visibility.Hidden;
            btn_histoGrid.Visibility = Visibility.Hidden;
            btn_majGrid.Visibility = Visibility.Hidden;
            img_nett_grid.Visibility = Visibility.Hidden;
            img_histo_grid.Visibility = Visibility.Hidden;
            img_maj_grid.Visibility = Visibility.Hidden;

            txt_output.Visibility = Visibility.Visible;
            btn_clear__histo.Visibility = Visibility.Visible;


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
            btn_clear__histo.Visibility = Visibility.Visible;


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
            btn_clear__histo.Visibility = Visibility.Hidden;
            btn_analyse.Content = "Analyser";
            btn_analyse.IsEnabled = true;

            txt_espace_a_nett.Visibility = Visibility.Visible;
            txt_last_analyse.Visibility = Visibility.Visible;
            txt_last_maj.Visibility = Visibility.Visible;

            txt_output.Items.Clear();

        }

        //Bouton Vue d'ensemble //////////////////////////////////////////
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
            btn_clear__histo.Visibility = Visibility.Hidden;
            btn_analyse.Content = "Analyser";
            btn_analyse.IsEnabled = true;

            txt_espace_a_nett.Visibility = Visibility.Visible;
            txt_last_analyse.Visibility = Visibility.Visible;
            txt_last_maj.Visibility = Visibility.Visible;

            txt_output.Items.Clear();

        }

        private void btn_clear__histo_Click(object sender, RoutedEventArgs e)
        {
            txt_output.Items.Clear();
            File.WriteAllText(@"C:\Users\Youcode\source\repos\brief 3\brief 3\bin\History\Test.txt", string.Empty);
        }

        private void btn_option_Click(object sender, RoutedEventArgs e)
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
            btn_clear__histo.Visibility = Visibility.Hidden;
            btn_analyse.Content = "Analyser";
            btn_analyse.IsEnabled = true;

            txt_output.Items.Clear();
        }

        private void btn_majGrid_Click(object sender, RoutedEventArgs e)
        {


            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("https://pastebin.com/sWt7jMj3").Contains("v0.0.0"))
                {
                    if (System.Windows.Forms.MessageBox.Show("Looks like there is an update! Do you want to download it?", "Demo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) using (var client = new WebClient())

                        {
                            Process.Start(@"C:\Users\Youcode\source\repos\brief 3\SmartScanUpdater\bin\Release\SmartScanUpdater.exe");
                            this.Close();
                        }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Vous êtes déjà à jour !");
                }
            }
            catch
            {

            }
        }
    }
}
