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
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            string neve = tbNeve.Text;

            int fordito = 0;
            if (rbFordito.IsChecked == true)
            {
                fordito = 1;
            }

            int nyelvcsalad = cbNyelvcsalad.SelectedIndex + 1;

            string megjelenesEve = tbMegjelenes.Text;

            int magasSzintu = 0;
            if (rbMagas.IsChecked == true)
            {
                magasSzintu = 1;
            }

            int nepszeruseg = Convert.ToInt32(slNepszeruseg.Value);


            string sor = $"{neve};{fordito};{nyelvcsalad};{megjelenesEve};{magasSzintu};{nepszeruseg}";

            StreamWriter iro = new StreamWriter("nyelvek.txt", true);
            iro.WriteLine(sor);
            iro.Close();
        }
    }
}
