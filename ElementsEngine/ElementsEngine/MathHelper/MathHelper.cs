using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsEngine.MathHelper
{
    public static class MathHelper
    {
        /// <summary>
        /// Clamp method
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// <returns>Clamped value</returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value > max)
            {
                return max;
            }
            if (value < min)
            {
                return min;
            }
            return value;
        }

        /// <summary>
        /// Clamp method
        /// </summary>
        /// <param name="value">Value to clamp</param>
        /// <param name="min">Minimum Value</param>
        /// <param name="max">Maximum Value</param>
        /// <returns>Clamped value</returns>
        public static float Clamp(float value, float min, float max)
        {
            if (value > max)
            {
                return max;
            }
            if (value < min)
            {
                return min;
            }
            return value;
        }
    }
}
