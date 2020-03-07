using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTheParcel.Api
{
    /// <summary>
    /// Parcel dimensions in mm
    /// </summary>
    public class ParcelDimensions
    {
        /// <summary>
        /// Parcel length in mm
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Parcel breadth in mm
        /// </summary>
        public int Breadth { get; set; }

        /// <summary>
        /// Parcel height in mm
        /// </summary>
        public int Height { get; set; }
    }

    public static class ParcelDimensionsExtensions
    {
        /// <summary>
        /// Volume of a parcel
        /// </summary>
        /// <param name="d"></param>
        /// <returns>Volume of a parcel in mm^3</returns>
        public static int Volume(this ParcelDimensions d)
        {
            return d.Length * d.Breadth * d.Height;
        }

        /// <summary>
        /// Rotates the parcel in a way that Length becomes the longest side and Height becomes the shortest side
        /// </summary>
        /// <param name="d"></param>
        /// <returns>Parcel dimensions after rotation</returns>
        public static ParcelDimensions Rotate(this ParcelDimensions d)
        {
            var rotated = new List<int>() { 
                d.Length,
                d.Breadth,
                d.Height
            }
            .OrderByDescending(x => x)
            .ToList();

            return new ParcelDimensions()
            {
                Length = rotated[0],
                Breadth = rotated[1],
                Height = rotated[2]
            };
        }

        /// <summary>
        /// Checks if a parcel with given dimensions fits into a container
        /// </summary>
        /// <param name="parcel"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static bool FitsInto(this ParcelDimensions parcel, ParcelDimensions container)
        {
            return parcel.Length <= container.Length
                && parcel.Breadth <= container.Breadth
                && parcel.Height <= container.Height;
        }
    }
}
