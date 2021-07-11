namespace LevelCore
{
    public class LevelManagement
    {
        private readonly UnitCommander _enemyUnits;
        private readonly UnitCommander _playerUnits;

        public LevelManagement(ICommanderFactory factory)
        {
            _enemyUnits = factory.CreateEnemyCommander();
            _playerUnits = factory.CreatePlayerCommander();
        }


        public void SpawnUnit()
        {
            _enemyUnits.SpawnUnit();
            _playerUnits.SpawnUnit();
        }


        public void Play()
        {
            _enemyUnits.Play();
            _playerUnits.Play();
        }


        public void Ready()
        {
            _enemyUnits.Ready();
            _playerUnits.Ready();
        }


        public void SetupCurrentIndex(int index)
        {
            _enemyUnits.SetupCurrentIndex(index);
            _playerUnits.SetupCurrentIndex(index);
        }
    }
}