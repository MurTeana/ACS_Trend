using ACS_Trend.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS_Trend.Models
{
    public class HomeIndexViewModel
    {
        public LineChartViewModel LineChartData_IN_Source { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },
           
            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    { 
                        enabled = false                       
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    { 
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_IN_Source_Result { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_IN_Aproxy { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_IN_Tg { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_IN_Result { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };

        public LineChartViewModel LineChartData_OUT_Source { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_OUT_Aproxy { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_OUT_Tg { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_OUT_Result { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };
        public LineChartViewModel LineChartData_TransCh { get; set; } = new LineChartViewModel()
        {
            xAxis = new XAxis
            {
                title = new Title()
                {
                    text = "Time"
                },
                crosshair = true
            },

            yAxis = new YAxis
            {
                title = new Title()
                {
                    text = "Parameter"
                },
                crosshair = true
            },

            plotOptions = new PlotOptions()
            {
                line = new Line()
                {
                    dataLabels = new DataLabels()
                    {
                        enabled = false
                    },
                    enableMouseTracking = true
                },

                series = new SeriesPT()
                {
                    lineWidth = 2,
                    allowPointSelect = true
                }
            },

            series = new List<Series>()
            {
                new Series()
                {
                    name ="",
                    color = "#4682B4",
                    data = new List<double[]>(),
                    marker = new Marker()
                    {
                        enabled = false,
                        radius = 5
                    }
                }
            }
        };

        // дополнительные параметры кнопок
        public string ProcessType { get; set; }

        // дополнительные параметры для анализа

        [Display(Name = "Точка старта")]
        [Required (ErrorMessage = "Введите точку старта")]
        public int? StartPoint { get; set; } = 1843;

        [Display(Name = "Коэффициент смещения")]
        [Required(ErrorMessage = "Заполните значение")]
        public double? K_Moving { get; set; } = 0.6;

        [Display(Name = "Параметр зоны нечувствительности графика тренда входного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public double? ToleranceZone_K_IN { get; set; } = 0.015;

        [Display(Name = "Параметр зоны нечувствительности графика тренда выходного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public double? ToleranceZone_K_OUT { get; set; } = 0.015;

        [Display(Name = "Нижнее ограничение точек тренда входного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public double? LowerLimit_IN { get; set; } = 4.5;

        [Display(Name = "Верхнее ограничение точек тренда входного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public double? UpperLimit_IN { get; set; } = 17;

        [Display(Name = "Нижнее ограничение точек тренда выходного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public double? LowerLimit_OUT { get; set; } = 256;

        [Display(Name = "Верхнее ограничение точек тренда выходного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public double? UpperLimit_OUT { get; set; } = 950;

        [Display(Name = "Ограничение по времени тренда входного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public int? TimeLimit_IN { get; set; } = 50;

        [Display(Name = "Ограничение по времени тренда выходного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public int? TimeLimit_OUT { get; set; } = 50;

        [Display(Name = "Коэффициент сглаживания графика тренда входного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public int? K_Approxy_IN { get; set; } = 40;


        [Display(Name = "Коэффициент сглаживания графика тренда выходного сигнала")]
        [Required(ErrorMessage = "Заполните значение")]
        public int? K_Approxy_OUT { get; set; } = 40;


        //
        public TrendPointViewModel TrendPointViewModel_ { get; set; }
        public Trend Trend_ { get; set; }
        public List<Trend> Trends { get; set; } = new List<Trend>();

        public int id;
        public Transient_characteristicPointViewModel Transient_characteristicPointViewModel_ { get; set; }
    }
}
