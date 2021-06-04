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

namespace Biglietto_Museo
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Cliente> Clienti = new List<Cliente>();
        public List<Prenotazione> Prenotazioni = new List<Prenotazione>();
        private string[] orario = new string[] { "18:30", "19:00", "19:30", "20:00", "20:30", "21:00" };
        public MainWindow()
        {
            InitializeComponent();

            foreach (string s in orario)
            {
                cmbOrario.Items.Add(s);
            }
        }

        private void btnAggiungi_Cliente_Click(object sender, RoutedEventArgs e)
        {

            //-----------------------------//

            if (txtUsername.Text == "")
            {
                MessageBox.Show("Inserire un username!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Inserire una password!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Cliente cliente = new Cliente(txtUsername.Text, txtPassword.Text);
                Clienti.Add(cliente);
                cmbSeleziona.Items.Add(cliente.Stampa_Cliente());
                cmbSelezionaCliente.Items.Add(cliente.Stampa_Cliente());
                lboStampa1.Items.Add(cliente.Stampa_Cliente());
                txtUsername.Text = "";
                txtPassword.Text = "";
            }


        }

        private void btnCancella_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                cmbSeleziona.Items.Clear();
                cmbSelezionaCliente.Items.Clear();
                cmbSelezionaOrario.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            
                int indice;
                if (cmbSelezionaCliente.SelectedIndex == -1)
                {
                    MessageBox.Show("Selezionare un cliente!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (dpData.SelectedDate == null)
                {
                    MessageBox.Show("Selezionare una data!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (cmbOrario.SelectedIndex == -1)
                {
                    MessageBox.Show("Selezionare un'Orario!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    indice = cmbSelezionaCliente.SelectedIndex;
                    Cliente cliente = Clienti[indice];
                    Prenotazione p = new Prenotazione(dpData.SelectedDate.Value, orario[cmbOrario.SelectedIndex], cliente);
                    cmbSelezionaOrario.Items.Add(orario[cmbOrario.SelectedIndex]);
                    cliente.Prenotazioni.Add(p);
                    Prenotazioni.Add(p);
                    lboStampa2.Items.Clear();
                    lboStampa2.Items.Add(p.Stampa());

                }
            
        }

        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbSelezionaCliente.SelectedIndex = -1;
            dpData.SelectedDate = null;
            cmbSelezionaOrario.SelectedIndex = -1;
            lboStampa1.Items.Clear();
            cmbSeleziona.SelectedIndex = -1;
            cmbOrario.SelectedIndex = -1;
            lboStampa2.Items.Clear();
        }
        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
    
}
    

