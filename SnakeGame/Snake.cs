using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame {
    class Snake : Figure {
        private Direction snakeDirection;
        /// <summary>
        /// Snake class
        /// </summary>
        /// <param name="tail">The start snake's position</param>
        /// <param name="length">The whole snake's length</param>
        /// <param name="direction">Where snake to go</param>
        public Snake(Point tail, int length, Direction direction):base() {
            snakeDirection = direction;
            Point point;
            for (int i = 0; i < length; i++) {
                point = new Point(tail);
                point.Move(i, direction);
                Points.Add(point);
            }
        }

        /// <summary>
        /// Manages snake's movement
        /// </summary>
        /// <param name="delayOfSnake">Initial value delay of snake [100..500]</param>
        public void Move(int delayOfSnake) {
            while(true) {
                Point tail = Points.First();
                Point newHead = GetNextPoint(Points.Last());
                Points.Add(newHead);                
                Points.Remove(tail);
                newHead.Draw();
                tail.Erase();
               
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow) {
                        snakeDirection = Direction.LEFT;
                    }
                    else if (key.Key == ConsoleKey.RightArrow) {
                        snakeDirection = Direction.RIGHT;
                    }
                    else if (key.Key == ConsoleKey.UpArrow) {
                        snakeDirection = Direction.UP;
                    }
                    else if (key.Key == ConsoleKey.DownArrow) {
                        snakeDirection = Direction.DOWN;
                    }
                }
                Thread.Sleep(delayOfSnake);
            }
        }

        public Point GetNextPoint(Point head) {
            Point newHead = new Point(head);
            newHead.Move(1, snakeDirection);
            return newHead;
        }
    }
}
