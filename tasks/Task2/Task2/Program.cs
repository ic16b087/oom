using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task2
{

    using Fussball;
    using Tennis;


    namespace Fussball
    {
        
        public class F_Player
    {

            //public fields
        //nur fuer Lernzwecke sind diese fields public sonst sollten sie private sein
        public string NACHNAME { get; }
        public string VORNAME { get; }
        public decimal GROESSE { get; set; }


            //private fields
        private decimal ABLOESE;



        //public property
        public decimal ABLOESESUMME
        {
            get
            {
                return ABLOESE;
            }
            set 
            {
                if (value < 0) throw new Exception("ABLOESESUMME darf nicht negativ sein.");
               ABLOESE = value;
            }
        }
            //public method
        public decimal Aufschlag_Abloese()
        {
            return (ABLOESE + 100000);
        }

        //constructor
        public F_Player(string nachname, string vorname, decimal groesse)
        {
            if (string.IsNullOrWhiteSpace(nachname)) throw new ArgumentException("Nachname darf nicht leer sein.", nameof(nachname));
            if (string.IsNullOrWhiteSpace(vorname)) throw new ArgumentException("Vorname darf nicht leer sein.", nameof(vorname));
            if (groesse < 100) throw new ArgumentOutOfRangeException("Spieler ist zu klein.");
    

            NACHNAME = nachname;
            VORNAME = vorname;
            GROESSE = groesse;
            
        }
        }
    }
    namespace Tennis
    {

        public class T_Player
        {

            //public fields
            //nur fuer Lernzwecke sind diese fields public sonst sollten sie private sein
            public string NACHNAME { get; }
            public string VORNAME { get; }
            

            //private fields
            private decimal GEHALT_intern;
            private decimal GROESSE;

            //public properties
            public decimal GEHALT_oeffentlich
            {
                set
                {
                    if (value < 0) throw new Exception("Gehalt darf nicht negativ sein.");
                    GEHALT_intern = value;
                }
            }

            public decimal Update_GROESSE
            {
                get
                {
                    return GROESSE;
                }
                set
                {
                    if (value < 0) throw new Exception("kann net geschrumpft sein");
                    GROESSE = GROESSE + value;
                }
            }

            //public method
            public decimal GEHALT()
            {
                return (GEHALT_intern / 2);
            }


            //Constructor
            public T_Player(string nachname, string vorname, decimal groesse)
            {
                if (string.IsNullOrWhiteSpace(nachname)) throw new ArgumentException("Nachname darf nicht leer sein.", nameof(nachname));
                if (string.IsNullOrWhiteSpace(vorname)) throw new ArgumentException("Vorname darf nicht leer sein.", nameof(vorname));
                if (groesse < 100) throw new ArgumentOutOfRangeException("Spieler ist zu klein.");


                NACHNAME = nachname;
                VORNAME = vorname;
                GROESSE = groesse;

            }




        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            decimal eingabe;

            try
            {

                F_Player Offensiv_1 = new F_Player("Ronaldo", "Christiano", 186);
                F_Player Defensiv_1 = new F_Player("Vidic", "Nemanja", 190);

                T_Player Tennis_1 = new T_Player("Thiem", "Dominik", 175);

                Console.WriteLine($"Vorname: {Offensiv_1.VORNAME} Nachname: {Offensiv_1.NACHNAME} Groesse: {Offensiv_1.GROESSE}");
                Console.WriteLine($"{Offensiv_1.NACHNAME} ist gewachsen. Geben Sie seine neue Groesse ein:");
                Offensiv_1.GROESSE = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine($"Vorname: {Offensiv_1.VORNAME} Nachname: {Offensiv_1.NACHNAME} Groesse: {Offensiv_1.GROESSE}");
                Console.WriteLine($"Geben Sie die neue Abloesesumme fuer {Defensiv_1.NACHNAME} ein");
                eingabe = Convert.ToDecimal(Console.ReadLine());
                Offensiv_1.ABLOESESUMME = eingabe;
                Console.WriteLine($"Abloesesumme fuer {Defensiv_1.NACHNAME} betraegt mit Spielerberater-Aufschlag: {Offensiv_1.Aufschlag_Abloese()}");

                Console.WriteLine($"Vorname: {Tennis_1.VORNAME} Nachname: {Tennis_1.NACHNAME} Groesse: {Tennis_1.Update_GROESSE}");
                Console.WriteLine($"{Tennis_1.NACHNAME} ist gewachsen. Um wie viel ist er gewachsen?:");
                Tennis_1.Update_GROESSE = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"Vorname: {Tennis_1.VORNAME} Nachname: {Tennis_1.NACHNAME} Groesse: {Tennis_1.Update_GROESSE}");
                Console.WriteLine($"Geben Sie die das echte Gehalt fuer {Tennis_1.NACHNAME} ein");
                eingabe = Convert.ToDecimal(Console.ReadLine());
                Tennis_1.GEHALT_oeffentlich = eingabe;
                Console.WriteLine($"{Tennis_1.NACHNAME} verdient offiziell fuer die Medien: {Tennis_1.GEHALT()}");

            }
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e.Message);
            }

        }
    }
}
