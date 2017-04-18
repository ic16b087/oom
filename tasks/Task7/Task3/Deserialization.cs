using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Task7.Fussball;

namespace Task7
{
    class Deserialization
    {
        public static void Run(F_Player[] rapid)
        {
            var spieler = rapid[0];

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var filename = Path.Combine(desktop, "rapid.json");

            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<F_Player[]>(textFromFile, settings);
            foreach (var x in itemsFromFile) Console.WriteLine($"Vorname: {x.VNAME} Nachname: {x.NNAME} Groesse: {x.P_GROESSE}");

        }
    }
}