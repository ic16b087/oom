using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using static System.Console;

namespace Task7
{
    public static class PushExample
    {
        public static void Run()
        {
            var w = new Form() { Text = "Task 7 Example", Width = 400, Height = 400 };


            IObservable<Point> moves = Observable.FromEventPattern<MouseEventArgs>(w, "MouseMove").Select(x => x.EventArgs.Location);

            moves
                .Throttle(TimeSpan.FromSeconds(0.2))
                .DistinctUntilChanged()
                .Subscribe(e => WriteLine($"[Koordinaten] ({e.X}, {e.Y})"))
                ;

            Application.Run(w);
        }
    }
}
