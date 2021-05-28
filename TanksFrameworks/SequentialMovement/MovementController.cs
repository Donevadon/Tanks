using System;
using System.Collections.Generic;

namespace SequentialMovement
{
    public class MovementController : ISequenceController
    {
        private readonly List<ISequence> _sequences;
        private readonly ISequencePacker _packer;

        protected MovementController(ISequencePacker packer)
        {
            _packer = packer;
            _sequences = new List<ISequence>();
        }

        
        public void Play(int index)
        {
            if (index == _sequences.Count)
            {
                var cs = _packer.Repackage();
                cs.Play();
            }
            else
            {
                _sequences[index].Restart();
            }
        }
        
        
        public void MoveTo(Vector2 movePoint)
        {
            _packer.AddRotate(movePoint);
            _packer.AddMove(movePoint);
        }

        
        public void RotateTo(Vector2 rotatePoint)
        {
            throw new NotImplementedException();
        }
        

        public void Record()
        {
            ISequence cs = _packer.Package();
            _sequences.Add(cs);
        }
    }
}