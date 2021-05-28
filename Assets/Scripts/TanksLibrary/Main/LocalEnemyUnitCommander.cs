using System.Collections.Generic;
using LevelCore;
using UnityEngine;

namespace TanksLibrary.Main
{
    public class LocalEnemyUnitCommander : UnitCommander
    {
        public LocalEnemyUnitCommander(IUnitFactory factory) : base(factory)
        {
        }
    }
}