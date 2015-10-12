using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class CollisionBox
    {
        private Vector2 velocity;
        public Vector2 Velocity{ get {return velocity; } set{velocity = value; }}
        private Vector2 acceleration;
        public Vector2 Acceleration{get {return acceleration;} set{acceleration = value;}}
        private Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }
        private float x;
        public float X { get{return position.X;} set{position.X = value;} }
        private float y;
        public float Y { get { return position.Y; } set { position.Y = value; } }
        private int width;
        public int Width { get { return width; } set { width = value; } }
        private int height;
        public int Height { get { return height; } set { height = value; } }
        private Point min;
        public Point Min { get { return min; } }

        public int Min_X { get { return min.X; } }
        public int Min_Y { get { return min.Y; } }
        private Point max;
        public Point Max { get { return max; } }
        public int Max_X { get { return max.X; } }
        public int Max_Y { get { return max.Y; } }
        

        private List<Point> cells;
        public List<Point> Cells { get { return cells; } set { cells = value; } }
        private float c1;
        private float c2;
        private float c3;
        private float c4;
        public CollisionBox(float x, float y, int width, int height)
        {
            this.x = x;
            this.y = y;
            position.X = x;
            position.Y = y;
            this.width = width;
            this.height = height;
            this.velocity = Vector2.Zero;
            acceleration = Vector2.Zero;
            min.X = (int)Position.X;
            min.Y = (int)Position.Y;
            max.X = (int)Position.X + width;
            max.Y = (int)Position.Y + height;
            cells = new List<Point>();
            OccupyingCells();
            
        }
        public void Physics(Vector2 position, Vector2 velocity, Vector2 acceleration){
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
            min.X = (int)Position.X;
            min.Y = (int)Position.Y;
            max.X = (int)Position.X + width;
            max.Y = (int)Position.Y + height ;
            OccupyingCells();
        }

        private void OccupyingCells()
        {          
            cells.Clear();
             c1 = position.X / 16;
             c2 = position.Y / 16;
             c3 = (position.X + width)/ 16;
             c4 = (position.Y + height) / 16;
            Cells.Add(new Point((int)c1, (int)c2));
            Cells.Add(new Point((int)c1, (int)c4));
            Cells.Add(new Point((int)c3, (int)c4));
            Cells.Add(new Point((int)c3, (int)c2));
        }
     
   
}

}
