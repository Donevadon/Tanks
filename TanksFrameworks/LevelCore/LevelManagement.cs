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

        public void Play(int index)
        {
            _enemyUnits.Play(index);
            _playerUnits.Play(index);
        }

        public void Ready()
        {
            _enemyUnits.Ready();
            _playerUnits.Ready();
        }
    }
}