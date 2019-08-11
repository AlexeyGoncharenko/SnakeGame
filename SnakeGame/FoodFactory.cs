using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    /// <summary>
    /// Manage the process of produce food
    /// </summary>
    class FoodFactory : Figure {
        private int widthGameArea;
        private int heightGameArea;
        private int amountOfFood;
        private char symbolOfFood;

        public FoodFactory(int width, int height, int amount, char symbol):base() {
            this.widthGameArea = width;
            this.heightGameArea = height;
            this.symbolOfFood = symbol;
            this.amountOfFood = amount;
        }

        public void MakeFood(){
            Random rnd = new Random();
            if (this.Points.Count > 0) this.Points.Clear();
            this.Points.Add(new Point(rnd.Next(1, widthGameArea - 1), rnd.Next(1, heightGameArea - 1), symbolOfFood));
            this.Draw();
        }

        public Point GetFood() {
            return this.Points.First();
        }

        public override void Draw() {
            Console.ForegroundColor = ConsoleColor.Green;
            base.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
