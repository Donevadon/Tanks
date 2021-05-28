namespace LevelCore
{
    public interface ICommanderFactory
    {
        UnitCommander CreateEnemyCommander();
        UnitCommander CreatePlayerCommander();
    }
}