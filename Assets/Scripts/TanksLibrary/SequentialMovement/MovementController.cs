using System;
using System.Collections.Generic;
using System.Linq;

namespace SequentialMovement
{
    public class MovementController : ISequenceController
    {
        private readonly ISequenceFactory _sequenceFactory;
        private readonly List<ISequence> _sequences;
        private ISequence _playingSequence = null;

        public MovementController(ISequenceFactory sequenceFactory,Vector2 startPosition, Vector2 startRotation)
        {
            _sequenceFactory = sequenceFactory;
            _sequences = new List<ISequence>()
            {
                _sequenceFactory.Create(startPosition, startRotation)
            };
            _playingSequence = _sequences[0];
        }

        
        public void NextMotion()
        {
            var lastSequence = _sequences.Last();
            var lastPosition = lastSequence.RecordAndGetLastPosition(out var lastRotation);
            _sequences.Add(_sequenceFactory.Create(lastPosition, lastRotation));
            lastSequence.Rewind();
        }
        
        
        public void SetIndex(int index)
        {
            _playingSequence.Rewind();
            if(--index > _sequences.Count)
                return;
            
            _playingSequence = _sequences[index];
            _playingSequence.Rewind();
        }
        
        
        public void Play()
        {
            _playingSequence.Rewind();
            _playingSequence.Play();
        }


        public void MoveTo(Vector2 movePoint)
        {
            RotateTo(movePoint);
            _playingSequence.AddMove(movePoint);
        }


        public void RotateTo(Vector2 rotatePoint)
        {
            _playingSequence.AddRotate(rotatePoint);
        }
    }
}