using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biglietto_Museo
{
    public class Cliente : MainWindow
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        private List<Prenotazione> prenotazioni = new List<Prenotazione>();

        public Cliente(string username, string password)
        {
            Username = username;
            Password = password;

        }
        

        public List<Prenotazione> GetPrenotazione()
        {
            return prenotazioni;
        }
        public void Aggiungi_Prenotazione_Cliente(Prenotazione p)
        {
            prenotazioni.Add(p);
        }

        public void Rimuovi_Prenotazione(Prenotazione p)
        {
            prenotazioni.Remove(p);
        }
        public int Conta_Prenotazione()
        {
            int count = 0;
            for (int i = 0; i < prenotazioni.Count; i++)
            {
                count++;
            }
            return count;
        }
        public double Costo_Prenotazioni()
        {
            double costo = 0;
            for (int i = 0; i < prenotazioni.Count; i++)
            {
                costo = costo + prenotazioni[i].CostoPrenotazione();
            }
            return costo;
        }


        public string Stampa_Cliente()
        {
            return $"{Username}";
        }
        public int Conteggio_Prenotazione(string ora)
        {
            int count = 0;
            for (int i = 0; i < prenotazioni.Count; i++)
            {
                if (prenotazioni[i].Ora == ora)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
