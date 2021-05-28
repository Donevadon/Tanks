using LevelCore.MovePointManagement;
using LevelCore.UnitSystem;

namespace Transmission
{
    public interface IMovementController
    {
        void Play(int index);
        void MoveTo(Vector2 movePoint);
        void RotateTo(Vector2 rotatePoint);
        void Ready();
    }
}