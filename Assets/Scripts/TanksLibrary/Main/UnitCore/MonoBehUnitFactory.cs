using System.Collections.Generic;
using LevelCore;
using TanksLibrary.Main.LevelCore;
using UnityEngine;

namespace TanksLibrary.Main.UnitCore
{
    public class MonoBehUnitFactory : IUnitFactory
    {
        private readonly LevelSettings _settings;
        
        public MonoBehUnitFactory(LevelSettings settings)
        {
            _settings = settings;
        }
        
        public List<IUnitLauncher> CreateUnits()
        {
            var unitList = new List<IUnitLauncher>();

            for (int i = 0; i < _settings.Count; i++)
            {
                var pack = _settings.GetUnitPosition(i);
                IUnitLauncher controller = Object.Instantiate(pack.Item1, pack.Item2,Quaternion.identity);
                unitList.Add(controller);
            }

            return unitList;
        }
    }
}