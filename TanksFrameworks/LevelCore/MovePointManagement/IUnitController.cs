namespace LevelCore.MovePointManagement
{
    public interface IUnitController
    {
        void MoveTo(Vector2 movePoint);
        void EnableHighlighting();
        void DisableHighlighting();
    }
}