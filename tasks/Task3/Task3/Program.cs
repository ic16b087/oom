using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Mersich David
//Fussball und Tennis -> Task2
//Sportler -> Task3

namespace Task3
{

    using Fussball;
    using Tennis;
    using Sportler;

    namespace Fussball
    {

        

        public class F_Player
        {

            //public fields
            //field sollten wenn moeglich private sein

            //private fields
            private decimal ABLOESE;
            private decimal GEHALT;
            private string NACHNAME;
            private string VORNAME;
            private decimal GROESSE;


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
            public decimal ALL_GEHALT
            {
                get
                {
                    return GEHALT;
                }
                set
                {
                    if (value < 0) throw new Exception("Gehalt darf nicht negativ sein.");
                    GEHALT = value;
                }
            }
            public string NNAME
            {
                get
                {
                    return NACHNAME;
                }
            }
            public string VNAME
            {
                get
                {
                    return VORNAME;
                }
            }
            public decimal P_GROESSE
            {
                get
                {
                    return GROESSE;
                }
                set
                {
                    if (value < 0) throw new Exception("Groesse darf nicht negativ sein.");
                    GROESSE = value;
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

            //private fields
            private decimal GEHALT_intern;
            private decimal GROESSE;
            private string NACHNAME;
            private string VORNAME;

            //public properties
            public string NNAME
            {
                get
                {
                    return NACHNAME;
                }
            }
            public string VNAME
            {
                get
                {
                    return VORNAME;
                }
            }
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
        public class T_Player_Jugend : T_Player
            {
                private decimal ALTER;

                public decimal P_ALTER
                {
                    get
                    {
                        return ALTER;
                    }
                    set
                    {
                        if (value < 0 || value > 18) throw new Exception("Alter passt nicht.");
                        ALTER = value;
                    }
                }


                public T_Player_Jugend(string nachname, string vorname, decimal groesse, decimal alter) : base(nachname, vorname, groesse)
                {

                    if (alter < 0 || alter > 18) throw new ArgumentOutOfRangeException("Alter passt nicht.");

                    ALTER = alter;
                }
            }
    }
    namespace Sportler
    {
        public interface Player
        {
            //Fragen wie das genau mit dem funktioniert
            string VNAME { get; }
            string NNAME { get; }
            void Print_FULLNAME();
        }
        class Eishockey : Player
        {

            private string NACHNAME;
            private string VORNAME;

            public string NNAME
            {
                get
                {
                    return NACHNAME;
                }
            }
            public string VNAME
            {
                get
                {
                    return VORNAME;
                }
            }

            public Eishockey(string nachname, string vorname)
            {
                if (string.IsNullOrWhiteSpace(nachname)) throw new ArgumentException("Nachname darf nicht leer sein.", nameof(nachname));
                if (string.IsNullOrWhiteSpace(vorname)) throw new ArgumentException("Vorname darf nicht leer sein.", nameof(vorname));

                NACHNAME = nachname;
                VORNAME = vorname;
            }

            public void Print_FULLNAME()
            {
                Console.WriteLine($"Nachname: {NNAME} Vorname: {VNAME}\n");
            }

        }
        class Volleyball : Player
            {

                private string NACHNAME;
                private string VORNAME;

                public string NNAME
                {
                    get
                    {
                        return NACHNAME;
                    }
                }
                public string VNAME
                {
                    get
                    {
                        return VORNAME;
                    }
                }

                public Volleyball(string nachname, string vorname)
                {
                    if (string.IsNullOrWhiteSpace(nachname)) throw new ArgumentException("Nachname darf nicht leer sein.", nameof(nachname));
                    if (string.IsNullOrWhiteSpace(vorname)) throw new ArgumentException("Vorname darf nicht leer sein.", nameof(vorname));

                    NACHNAME = nachname;
                    VORNAME = vorname;
                }

                public void Print_FULLNAME()
                {
                    Console.WriteLine($"Nachname: {NNAME} Vorname: {VNAME}\n");
                }
            }
    }

    class Program
    {

        static void Main(string[] args)
        {

            //Test Unnamed Method -> Wo sinnvoll einsetzen (also nicht in der main? Warum Unnamed? Fragen!!!
            Func<decimal, decimal, decimal> gehalt_monat;
            gehalt_monat = (a, b) => a * b; // das gleich wie -> gehalt_monat = (decimal a, decimal b) => { return a * b; };

 
            decimal eingabe;
            string test;

            try
            {
                F_Player Offensiv_1 = new F_Player("Ronaldo", "Christiano", 186);
                F_Player Defensiv_1 = new F_Player("Vidic", "Nemanja", 190);

                T_Player Tennis_1 = new T_Player("Thiem", "Dominik", 175);
                T_Player_Jugend Tennis_2 = new T_Player_Jugend("Federer", "Roger", 175, 15); //vererbte Klasse mit zusaetzlichem Field

                Offensiv_1.ALL_GEHALT = gehalt_monat(2000, 24);

                Console.WriteLine($"Vorname: {Offensiv_1.VNAME} Nachname: {Offensiv_1.NNAME} Groesse: {Offensiv_1.P_GROESSE} Gehalt: {Offensiv_1.ALL_GEHALT}");
                Console.WriteLine($"{Offensiv_1.NNAME} ist gewachsen. Geben Sie seine neue Groesse ein:");
                Offensiv_1.P_GROESSE = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine($"Vorname: {Offensiv_1.VNAME} Nachname: {Offensiv_1.NNAME} Groesse: {Offensiv_1.P_GROESSE}");
                Console.WriteLine($"Geben Sie die neue Abloesesumme fuer {Defensiv_1.NNAME} ein");
                eingabe = Convert.ToDecimal(Console.ReadLine());
                Offensiv_1.ABLOESESUMME = eingabe;
                Console.WriteLine($"Abloesesumme fuer {Defensiv_1.NNAME} betraegt mit Spielerberater-Aufschlag: {Offensiv_1.Aufschlag_Abloese()}");

                Console.WriteLine($"Vorname: {Tennis_2.VNAME} Nachname: {Tennis_2.NNAME} Groesse: {Tennis_2.Update_GROESSE} Alter: {Tennis_2.P_ALTER}");
                Console.WriteLine($"Vorname: {Tennis_1.VNAME} Nachname: {Tennis_1.NNAME} Groesse: {Tennis_1.Update_GROESSE}");
                Console.WriteLine($"{Tennis_1.NNAME} ist gewachsen. Um wie viel ist er gewachsen?");
                Tennis_1.Update_GROESSE = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"Vorname: {Tennis_1.VNAME} Nachname: {Tennis_1.NNAME} Groesse: {Tennis_1.Update_GROESSE}");
                Console.WriteLine($"Geben Sie die das echte Gehalt fuer {Tennis_1.NNAME} ein");
                eingabe = Convert.ToDecimal(Console.ReadLine());
                Tennis_1.GEHALT_oeffentlich = eingabe;
                Console.WriteLine($"{Tennis_1.NNAME} verdient offiziell nur: {Tennis_1.GEHALT()}");

                // Task 3

                Player x = new Eishockey("Mersich", "David");
                x.Print_FULLNAME();
                Player y = new Volleyball("Schrammel", "Dominik");
                y.Print_FULLNAME();

                test = y.NNAME;
                Console.WriteLine($"Test: Nochmals Nachname: {test}\n");


                //TASK 3.4

                Player[] array_1 = { new Eishockey("Reichart", "Mario"), new Volleyball("Kowalski", "Pawel"), new Volleyball("Pichler", "Rosamunde"), new Volleyball("Susane", "Reisinger") };

                for (var i = 0; i < array_1.Length; i++)
                {
                    array_1[i].Print_FULLNAME();
                }


            }
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e.Message);
            }

        }
    }
}
