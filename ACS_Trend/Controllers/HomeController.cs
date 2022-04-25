using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Functions;
using ACS_Trend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ACS_Trend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var masterModel = new HomeIndexViewModel();

            // line chart DEFAULT
            IChartData chartData = new ChartData_();
            var lineChartData = chartData.GetLineChartData(null, null, null, null, null, false, null, null, null);

            masterModel.LineChartData_IN_Source = lineChartData;
            masterModel.LineChartData_IN_Aproxy = lineChartData;
            masterModel.LineChartData_IN_Tg = lineChartData;
            masterModel.LineChartData_IN_Result = lineChartData;

            masterModel.LineChartData_OUT_Source = lineChartData;            
            masterModel.LineChartData_OUT_Aproxy = lineChartData;            
            masterModel.LineChartData_OUT_Tg = lineChartData;
            masterModel.LineChartData_OUT_Result = lineChartData;

            //masterModel.K_Approxy_IN = 100;
            //masterModel.StartPoint_IN = 32; //1843;

            //masterModel.K_Approxy_OUT = 100;
            //masterModel.StartPoint_OUT = 32; //1843;

            return View(masterModel);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel masterModel, IFormFile file)
        {
            int kMovAver_IN = masterModel.K_Approxy_IN;
            int kMovAver_OUT = masterModel.K_Approxy_IN;

            int startpoint_IN = masterModel.StartPoint_IN;
            int startpoint_OUT = masterModel.StartPoint_OUT;

            // Зона ограничений поиска по точкам      
            double upperLimit_IN = masterModel.UpperLimit_IN;
            double lowerLimit_IN = masterModel.LowerLimit_IN;

            double upperLimit_OUT = masterModel.UpperLimit_OUT;
            double lowerLimit_OUT = masterModel.LowerLimit_OUT;

            int timeLimit_IN = masterModel.TimeLimit_IN;
            int timeLimit_OUT = masterModel.TimeLimit_OUT;


            if (masterModel.ProcessType == "Построить графики")
            {
                // точки графика lineChartDataINSource
                IImportData importData = new ImportData_();
                List<Point> pointslist_IN_SOURCE = importData.ImportPoints(file); 
                
                int pointscount = pointslist_IN_SOURCE.Count;

                List<double[]> pointsdata = new List<double[]>();

                for (int point = 0; point < pointscount; point++)
                {
                    var date_time = Convert.ToDouble(pointslist_IN_SOURCE[point].Date);
                    var parameter = Convert.ToDouble(pointslist_IN_SOURCE[point].Parameter);

                    var pointChart = new double[] { date_time, parameter };
                    pointsdata.Add(pointChart);
                }

                List<double[]> pointsdataOUT = new List<double[]>();

                for (int point = 0; point < pointscount; point++)
                {
                    var date_time = Convert.ToDouble(pointslist_IN_SOURCE[point].Date);
                    var parameter = Convert.ToDouble(pointslist_IN_SOURCE[point].ParameterOUT);

                    var pointChart = new double[] { date_time, parameter };
                    pointsdataOUT.Add(pointChart);
                }


                IMathFunc mathFunc = new MathFunc_();

                // обработка точек по диапазону ограничений
                List<double[]> limitpointsdata = new List<double[]>();
                int k = 0;

                for (int i = 0; i < pointsdata.Count; i++)
                {
                    if (pointsdata[i][1] > lowerLimit_IN && pointsdata[i][1] < upperLimit_IN)
                    {
                        limitpointsdata.Add(new double []{ k, pointsdata[i][1] });
                        k++;
                    }                        
                }

                List<double[]> limitpointsdataOUT = new List<double[]>();
                int s = 0;

                for (int i = 0; i < pointsdataOUT.Count; i++)
                {
                    if (pointsdataOUT[i][1] > lowerLimit_OUT && pointsdataOUT[i][1] < upperLimit_OUT)
                    {
                        limitpointsdataOUT.Add(new double[] { s, pointsdataOUT[i][1] });
                        s++;
                    }
                }

                // точки графиков
                List<double[]> pointsdataMovAverage = mathFunc.MovAverageList(limitpointsdata, kMovAver_IN); // pointsdata
                List<double[]> pointsdataTg = mathFunc.DerOfFuncList(pointsdataMovAverage);

                ChartZones chartZones = mathFunc.FindPointList(pointsdataMovAverage, pointsdataTg, startpoint_IN, upperLimit_IN, lowerLimit_IN, timeLimit_IN);
                List<int> pointsFind = chartZones.pointFindAll;
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

                List<double[]> pointsdataOUTMovAverage = mathFunc.MovAverageList(limitpointsdataOUT, kMovAver_OUT);
                List<double[]> pointsdataOUTTg = mathFunc.DerOfFuncList(pointsdataOUTMovAverage);

                ChartZones chartZones_OUT = mathFunc.FindPointList(pointsdataOUTMovAverage, pointsdataOUTTg, startpoint_OUT, upperLimit_OUT, lowerLimit_OUT, timeLimit_OUT);
                List<int> pointsFind_OUT = chartZones_OUT.pointFindAll;
                List<double[]> pointsdataResult_OUT = new List<double[]>();

                for (int j = 0; j < pointsFind_OUT.Count; j++)
                {
                    for (int i = 0; i < pointsdataOUTMovAverage.Count; i++)
                    {
                        if (pointsFind_OUT[j] == i && pointsFind_OUT[j] != 0)
                        {
                            pointsdataResult_OUT.Add(pointsdataOUTMovAverage[i]);
                        }
                    }
                }

                // графики
                string titleIN = "Тренд входной динамической характеристики теплоэнергетичеcкого оборудования";
                string parameterIN = "parameterIN";
                string seriesNameTP_IN = "Точки тренда входного сигнала";
                string seriesNameTPAver_IN = "Точки сглаженных значений тренда входного сигнала";
                string seriesNameTPTg_IN = "Точки производных графика трендов";
                string seriesNameFP_IN = "Точки найденные";

                string titleOUT = "Тренд выходной динамической характеристики теплоэнергетичеcкого оборудования";
                string parameterOUT = "parameterOUT";
                string seriesNameTP_OUT = "Точки тренда выходного сигнала";
                string seriesNameTPAver_OUT = "Точки сглаженных значений тренда выходного сигнала";
                string seriesNameTPTg_OUT = "Точки производных графика трендов";
                string seriesNameFP_OUT = "Точки найденные";

                string colorMain = "#4682B4"; //255, 99, 71
                string colorFind = "rgba(255,99,71,.5)";

                bool markerEnable = false;
                bool markerEnable2 = true;

                var plotlinesY_IN = new List<PlotLines> { new PlotLines("red", 4, 1), new PlotLines("red", 17, 1) };
                var plotlinesY_OUT = new List<PlotLines> { new PlotLines("red", 293, 1), new PlotLines("red", 950, 1) };

                // входной сигнал
                IChartData chartData = new ChartData_();

                masterModel.LineChartData_IN_Source = chartData.GetLineChartData(pointsdata, titleIN, parameterIN, seriesNameTP_IN, colorMain, markerEnable, null, null, plotlinesY_IN);
                masterModel.LineChartData_IN_Aproxy = chartData.GetLineChartData(pointsdataMovAverage, titleIN, parameterIN, seriesNameTPAver_IN, colorMain, markerEnable, chartZones.plotbands, chartZones.plotlines, plotlinesY_IN);
                masterModel.LineChartData_IN_Tg = chartData.GetLineChartData(pointsdataTg, titleIN, parameterIN, seriesNameTPTg_IN, colorMain, markerEnable, null, null, null);
                masterModel.LineChartData_IN_Result = chartData.GetLineChartData(pointsdataResult, titleIN, parameterIN, seriesNameFP_IN, colorFind, markerEnable2, null, null, null);

                // выходной сигнал
                masterModel.LineChartData_OUT_Source = chartData.GetLineChartData(pointsdataOUT, titleOUT, parameterOUT, seriesNameTP_OUT, colorMain, markerEnable, null, null, plotlinesY_OUT);
                masterModel.LineChartData_OUT_Aproxy = chartData.GetLineChartData(pointsdataOUTMovAverage, titleOUT, parameterOUT, seriesNameTPAver_OUT, colorMain, markerEnable, chartZones_OUT.plotbands, chartZones_OUT.plotlines, plotlinesY_OUT);
                masterModel.LineChartData_OUT_Tg = chartData.GetLineChartData(pointsdataOUTTg, titleOUT, parameterOUT, seriesNameTPTg_OUT, colorMain, markerEnable, null, null, null);
                masterModel.LineChartData_OUT_Result = chartData.GetLineChartData(pointsdataResult_OUT, titleOUT, parameterOUT, seriesNameFP_OUT, colorFind, markerEnable2, null, null, null);

                return View(masterModel);
            }

            //if (masterModel.ProcessType == "Сохранить результаты")
            //{
            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
