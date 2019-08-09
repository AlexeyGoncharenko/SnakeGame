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
            CreateObstacles();
            // create snake
            Snake snake = new Snake(new Point(40, 14, '*'), 5, Direction.RIGHT);
            snake.Draw();
            snake.Move(300);
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
        
        /// <summary>
        /// Create obstacles
        /// </summary>
        public static void CreateObstacles(){
            int minNumberOfHorizontalLines = 3;
            int maxNumberOfHorizontalLines = 5;
            int minLengthOfHorizontalLines = 3;
            int maxLengthOfHorizontalLines = 8;
            int minNumberOfVerticalLines = 5;
            int maxNumberOfVerticalLines = 8;
            int minLengthOfVerticalLines = 3;
            int maxLengthOfVerticalLines = 8;
            int maxX = 10;
            int maxY = 10;
            Random rnd = new Random();
            List<HorizontalLine> horizontalLines = new List<HorizontalLine>();
            List<VerticalLine> verticalLines = new List<VerticalLine>();

            // Draw horizontal and vertical lines in the active game's area
            int numberOfHorizontalLines = rnd.Next(minNumberOfHorizontalLines, maxNumberOfHorizontalLines + 1);
            int numberOfVerticalLines = rnd.Next(minNumberOfVerticalLines, maxNumberOfVerticalLines + 1);

            for (int i = 0; i < numberOfHorizontalLines; i++) {
                horizontalLines.Add(new HorizontalLine(rnd.Next(maxX), rnd.Next(maxY), rnd.Next(minLengthOfHorizontalLines, maxLengthOfHorizontalLines + 1)));
            }

            for (int i = 0; i < numberOfVerticalLines; i++) {
                verticalLines.Add(new VerticalLine(rnd.Next(maxX), rnd.Next(maxY), rnd.Next(minLengthOfVerticalLines, maxLengthOfVerticalLines + 1)));
            }

            foreach (HorizontalLine line in horizontalLines) line.Draw();
            foreach (VerticalLine line in verticalLines) line.Draw();
        }
    }
}
