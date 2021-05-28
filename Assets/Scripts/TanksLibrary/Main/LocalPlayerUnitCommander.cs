using System.Collections.Generic;
using LevelCore;
using UnityEngine;

namespace TanksLibrary.Main
{
    public class LocalPlayerUnitCommander : UnitCommander
    {
        public LocalPlayerUnitCommander(IUnitFactory factory) : base(factory)
        {
        }
    }
}