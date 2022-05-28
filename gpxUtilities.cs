using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTools
{
    public class GpxUtilities
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
        public double GetDistanceBetweenTrackPointsKilometers(GpxTrackPoint trackPoint1, GpxTrackPoint trackPoint2)
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
        public double GetDistanceBetweenTrackPointsMiles(GpxTrackPoint trackPoint1, GpxTrackPoint trackPoint2)
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

        public double GetTrackTotalDistanceMiles(GpxTrack track)
        {
            GpxTrackPoint lastTrackPoint = track.TrackPoints[track.TrackPoints.Count - 1];
            var i = track.TrackPoints.Count - 1;
            var totalDistance = 0.00;
            while (i > 0)
            {
                var currentTrackPoint = track.TrackPoints[i];
                var distance = GetDistanceBetweenTrackPointsMiles(currentTrackPoint, lastTrackPoint);
                totalDistance += distance;
                lastTrackPoint = currentTrackPoint;
                i--;
            }
            return totalDistance;
        }
        public double GetTrackTotalDistanceKilometers(GpxTrack track)
        {
            GpxTrackPoint lastTrackPoint = track.TrackPoints[track.TrackPoints.Count - 1];
            var i = track.TrackPoints.Count - 1;
            var totalDistance = 0.00;
            while (i > 0)
            {
                var currentTrackPoint = track.TrackPoints[i];
                var distance = GetDistanceBetweenTrackPointsMiles(currentTrackPoint, lastTrackPoint);
                totalDistance += distance;
                lastTrackPoint = currentTrackPoint;
                i--;
            }
            return totalDistance;
        }

        public double GetSlopeBetweenTrackPoints(GpxTrackPoint trackPoint1, GpxTrackPoint trackPoint2)
        {
            var elevationChange = GetElevationChangeBetweenTrackPoints(trackPoint1, trackPoint2);
            var distance = GetDistanceBetweenTrackPointsMiles(trackPoint1, trackPoint2);
            var slope  = (elevationChange / distance) * 100;
            return slope;
        }

        public double GetElevationChangeBetweenTrackPoints(GpxTrackPoint trackPoint1, GpxTrackPoint trackPoint2)
        {
            var ElevationChange = trackPoint1.elevation - trackPoint2.elevation;
            return ElevationChange;
        }

        public double GetSpeedBetweenTrackPointsMph(GpxTrackPoint trackPoint1, GpxTrackPoint trackPoint2)
        {
            var distance = GetDistanceBetweenTrackPointsMiles(trackPoint1, trackPoint2);
            var time = (trackPoint1.time - trackPoint2.time).TotalHours;
            var speed = distance / time;
            return speed;
        }

        public double GetSpeedBetweenTrackPointsKph(GpxTrackPoint trackPoint1, GpxTrackPoint trackPoint2)
        {
            var distance = GetDistanceBetweenTrackPointsKilometers(trackPoint1, trackPoint2);
            var time = (trackPoint1.time - trackPoint2.time).TotalHours;
            var speed = distance / time;
            return speed;
        }
        /// The below are returning NaN at the moment. This needs debugged.
        public double GetTrackAverageSpeedMph(GpxTrack track)
        {
            GpxTrackPoint lastTrackPoint = track.TrackPoints[track.TrackPoints.Count - 1];
            var i = track.TrackPoints.Count - 1;
            List<double> speeds = new List<double>();
            while (i > 0)
            {
                var currentTrackPoint = track.TrackPoints[i];
                var speed = GetSpeedBetweenTrackPointsMph(currentTrackPoint, lastTrackPoint);
                speeds.Add(speed);
                lastTrackPoint = currentTrackPoint;
                i--;
            }
            
            return speeds.Average();
        }
        public double GetTrackAverageSpeedKph(GpxTrack track)
        {
            GpxTrackPoint lastTrackPoint = track.TrackPoints[track.TrackPoints.Count - 1];
            var i = track.TrackPoints.Count - 1;
            List<double> speeds = new List<double>();
            while (i > 0)
            {
                var currentTrackPoint = track.TrackPoints[i];
                var speed = GetSpeedBetweenTrackPointsKph(currentTrackPoint, lastTrackPoint);
                speeds.Add(speed);
                lastTrackPoint = currentTrackPoint;
                i--;
            }

            return speeds.Average();
        }
        ///

    }
}
