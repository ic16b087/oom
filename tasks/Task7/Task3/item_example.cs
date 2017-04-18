
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;
using System.Threading;
using Task7.Sportler;

namespace Task7
{
    public static class item_example
    {
        public static void Run()
        {
            var team = new List<Player>()
                    {
                        new Eishockey("Reichart", "Mario"),
                        new Eishockey("Oesterreicher", "Alex"),
                        new Eishockey("Focsa", "Eduard"),
                        new Eishockey("Focsa", "Ludwig"),
                        new Volleyball("Steiner", "Louis"),
                        new Volleyball("Focsa", "Hans"),
                        new Volleyball("Matuschewski", "Helen"),
                        new Volleyball("Foo", "Bar")

                    };


            var producer = new Subject<Player>(); //own producer

            producer.Subscribe(x => Console.WriteLine("Vorname: {0} Nachname: {1}  ", x.VNAME, x.NNAME));

            Console.WriteLine("");
            Console.WriteLine("-- Task 7 --");
            Console.WriteLine("Spieler deren Nachname mit Focsa beginnt:");



            var t = new Thread(() =>
            {
                var auswahl = from x in team
                              where x.NNAME.StartsWith("Focsa")
                              select x;

              foreach (var spieler in auswahl)
                {
                    Console.WriteLine($"Info: sent {spieler.NNAME} {spieler.VNAME}");
                    producer.OnNext(spieler); // push value spieler to subscribers
                                  
                } 
            });
            t.Start();
        }
    }
}
