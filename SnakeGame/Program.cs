using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Alexey Goncharenko
/// Date:   the 5th of August 2018
/// Title:  Snake - Console Game
/// Description: That's the game that originates the whole decades ago.
/// </summary>

namespace SnakeGame {
    class Program {
        private static int minNumberOfHorizontalLines = 3;
        private static int maxNumberOfHorizontalLines = 5;      
        private static int minLengthOfHorizontalLines = 3;
        private static int maxLengthOfHorizontalLines = 8;
        private static int minNumberOfVerticalLines = 5;
        private static int maxNumberOfVerticalLines = 8;
        private static int minLengthOfVerticalLines = 3;
        private static int maxLengthOfVerticalLines = 8;
        private static int maxX = 10;
        private static int maxY = 10;
        private static int areaHeight = 25;
        private static int areaWidth = 80;

        private static Random rnd = new Random();

        public static void Main(string[] args) {
            // Set size of active game area;
            System.Console.SetWindowSize(areaWidth, areaHeight);
            System.Console.SetBufferSize(areaWidth, areaHeight);

            // Draw bounding game area
            List<Figure> boundaries = new List<Figure>();
            boundaries.Add(new HorizontalLine(0, 0, areaWidth - 1));
            boundaries.Add(new HorizontalLine(0, areaHeight - 1, areaWidth - 1));
            boundaries.Add(new VerticalLine(0, 0, areaHeight - 1));
            boundaries.Add(new VerticalLine(areaWidth - 2, 0, areaHeight - 1));
            foreach (Figure figure in boundaries) figure.Draw();

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
            Console.Read();
        }      
    }
}
