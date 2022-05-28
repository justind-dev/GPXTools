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
    }
}
