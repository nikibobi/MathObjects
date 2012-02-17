using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using MathObjectsLib.Angles;

namespace MathObjectsLib.Vectors
{
    public class Vector
    {
        private double value;
        private double angle; //in radians

        //private base constructor for all other ctors

        /// <summary>
        /// Creates a vector with Polar coordinates
        /// </summary>
        /// <param name="value">The lenght of the vector</param>
        /// <param name="angle">The angle(in radians) of the vector</param>
        private Vector(double value, double angle)
        {
            this.Value = value;
            this.Angle = angle;
        }

        /// <summary>
        /// Creates a zero vector (0,0)
        /// </summary>
        public Vector()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Creates a vector with Cartesian cooordinates
        /// </summary>
        /// <param name="pos">A point representing the coordinates (x and y) of the vector</param>
        public Vector(PointF pos)
            : this(Math.Sqrt(pos.X * pos.X + pos.Y * pos.Y), Math.Atan(pos.Y / pos.X))
        {
        }

        /// <summary>
        /// Creates a vector with Cartesian cooordinates
        /// </summary>
        /// <param name="x">The x component(coordinate) of the vector</param>
        /// <param name="y">The y component(coordinate) of the vector</param>
        public Vector(float x, float y)
            : this(new PointF(x, y))
        {
        }

        /// <summary>
        /// Creates a vector with Polar coordinates
        /// </summary>
        /// <param name="value">The lenght of the vector</param>
        /// <param name="angle">RadiansAngle object for the angle</param>
        public Vector(float value, RadiansAngle angle)
            : this(value, (float)angle)
        {

        }

        /// <summary>
        /// Creates a vector with Polar coordinates
        /// </summary>
        /// <param name="value">The lenght of the vector</param>
        /// <param name="angle">DegreesAngle object for the angle</param>
        public Vector(float value, DegreesAngle angle)
            : this(value, (RadiansAngle)angle)
        {

        }

        /// <summary>
        /// The lenght/magnitude/norm of the vector
        /// </summary>
        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
        /// <summary>
        /// Angle in Radians
        /// </summary>
        public double Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                this.angle = value;
            }
        }

        /// <summary>
        /// The X component(coordinate) of the vector
        /// </summary>
        public double X
        {
            get
            {
                return Value * Math.Cos(Angle); // x = r*cos(a)              
            }
            //set
            //{
            //    this.Value = value / Math.Cos(Angle); // r = x/cos(a)
            //}
        }
        /// <summary>
        /// The Y component(coordinate) of the vector
        /// </summary>
        public double Y
        {
            get
            {
                return Value * Math.Sin(Angle); // y = r*sin(a)              
            }
            //set
            //{
            //    this.Value = value / Math.Sin(Angle); // r = y/sin(a)
            //}
        }

        /// <summary>
        /// Gets a vector component (X or Y)
        /// </summary>
        /// <param name="component">index of the component</param>
        /// <returns>The component</returns>
        public double this[int component]
        {
            get
            {
                if (component == 0)
                {
                    return this.X;
                }
                else if (component == 1)
                {
                    return this.Y;
                }
                else
                {
                    throw new IndexOutOfRangeException("There is no vector value at " + component + "!");
                }
            }
        }

        /// <summary>
        /// Normalizes the vector
        /// </summary>
        public void Normalize()
        {
            this.Value = 1;
        }

        /// <summary>
        /// Return new normalize vector
        /// </summary>
        /// <returns>The normalized vector</returns>
        public Vector GetNormalized()
        {
            Vector result = this / this.Value;
            return result;
        }

        #region Draw method

        /// <summary>
        /// Draw an arrow representing the vector
        /// </summary>
        /// <param name="g">A graphics object to be used to draw the arrow</param>
        public void Draw(Graphics g)
        {
            Point location = new Point();
            Draw(g, location);
        }

        /// <summary>
        /// Draw an arrow representing the vector
        /// </summary>
        /// <param name="g">A graphics object to be used to draw the arrow</param>
        /// <param name="location">A point where to draw the beginong of the arrow</param>
        public void Draw(Graphics g, Point location)
        {
            Color color = Color.Black;
            Draw(g, location, color);
        }

        /// <summary>
        /// Draw an arrow representing the vector
        /// </summary>
        /// <param name="g">A graphics object to be used to draw the arrow</param>
        /// <param name="location">A point where to draw the beginong of the arrow</param>
        /// <param name="color">A color in witch the arrow will be drawn in</param>
        public void Draw(Graphics g, Point location, Color color)
        {
            using (Pen pen = new Pen(color))
            {
                pen.Width = 5f;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.ArrowAnchor;

                Draw(g, location, color, pen);
            }
        }

        /// <summary>
        /// Draw an arrow representing the vector
        /// </summary>
        /// <param name="g">A graphics object to be used to draw the arrow</param>
        /// <param name="location">A point where to draw the beginong of the arrow</param>
        /// <param name="color">A color in witch the arrow will be drawn in</param>
        /// <param name="pen">A pen used for draing the line representing the vector</param>
        public void Draw(Graphics g, Point location, Color color, Pen pen)
        {
            Vector start = new Vector(location);
            Vector end = start + this;

            PointF startPopint = new PointF((float)start.X, (float)start.Y);
            PointF endPoint = new PointF((float)end.X, (float)end.Y);

            g.DrawLine(pen, startPopint, endPoint);
        }

        #endregion

        #region Operators

        //vector product of the sum of 2 vectors
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            Vector result = Vector.Addition(vector1, vector2);
            return result;
        }

        //the oposite vector of this vector
        public static Vector operator -(Vector vector)
        {
            Vector result = new Vector(vector.Value, Math.PI + vector.Angle); // 180 + angle is the opposite angle
            return result;
        }

        //vector product of the subtraction of2 vectors
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            Vector result = vector1 + (-vector2);
            return result;
        }

        //scalar product of 2 vectors
        public static double operator *(Vector vector1, Vector vector2)
        {
            double angle = vector1.Angle - vector2.Angle;
            double result = vector1.Value * vector2.Value * Math.Cos(angle);
            return result;
        }

        //scalar multiply a vector
        public static Vector operator *(double number, Vector vector)
        {
            Vector result = Vector.ScalarMultiply(number, vector);
            return result;
        }

        //scalar multiply a vector (inverted order)
        public static Vector operator *(Vector vector, double number)
        {
            Vector result = Vector.ScalarMultiply(number, vector);
            return result;
        }

        public static Vector operator /(Vector vector, double number)
        {
            Vector result = Vector.ScalarMultiply(1.0 / number, vector);
            return result;
        }

        #endregion

        #region private static helper methods

        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="vector2">Second vector</param>
        /// <returns>The resulting vector from the addition</returns>
        private static Vector Addition(Vector vector1, Vector vector2)
        {
            double x = vector1.X + vector2.X;
            double y = vector1.Y + vector2.Y;
            double value = Math.Sqrt(x * x + y * y);
            double angle = Math.Atan2(y, x);
            Vector result = new Vector(value, angle);
            return result;
        }

        /// <summary>
        /// Scalar multiplies a vector by a real number
        /// </summary>
        /// <param name="number">Scale number</param>
        /// <param name="vector">The vector witch we scalarly multiply</param>
        /// <returns>Scaled vector</returns>
        private static Vector ScalarMultiply(double number, Vector vector)
        {
            double x = Math.Abs(number) * vector.X;
            double y = Math.Abs(number) * vector.Y;
            double value = Math.Sqrt(x * x + y * y);
            Vector result = new Vector(value, vector.angle);
            if (number < 0)
                return -result;
            else
                return result;
        }

        #endregion
    }
}
