using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Nyelv> nyelvek;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            string[] mezok = {
                tbNeve.Text,
                rbFordito.IsChecked == true ? "1" : "0",
                (cbNyelvcsalad.SelectedIndex + 1).ToString(),
                tbMegjelenes.Text,
                rbMagas.IsChecked == true ? "1" : "0",
                Convert.ToString(slNepszeruseg.Value)
            };

            string sor = String.Join(';', mezok);

            StreamWriter iro = new StreamWriter("nyelvek.txt", true);
            iro.WriteLine(sor);
            iro.Close();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl && tabControl.SelectedIndex == 1)
            {
                tbMegjelenesSzuro.Text = "";
                nyelvek = new List<Nyelv>();

                string[] sorok = File.ReadAllLines("nyelvek.txt");
                foreach (string sor in sorok)
                {
                    string[] mezok = sor.Split(';');

                    Nyelv nyelv = new Nyelv(
                        mezok[0],
                        mezok[1] == "1",
                        (Nyelvcsaladok)Int32.Parse(mezok[2]) - 1,
                        Int32.Parse(mezok[3]),
                        mezok[4] == "1",
                        Int32.Parse(mezok[5])
                    );
                    nyelvek.Add(nyelv);
                }
                dgNyelvek.ItemsSource = nyelvek;
            }
        }

        private void tbMegjelenesSzuro_TextChanged(object sender, TextChangedEventArgs e)
        {
            Szures();
        }

        private void cbNyelvcsaladSzuro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (nyelvek != null)
            {
                Szures();
            }
        }

        private void Szures() {

            int megjelenes = 0;
            bool megjelenesSzamE = Int32.TryParse(tbMegjelenesSzuro.Text, out megjelenes);
            dgNyelvek.ItemsSource = nyelvek.Where(
                x => (!megjelenesSzamE || x.MegjelenesEve == megjelenes) &&
                     (cbNyelvcsaladSzuro.SelectedIndex == 0 ||
                        x.Nyelvcsalad == (Nyelvcsaladok)cbNyelvcsaladSzuro.SelectedIndex - 1)
            );
        }
    }
}
