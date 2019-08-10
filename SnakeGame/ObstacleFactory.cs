using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    /// <summary>
    /// Manages the process of produce obstacles on the game's area
    /// </summary>
    class ObstacleFactory {
        private int widthGameArea;
        private int heightGameArea;
        private int amountObstacles;
        private char symbolOfObstacle;

        public ObstacleFactory(int width, int height, int amount, char symbol) {
            this.widthGameArea = width;
            this.heightGameArea = height;
            this.amountObstacles = amount;
            this.symbolOfObstacle = symbol;
        }
        
        public List<Figure> MakeObstacles() {
            // Draw obstacles in the active game's area
            Random rnd = new Random();
            List<Figure> obstacles = new List<Figure>();
            int amount = rnd.Next(1, amountObstacles + 1);
            for (int i = 0; i < amount ; i++) {
                if (rnd.Next() % 2 == 0)
                    obstacles.Add(new HorizontalLine(rnd.Next(1, widthGameArea - 10), rnd.Next(1, heightGameArea), rnd.Next(5, 10)));
                else
                    obstacles.Add(new VerticalLine(rnd.Next(1, widthGameArea - 1), rnd.Next(1, heightGameArea - 10), rnd.Next(5, 10)));
            }
            foreach (Figure obj in obstacles) obj.Draw();
            return obstacles;
        }
    }
}
