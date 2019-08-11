using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    // base game's graphical primitive
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

        public int X{
            set { this.x = value; }
            get { return this.x; }
        }

        public int Y {
            set { this.y = value; }
            get { return this.y; }
        }

        public char Symbol {
            set { this.symbol = value; }
            get { return this.symbol; }
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

        // check does the snake's head reach the object
        public bool IsHit(Point obj) {
            return (this.x == obj.x && this.y == obj.y);
        }

        // just draw point
        public void Draw() {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.symbol);
        }

        // just cleanup point from game's area
        public void Erase() {
            this.symbol = ' ';
            this.Draw();
        }
    }
}
