using System;
using DG.Tweening;
using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents.TransmissionComponents
{
    public class Transmission : MonoBehaviour, IControllerBinder<ITransmissionController>
    {
        private Track LeftTrack { get; set; }

        private Track RightTrack { get; set; }

        private Transform _bodyTransform;
        private Transform BodyTransform => _bodyTransform != null 
            ? _bodyTransform 
            : (_bodyTransform = transform.parent != null
                ? transform.parent 
                : transform);
        

        void IControllerBinder<ITransmissionController>.ControllerBind(ITransmissionController controller)
        {
            controller.OnMoveTo += ControllerOnOnMoveTo;
        }

        private void ControllerOnOnMoveTo(object sender, Vector2 e)
        {
            MoveTo(e);
        }
        
        private void MoveTo(Vector2 vector2)
        {
            var seq = DOTween.Sequence(); //TODO:Вынести управление анимацией в отдельный статичный класс
            var position = (Vector2)BodyTransform.position;
            var distance = Vector2.Distance(position, vector2);
        
            seq.Append(BodyTransform.DORotate(position.AngleParse(vector2), 1));
            seq.Append(BodyTransform.DOMove(vector2, distance / 2f));
        }


        private void Awake()
        {
            InitTracks();
        }

        private void InitTracks()
        {
            var factory = CreateTrackFactory();
            LeftTrack = factory.GetLeftTrack();
            RightTrack = factory.GetRightTrack();
        }

        protected virtual ITrackFactory CreateTrackFactory()
        {
            return new MonoBehaviorTrackFactory(this);
        }
    }
}