namespace TanksLibrary.Core
{
    public interface IControllerBinder<in T>
    {
        void ControllerBind(T controller);
    }
}