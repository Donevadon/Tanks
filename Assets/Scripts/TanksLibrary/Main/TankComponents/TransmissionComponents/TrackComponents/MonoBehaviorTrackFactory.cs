using System;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents
{
    public class MonoBehaviorTrackFactory : ITrackFactory
    {
        private readonly Track[] _tracks;
        
        public MonoBehaviorTrackFactory(MonoBehaviour behaviour)
        {
            _tracks = behaviour.GetComponentsInChildren<Track>();
        }
        
        
        public IRunningGear GetLeftTrack()
        {
            return GetTrack(Side.Left);
        }
        
        private Track GetTrack(Side side)
        {
            foreach (var track in _tracks)
            {
                if (track.Side == side) return track; 
            }
            throw new AggregateException($"{side.ToString()} track not found");
        }

        
        public IRunningGear GetRightTrack() 
        { 
            return GetTrack(Side.Right);
        }
        
    }
}