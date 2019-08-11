using System;
using System.Collections.Generic;
using System.Linq;

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
           this.snakeDirection = direction;
            Point point;
            for (int i = 0; i < length; i++) {
                point = new Point(tail);
                point.Move(i, direction);
                this.Points.Add(point);
            }
        }

        /// <summary>
        /// Manage snake's movement
        /// </summary>
        public void Move() {
            Point tail = Points.First();
            Point newPosOfHead = GetNextPoint(Points.Last());
            Points.Add(newPosOfHead);                
            Points.Remove(tail);
            tail.Erase();
            newPosOfHead.Draw();
        }

        // get next positon of snake's head
        public Point GetNextPoint(Point head) {
            Point newPosOfHead = new Point(head);
            newPosOfHead.Move(1, snakeDirection);
            return newPosOfHead;
        }

        // observe what key was pressed
        public void KeyHandler(ConsoleKey key) {  
            if (key == ConsoleKey.LeftArrow) {
                snakeDirection = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow) {
                snakeDirection = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow) {
                snakeDirection = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow) {
                snakeDirection = Direction.DOWN;
            }
        }

        // check does the snake bite some food
        public bool Eat(Point food){
            Point nextPosOfHead = GetNextPoint(Points.Last());
            if(nextPosOfHead.IsHit(food)){
                food.Symbol = nextPosOfHead.Symbol;                
                Points.Add(food);
                this.Draw();
                return true;
            }else{
                return false;
            }
        }

        // check does the snake bite some obstacle
        public bool IsHitObstacle(List<Figure> obstacles) {
            Point nextPosOfHead = GetNextPoint(Points.Last());
            
            foreach (Figure figure in obstacles) {
                foreach (Point point in figure.Points) {
                    if (point.IsHit(nextPosOfHead)) 
                        return true;
                }
            }
            return false;
        }

        // check does the snake bite the tail
        public bool IsHitTail() {
            Point nextPosOfHead = GetNextPoint(this.Points.Last());
            foreach (Point point in this.Points) {
                if (point.IsHit(nextPosOfHead))
                    return true;
            }
            return false;
        }
    }
}
