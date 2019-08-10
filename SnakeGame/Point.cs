using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// base game's graphical primitive
namespace SnakeGame {
    class Point {
        private int x;
        private int y;
        private char symbol;

        public Point() {
            this.x = 0;
            this.y = 0;
            this.symbol = '*';
        }
        
        public Point(int x, int y, char symbol) {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
        }

        public Point(Point p) {
            this.x = p.x;
            this.y = p.y;
            this.symbol = p.symbol;
        }

        // direction of point movement
        public void Move(int offset, Direction direction) {
            if(direction == Direction.LEFT){
                this.x -= offset;
            }
            else if (direction == Direction.RIGHT)
            {
                this.x += offset;
            }
            else if (direction == Direction.UP)
            {
                this.y -= offset;
            }
            else if (direction == Direction.DOWN)
            {
                this.y += offset;
            }
        }

        // just draw point
        public void Draw() {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.symbol);
        }

        // just cleanup point from game's area
        public void CleanUp() {
            this.symbol = ' ';
            this.Draw();
        }
    }
}
