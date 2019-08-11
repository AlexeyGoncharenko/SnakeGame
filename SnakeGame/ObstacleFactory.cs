using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    /// <summary>
    /// Manage the process of produce obstacles in the active game's area
    /// </summary>
    class ObstacleFactory {
        private int widthGameArea;
        private int heightGameArea;
        private int amountObstacles;
        private char symbolOfObstacle;
        private List<Figure> obstacles;

        /// <summary>
        /// Set size and draw boundaries & obstacles in the active game's area
        /// </summary>
        /// <param name="width">Width of an active game area</param>
        /// <param name="height">Height of an active game area</param>
        public ObstacleFactory(int width, int height, int amount, char symbol) {
            this.widthGameArea = width;
            this.heightGameArea = height;
            this.amountObstacles = amount;
            this.symbolOfObstacle = symbol;
            this.obstacles = new List<Figure>();
            System.Console.SetWindowSize(width, height);
            System.Console.SetBufferSize(width, height);
        }
 
        // Draw obstacles in the active game's area
        public void MakeObstacles() {
            Random rnd = new Random();            
            int amount = rnd.Next(1, amountObstacles + 1);
            for (int i = 0; i < amount ; i++) {
                if (rnd.Next() % 2 == 0)
                    obstacles.Add(new HorizontalLine(rnd.Next(1, widthGameArea - 10), rnd.Next(1, heightGameArea), rnd.Next(5, 10), symbolOfObstacle));
                else
                    obstacles.Add(new VerticalLine(rnd.Next(1, widthGameArea - 1), rnd.Next(1, heightGameArea - 10), rnd.Next(5, 10), symbolOfObstacle));
            }
            obstacles.Add(new HorizontalLine(0, 0, widthGameArea - 1, '*'));
            obstacles.Add(new HorizontalLine(0, heightGameArea - 1, widthGameArea- 1, '*'));
            obstacles.Add(new VerticalLine(0, 0, heightGameArea - 1, '*'));
            obstacles.Add(new VerticalLine(widthGameArea - 2, 0, heightGameArea - 1, '*'));
            foreach (Figure figure in obstacles) figure.Draw();
        }
        
        public List<Figure> GetObstacles() {
                return this.obstacles;
        }
    }
}
