using System;

namespace ACS_Trend.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IControl_object_typeRepository Control_object_types { get; }
        IControl_objectRepository Control_objects { get; }
        IRegulatorRepository Regulators { get; }
        ISignal_typeRepository Signal_types { get; }
        IStation_typeRepository Station_types { get; }
        IStationRepository Stations { get; }
        ITransient_characteristicPointRepository Transient_characteristicPoints { get; }
        ITrend_parameter_nameRepository Trend_parameter_names { get; }
        ITrendRepository Trends { get; }
        IUnitRepository Units { get; }

        int Complete();
    }
}
