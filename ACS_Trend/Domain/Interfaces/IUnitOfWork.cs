using System;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IControl_object_typeRepository Control_object_types { get; }
        //IControl_objectRepository Control_objects { get; }
        //IRegulatorRepository Regulators { get; }
        //ISignal_typeRepository Signal_types { get; }
        IStation_typeRepository Station_types { get; }
        IStationRepository Stations { get; }
        //ITransient_characteristicRepository Transient_characteristics { get; }
        //ITrend_parameter_typeRepository Trend_parameter_types { get; }
        //ITrend_parameterRepository Trend_parameters { get; }
        //ITrendPointRepository TrendPoints { get; }
        ITrendRepository Trends { get; }
        IUnitRepository Units { get; }

        int Complete();
    }
}
