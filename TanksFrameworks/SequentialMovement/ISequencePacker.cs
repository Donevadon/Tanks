namespace SequentialMovement
{
    public interface ISequencePacker
    {
        ISequence Repackage();
        ISequence Package();
        void AddRotate(Vector2 movePoint);
        void AddMove(Vector2 movePoint);
    }
}