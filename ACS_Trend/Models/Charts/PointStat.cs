namespace ACS_Trend.Models.Charts
{
    public class PointStat
    {
        public PointStat(int pointIndex, double pointValue, bool isWP, bool isEndOfSteadyState)
        {
            PointIndex = pointIndex;
            PointValue = pointValue;
            IsWP = isWP;
            IsEndOfSteadyState = isEndOfSteadyState;
        }

        public int PointIndex { get; set; }
        public double PointValue { get; set; }
        public bool IsWP { get; set; }
        public bool IsEndOfSteadyState { get; set; }
    }
}
