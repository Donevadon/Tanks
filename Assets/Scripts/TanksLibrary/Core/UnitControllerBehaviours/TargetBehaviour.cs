namespace TanksLibrary.Core.UnitControllerBehaviours
{
    public class TargetBehaviour : ITargetSystem
    {
        private ITargetElement _target;
        
        public void SetTarget(ITargetElement target)
        {
            _target?.DisableHighlighting();
            _target = target;
            _target.EnableHighlighting();
        }
    }
}