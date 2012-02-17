using System;

namespace MathObjectsLib.Angles
{
    /// <summary>
    /// Abstract angle class containing angle value
    /// </summary>
    public abstract class Angle
    {
        /// <summary>
        /// The PI mathematical constant (aka 3.14)
        /// </summary>
        protected const double PI = Math.PI; //this is for easy reading

        private double value;

        /// <summary>
        /// Creates angle with a value = 0
        /// </summary>
        public Angle()
            : this(0) 
        {
        }

        /// <summary>
        /// Creates angle
        /// </summary>
        /// <param name="value">Angle value</param>
        public Angle(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or Sets the angle value
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
        /// Returns a string containing angle's value
        /// </summary>
        /// <returns>Angle's value</returns>
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
