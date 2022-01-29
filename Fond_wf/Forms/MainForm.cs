using Fond_wf.Functions;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Fond_wf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            kAproxy_txtbox.Text = "6";
            startp_txtbox.Text = "183";
            qGO2_txtbox.Text = "10"; 
            tol1_txtbox.Text = "0,027";
            tol2_txtbox.Text = "0,02";
            timeExp_txtbox.Text = "10";
        }

        public DataTable csvTable_ = new DataTable();
        public DataTable dataTableNew = new DataTable();

        public PlotView pv1_IN;
        public PlotView pv2_IN;
        public PlotView pv3_IN;

        public PlotView pv1_OUT;
        public PlotView pv2_OUT;
        public PlotView pv3_OUT;

// Подгрузка файла
        private void path_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите файл";
            //ofd.Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx|All Files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.FileName = path_txtbox.Text;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path_txtbox.Text = @ofd.FileName;
            }
            else
            {
                MessageBox.Show("Файл не был выбран");
                ofd.Dispose();
            }
        }
// Извлечение данных
        private void loadData_btn_Click(object sender, EventArgs e)
        {
            string filepath = path_txtbox.Text;

            IDataFunc dataFunc = new IDataFunc_();
            csvTable_ = dataFunc.GetDataFromFile(filepath);

            //DataGridView
            dataGridView1.DataSource = csvTable_;
        }
// Анализ данных
        private void approxy_btn_Click(object sender, EventArgs e)
        {
            int countData = csvTable_.Rows.Count;
            int qGO = Convert.ToInt32(kAproxy_txtbox.Text);
            int qGO2 = Convert.ToInt32(qGO2_txtbox.Text);
            int startPoint = Convert.ToInt32(startp_txtbox.Text);
            double tolerance_kAproxy = Convert.ToDouble(tol1_txtbox.Text);
            double tolerance_tgY = Convert.ToDouble(tol2_txtbox.Text);
            int timeExp = Convert.ToInt32(timeExp_txtbox.Text);
// IN
            double[] y = new double[countData];
            double[] yAproxy = new double[countData];
            double[] tgalpha_ = new double[countData];
            int[] findPoint_ = new int[countData];

            for (int i = 0; i < (countData); i++)
            {
                y[i] = Convert.ToDouble(csvTable_.Rows[i][2].ToString());
            }

            IMathFunc mathFunc = new MathFunc_();

            yAproxy = mathFunc.MovAverage(y, qGO);
            tgalpha_ = mathFunc.DerOfFunc(yAproxy);
            findPoint_ = mathFunc.FindPoint(yAproxy, tgalpha_, startPoint, qGO2, tolerance_kAproxy, tolerance_tgY, timeExp);

// OUT
            double[] y_out = new double[countData];
            double[] yAproxy_out = new double[countData];
            double[] tgalpha_out = new double[countData];

            for (int i = 0; i < (countData); i++)
            {
                y_out[i] = Convert.ToDouble(csvTable_.Rows[i][3].ToString());
            }

            yAproxy_out = mathFunc.MovAverage(y_out, qGO);
            tgalpha_out = mathFunc.DerOfFunc(yAproxy_out);

// dataTableNew
            dataTableNew.Columns.Add("Num");
            dataTableNew.Columns.Add("Date");
            dataTableNew.Columns.Add("In_fuel");
            dataTableNew.Columns.Add("Out_power");
            dataTableNew.Columns.Add("AproxParam_IN");
            dataTableNew.Columns.Add("tgParam_IN");
            dataTableNew.Columns.Add("findPoint");
            dataTableNew.Columns.Add("AproxParam_OUT");
            dataTableNew.Columns.Add("tgParam_IN_OUT");

            DataRow workRow;
            for (int i = 0; i < (countData); i++)
            {
                workRow = dataTableNew.NewRow();
                workRow[0] = csvTable_.Rows[i][0];
                workRow[1] = csvTable_.Rows[i][1];
                workRow[2] = csvTable_.Rows[i][2];
                workRow[3] = csvTable_.Rows[i][3];

                workRow[4] = yAproxy[i];
                workRow[5] = tgalpha_[i];
                workRow[6] = findPoint_[i];

                workRow[7] = yAproxy_out[i];
                workRow[8] = tgalpha_out[i];

                dataTableNew.Rows.Add(workRow);
            }

            dataGridView1.DataSource = dataTableNew;
            MessageBox.Show("Done");
            MessageBox.Show(tolerance_tgY.ToString());           
        }
// Построение графиков
        private void normalgr_btn_Click(object sender, EventArgs e)
        {
            pv1_IN = newNormalPlot2(csvTable_, 2, dataTableNew, 6); 
            pv1_IN.Location = new Point(280, 80);
            pv1_IN.Model.Title = "График1_IN";           

            //pv1_OUT = newNormalPlot(csvTable_, 3);
            //pv1_OUT.Location = new Point(735, 80);
            //pv1_OUT.Model.Title = "График1_OUT";

            MessageBox.Show("Done");
        }

        private void grafanalize_btn_Click(object sender, EventArgs e)
        {
            pv2_IN = newNormalPlot2(dataTableNew, 4, dataTableNew, 6);
            pv2_IN.Location = new Point(280, 280);
            pv2_IN.Model.Title = "График2_IN";

            pv3_IN = newNormalPlot(dataTableNew, 5);
            pv3_IN.Location = new Point(280, 480);
            pv3_IN.Model.Title = "График3_IN";

            //pv2_OUT = newNormalPlot(dataTableNew, 7);
            //pv2_OUT.Location = new Point(735, 280);
            //pv2_OUT.Model.Title = "График2_OUT";

            //pv3_OUT = newNormalPlot(dataTableNew, 8);
            //pv3_OUT.Location = new Point(735, 480);
            //pv3_OUT.Model.Title = "График3_OUT";

            MessageBox.Show("Done");
        }
// Функции графиков
        // Plot
        private PlotView newNormalPlot(DataTable dataTable, int colNum)
        {
            //Plot
            PlotView pv = new PlotView();
            pv.Location = new Point(0, 0);
            pv.Size = new Size(450, 200);
            Controls.Add(pv);

            pv.Model = new PlotModel { Title = "" };
            pv.Model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time" });
            pv.Model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Param" });

            // FunctionSeries
            FunctionSeries fs = new FunctionSeries();

            IDataFunc dataFunc = new IDataFunc_();

            for (var i = 0; i < dataFunc.GetDataForPlotXY(dataTable, 0, 1).Count; i++)
            {
                double y = Convert.ToDouble(dataTable.Rows[i][colNum].ToString());
                fs.Points.Add(new DataPoint(i, y));
            }

            // Add FunctionSeries
            pv.Model.Series.Add(fs);

            return pv;
        }

        // Plot2
        private PlotView newNormalPlot2(DataTable dataTable, int colNum, DataTable dataTable2, int colNum2)
        {
            //Plot
            PlotView pv = new PlotView();
            pv.Location = new Point(0, 0);
            pv.Size = new Size(450, 200);
            Controls.Add(pv);

            pv.Model = new PlotModel { Title = "" };
            pv.Model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time" });
            pv.Model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Param" });

            // FunctionSeries
            FunctionSeries fs = new FunctionSeries();

            IDataFunc dataFunc = new IDataFunc_();

            for (var i = 0; i < dataFunc.GetDataForPlotXY(dataTable, 0, 1).Count; i++)
            {
                double y = Convert.ToDouble(dataTable.Rows[i][colNum].ToString());
                fs.Points.Add(new DataPoint(i, y));
            }

            // Add FunctionSeries
            pv.Model.Series.Add(fs);

            FunctionSeries fs2 = new FunctionSeries();
            fs2.MarkerType = MarkerType.Circle;
            fs2.MarkerFill = OxyColors.Blue;
            fs2.LineStyle = LineStyle.None;
            

            int i2 = 0;
            while (i2 < dataTable2.Rows.Count)
            {
                int time = Convert.ToInt32(dataTable2.Rows[i2][colNum2].ToString());
                double y2 = Convert.ToDouble(dataTable.Rows[time][colNum].ToString());

                fs2.Points.Add(new DataPoint(time, y2));
                
                i2++;
            }

            pv.Model.Series.Add(fs2);
            
            return pv;
        }
    }
}
