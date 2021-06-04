using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biglietto_Museo
{
    public class Prenotazione
    {
        private const double Prezzo = 20;
        private List<Prenotazione> prenotazioni = new List<Prenotazione>();
        public string Ora { get; set; }

        public DateTime Data { get; set; }
        public Cliente c { get; set; }

        public Prenotazione(DateTime data, string ora, Cliente cliente)
        {
            c = cliente;
            cliente.Aggiungi_Prenotazione_Cliente(this);
            this.Ora = ora;
            this.Data = data;

        }
        public void Aggiungi_Prenotazione(Prenotazione p)
        {
            prenotazioni.Remove(p);
        }

        public string Stampa()
        {
            return $"{c.Stampa_Cliente()} {Data.ToShortDateString()} {Ora} {CostoPrenotazione()}euro";
        }
        public double CostoPrenotazione()
        {
            double prezzo = 0;
            prezzo = Prezzo;
            return prezzo;
        }
    }
}
