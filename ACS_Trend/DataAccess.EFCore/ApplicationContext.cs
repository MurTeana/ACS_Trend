using ACS_Trend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ACS_Trend.Models;

namespace ACS_Trend.DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Control_object> Control_objects { get; set; }
        public DbSet<Control_object_type> Control_object_types { get; set; }
        public DbSet<Regulator> Regulators { get; set; }
        public DbSet<Signal_type> Signal_types { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Station_type> Station_types { get; set; }
        public DbSet<Transient_characteristic> Transient_characteristics { get; set; }
        public DbSet<Trend> Trends { get; set; }
        public DbSet<Trend_parameter> Trend_parameters { get; set; }
        public DbSet<Trend_parameter_type> Trend_parameter_types { get; set; }
        public DbSet<TrendPoint> TrendPoints { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // STATION
            modelBuilder
                .Entity<Station>()
                .HasOne(u => u.Station_type)
                .WithMany(p => p.Station)
                .HasForeignKey(p => p.ST_ID_Station_type);

            // STATION DATA
            modelBuilder
                .Entity<Station>()
                .HasData(
                new Station[]
                {
                new Station { ID_Station = 1, Station_name="Костромская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "3630 МВт", HeatPower = "450 Гкал/ч"},
                new Station { ID_Station = 2, Station_name="Конаковская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "2520 МВт", HeatPower = "120 Гкал/ч"},
                new Station { ID_Station = 3, Station_name="Беловская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "1260 МВт", HeatPower = "229 Гкал/ч"},
                new Station { ID_Station = 4, Station_name="Березовская ГРЭС-1",ST_ID_Station_type = 1,ElectricalPower = "2400 МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 5, Station_name="Ермаковская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 6, Station_name="Киришская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 7, Station_name="Криворожская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 8, Station_name="Новочерскасская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 9, Station_name="Приднепровская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 10, Station_name="Рефтинская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 11, Station_name="Троицкая ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 12, Station_name="Черепецкая ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 13, Station_name="Шатурская ГРЭС-5",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 14, Station_name="Экибастузкая ГРЭС-1",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 15, Station_name="Рязанская ГРЭС",ST_ID_Station_type = 1,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 16, Station_name="Павлодарская ТЭЦ-1",ST_ID_Station_type = 3,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                new Station { ID_Station = 17, Station_name="Калининградская ТЭЦ-2",ST_ID_Station_type = 3,ElectricalPower = "МВт", HeatPower = "Гкал/ч"},
                });

            // STATION_TYPE
            // STATION_TYPE DATA
            modelBuilder
                .Entity<Station_type>()
                .HasData(
                new Station_type[]
                {
                new Station_type { ID_Station_type = 1, Station_type_name = "ТЭС"},
                new Station_type { ID_Station_type = 2, Station_type_name = "ГЭС"},
                new Station_type { ID_Station_type = 3, Station_type_name = "ТЭЦ"},
                new Station_type { ID_Station_type = 4, Station_type_name = "АЭС"},
                new Station_type { ID_Station_type = 5, Station_type_name = "Альтернативные ЭС"},
                });

            // CONTROL_OBJECT
            modelBuilder
                .Entity<Control_object>()
                .HasOne(u => u.Control_object_type)
                .WithMany(p => p.Control_object)
                .HasForeignKey(p => p.CO_ID_Control_object_type);

            // CONTROL_OBJECT DATA
            modelBuilder
                .Entity<Control_object>()
                .HasData(
                new Control_object[]
                {
                new Control_object { ID_Control_object = 1, Control_object_name = "Название котла", CO_ID_Control_object_type = 1, Extend_information = ""},
                new Control_object { ID_Control_object = 2, Control_object_name = "Название турбины", CO_ID_Control_object_type = 2, Extend_information = ""},
                });

            // CONTROL_OBJECT_TYPE
            // CONTROL_OBJECT_TYPE DATA
            modelBuilder
                .Entity<Control_object_type>()
                .HasData(
                new Control_object_type[]
                {
                new Control_object_type { ID_Control_object_type = 1, Control_object_type_name = "котел"},
                new Control_object_type { ID_Control_object_type = 2, Control_object_type_name = "турбина"}
                });

            // TREND
            modelBuilder
                .Entity<Trend>()
                .HasOne(u => u.Station)
                .WithMany(p => p.Trend)
                .HasForeignKey(p => p.T_ID_Station);

            modelBuilder
                .Entity<Trend>()
                .HasOne(u => u.Trend_parameter)
                .WithMany(p => p.Trend)
                .HasForeignKey(p => p.T_ID_Trend_parameter);

            modelBuilder
                .Entity<Trend>()
                .HasOne(u => u.Unit)
                .WithMany(p => p.Trend)
                .HasForeignKey(p => p.T_ID_Unit);

            // TREND DATA
            modelBuilder
                .Entity<Trend>()
                .HasData(
                new Trend[]
                {
                new Trend { ID_Trend = 1, T_ID_Station = 2, T_ID_Trend_parameter = 1, T_ID_Unit = 2},
                new Trend { ID_Trend = 2, T_ID_Station = 1, T_ID_Trend_parameter = 1, T_ID_Unit = 1},
                });

            // TREND_PARAMETER
            modelBuilder
                .Entity<Trend_parameter>()
                .HasOne(u => u.Control_object)
                .WithMany(p => p.Trend_parameter)
                .HasForeignKey(p => p.TP_ID_Control_object);
            modelBuilder
                .Entity<Trend_parameter>()
                .HasOne(u => u.Regulator)
                .WithMany(p => p.Trend_parameter)
                .HasForeignKey(p => p.TP_ID_Regulator);
            modelBuilder
                .Entity<Trend_parameter>()
                .HasOne(u => u.Signal_type)
                .WithMany(p => p.Trend_parameter)
                .HasForeignKey(p => p.TP_ID_Signal_type);
            modelBuilder
                .Entity<Trend_parameter>()
                .HasOne(u => u.Trend_parameter_type)
                .WithMany(p => p.Trend_parameter)
                .HasForeignKey(p => p.TP_ID_Trend_parameter_type);

            // TREND_PARAMETER DATA
            modelBuilder
                .Entity<Trend_parameter>()
                .HasData(
                new Trend_parameter[]
                {
                new Trend_parameter { ID_Trend_parameter = 1, Trend_parameter_name = "расход пара", TP_ID_Trend_parameter_type = 1, TP_ID_Control_object = 1, TP_ID_Regulator = 1, TP_ID_Signal_type = 1 },
                new Trend_parameter { ID_Trend_parameter = 2, Trend_parameter_name = "расход воды", TP_ID_Trend_parameter_type = 1, TP_ID_Control_object = 1, TP_ID_Regulator = 1, TP_ID_Signal_type = 1},
                });

            // REGULATOR DATA
            modelBuilder
                .Entity<Regulator>()
                .HasData(
                new Regulator[]
                {
                new Regulator { ID_Regulator = 1, Regulator_name = "клапан" },
                new Regulator { ID_Regulator = 2, Regulator_name = "задвижка" },
                });

            // SIGNAL_TYPE DATA
            modelBuilder
                .Entity<Signal_type>()
                .HasData(
                new Signal_type[]
                {
                new Signal_type { ID_Signal_type = 1, Signal_type_name = "входной сигнал"},
                new Signal_type { ID_Signal_type = 2, Signal_type_name = "выходной сигнал"},
                });

            // TREND_PARAMETER_TYPE DATA
            modelBuilder
                .Entity<Trend_parameter_type>()
                .HasData(
                new Trend_parameter_type[]
                {
                new Trend_parameter_type { ID_Trend_parameter_type = 1, Trend_parameter_type_name = "Trend_parameter_type_name"},
                new Trend_parameter_type { ID_Trend_parameter_type = 2, Trend_parameter_type_name = "Trend_parameter_type_name"},
                });

            // UNIT
            //
            // UNIT DATA
            modelBuilder
                .Entity<Unit>()
                .HasData(
                new Unit[]
                {
                new Unit { ID_Unit = 1, Unit_name = "кг"},
                new Unit { ID_Unit = 2, Unit_name = "м.куб."},
                });

            // TRENDPOINT
            modelBuilder
                .Entity<TrendPoint>()
                .HasOne(u => u.Trend)
                .WithMany(p => p.TrendPoint)
                .HasForeignKey(p => p.TP_ID_Trend);
            // TRENDPOINTDATA
            modelBuilder
                .Entity<TrendPoint>()
                .HasData(
                new TrendPoint[]
                {
                    new TrendPoint { ID_TrendPoint = 1, Date_time = 1, Parameter = 2, TP_ID_Trend = 1},
                    new TrendPoint { ID_TrendPoint = 2, Date_time = 2, Parameter = 4, TP_ID_Trend = 1},
                    new TrendPoint { ID_TrendPoint = 3, Date_time = 3, Parameter = 8, TP_ID_Trend = 1},
                    new TrendPoint { ID_TrendPoint = 4, Date_time = 4, Parameter = 12, TP_ID_Trend = 1},
                    new TrendPoint { ID_TrendPoint = 5, Date_time = 4, Parameter = 12, TP_ID_Trend = 2},
                    new TrendPoint { ID_TrendPoint = 6, Date_time = 4, Parameter = 12, TP_ID_Trend = 2},
                    new TrendPoint { ID_TrendPoint = 7, Date_time = 4, Parameter = 12, TP_ID_Trend = 2},
                    new TrendPoint { ID_TrendPoint = 8, Date_time = 4, Parameter = 12, TP_ID_Trend = 2},
                });

            // В: Расход топлива - вх
            // Видимый расход пара
            // Электрическая мощность генератора 
            // Температура газов в полут. 
            // Температ.газов в полутоп. 
            // Ист.расход пара 
            // Давл.в барабане. 
            // Давл.пара в барабане 
            // Давл.пара перед турбиной 
            // Содерж.кислорода 
            // Темпеpатуpа за СРЧ. 
            // Температура газов. 
            // Темпеpатуpа за СРЧ 
            // Темпеpатуpа за ВРЧ
            // Темпеpатуpа за ПЭ
            // Изм. расода пара
            // Температура газов
            //
            // В: pасход питательной воды
            // Темпеpатуpа за СРЧ
            // Темпеpатуpа за ВРЧ
            // Темпеpатуpа за ПЭ
            // Расxод паpа
            // 
            //В:топ-м откл.ПСУ ср.ярус
            //Тем-ра газов за ширм.
            //
            //В:рег.клапан.ТА
            //Изм.тем.пара пеpед 2-й ст
            //
            //
        }       

        public DbSet<ACS_Trend.Models.Control_objectViewModel> Control_objectViewModel { get; set; }

        public DbSet<ACS_Trend.Models.StationViewModel> StationViewModel { get; set; }

        public DbSet<ACS_Trend.Models.Trend_parameter_typeViewModel> Trend_parameter_typeViewModel { get; set; }

        public DbSet<ACS_Trend.Models.Trend_parameterViewModel> Trend_parameterViewModel { get; set; }

        public DbSet<ACS_Trend.Models.TrendPointViewModel> TrendPointViewModel { get; set; }
    }
}
