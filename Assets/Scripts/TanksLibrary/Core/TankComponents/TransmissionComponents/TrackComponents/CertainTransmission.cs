namespace TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents
{
    public class CertainTransmission : Transmission
    {
        protected override ITrackFactory CreateTrackFactory()
        {
            return new MonoBehaviorTrackFactory(this);
        }
    }
}