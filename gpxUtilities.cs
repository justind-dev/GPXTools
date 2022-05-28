using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTools
{
    public class gpxUtilities
    {
        static double kilometersToMiles(double kilometers)
        {
            double miles = kilometers / 1.6;
            return miles;
        }

        static double toRadians(
       double angleIn10thofaDegree)
        {
            // Angle in 10th
            // of a degree
            return (angleIn10thofaDegree *
                           Math.PI) / 180;
        }
        public double GetDistanceKilometers(gpxTrackPoint trackPoint1, gpxTrackPoint trackPoint2)
        {

            // The math module contains
            // a function named toRadians
            // which converts from degrees
            // to radians.
            var lon1 = toRadians(trackPoint1.longitude);
            var lon2 = toRadians(trackPoint2.longitude);
            var lat1 = toRadians(trackPoint1.latitude);
            var lat2 = toRadians(trackPoint2.latitude);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in
            // kilometers. Use 3956
            // for miles
            double r = 6371;

            // calculate the result
            return (c * r);
        }
        public double GetDistanceMiles(gpxTrackPoint trackPoint1, gpxTrackPoint trackPoint2)
        {

            // The math module contains
            // a function named toRadians
            // which converts from degrees
            // to radians.
            var lon1 = toRadians(trackPoint1.longitude);
            var lon2 = toRadians(trackPoint2.longitude);
            var lat1 = toRadians(trackPoint1.latitude);
            var lat2 = toRadians(trackPoint2.latitude);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in
            // kilometers. Use 3956
            // for miles
            double r = 3956;

            // calculate the result
            return (c * r);
        }
    }
}
