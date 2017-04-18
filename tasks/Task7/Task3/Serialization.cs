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
    class Serialization_Store
    {
        public static void Run(F_Player[] rapid)
        {
            var spieler = rapid[0];

           
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(rapid, settings));

            
            var text = JsonConvert.SerializeObject(rapid, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "rapid.json");
            File.WriteAllText(filename, text);   
        }
    }
}
