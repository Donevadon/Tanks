using LevelCore.MovePointManagement;

namespace LevelCore.UnitSystem
{
    public class Unit : IUnitLauncher
    {
        private readonly TargetManagement _target;
        private readonly IComponentFacade _components;

        protected Unit(IComponentFacade components)
        {
            _components = components;
            _target = new TargetManagement();
        }


        public void Play(int index)
        {
            _components.Play(index);
        }

        
        public void Ready()
        {
            _components.Ready();
        }


        public void OnClick()
        {
            var controller = (IUnitController)_components;
            _target.SetTarget(controller);
        }
    }
}