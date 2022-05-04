using ACS_Trend.Models.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_Trend.Models
{
    public class LineChartViewModel
    {
        public LineChartViewModel()
        {
            title = new Title();
            subtitle = new Subtitle();
            xAxis = new XAxis();
            yAxis = new YAxis();
            plotOptions = new PlotOptions();
            series = new List<Series>();
        }
        public Title title { get; set; }
        public Subtitle subtitle { get; set; }
        public XAxis xAxis { get; set; }
        public YAxis yAxis { get; set; }
        public PlotOptions plotOptions { get; set; }
        public List<Series> series { get; set; }
    }

    // Title
    public class Title
    {
        public Title()
        {
        }
        public string text { get; set; }
    }

    // Subtitle
    public class Subtitle
    {
        public Subtitle()
        {
            text = "";
        }
        public string text { get; set; }
    }

    // XAxis
    public class XAxis
    {
        public XAxis()
        {
            title = new Title();
            plotBands = new List<PlotBands>();
        }

        public Title title { get; set; }
        public List<string> categories { get; set; }
        public bool crosshair { get; set; }
        public List<PlotBands> plotBands { get; set; }
        public List<PlotLines> plotLines { get; set; }
    }

    public class PlotBands
    {
        public PlotBands(string _color, double _from, double _to)
        {
            color = _color;
            from = _from;
            to = _to;
        }
        public string color { get; set; }
        public double from { get; set; }
        public double to { get; set; }
    }
    public class PlotLines
    {
        public PlotLines(string _color, double _value, int _width)
        {
            color = _color;
            value = _value;
            width = _width;
        }
        public string color { get; set; }
        public double value { get; set; }
        public int width { get; set; }
    }

    // YAxis
    public class YAxis
    {
        public YAxis()
        {
            title = new Title();
        }
        public Title title { get; set; }
        public List<string> categories { get; set; }
        public List<PlotLines> plotLines { get; set; }
        public bool crosshair { get; set; }
    }

    // Series
    public class Series
    {
        public Series()
        {
            //name = _name;
            //color = _color;
            data = new List<double[]>();
            marker = new Marker();
        }
        public string name { get; set; }
        public string color { get; set; }
        public string dashStyle { get; set; }  // тип линии     
        public string type { get; set; } // тип графика??
        public List<double[]> data { get; set; } = new List<double[]>();
        public Marker marker { get; set; }
    }

    // Series: Marker
    public class Marker
    {
        public bool enabled { get; set; }
        public int radius { get; set; }
    }

    // PlotOptions
    public class PlotOptions
    {
        public PlotOptions()
        {
            line = new Line();
            series = new SeriesPT();
        }       
        public Line line { get; set; }
        public SeriesPT series { get; set; }
    }

    public class SeriesPT
    {
        public SeriesPT()
        {
            marker = new Marker();
        }
        public int lineWidth { get; set; }
        public Marker marker { get; set; }
        public bool allowPointSelect { get; set; }
    }

    // PlotOptions: Line
    public class Line
    {
        public Line()
        {
            dataLabels = new DataLabels();
        }
        public DataLabels dataLabels { get; set; }
        public bool enableMouseTracking { get; set; }
    }

    // PlotOptions: DataLabels
    public class DataLabels
    {
        public DataLabels()
        {
        }
        public bool enabled { get; set; }
    }
}
