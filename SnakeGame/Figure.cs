using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame {
    // base class of geometric figures
    class Figure {
        private List<Point> points;
        
        public Figure() {
            points = new List<Point>();
        }

        // public feature for inherited classes
        public List<Point> Points {
            get { return points; }
            set { points = value; }
        }
        
        // just draw figure
        public virtual void Draw() {
            foreach (Point point in points) point.Draw();
        }
    }
}
