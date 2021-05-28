using System.Collections.Generic;

namespace LevelCore
{
    public interface IUnitFactory
    {
        List<IUnitLauncher> CreateUnits();
    }
}