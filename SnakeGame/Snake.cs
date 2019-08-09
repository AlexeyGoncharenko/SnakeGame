using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame {
    class Snake : Figure {
        Direction snakeDirection;
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
                Obj.Add(point);
            }
        }

        /// <summary>
        /// Manages snake's movement
        /// </summary>
        /// <param name="speedOfSnake">Initial value of snake speed [100..500]</param>
        public void Move(int speedOfSnake) {
            while(true) {
                Point tail = Obj.First();
                Point newHead = GetNextPoint(Obj.Last());
                Obj.Remove(tail);
                Obj.Add(newHead);
                tail.CleanUp();
                newHead.Draw();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        snakeDirection = Direction.LEFT;
                    }
                    else if (key.Key == ConsoleKey.RightArrow)
                    {
                        snakeDirection = Direction.RIGHT;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        snakeDirection = Direction.UP;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        snakeDirection = Direction.DOWN;
                    }
                }
                Thread.Sleep(speedOfSnake);
            }
        }

        public Point GetNextPoint(Point head) {
            Point newHead = new Point(head);
            newHead.Move(1, snakeDirection);
            return newHead;
        }
    }
}
