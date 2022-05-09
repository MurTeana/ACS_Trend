using ACS_Trend.DataAccess.EFCore.Repositories;
using ACS_Trend.Domain.Interfaces;

namespace ACS_Trend.DataAccess.EFCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Control_object_types = new Control_object_typeRepository(_context);
            Control_objects = new Control_objectRepository(_context);
            Regulators = new RegulatorRepository(_context);
            Signal_types = new Signal_typeRepository(_context);
            Station_types = new Station_typeRepository(_context);
            Stations = new StationRepository(_context);
            Transient_characteristics = new Transient_characteristicRepository(_context);
            Trend_parameters = new Trend_parameterRepository(_context);
            TrendPoints = new TrendPointRepository(_context);
            Trends = new TrendRepository(_context);
            Units = new UnitRepository(_context);
        }
        public IControl_object_typeRepository Control_object_types { get; private set; }
        public IControl_objectRepository Control_objects { get; private set; }
        public IRegulatorRepository Regulators { get; private set; }
        public ISignal_typeRepository Signal_types { get; private set; }
        public IStation_typeRepository Station_types { get; private set; }
        public IStationRepository Stations { get; private set; }
        public ITransient_characteristicRepository Transient_characteristics { get; private set; }
        public ITrend_parameterRepository Trend_parameters { get; private set; }
        public ITrendPointRepository TrendPoints { get; private set; }
        public ITrendRepository Trends { get; private set; }
        public IUnitRepository Units { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
