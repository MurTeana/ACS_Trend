using ACS_Trend.Domain.Entities;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.Functions;
using ACS_Trend.Models;
using ACS_Trend.Models.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
            //БД
            ViewBag.Stations = new SelectList(_unitOfWork.Stations.GetAllStations(), "ID_Station", "Station_name");
            ViewBag.Units = new SelectList(_unitOfWork.Units.GetAllUnits(), "ID_Unit", "Unit_name");
            ViewBag.Trend_parameters = new SelectList(_unitOfWork.Trend_parameter_names.GetAllTrend_parameter_names(), "ID_Trend_parameter_name", "Trend_parameter_name_val");

            ViewBag.Control_objects = new SelectList(_unitOfWork.Control_objects.GetAllControl_objects(), "ID_Control_object", "Control_object_name");
            ViewBag.Signal_types = new SelectList(_unitOfWork.Signal_types.GetAllSignal_types(), "ID_Signal_type", "Signal_type_name");
            ViewBag.Regulators = new SelectList(_unitOfWork.Regulators.GetAllRegulators(), "ID_Regulator", "Regulator_name");

            var masterModel = new HomeIndexViewModel();

            // line chart DEFAULT
            var chartsParam_default = new List<LineChartData> { new ChartsParameters().LineChartData_Default };

            IChartData chartData = new ChartData_();

            masterModel.LineChartData_IN_Source = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Source_Result = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Aproxy = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Tg = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Result = chartData.GetLineChartData(chartsParam_default);

            masterModel.LineChartData_OUT_Source = chartData.GetLineChartData(chartsParam_default);         
            masterModel.LineChartData_OUT_Aproxy = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_OUT_Tg = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_OUT_Result = chartData.GetLineChartData(chartsParam_default);

            masterModel.LineChartData_TransCh = chartData.GetLineChartData(chartsParam_default);

            return View(masterModel);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel masterModel, IFormFile file)
        {
            //try
            //{

            // line chart DEFAULT
            var chartsParam_default = new List<LineChartData> { new ChartsParameters().LineChartData_Default };

            IChartData chartData = new ChartData_();

            masterModel.LineChartData_IN_Source = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Source_Result = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Aproxy = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Tg = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_IN_Result = chartData.GetLineChartData(chartsParam_default);

            masterModel.LineChartData_OUT_Source = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_OUT_Aproxy = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_OUT_Tg = chartData.GetLineChartData(chartsParam_default);
            masterModel.LineChartData_OUT_Result = chartData.GetLineChartData(chartsParam_default);

            masterModel.LineChartData_TransCh = chartData.GetLineChartData(chartsParam_default);

            //БД ViewBag
            ViewBag.Stations = new SelectList(_unitOfWork.Stations.GetAllStations(), "ID_Station", "Station_name");
            ViewBag.Units = new SelectList(_unitOfWork.Units.GetAllUnits(), "ID_Unit", "Unit_name");
            ViewBag.Trend_parameters = new SelectList(_unitOfWork.Trend_parameter_names.GetAllTrend_parameter_names(), "ID_Trend_parameter_name", "Trend_parameter_name_val");

            ViewBag.Control_objects = new SelectList(_unitOfWork.Control_objects.GetAllControl_objects(), "ID_Control_object", "Control_object_name");
            ViewBag.Signal_types = new SelectList(_unitOfWork.Signal_types.GetAllSignal_types(), "ID_Signal_type", "Signal_type_name");
            ViewBag.Regulators = new SelectList(_unitOfWork.Regulators.GetAllRegulators(), "ID_Regulator", "Regulator_name");
    

            if (masterModel.ProcessType == "Построить графики трендов") //&& (file != null))
            {
                if (file == null)
                {
                    //var chartsParam_default = new List<LineChartData> { new ChartsParameters().LineChartData_Default };

                    //IChartData chartData = new ChartData_();

                    //masterModel.LineChartData_IN_Source = chartData.GetLineChartData(chartsParam_default);
                    //masterModel.LineChartData_IN_Source_Result = chartData.GetLineChartData(chartsParam_default);
                    //masterModel.LineChartData_IN_Aproxy = chartData.GetLineChartData(chartsParam_default);
                    //masterModel.LineChartData_IN_Tg = chartData.GetLineChartData(chartsParam_default);
                    //masterModel.LineChartData_IN_Result = chartData.GetLineChartData(chartsParam_default);

                    //masterModel.LineChartData_OUT_Source = chartData.GetLineChartData(chartsParam_default);
                    //masterModel.LineChartData_OUT_Aproxy = chartData.GetLineChartData(chartsParam_default);
                    //masterModel.LineChartData_OUT_Tg = chartData.GetLineChartData(chartsParam_default);
                    //masterModel.LineChartData_OUT_Result = chartData.GetLineChartData(chartsParam_default);

                    //masterModel.LineChartData_TransCh = chartData.GetLineChartData(chartsParam_default);

                    ViewBag.Temp = "Файл не выбран! Для проведения анализа выберите  файл!";

                    return View(masterModel);
                    //throw new FileNotFoundException();
                }
                else
                {
                    // точки графика lineChartDataINSource
                    IImportData importData = new ImportData_();
                    List<Point> pointslist_SOURCE = importData.ImportPoints(file);

                    IPoint_handler point_Handler = new IPoint_handler_();

                    List<double[]> pointsdataIN = point_Handler.ParsePoints(pointslist_SOURCE, "IN");
                    List<double[]> pointsdataOUT = point_Handler.ParsePoints(pointslist_SOURCE, "OUT");

                    HttpContext.Session.SetString("PointsDataIN", JsonConvert.SerializeObject(pointsdataIN));
                    HttpContext.Session.SetString("PointsDataOUT", JsonConvert.SerializeObject(pointsdataOUT));

                    // графики
                    //IChartData chartData = new ChartData_();

                    //var chartsParam_default = new List<LineChartData> { new ChartsParameters().LineChartData_Default };

                    // параметры графиков входного сигнала
                    var chartsParam_IN_Source = new List<LineChartData> { new ChartsParameters().LineChartData_IN_Source };
                    chartsParam_IN_Source[0].pointsdata = pointsdataIN; //

                    //модели входного сигнала
                    masterModel.LineChartData_IN_Source = chartData.GetLineChartData(chartsParam_IN_Source);
                    masterModel.LineChartData_IN_Source_Result = chartData.GetLineChartData(chartsParam_default);
                    masterModel.LineChartData_IN_Aproxy = chartData.GetLineChartData(chartsParam_default);
                    masterModel.LineChartData_IN_Tg = chartData.GetLineChartData(chartsParam_default);
                    masterModel.LineChartData_IN_Result = chartData.GetLineChartData(chartsParam_default);

                    // параметры графиков выходного сигнала
                    var chartsParam_OUT_Source = new List<LineChartData> { new ChartsParameters().LineChartData_OUT_Source };
                    chartsParam_OUT_Source[0].pointsdata = pointsdataOUT;

                    //модели выходного сигнала
                    masterModel.LineChartData_OUT_Source = chartData.GetLineChartData(chartsParam_OUT_Source);
                    masterModel.LineChartData_OUT_Aproxy = chartData.GetLineChartData(chartsParam_default);
                    masterModel.LineChartData_OUT_Tg = chartData.GetLineChartData(chartsParam_default);
                    masterModel.LineChartData_OUT_Result = chartData.GetLineChartData(chartsParam_default);

                    masterModel.LineChartData_TransCh = chartData.GetLineChartData(chartsParam_default);

                    HttpContext.Session.SetString("MasterModel_1", JsonConvert.SerializeObject(masterModel));

                    return View(masterModel);
                }               
            }

            if (masterModel.ProcessType == "Выполнить анализ")
            {
                if (masterModel.LowerLimit_IN > masterModel.UpperLimit_IN)
                {
                    ModelState.AddModelError("LowerLimit_IN", "Нижнее ограничение не может быть больше верхнего ограничения");
                }

                if (masterModel.LowerLimit_OUT > masterModel.UpperLimit_OUT)
                {
                    ModelState.AddModelError("LowerLimit_OUT", "Нижнее ограничение не может быть больше верхнего ограничения");
                }

                if (ModelState.IsValid)
                {
                    // параметры анализа
                    int kMovAver_IN = (int)masterModel.K_Approxy_IN;
                    int kMovAver_OUT = (int)masterModel.K_Approxy_IN;

                    int startpoint = (int)masterModel.StartPoint;
                    double toleranceZone_K_IN = (double)masterModel.ToleranceZone_K_IN;
                    double toleranceZone_K_OUT = (double)masterModel.ToleranceZone_K_OUT;

                    // Зона ограничений поиска по точкам      
                    double upperLimit_IN = (double)masterModel.UpperLimit_IN;
                    double lowerLimit_IN = (double)masterModel.LowerLimit_IN;

                    double upperLimit_OUT = (double)masterModel.UpperLimit_OUT;
                    double lowerLimit_OUT = (double)masterModel.LowerLimit_OUT;

                    int timeLimit_IN = (int)masterModel.TimeLimit_IN;
                    int timeLimit_OUT = (int)masterModel.TimeLimit_OUT;

                    // точки графика lineChartDataINSource
                    var pointsdataIN = JsonConvert.DeserializeObject<List<double[]>>(HttpContext.Session.GetString("PointsDataIN"));
                    var pointsdataOUT = JsonConvert.DeserializeObject<List<double[]>>(HttpContext.Session.GetString("PointsDataOUT"));

                    // ТОЧКИ ГРАФИКОВ
                    IMathFunc mathFunc = new MathFunc_();

                    // IN
                    List<double[]> pointsdataMovAverage_IN = mathFunc.MovAverageList(pointsdataIN, kMovAver_IN);
                    List<double[]> pointsdataDerF_IN = mathFunc.DerOfFuncList(pointsdataMovAverage_IN);

                    // анализ точек входного сигнала
                    IPoint_handler point_Handler = new IPoint_handler_();

                    Analysis_result analysis_result_IN = mathFunc.FindPointList(pointsdataMovAverage_IN, pointsdataDerF_IN, startpoint, upperLimit_IN, lowerLimit_IN, timeLimit_IN, toleranceZone_K_IN, true);
                    HttpContext.Session.SetString("Analysis_result_IN", JsonConvert.SerializeObject(analysis_result_IN));
                    List<double[]> pointsdataResult = point_Handler.GetPointsDataResult(analysis_result_IN._PointsStat, pointsdataMovAverage_IN);

                    // OUT
                    List<double[]> pointsdataMovAverage_OUT = mathFunc.MovAverageList(pointsdataOUT, kMovAver_OUT);
                    List<double[]> pointsdataDerF_OUT = mathFunc.DerOfFuncList(pointsdataMovAverage_OUT);

                    // анализ точек выходного сигнала
                    Analysis_result analysis_result_OUT = mathFunc.FindPointList(pointsdataMovAverage_OUT, pointsdataDerF_OUT, startpoint, upperLimit_OUT, lowerLimit_OUT, timeLimit_OUT, toleranceZone_K_OUT, false);
                    HttpContext.Session.SetString("Analysis_result_OUT", JsonConvert.SerializeObject(analysis_result_OUT));
                    List<double[]> pointsdataResult_OUT = point_Handler.GetPointsDataResult(analysis_result_OUT._PointsStat, pointsdataMovAverage_OUT);

                    // зоны графика для получения переходных характеристик СМЕЩЕНИЕ
                    List<PointStat> pointStats = new List<PointStat>();
                    double k_Moving = (double)masterModel.K_Moving;

                    int kMovingPoints = Convert.ToInt32(kMovAver_IN * k_Moving);

                    foreach (var item in analysis_result_IN._PointsStat)
                    {
                        if (item.IsEndOfSteadyState == true)
                        {
                            pointStats.Add(new PointStat(item.PointIndex + kMovingPoints, item.PointValue, item.IsWP, item.IsEndOfSteadyState));
                        }
                        else
                        {
                            pointStats.Add(new PointStat(item.PointIndex, item.PointValue, item.IsWP, item.IsEndOfSteadyState));
                        }
                    }

                    List<Dchar_Zone> dchar_ZonesSource_Result = new List<Dchar_Zone>();

                    foreach (var item in analysis_result_IN._Dchar_Zones)
                    {
                        dchar_ZonesSource_Result.Add(new Dchar_Zone(item.LeftPoint + kMovingPoints, item.MiddlePoint, item.RightPoint + kMovingPoints, item.StateZone));
                    }

                    // получение переходных характеристик
                    List<List<double[]>> transCharacteristics = mathFunc.GetTransCh(pointsdataIN, pointsdataOUT, dchar_ZonesSource_Result);
                    HttpContext.Session.SetString("TransCharacteristics", JsonConvert.SerializeObject(transCharacteristics));

                    var chartsParam_TransCh = new List<LineChartData>();

                    int pch = 1;

                    foreach (var item in transCharacteristics)
                    {
                        var chartsParameters = new ChartsParameters().LineChartData_TransCh;
                        chartsParameters.pointsdata = item;
                        chartsParameters.seriesName = "Переходная характеристика - " + pch;
                        chartsParam_TransCh.Add(chartsParameters);

                        pch++;
                    }
              
                    // параметры графиков входного сигнала
                    //IChartData chartData = new ChartData_();

                    var chartsParam_IN_Source = new List<LineChartData> {
                        new ChartsParameters().LineChartData_IN_Source,
                        new ChartsParameters().LineChartData_IN_Result,
                    };
                    chartsParam_IN_Source[0].pointsdata = pointsdataIN;
                    chartsParam_IN_Source[1].pointsdata = point_Handler.GetPointsDataResult(pointStats, pointsdataIN);

                    var chartsParam_IN_MovAver = new List<LineChartData> { 
                        new ChartsParameters().LineChartData_IN_MovAver, 
                        new ChartsParameters().LineChartData_IN_Result
                        };

                    chartsParam_IN_MovAver[0].pointsdata = pointsdataMovAverage_IN;
                    chartsParam_IN_MovAver[0].plotBands = analysis_result_IN._Plotbands;
                    chartsParam_IN_MovAver[0].plotLinesX = analysis_result_IN._Plotlines;
                    chartsParam_IN_MovAver[0].plotLinesY = new List<PlotLines> { new PlotLines("red", upperLimit_IN, 1), new PlotLines("red", lowerLimit_IN, 1) };
                    chartsParam_IN_MovAver[1].pointsdata = pointsdataResult;

                    var chartsParam_IN_DerF = new List<LineChartData> { new ChartsParameters().LineChartData_IN_DerF };
                    chartsParam_IN_DerF[0].pointsdata = pointsdataDerF_IN;

                    //модели входного сигнала
                    masterModel.LineChartData_IN_Source = chartData.GetLineChartData(chartsParam_IN_Source);
                    masterModel.LineChartData_IN_Aproxy = chartData.GetLineChartData(chartsParam_IN_MovAver);
                    masterModel.LineChartData_IN_Tg = chartData.GetLineChartData(chartsParam_IN_DerF);

                    // параметры графиков выходного сигнала
                    var chartsParam_OUT_Source = new List<LineChartData> { 
                        new ChartsParameters().LineChartData_OUT_Source 
                    };
                    chartsParam_OUT_Source[0].pointsdata = pointsdataOUT;

                    var chartsParam_OUT_MovAver = new List<LineChartData> { 
                        new ChartsParameters().LineChartData_OUT_MovAver,
                        new ChartsParameters().LineChartData_OUT_Result
                    };

                    chartsParam_OUT_MovAver[0].pointsdata = pointsdataMovAverage_OUT;
                    chartsParam_OUT_MovAver[0].plotLinesY = new List<PlotLines> { new PlotLines("red", upperLimit_OUT, 1), new PlotLines("red", lowerLimit_OUT, 1) };
                    chartsParam_OUT_MovAver[1].pointsdata = pointsdataResult_OUT;

                    var chartsParam_OUT_DerF = new List<LineChartData> { new ChartsParameters().LineChartData_OUT_DerF };
                    chartsParam_OUT_DerF[0].pointsdata = pointsdataDerF_OUT;

                    //модели выходного сигнала
                    masterModel.LineChartData_OUT_Source = chartData.GetLineChartData(chartsParam_OUT_Source);
                    masterModel.LineChartData_OUT_Aproxy = chartData.GetLineChartData(chartsParam_OUT_MovAver);
                    masterModel.LineChartData_OUT_Tg = chartData.GetLineChartData(chartsParam_OUT_DerF);

                    masterModel.LineChartData_TransCh = chartData.GetLineChartData(chartsParam_TransCh);

                    HttpContext.Session.SetString("MasterModel", JsonConvert.SerializeObject(masterModel));           
                }

                return View(masterModel);
            }

            if (masterModel.ProcessType == "Сохранить результаты")
            {
                var masterModel_ = JsonConvert.DeserializeObject<HomeIndexViewModel>(HttpContext.Session.GetString("MasterModel"));

                Transient_characteristicPointViewModel transient_CharacteristicPointViewModel = new Transient_characteristicPointViewModel();

                transient_CharacteristicPointViewModel.pointsIN = JsonConvert.DeserializeObject<List<double[]>>(HttpContext.Session.GetString("PointsDataIN"));
                transient_CharacteristicPointViewModel.pointsOUT = JsonConvert.DeserializeObject<List<double[]>>(HttpContext.Session.GetString("PointsDataOUT"));
                transient_CharacteristicPointViewModel.trCharListpoints = JsonConvert.DeserializeObject<List<List<double[]>>> (HttpContext.Session.GetString("TransCharacteristics"));

                masterModel.Transient_characteristicPointViewModel_.TrendIN.T_ID_Signal_type = 1;
                masterModel.Transient_characteristicPointViewModel_.TrendOUT.T_ID_Signal_type = 2;

                transient_CharacteristicPointViewModel.TrendIN = masterModel.Transient_characteristicPointViewModel_.TrendIN;
                transient_CharacteristicPointViewModel.TrendOUT = masterModel.Transient_characteristicPointViewModel_.TrendOUT;

                if (ModelState.IsValid)
                {
                    _unitOfWork.Transient_characteristicPoints.AddNewListTransient_characteristicPoints(transient_CharacteristicPointViewModel);
                    ViewBag.Issuccess = "Data Added";
                }

                return View(masterModel_);
            }
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
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
