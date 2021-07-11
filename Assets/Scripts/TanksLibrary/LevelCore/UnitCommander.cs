using System.Collections.Generic;

namespace LevelCore
{
    public abstract class UnitCommander
    {
        private readonly IUnitFactory _unitFactory;
        private List<IUnitLauncher> _units;

        protected UnitCommander(IUnitFactory factory)
        {
            _unitFactory = factory;
        }

        public void Play()
        {
            PlayUnits();
        }

        private void PlayUnits()
        {
            foreach (var unit in _units)
                unit.Play();
        }


        public void Ready()
        {
            ReadyUnits();
        }

        private void ReadyUnits()
        {
            foreach (var unit in _units) unit.Ready();
        }


        public void SpawnUnit()
        {
            _units = _unitFactory.CreateUnits();
        }


        public void SetupCurrentIndex(int index)
        {
            foreach (var unit in _units) unit.SetupCurrentIndex(index);
        }
    }
}