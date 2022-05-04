using ACS_Trend.Domain.Entities;
using ACS_Trend.Models;
using ACS_Trend.Models.Charts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.Functions
{
    public interface IMathFunc
    {
        List<double[]> MovAverageList(List<double[]> pointsdata, int stepMovAv);
        List<double[]> DerOfFuncList(List<double[]> pointsdata);
        Analysis_result FindPointList(List<double[]> pointsY_av, List<double[]> pointsY_av_Tg, int startPoint, double upLimit, double lowLimit, double timeLimit, double toleranceZone_K, bool isIN);
        public List<Dchar_Zone> GetDchar_ZonesState(Analysis_result analysis_Result_IN, Analysis_result analysis_Result_OUT);
    }

    public class MathFunc_ : IMathFunc
    {
        // Скользящее среднее LIST
        public List<double[]> MovAverageList(List<double[]> pointsdata, int stepMovAv)
        {
            int countData = pointsdata.Count();
            double[] yAproxy = new double[countData];
            List<double[]> pointsdataOUT = new List<double[]>();
            double sumY = 0;

            for (int i = 0; i < (countData - stepMovAv); i++)
            {
                for (int k = 0; k < stepMovAv; k++)
                {
                    sumY = sumY + pointsdata[k + i][1];
                }
                yAproxy[i] = sumY / stepMovAv;

                var pointChart = new double[] { pointsdata[i][0], yAproxy[i] };
                pointsdataOUT.Add(pointChart);

                sumY = 0;
            }

            return pointsdataOUT;
        }

        // Производная функции LIST
        public List<double[]> DerOfFuncList(List<double[]> pointsdata)
        {
            int countData = pointsdata.Count;
            double[] tgalpha_ = new double[countData];
            List<double[]> pointsdataOUT = new List<double[]>();

            for (var i = 0; i < countData; i++)
            {
                if (i > 0)
                {
                    tgalpha_[i] = (pointsdata[i][1] - pointsdata[i - 1][1]);
                }
                else
                {
                    tgalpha_[i] = 0;
                }

                var pointChart = new double[] { pointsdata[i][0], tgalpha_[i] };
                pointsdataOUT.Add(pointChart);
            }
            return pointsdataOUT;
        }

         // Поиск точек LIST
        public Analysis_result FindPointList(List<double[]> pointsY_av, List<double[]> pointsY_av_Tg, int startPoint, double upLimit, double lowLimit, double timeLimit, double toleranceZone_K, bool isIN)
        {        
            int countParam = pointsY_av.Count;
            int i = startPoint; // Стартовая точка                      
                       
            int ind_FP = 0;

            List<int> pointFind1 = new List<int>();
            int pointFind_av = 0;
            List<int> pointFind2 = new List<int>();
            int pointFind_tg = 0;

            List<PointStat> pointStatistics = new List<PointStat>();
            List<Dchar_Zone> dchar_Zones = new List<Dchar_Zone>();
            List<int[]> pointState = new List<int[]>();

            double[] pointAver_ = new double[countParam];

            // добавляем стартовую точку в массив статистики по точкам
            //pointStatistics.Add(new PointStat(startPoint, pointsY_av[startPoint][1], false));

            // поиск максимального значения в диапазоне (производные)
            double maxABSVal = MaxABSVal(pointsY_av_Tg, startPoint);

            // параметры зоны нечувствительности (производные) - округление (количество знаков)
            //int roundVal = RoundVal(maxABSVal);
            int roundVal = 5;

            // Анализ точек тренда
            while (i < (countParam - 1)) // 
            {
                int qPoints = 2;

                // Анализ графика сглаженных значений
                double sumPoints = pointsY_av[i][1];
                double pointAver = pointsY_av[i][1];

                // параметры зоны нечувствительности
                double tolerance_kAproxy = pointsY_av[i][1] * toleranceZone_K; // 1-2 % от искомого значения

                while ((Math.Abs(pointsY_av[i][1] - pointAver) < tolerance_kAproxy) && i < (countParam - 1))
                {
                    sumPoints = pointsY_av[i][1] + sumPoints;
                    pointAver = sumPoints / qPoints;
                    pointAver_[qPoints - 2] = sumPoints;
                    qPoints++;

                    i++;
                }

                pointFind_av = i; // сдвиг назад на одну точку УБРАЛА

                pointFind1.Add(pointFind_av);
                pointFind_av = 0;

                double tolerance_tgY = Math.Round(maxABSVal * 0.01, roundVal); // 1% от максимума в диапазоне значений (абсолютное)

                // Анализ графика производных
                int qPoints2;
                qPoints2 = 0;

                while ((Math.Abs(pointsY_av_Tg[i][1]) > tolerance_tgY) && i < (countParam - 1))
                {
                    qPoints2++;
                    i++;
                }

                if (qPoints2 > 0)
                {
                    pointFind_tg = pointFind1[ind_FP] + qPoints2;
                }   

                pointFind2.Add(pointFind_tg); // сдвиг назад на одну точку УБРАЛА                
                pointFind_tg = 0;

                // проверка выхода точки из заданного интервала
                // проверка временного интервала
                if (pointFind1[ind_FP] != 0 && pointFind2[ind_FP] != 0)
                {
                    if (isIN == true)
                    {
                        // первая точка
                        if (ind_FP != 0 && (pointFind1[ind_FP] - pointFind2[ind_FP - 1]) < timeLimit)
                        {
                            pointStatistics.Last().IsWP = true;
                            pointStatistics.Add(new PointStat(pointFind1[ind_FP], pointsY_av[pointFind1[ind_FP]][1], true, true));

                            pointStatistics.Add(new PointStat(pointFind2[ind_FP], pointsY_av[pointFind2[ind_FP]][1], true, false)); //!!!
                        }
                        else if(pointsY_av[pointFind1[ind_FP]][1] > upLimit || pointsY_av[pointFind1[ind_FP]][1] < lowLimit)
                        {
                            pointStatistics.Add(new PointStat(pointFind1[ind_FP], pointsY_av[pointFind1[ind_FP]][1], true, true));
                        }
                        else
                        {
                            pointStatistics.Add(new PointStat(pointFind1[ind_FP], pointsY_av[pointFind1[ind_FP]][1], false, true));
                        }

                        // вторая точка
                        if (pointStatistics.Last().PointIndex != pointFind2[ind_FP])
                        {
                            if ((pointFind2[ind_FP] - pointFind1[ind_FP]) < timeLimit)
                            {
                                pointStatistics.Add(new PointStat(pointFind2[ind_FP], pointsY_av[pointFind2[ind_FP]][1], true, false));
                            }
                            else if (pointsY_av[pointFind2[ind_FP]][1] > upLimit || pointsY_av[pointFind2[ind_FP]][1] < lowLimit)
                            {
                                pointStatistics.Add(new PointStat(pointFind2[ind_FP], pointsY_av[pointFind2[ind_FP]][1], true, false));
                            }
                            else
                            {
                                pointStatistics.Add(new PointStat(pointFind2[ind_FP], pointsY_av[pointFind2[ind_FP]][1], false, false));
                            }
                        }
                    }
                    else
                    {
                        pointStatistics.Add(new PointStat(pointFind1[ind_FP], pointsY_av[pointFind1[ind_FP]][1], false, true));
                        pointStatistics.Add(new PointStat(pointFind2[ind_FP], pointsY_av[pointFind2[ind_FP]][1], false, false));
                    }
                }

                ind_FP++;
            }

            pointStatistics.Add(new PointStat(countParam - 1, pointsY_av[countParam - 1][1], false, false));

            // ChartZones
            List <PlotBands> plotBands = new List<PlotBands>();
            List <PlotLines> plotLines = new List<PlotLines>();

            int pf = 0;
            int leftLine;
            int middleLine;
            int rightLine;

            while (pf < pointStatistics.Count)
            {
                if (pointStatistics[pf].IsWP == true)
                {
                    leftLine = pointStatistics[pf - 1].PointIndex + 1;

                    if (pf < pointStatistics.Count - 1)
                    {
                        rightLine = pointStatistics[pf + 1].PointIndex + 1;
                    }
                    else
                    {
                        rightLine = pointStatistics[pf].PointIndex + 1;
                    }

                    plotBands.Add(new PlotBands("rgba(247, 176, 180, 1)", leftLine, rightLine));
                }

                if (pf < pointStatistics.Count - 2 && 
                    pointStatistics[pf].IsWP != true &&
                    pointStatistics[pf + 1].IsWP != true &&
                    pointStatistics[pf + 2].IsWP != true)
                {
                    leftLine = pointStatistics[pf].PointIndex + 1;
                    middleLine = pointStatistics[pf + 1].PointIndex + 1;
                    rightLine = pointStatistics[pf + 2].PointIndex + 1;

                    plotBands.Add(new PlotBands("rgba(107,201,91,.5)", leftLine, rightLine));

                    plotLines.Add(new PlotLines("grey", leftLine, 1));
                    plotLines.Add(new PlotLines("grey", rightLine, 1));

                    dchar_Zones.Add(new Dchar_Zone(leftLine - 1, middleLine - 1, rightLine - 1, false));

                    pf++;
                }
                //else if(pf < pointStatistics.Count - 2 &&
                //    pointStatistics[pf].IsWP != true &&
                //    pointStatistics[pf + 1].IsWP != true &&
                //    pointStatistics[pf + 2].IsWP != false)
                //{
                //    leftLine = pointStatistics[pf].PointIndex + 1;
                //    rightLine = pointStatistics[pf + 1].PointIndex + 1;

                //    plotBands.Add(new PlotBands("rgba(107,201,91,.5)", leftLine, rightLine));

                //    //dchar_Zones.Add(new Dchar_Zone(leftLine - 1, 0, rightLine - 1, false));
                //}

                pf++;
            }

            // признак нахождения на участке равновесия (0 - нет, 1 - да)
            int q = 0;
            int q2 = 0;


            while (q2 < dchar_Zones.Count())
            {
                while (q < pointsY_av.Count() && q <= dchar_Zones[q2].RightPoint)
                {
                    if (q >= dchar_Zones[q2].MiddlePoint)
                    {
                        pointState.Add(new int[]{ q, 1}); // точка лежит на линии равновесия
                    }
                    else
                    {
                        pointState.Add(new int[]{ q, 0}); // точка не лежит на линии равновесия
                    }

                    q++;
                }

                q2++;
            }

            Analysis_result analysis_result = new Analysis_result(plotBands, plotLines, pointStatistics, dchar_Zones, pointState);

            return analysis_result;
        }

        // проверка корректности найденных диапазонов
        public List<Dchar_Zone> GetDchar_ZonesState(Analysis_result analysis_Result_IN, Analysis_result analysis_Result_OUT)
        {
            List<Dchar_Zone> new_Zones = new List<Dchar_Zone>();

            for (int i = 0; i < analysis_Result_IN._Dchar_Zones.Count(); i++)
            {
                var leftP = analysis_Result_IN._Dchar_Zones[i].LeftPoint;
                var middleP = analysis_Result_IN._Dchar_Zones[i].MiddlePoint;
                var rightP = analysis_Result_IN._Dchar_Zones[i].RightPoint;
                var qPointsL = Convert.ToInt32(Math.Round((middleP - leftP) * 0.1, 0)); // смещение в 10%
                var qPointsR = Convert.ToInt32(Math.Round((rightP - middleP) * 0.1, 0)); // смещение в 10%

                bool isOnSteadyStateL = false;
                bool isOnSteadyStateR = false;

                // проверка нахождения точек на линии момента равновесия
                int qPL = leftP - qPointsL;

                while (qPL < (rightP + qPointsL * 2) && isOnSteadyStateL == false)
                {
                    if (analysis_Result_OUT._PointState[qPL][1] == 1)
                    {
                        isOnSteadyStateL = true;
                    }

                    qPL++;
                }

                int qPR = rightP - qPointsR;
                                
                while (qPR < (rightP + qPointsR * 2) && isOnSteadyStateR == false)
                {                  
                    if (analysis_Result_OUT._PointState[qPR][1] == 1)
                    {
                        isOnSteadyStateR = true;
                    }

                    qPR++;
                }

                if(isOnSteadyStateL == true && isOnSteadyStateR == true)
                {
                    new_Zones.Add(new Dchar_Zone(leftP, middleP, rightP, true));
                }
            }

            return new_Zones;
        }


        private double MaxABSVal( List<double[]> pointsY_av_Tg, int startPoint)
        {
            int countParam = pointsY_av_Tg.Count; //pointsY_av_Tg.Count;

            double[] tgY = new double[countParam];

            for (int k = startPoint; k < countParam; k++)
            {
                tgY[k] = pointsY_av_Tg[k][1];
            }

            double maxVal = tgY.Max();
            double minVal = tgY.Min();

            double[] maxminVal = new double[] { Math.Abs(maxVal), Math.Abs(minVal) };

            double maxABSVal = maxminVal.Max();

            return maxABSVal;
        }

        private bool SignOfDerY(List<double> helperval)
        {
            bool flag = false;

            // поиск экстремумов
            double maxValpoint = helperval.Max();
            double minValpoint = helperval.Min();

            double[] maxminValpoint = new double[] { Math.Abs(maxValpoint), Math.Abs(minValpoint) };

            double maxABSValpoint = maxminValpoint.Max();

            double pointZ = 0;

            if (maxminValpoint[0] == maxABSValpoint)
                pointZ = maxValpoint;
            else
                pointZ = minValpoint;

            if (pointZ > 0)
                flag = true;
            else
                flag = false;

            return flag;
        }

        private int RoundVal(double maxABSVal)
        {
            if (maxABSVal > 1)
                return 2;
            else if (maxABSVal * 10 > 1)
                return 3;
            else if (maxABSVal * 100 > 1)
                return 4;
            else
                return 0;
        }
    }
}
