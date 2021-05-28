using System.Collections.Generic;
using System.Security.Principal;

namespace LevelCore
{
    public abstract class UnitCommander
    {
        private List<IUnitLauncher> _units;
        private readonly IUnitFactory _unitFactory;

        protected UnitCommander(IUnitFactory factory) => this._unitFactory = factory;

        public void Play(int index) => PlayUnits(index);

        private void PlayUnits(int index)
        {
            foreach (IUnitLauncher unit in _units)
                unit.Play(index);
        }

        public void Ready() => ReadyUnits();

        private void ReadyUnits()
        {
            foreach (var unit in _units)
            {
                unit.Ready();
            }
        }
        
        public void SpawnUnit() => _units = _unitFactory.CreateUnits();
    }
}