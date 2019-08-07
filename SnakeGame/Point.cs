using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// base game's graphical primitive
namespace SnakeGame {
    class Point {
        public int x;
        public int y;
        public char symbol;

        public Point() {
            this.x = 0;
            this.y = 0;
            this.symbol = '\0';
        }
        
        public Point(int x, int y, char symbol) {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }
       
        // just draw point
        public void Draw() {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }
}
