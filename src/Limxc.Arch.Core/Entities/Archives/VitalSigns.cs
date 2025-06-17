using System;
using Limxc.Arch.Core.Archives.Exceptions;

namespace Limxc.Arch.Core.Archives
{
    /// <summary>
    ///     人体体征
    /// </summary>
    public class VitalSigns
    {
        public VitalSigns(double height, double weight)
        {
            if ((height > 0 && height < 5) || height > 300)
                throw new HeightUnitError(height);
            Height = height;
            Weight = weight;
        }

        public VitalSigns() { }

        /// <summary>
        ///     cm
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        ///     kg
        /// </summary>
        public double Weight { get; set; }

        public double Bmi
        {
            get
            {
                if (Weight * Height == 0)
                    return 0;
                return Math.Round(
                    Weight * 10000 / (Height * Height),
                    1,
                    MidpointRounding.AwayFromZero
                );
            }
        }

        public DateTime UpdateDate { get; } = DateTime.Now;
    }
}
