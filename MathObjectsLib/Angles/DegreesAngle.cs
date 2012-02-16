namespace MathObjectsLib.Angles
{
    /// <summary>
    /// A class witch contains an angle in Degrees
    /// </summary>
    sealed class DegreesAngle : Angle
    {
        /// <summary>
        /// Creates angle with a value = 0
        /// </summary>
        public DegreesAngle()
            : base()
        {
        }

        /// <summary>
        /// Creates angle in degrees
        /// </summary>
        /// <param name="value">Angle in radians</param>
        public DegreesAngle(double value)
            : base(value)
        {
        }

        /// <summary>
        /// Explictly(with a cast) converts angle from degrees to radians
        /// </summary>
        /// <param name="degrees">DegreesAngle object containing the angle in degrees</param>
        /// <returns>RadiansAngle object with angle in radians</returns>
        public static explicit operator RadiansAngle(DegreesAngle degrees)
        {
            RadiansAngle result;
            double value = (PI / 180) * degrees.Value;
            result = new RadiansAngle(value);
            return result;
        }

        /// <summary>
        /// Inplictly(without a cast) converts an angle to double
        /// </summary>
        /// <param name="angle">DegreesAngle object</param>
        /// <returns>Double value of the angle in degrees</returns>
        public static implicit operator double(DegreesAngle angle)
        {
            return angle.Value;
        }

        /// <summary>
        /// Inplictly(without a cast) creates an angle object form a specified angle
        /// </summary>
        /// <param name="value">Angle in degrees</param>
        /// <returns>DegreesAngle object</returns>
        public static implicit operator DegreesAngle(double value)
        {
            return new DegreesAngle(value);
        }
    }
}
