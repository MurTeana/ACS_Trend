using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_Trend.Models.ViewModels
{
    public class LineChartVM
    {
        public LineChartVM()
        {
            title = new Title();
            subtitle = new Subtitle();
            xAxis = new XAxis();
            yAxis = new YAxis();
            plotOptions = new PlotOptions();
            series = new Series();
        }
        public Title title { get; set; }
        public Subtitle subtitle { get; set; }
        public XAxis xAxis { get; set; }
        public YAxis yAxis { get; set; }
        public PlotOptions plotOptions { get; set; }
        public Series series { get; set; }
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
        }
        public Title title { get; set; }
        public List<string> categories { get; set; }
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
    }

    // Series
    public class Series
    {
        public Series()
        {
            data = new List<double[]>();
        }
        public string name { get; set; }
        public List<double[]> data { get; set; }
    }

    // PlotOptions
    public class PlotOptions
    {
        public PlotOptions()
        {
            line = new Line();
        }
        public Line line { get; set; }
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
