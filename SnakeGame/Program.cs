using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Author: Alexey Goncharenko (github: @AlexeyGoncharenko)
/// Date:   the 5th of August 2018
/// Title:  Console Game: Snake
/// Description: That's the game that originates the whole decades ago.
/// </summary>

namespace SnakeGame {
    class Program {
        private const int WIDTH = 80;
        private const int HEIGHT= 25;

        public static void Main(string[] args) {
            // set size and draw boundaries of an active game area 
            // create obstacles
            ObstacleFactory obstacles = new ObstacleFactory(WIDTH, HEIGHT, 15, '#');
            obstacles.MakeObstacles();           
            
            // create food for the snake
            FoodFactory food = new FoodFactory(WIDTH, HEIGHT, 1, '$');
            food.MakeFood();

            // create the snake
            Snake snake = new Snake(new Point(40, 14, '@'), 5, Direction.RIGHT);
            snake.Draw();         
             
            // checking eating food and colliding in obstacles 
            while (true) {                
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.KeyHandler(key.Key);
                }              
                if (snake.IsHitObstacle(obstacles.GetObstacles()) || snake.IsHitTail()) {
                    GameOver();
                    break;
                }
                else if (snake.Eat(food.GetFood())) {
                    food.MakeFood();
                }
                else {
                    snake.Move();
                }  
                Thread.Sleep(100);
            }
        }

        // draw message in the end of the game
        public static void GameOver() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("-===GAME OVER===-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
