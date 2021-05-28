namespace TanksLibrary.Core.TankComponents.TransmissionComponents
{
    public interface ITrackFactory
    {
        IRunningGear GetLeftTrack();
        IRunningGear GetRightTrack();
    }
}