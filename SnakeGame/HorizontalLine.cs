using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    class HorizontalLine : Figure {        
        // construct new horizontal line
        public HorizontalLine(int x, int y, int length, char symbol):base() {
            for (int i = 0; i < length; i++) {
                Points.Add(new Point(x + i, y, symbol));
            }
        }

        public override void Draw() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
