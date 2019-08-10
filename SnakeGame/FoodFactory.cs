using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    /// <summary>
    /// Manages the process of produce food
    /// </summary>
    class FoodFactory {
        private int widthGameArea;
        private int heightGameArea;
        private int amountOfFood;
        private char symbolOfFood;
        private Figure food;

        public FoodFactory(int width, int height, int amount, char symbol) {
            this.widthGameArea = width;
            this.heightGameArea = height;
            this.symbolOfFood = symbol;
            this.amountOfFood = amount;
            this.food = new Figure();
        }

        public void MakeFood(){
            Random rnd = new Random();
            int numberOfFood = rnd.Next(5, amountOfFood + 1);
            for (int i = 0; i < numberOfFood; i++) {
                 this.food.Points.Add(new Point(rnd.Next(1, widthGameArea - 1), rnd.Next(1, heightGameArea - 1), symbolOfFood));
            }
            this.food.Draw();
        }

        public Figure GetFood(){
            return this.food;
        }
    }
}
