namespace MathObjectsLib.Angles
{
    /// <summary>
    /// A class witch contains an angle in Radians
    /// </summary>
    public sealed class RadiansAngle : Angle
    {
        /// <summary>
        /// Creates angle with a value = 0
        /// </summary>
        public RadiansAngle()
            : base()
        {
        }

        /// <summary>
        /// Creates angle in radians
        /// </summary>
        /// <param name="value">Angle in radians</param>
        public RadiansAngle(double value)
            : base(value)
        {
        }

        /// <summary>
        /// Explictly(with a cast) converts angle from radians to degrees
        /// </summary>
        /// <param name="radians">RadiansAngle object containing the angle in radians</param>
        /// <returns>DegreesAngle object with angle in degrees</returns>
        public static explicit operator DegreesAngle(RadiansAngle radians)
        {
            DegreesAngle result;
            double value = (180 / PI) * radians.Value;
            result = new DegreesAngle(value);
            return result;
        }

        /// <summary>
        /// Inplictly(without a cast) converts an angle to double
        /// </summary>
        /// <param name="angle">RadiansAngle object</param>
        /// <returns>Double value of the angle in radians</returns>
        public static implicit operator double(RadiansAngle radians)
        {
            return radians.Value;
        }

        /// <summary>
        /// Inplictly(without a cast) creates an angle object form a specified angle
        /// </summary>
        /// <param name="value">Angle in radians</param>
        /// <returns>RadiansAngle object</returns>
        public static implicit operator RadiansAngle(double value)
        {
            return new RadiansAngle(value);
        }
    }
}
