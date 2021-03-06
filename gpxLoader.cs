using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GPXTools
{
    public class GpxLoader
    {
        /// <summary>
        /// Load the Xml document for parsing
        /// </summary>
        /// <param name="sFile">Fully qualified file name (local)</param>
        /// <returns>XDocument</returns>
        private XDocument GetGpxDoc(string sFile)
        {
            XDocument gpxDoc = XDocument.Load(sFile);
            return gpxDoc;
        }

        /// <summary>
        /// Load the namespace for a standard GPX document
        /// </summary>
        /// <returns></returns>
        private XNamespace GetGpxNameSpace()
        {
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            return gpx;
        }

        /// <summary>
        /// When passed a file, open it and parse all tracks
        /// and track segments from it.
        /// </summary>
        /// <param name="sFile">Fully qualified file name (local)</param>
        /// <returns>string containing line delimited waypoints from the
        /// file (for test)</returns>
        public List<GpxTrack> LoadGPXTracks(string sFile)
        {
            GpxUtilities utilities = new GpxUtilities();
            XDocument gpxDoc = GetGpxDoc(sFile);
            XNamespace gpx = GetGpxNameSpace();
            var tracks = from track in gpxDoc.Descendants(gpx + "trk")
                         select new
                         {
                             Name = track.Element(gpx + "name") != null ?
                            track.Element(gpx + "name").Value : null,
                             Segs = (
                                from trackpoint in track.Descendants(gpx + "trkpt")
                                select new
                                {
                                    Latitude = trackpoint.Attribute("lat").Value,
                                    Longitude = trackpoint.Attribute("lon").Value,
                                    Elevation = trackpoint.Element(gpx + "ele") != null ?
                                    trackpoint.Element(gpx + "ele").Value : null,
                                    Time = trackpoint.Element(gpx + "time") != null ?
                                    trackpoint.Element(gpx + "time").Value : null
                                }
                              )
                         };
            List<GpxTrack> gpxTracks = new List<GpxTrack>();
            
            foreach (var trk in tracks)
            {
                // Populate track data objects.
                GpxTrack newGpxTrack = new GpxTrack();
                newGpxTrack.TrackPoints = new List<GpxTrackPoint>();
                List<GpxTrackPoint> points = new List<GpxTrackPoint>();
                newGpxTrack.Name = trk.Name;

                foreach (var trkSeg in trk.Segs)
                {
                    // Populate detailed track segments
                    // in the object model here.

                    newGpxTrack.TrackPoints.Add(new GpxTrackPoint()
                    {
                        latitude = Double.Parse(trkSeg.Latitude),
                        longitude = Double.Parse(trkSeg.Longitude),
                        elevation = double.Parse(trkSeg.Elevation),
                        time = DateTime.Parse(trkSeg.Time)

                    });
                }
                newGpxTrack.TotalDistanceKilometers = utilities.GetTrackTotalDistanceKilometers(newGpxTrack);

                newGpxTrack.TotalDistanceMiles = utilities.GetTrackTotalDistanceMiles(newGpxTrack);

                newGpxTrack.SpeedsKph = utilities.GetTrackSpeedsKph(newGpxTrack);

                newGpxTrack.SpeedsMph = utilities.GetTrackSpeedsMph(newGpxTrack);

                newGpxTrack.Slopes = utilities.GetTrackSlopePoints(newGpxTrack);

                gpxTracks.Add(newGpxTrack);
            }
            return gpxTracks;
        }
    }
}
