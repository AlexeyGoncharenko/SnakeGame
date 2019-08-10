using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    /// <summary>
    /// Manages the process of produce food
    /// </summary>
    class FoodFactory : Figure {
        private int widthGameArea;
        private int heightGameArea;
        private int amountOfFood;
        private char symbolOfFood;

        public FoodFactory(int width, int height, int amount, char symbol) :base() {
            this.widthGameArea = width;
            this.heightGameArea = height;
            this.symbolOfFood = symbol;
            this.amountOfFood = amount;
        }

        public List<Point> MakeFood(){
            Random rnd = new Random();
            int numberOfFood = rnd.Next(5, amountOfFood + 1);
            for (int i = 0; i < numberOfFood; i++) {
                Obj.Add(new Point(rnd.Next(1, widthGameArea - 1), rnd.Next(1, heightGameArea - 1), symbolOfFood));
            }
            this.Draw();
            return this.Obj;
        }
    }
}
