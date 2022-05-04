using ACS_Trend.Models;
using ACS_Trend.Models.Charts;
using System;
using System.Collections.Generic;


namespace ACS_Trend.Functions
{
    public interface IPoint_handler
    {
        public List<double[]> ParsePoints(List<Point> pointslist_SOURCE, string type);
        public List<double[]> GetPointsDataResult(List<PointStat> pointStats, List<double[]> pointsdataMovAverage);
    }

    public class IPoint_handler_ : IPoint_handler
    {
        // функции обработки точек
        public List<double[]> ParsePoints(List<Point> pointslist_SOURCE, string type)
        {
            List<double[]> pointsdataIN = new List<double[]>();
            List<double[]> pointsdataOUT = new List<double[]>();

            for (int point = 0; point < pointslist_SOURCE.Count; point++)
            {
                var date_time = Convert.ToDouble(pointslist_SOURCE[point].Date);
                var parameter_IN = Convert.ToDouble(pointslist_SOURCE[point].Parameter);
                var parameter_OUT = Convert.ToDouble(pointslist_SOURCE[point].ParameterOUT);

                var pointChartIN = new double[] { date_time, parameter_IN };
                var pointChartOUT = new double[] { date_time, parameter_OUT};

                pointsdataIN.Add(pointChartIN);
                pointsdataOUT.Add(pointChartOUT);
            }

            switch (type)
            {
                case "IN":
                    return pointsdataIN;
                case "OUT":
                    return pointsdataOUT;
            }

            return null;
        }

        public List<double[]> GetPointsDataResult(List<PointStat> pointStats, List<double[]> pointsdataMovAverage)
        {
            List<int> pointsFind = new List<int>();

            foreach (var item in pointStats)
            {
                pointsFind.Add(item.PointIndex);
            }

            List<double[]> pointsdataResult = new List<double[]>();

            for (int j = 0; j < pointsFind.Count; j++)
            {
                for (int i = 0; i < pointsdataMovAverage.Count; i++)
                {
                    if (pointsFind[j] == i && pointsFind[j] != 0)
                    {
                        pointsdataResult.Add(pointsdataMovAverage[i]);
                    }
                }
            }

            return pointsdataResult;
        }
    }
}
