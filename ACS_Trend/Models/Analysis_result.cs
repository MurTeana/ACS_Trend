using ACS_Trend.Models.Charts;
using System.Collections.Generic;

namespace ACS_Trend.Models
{
    public class Analysis_result
    {
        public Analysis_result(List<PlotBands> plotbands, List<PlotLines> plotlines, List<PointStat> pointsStat, List<Dchar_Zone> dchar_Zones, List<int[]> pointState)
        {
            _Plotbands = plotbands;
            _Plotlines = plotlines;
            _PointsStat = pointsStat;
            _Dchar_Zones = dchar_Zones;
            _PointState = pointState;
        }
        public List<PlotBands> _Plotbands { get; set; }
        public List<PlotLines> _Plotlines { get; set; }
        public List<PointStat> _PointsStat { get; set; }
        public List<Dchar_Zone> _Dchar_Zones { get; set; }
        public List<int[]> _PointState { get; set; }
}
}
