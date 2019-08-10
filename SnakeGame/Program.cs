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
        public static void Main(string[] args) {                 
            CreateArea(80, 25);      
            
            // create obstacles
            ObstacleFactory obstacles = new ObstacleFactory(80, 25, 15, '#');
            List<Figure> listOfObstacles = obstacles.MakeObstacles();           
            
            // create food for snake
            FoodFactory food = new FoodFactory(80, 25, 15, '$');
            List<Point> listOfFood = food.MakeFood();

            // create snake
            Snake snake = new Snake(new Point(40, 14, '@'), 5, Direction.RIGHT);
            snake.Draw();
            snake.Move(100, listOfFood, listOfObstacles);

            while(true){
                if(listOfFood.Count() == 0) {
                    listOfFood = food.MakeFood();
                }
            }
        }

        /// <summary>
        /// Create game's area
        /// </summary>
        /// <param name="width">Width of active area</param>
        /// <param name="height">Height of active area</param>
        public static void CreateArea(int width, int height) {
            // Set size of active game area;
            System.Console.SetWindowSize(width, height);
            System.Console.SetBufferSize(width, height);

            // Draw bounding game's area
            List<Figure> boundaries = new List<Figure>();
            boundaries.Add(new HorizontalLine(0, 0, width - 1));
            boundaries.Add(new HorizontalLine(0, height - 1, width - 1));
            boundaries.Add(new VerticalLine(0, 0, height - 1));
            boundaries.Add(new VerticalLine(width - 2, 0, height - 1));
            foreach (Figure figure in boundaries) figure.Draw();
        }
    }
}
