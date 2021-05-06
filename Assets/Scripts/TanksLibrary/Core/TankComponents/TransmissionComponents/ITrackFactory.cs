using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents;

namespace TanksLibrary.Core.TankComponents.TransmissionComponents
{
    public interface ITrackFactory
    {
        Track GetLeftTrack();
        Track GetRightTrack();
    }
}