using LevelCore;
using TanksLibrary.Main.UnitCore;
using UnityEngine;
using UnityEngine.UI;

namespace TanksLibrary.Main.LevelCore
{
    public class MonoBehLevelManager : MonoBehaviour, ICommanderFactory
    {
        private LevelManagement _management;
        [SerializeField]private Text _numberProgress;
        [SerializeField] private LevelSettings playerLevelSettings;
        [SerializeField] private LevelSettings enemyLevelSettings;
        
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
            _management.SetupCurrentIndex(index);
            _numberProgress.text = index.ToString();
        }
        
        public void Play()
        {
            _management.Play();
        }

        public void Ready()
        {
            _management.Ready();
        }
    }
}