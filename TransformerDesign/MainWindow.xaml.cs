using System;
using System.Collections.Generic;
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
using TransformerDesign.TransformerBase;

namespace TransformerDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ElectricalSteel electricalSteel;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                electricalSteel = new ElectricalSteel();
                electricalSteel.CoreLossNominal1550 = Convert.ToDouble(po15.Text);
                electricalSteel.CoreLossNominal1750 = Convert.ToDouble(po17.Text);
                p.Text = electricalSteel.GetCoreLossNominal(Convert.ToDouble(bt.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }

        }
    }
}
