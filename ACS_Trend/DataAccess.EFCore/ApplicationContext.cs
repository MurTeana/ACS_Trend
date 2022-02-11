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
            //
            //
            // STATION_TYPE DATA
            modelBuilder
                .Entity<Station_type>()
                .HasData(
                new Station_type[]
                {
                new Station_type { ID_Station_type = 1, StationType = "ТЭС"},
                new Station_type { ID_Station_type = 2, StationType = "ГЭС"},
                new Station_type { ID_Station_type = 3, StationType = "ТЭЦ"},
                new Station_type { ID_Station_type = 4, StationType = "АЭС"},
                new Station_type { ID_Station_type = 5, StationType = "Альтернативные ЭС"},
                });

            // CONTROL_OBJECT
            modelBuilder
                .Entity<Control_object>()
                .HasOne(u => u.Control_object_type)
                .WithMany(p => p.Control_object)
                .HasForeignKey(p => p.CO_Control_object_type);

            // CONTROL_OBJECT DATA
            modelBuilder
                .Entity<Control_object>()
                .HasData(
                new Control_object[]
                {
                new Control_object { ID_Control_object = 1, Control_object_name = "Название котла", CO_Control_object_type = 1, Extend_information = ""},
                new Control_object { ID_Control_object = 2, Control_object_name = "Название турбины", CO_Control_object_type = 2, Extend_information = ""},
                });

            // CONTROL_OBJECT_TYPE
            //
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
            // 
            //
            //
            // TREND PARAMETER
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

            // TREND PARAMETER DATA

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
    }
}
