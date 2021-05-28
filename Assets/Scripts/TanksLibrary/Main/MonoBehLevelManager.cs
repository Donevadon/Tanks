using LevelCore;
using UnityEngine;

namespace TanksLibrary.Main
{
    public class MonoBehLevelManager : MonoBehaviour, ICommanderFactory
    {
        private LevelManagement _management;
        [SerializeField] private LevelSettings playerLevelSettings;
        [SerializeField] private LevelSettings enemyLevelSettings;
        private int _index;
        
        private void Awake()
        {
            _management = new LevelManagement(this);
            _management.SpawnUnit();
        }

        
        UnitCommander ICommanderFactory.CreateEnemyCommander()
        {
            return new LocalEnemyUnitCommander(new MonoBehUnitFactory(enemyLevelSettings));
        }

        
        UnitCommander ICommanderFactory.CreatePlayerCommander()
        {
            return new LocalPlayerUnitCommander(new MonoBehUnitFactory(playerLevelSettings));
        }

        public void SetIndex(int index)
        {
            _index = index;
        }
        
        public void Play()
        {
            _management.Play(_index);
        }

        public void Ready()
        {
            _management.Ready();
        }
    }
}