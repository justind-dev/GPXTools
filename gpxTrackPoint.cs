using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTools
{
    public struct gpxTrackPoint
    {
        public string name;
        public double elevation;
        public double latitude , longitude;
        public DateTime time;
    }
}
