namespace SequentialMovement
{
    public interface ISequenceController
    {
        void Play();
        void MoveTo(Vector2 movePoint);
        void RotateTo(Vector2 rotatePoint);
        void NextMotion();
        void SetIndex(int index);
    }
}