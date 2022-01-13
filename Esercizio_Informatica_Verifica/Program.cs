//Michele Gabrieli              4F              13/01/2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Informatica_Verifica
{
    class Treni         //classe padre Treni
    {
        //Attributi:
        public string codtreno;
        public string tipo;
        public string nome;
        public int costo;

        //costruttore:
        public Treni(string codtreno, string tipo, string nome, int costo)  
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.costo = costo;
        }
        //uso dei metodi virtual per poter usare il polimorfismo e sovrascrivere i metodi nelle classi figlie
        public virtual float CostoMezzi()   //metodo virtual di costomezzi che calcola il costo del mezzo
        {
            return costo;
        }

        public virtual float Prezzokm(float km) //metodo virtual di prezzokm che calcola il consumo del treno per tot km
        {
            return km;          
        }

        public virtual float Tot(float km)         //metodo virtual che calcola il costo totale dell'uso e del costo mezzo del treno
        {
            return km + costo;
        }
    }

    class Passeggeri : Treni        //classe Passeggeri, figlia della classe treni
    {
        //attributi:
        private int numpasseggeri;
        private string alimentazione;

        //Costruttore:
        public Passeggeri(string codtreno, string tipo, string nome, int costo, int numpasseggeri, string alimentazione) : base(codtreno, tipo, nome, costo)
        {
            this.numpasseggeri = numpasseggeri;
            this.alimentazione = alimentazione;
        }
        //metodi override di sovrascrittura
        public override float CostoMezzi()      //Costo mezzo del treno per passeggeri aumentato del 25%
        {
            return ((costo / 100) * 25) + costo;
        }

        public override float Prezzokm(float km)    //PrezzoKm del treno passeggeri per km è di 100 euro
        {
            return km * 100;
        }

        public override float Tot(float km)     //costo totale del mezzo è la somma del costo mezzo e prezzo al km
        {
            return (((costo / 100) * 25) + costo) + (km * 100);
        }

    }

    class Merci : Treni
    {
        //Attributi:
        private int numpasseggeri;
        private string alimentazione;

        //Costruttore:
        public Merci(string codtreno, string tipo, string nome, int costo, int numpasseggeri, string alimentazione) : base(codtreno, tipo, nome, costo)
        {
            this.numpasseggeri = numpasseggeri;
            this.alimentazione = alimentazione;
        }
        //metodi override di sovrascrittura
        public override float CostoMezzi()      //Costo mezzo del treno per passeggeri aumentato del 35%
        {
            return ((costo / 100) * 35) + costo;
        }

        public override float Prezzokm(float km)    //PrezzoKm del treno passeggeri per km è di 150 euro
        {
            return km * 150;
        }

        public override float Tot(float km)     //costo totale del mezzo è la somma del costo mezzo e prezzo al km
        {
            return (((costo / 100) * 35) + costo) + (km * 150);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //inizializzazione variabili nel main:
            int costo1;     
            int costo2;
            float km;

            //Prendo in input il costo del mezzo da tastiera
            Console.WriteLine("Inserisci il costo mezzo del treno Thomas: ");
            costo1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il costo mezzo del treno Thomas: ");
            costo2 = int.Parse(Console.ReadLine());

            //Inizializzo le classi e gli passo i seguenti valori
            Passeggeri p = new Passeggeri("codtreno", "nazionale", "Thomas", costo1, 100, "Elettrico");
            Merci m = new Merci("codtreno", "regionale", "Sam", costo2, 10, "Elettrico");

            //Comunico all'utente il costo del mezzo
            Console.WriteLine("\nCosto mezzo Thomas: {0}", p.CostoMezzi());
            Console.WriteLine("Costo mezzo Sam: {0}\n", m.CostoMezzi());

            //Prendo in input il numero di km effettuati dal treno
            Console.WriteLine("Quanti km ha percorso il treno?");
            km = float.Parse(Console.ReadLine());

            //comunico all'utente il consumo del mezzo e passo al metodo il numero dei km effettuati
            Console.WriteLine("Consumo mezzo Thomas: {0}", p.Prezzokm(km));
            Console.WriteLine("Consumo mezzo Sam: {0}\n", m.Prezzokm(km));

            //Comunico all'utente il costo totale del mezzo tra consumo e costo iniziale
            Console.WriteLine("Prezzo totale mezzo Thomas: {0}", p.Tot(km));
            Console.WriteLine("Prezzo totale mezzo Sam: {0}", m.Tot(km));

            Console.ReadLine();
        }
    }
}
