using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Task3.Fussball;

namespace Task3
{
    class Deserialization
    {
        public static void Run(F_Player[] rapid)
        {
            var spieler = rapid[0];

            // 1. serialize a single player to a JSON string
            //Console.WriteLine(JsonConvert.SerializeObject(spieler));

            // 2. ... with nicer formatting
            // Console.WriteLine(JsonConvert.SerializeObject(spieler, Formatting.Indented));

            // 3. serialize all items
            // ... include type, so we can deserialize sub-classes to interface type
            //var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            //Console.WriteLine(JsonConvert.SerializeObject(rapid, settings));

            // 4. store json string to file "rapid.json" on your Desktop

            //var text = JsonConvert.SerializeObject(rapid, settings);
            //var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //var filename = Path.Combine(desktop, "rapid.json");
            //File.WriteAllText(filename, text);



            // 5. deserialize items from "rapid.json"
            // ... and print

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var filename = Path.Combine(desktop, "rapid.json");

            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<F_Player[]>(textFromFile, settings);
            foreach (var x in itemsFromFile) Console.WriteLine($"Vorname: {x.VNAME} Nachname: {x.NNAME} Groesse: {x.P_GROESSE}");

        }
    }
}