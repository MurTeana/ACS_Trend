
namespace ACS_Trend.Models.Charts
{
    public class Dchar_Zone
    {
        public Dchar_Zone(int leftPoint, int middlePoint, int rightPoint, bool stateZone)
        {
            LeftPoint = leftPoint;
            MiddlePoint = middlePoint;
            RightPoint = rightPoint;
            StateZone = stateZone;
        }

        public int LeftPoint { get; set; }
        public int MiddlePoint { get; set; }
        public int RightPoint { get; set; }
        public bool StateZone { get; set; }
    }
}
