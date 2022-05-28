using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTools
{
    public class gpxTrack
    {
        public string Name { get; set; }
        public List<gpxTrackPoint> TrackPoints { get; set; }
    }
}
