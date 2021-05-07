using UnityEngine;

namespace TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents
{
    public abstract class Track : MonoBehaviour, IRunningGear
    {
        public abstract Side Side { get; }
    
    }
}