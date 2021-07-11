namespace LevelCore.MovePointManagement
{
    public class TargetManagement
    {
        private static IUnitController _target;

        private static IUnitController Target
        {
            get => _target;
            set
            {
                _target?.DisableHighlighting();
                _target = value;
                _target.EnableHighlighting();
            }
        }


        internal void SetTarget(IUnitController target)
        {
            Target = target;
        }


        public void SetMove(Vector2 movePoint)
        {
            Target.MoveTo(movePoint);
        }
    }
}