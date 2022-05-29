using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTools
{
    public class GpxTrack
    {
        public string Name { get; set; }
        public List<GpxTrackPoint> TrackPoints { get; set; }

        public List<double> SpeedsKph { get; set; }
        public List<double> SpeedsMph { get; set; }
        public double TotalDistanceMiles { get; set; }
        public double TotalDistanceKilometers { get; set; }
        public List<double> Slopes { get; set; }

        /// <summary>
        /// Returns the max speed achieved in a track in MPH.
        /// </summary>
        /// <returns>Returns the max speed during the track in MPH</returns>
        public double MaxSpeedMph()
        {
            var maxSpeed = SpeedsMph.Max();
            return maxSpeed;
        }
        /// <summary>
        /// Returns the max speed achieved in a track in KPH.
        /// </summary>
        /// <returns>Returns the max speed during the track in KPH</returns>
        public double MaxSpeedKph()
        {
            var maxSpeed = SpeedsKph.Max();
            return maxSpeed;
        }
        /// <summary>
        /// Returns the min speed achieved in a track in MPH.
        /// </summary>
        /// <returns>Returns the min speed during the track in MPH</returns>
        public double MinSpeedMph()
        {
            var maxSpeed = SpeedsMph.Min();
            return maxSpeed;
        }
        /// <summary>
        /// Returns the min speed achieved in a track in KPH.
        /// </summary>
        /// <returns>Returns the min speed during the track in KPH</returns>
        public double MinSpeedKph()
        {
            var maxSpeed = SpeedsKph.Min();
            return maxSpeed;
        }
        /// <summary>
        /// Returns the average speed achieved in a track in KPH.
        /// </summary>
        /// <returns>Returns the average speed during the track in KPH</returns>
        public double AverageSpeedKph()
        {
            var averageSpeed = SpeedsKph.Average();
            return averageSpeed;
        }
        /// <summary>
        /// Returns the average speed achieved in a track in MPH.
        /// </summary>
        /// <returns>Returns the average speed during the track in MPH</returns>
        public double AverageSpeedMph()
        {
            var averageSpeed = SpeedsMph.Average();
            return averageSpeed;
        }
        /// <summary>
        /// Returns the average grade between all slope points in a track in % of 100% grade.
        /// </summary>
        /// <returns>Returns the average grade between all slope points in a track in % of 100% grade.</returns>
        public double AverageGrade()
        {
            return Slopes.Average();
        }
        /// <summary>
        /// Returns the max grade in all slope points in a track in % of 100% grade.
        /// </summary>
        /// <returns>Returns the max grade in all slope points in a track in % of 100% grade.</returns>
        public double MaxGrade()
        {
            return Slopes.Max();
        }
        /// <summary>
        /// Returns the min grade in all slope points in a track in % of 100% grade.
        /// </summary>
        /// <returns>Returns the min grade in all slope points in a track in % of 100% grade.</returns>
        public double MinGrade()
        {
            return Slopes.Min();
        }
        /// <summary>
        /// Returns the total distance of the track segments in miles.
        /// </summary>
        /// <returns> Returns the total distance of the track segments in miles.</returns>
        public double DistanceMiles()
        {
            return TotalDistanceMiles;
        }
        /// <summary>
        /// Returns the total distance of the track segments in kilometers.
        /// </summary>
        /// <returns> Returns the total distance of the track segments in kilometers.</returns>
        public double DistanceKilometers()
        {
            return TotalDistanceKilometers;
        }
    }
}
