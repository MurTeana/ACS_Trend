using ACS_Trend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS_Trend.Functions
{
    public interface IMathFunc
    {
        List<double[]> MovAverageList(List<double[]> pointsdata, int qGO);
        List<double[]> DerOfFuncList(List<double[]> pointsdata);
        ChartZones FindPointList(List<double[]> pointsY_av, List<double[]> pointsY_av_Tg, int startPoint);
    }

    public class MathFunc_ : IMathFunc
    {
        // Скользящее среднее LIST
        public List<double[]> MovAverageList(List<double[]> pointsdata, int stepMovAv)
        {
            int countData = pointsdata.Count;
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
        public ChartZones FindPointList(List<double[]> pointsY_av, List<double[]> pointsY_av_Tg, int startPoint)
        {
            int countParam = pointsY_av.Count;
            int i = startPoint; // Стартовая точка

            int pointFind_av = 0;
            int pointFind_tg = 0;
            int ind_FP = 0;

            double[] pointAver_ = new double[countParam];

            List<int> pointFind1 = new List<int>();
            List<int> pointFind2 = new List<int>();
            List<int> pointFindAll = new List<int>();
            List<int> wrongPoints = new List<int>();

            pointFindAll.Add(startPoint);

            bool flag = false;
            List <bool> staticflags = new List<bool>();
            List <int> staticpoint = new List<int>();

            List <double> helperval = new List<double>();

            // поиск максимального значения в диапазоне
            double[] tgY = new double[countParam];

            for (int k = 0; k < countParam; k++)
            {
                tgY[k] = pointsY_av_Tg[k][1];
            }

            double maxVal = tgY.Max();
            double minVal = tgY.Min();

            double[] maxminVal = new double[] { Math.Abs(maxVal), Math.Abs(minVal) };

            double maxABSVal = maxminVal.Max();


            while (i < (countParam - 1)) // 
            {
                int qPoints = 2;

                // Анализ графика сглаженных значений
                double sumPoints = pointsY_av[i][1];
                double pointAver = pointsY_av[i][1];

                // параметры зоны нечувствительности
                double tolerance_kAproxy = pointsY_av[i][1] * 0.01; // 1-2 % от искомого значения

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

                // параметры зоны нечувствительности
                int roundVal = 0;

                if (maxABSVal > 1)
                    roundVal = 2;
                else if (maxABSVal * 10 > 1)
                    roundVal = 3;
                else if (maxABSVal * 100 > 1)
                    roundVal = 4;

                double tolerance_tgY = Math.Round(maxABSVal * 0.01, roundVal); // 1% от максимума в диапазоне значений (абсолютное)

                // Анализ графика производных
                int qPoints2;
                qPoints2 = 0;

                while ((Math.Abs(pointsY_av_Tg[i][1]) > tolerance_tgY) && i < (countParam - 1))
                {
                    helperval.Add(pointsY_av_Tg[i][1]);

                    qPoints2++;
                    i++;
                }

                if (qPoints2 > 0)
                {
                    pointFind_tg = pointFind1[ind_FP] + qPoints2;
                }   

                // + -
                if (helperval.Count() != 0)
                {
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

                    staticflags.Add(flag);
                    staticpoint.Add(i);

                    helperval.Clear();
                }

                pointFind2.Add(pointFind_tg); // сдвиг назад на одну точку УБРАЛА
                pointFind_tg = 0;

                if (pointFind2[ind_FP] != 0)
                {
                    pointFindAll.Add(pointFind1[ind_FP]);
                    pointFindAll.Add(pointFind2[ind_FP]);                    
                }
                else if (pointFind1[ind_FP] != 0)
                {
                    //wrongPoints.Add(pointFind1[ind_FP]);
                }

                ind_FP++;
            }

            // отсеивание точек перемена знака на графике производных

            for (int stF = 0; stF < staticflags.Count() - 1; stF++)
            {
                if (staticflags[stF] == staticflags[stF + 1])
                {
                    wrongPoints.Add(staticpoint[stF]);
                    wrongPoints.Add(staticpoint[stF + 1]);
                }                    
            }

            wrongPoints.Sort();

            // ChartZones
            List <PlotBands> plotBands = new List<PlotBands>();
            List <PlotLines> plotLines = new List<PlotLines>();

            plotLines.Add(new PlotLines("grey", pointFindAll[0], 3));
            int point = 0;

            for (int p = 1; p < pointFindAll.Count() - 2; p = p + 2)
            {
                point = (pointFindAll[p + 1] + pointFindAll[p + 2]) / 2;
                plotLines.Add(new PlotLines("grey", point, 1));
            }

            plotLines.Add(new PlotLines("black", pointFindAll.Last(), 3));

            int wp = 0;
            int pL = 1;
            wrongPoints.Add(countParam);

            while (pL < plotLines.Count() && wp < wrongPoints.Count())
            {
                if (wrongPoints[wp] > plotLines[pL].value)
                {
                    plotBands.Add(new PlotBands("rgba(107,201,91,.5)", plotLines[pL - 1].value, plotLines[pL].value));                                     
                }
                else
                {
                    plotBands.Add(new PlotBands("rgba(255,211,208,.5)", plotLines[pL - 1].value, plotLines[pL].value));
                    wp++;
                }
                   
                pL++;
            }              

            ChartZones chartZones = new ChartZones(plotBands, plotLines, pointFindAll);

            return chartZones;
        }
 
    }
}
