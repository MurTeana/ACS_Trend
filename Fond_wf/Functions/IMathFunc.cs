using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fond_wf.Functions
{
    public interface IMathFunc
    {
        double[] MovAverage(double[] y, int qGO);
        double[] DerOfFunc(double[] yAproxy);
        int[] FindPoint(double[] y, double[] yTg, int startPoint, int step, double tolerance_kAproxy, double tolerance_tgY, int timeExp);
    }

    public class MathFunc_ : IMathFunc
    {
// Скользящее среднее
        public double[] MovAverage(double[] y, int stepMovAv)
        {
            int countData = y.Length;
            double[] yAproxy = new double[countData];
            double sumY = 0;

            for (int i = 0; i < (countData - stepMovAv); i++)
            {
                for (int k = 0; k < stepMovAv; k++)
                {
                    sumY = sumY + y[k + i];
                }
                yAproxy[i] = sumY / stepMovAv;
                sumY = 0;
            }

            return yAproxy;
        }
// Производная функции
        public double[] DerOfFunc(double[] y)
        {
            int countData = y.Length;
            double[] tgalpha_ = new double[countData];

            for (var i = 0; i < countData; i++)
            {
                if (i > 0)
                {
                    tgalpha_[i] = (y[i] - y[i - 1]);
                }
                else
                {
                    tgalpha_[i] = 0;
                }
            }
            return tgalpha_;
        }
// Поиск точек
        public int[] FindPoint(double[] y, double[] yTg, int startPoint, int step, double tolerance_kAproxy, double tolerance_tgY, int timeExp)
        {
            int countParam = y.Length;
            
            double[] pointAver_ = new double[countParam];

            int[] pointFind1 = new int[countParam];
            int[] pointFind2 = new int[countParam];
            int[] pointFindAll = new int[countParam];

            int i = startPoint;
            // Анализ графика сглаженных значений
            while (pointFind1[0] == 0)//(i < countParam)
            {
                double sumPoints = y[i];
                double pointAver = y[i];
                int qPoints = 2;

                while (Math.Abs(y[i]-pointAver) < tolerance_kAproxy)
                {
                    sumPoints = y[i] + sumPoints;
                    pointAver = sumPoints / qPoints;
                    pointAver_[qPoints - 2] = sumPoints;
                    qPoints++;

                    i++;                   
                }
                pointFind1[0] = i;
            }
            // Расчет tolerance_tgY
            int qPoints_tolerance_tgY = pointFind1[0] - startPoint;
            double sumPoints_tolerance_tgY = 0;

            for (int j = 0; j < qPoints_tolerance_tgY; j++)
            {
                sumPoints_tolerance_tgY = yTg[j + startPoint] + sumPoints_tolerance_tgY;
            }
            tolerance_tgY = sumPoints_tolerance_tgY / qPoints_tolerance_tgY;
            tolerance_tgY = 0.02;

            // Анализ графика производных
            while (pointFind2[0] == 0)
            {
                int qPoints2 = 0;

                while (Math.Abs(yTg[i]) > tolerance_tgY)
                {
                    qPoints2++;
                    i++;
                }
                pointFind2[0] = pointFind1[0] + qPoints2;
            }
            pointFindAll[0] = startPoint;
            pointFindAll[1] = pointFind1[0];
            pointFindAll[2] = pointFind2[0];
            return pointFindAll;
        }


        //public int[] FindPoint(double[] y, double[] yTg, int startPoint, int step, double tolerance, double tolerance2, int timeExp)
        //{
        //    int countParam = y.Length;
        //    int sch0 = startPoint;

        //    int[] pointFind1 = new int[countParam];
        //    int[] pointFind2 = new int[countParam];
        //    int[] pointFindAll = new int[countParam];

        //    double sumYAproxy_ = 0;

        //    int h = 0;
        //    int p = 0;



        //    while ((sch0 < countParam - step) && (h < countParam - 1))
        //    {
        //        for (int j = sch0; j < step + sch0; j++)
        //        {
        //            sumYAproxy_ = sumYAproxy_ + y[j];
        //        }
        //        double y_aver = sumYAproxy_ / step;
        //        sumYAproxy_ = 0;

        //        int sch1 = sch0 + step;

        //        while ((Math.Abs((y[sch1] - y_aver) / y_aver) < tolerance))
        //        {
        //            pointFind1[p] = sch1;
        //            sch1++;
        //        }

        //        if (pointFind1[p] != 0)
        //        {
        //            int sch2 = pointFind1[p] + 1;

        //            while ((Math.Abs(yTg[sch2]) > tolerance2))
        //            {
        //                pointFind2[p] = sch2;
        //                sch2++;
        //            }

        //            if (pointFind2[p] != 0)
        //            {
        //                pointFindAll[h] = pointFind1[p];
        //                pointFindAll[h + 1] = pointFind2[p];

        //                sch0 = pointFind2[p] + 1;
        //                h = h + 2;
        //                p++;
        //            }
        //            else
        //            {
        //                sch0 = sch0 + 10;
        //            }
        //        }
        //        else
        //        {
        //            sch0 = sch0 + 10;
        //        }
        //    }
        //    return pointFindAll;
        //}


    }
}
