
namespace SequentialMovement
{
    public interface ISequenceFactory
    {
        ISequence Create(Vector2 startPosition);
    }
}