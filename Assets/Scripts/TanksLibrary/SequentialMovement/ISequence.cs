namespace SequentialMovement
{
    public interface ISequence
    {
        void Play();
        void Rewind();
        void AddMove(Vector2 movePoint);
        void AddRotate(Vector2 movePoint);
        Vector2 RecordAndGetLastPosition(out Vector2 lastRotation);
    }
}