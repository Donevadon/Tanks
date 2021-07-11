using LevelCore.MovePointManagement;

namespace LevelCore.UnitSystem
{
    public class Unit : IUnitLauncher
    {
        private readonly IComponentFacade _components;
        private readonly TargetManagement _target;

        public Unit(IComponentFacade components)
        {
            _components = components;
            _target = new TargetManagement();
        }


        public void Play()
        {
            _components.Play();
        }


        public void Ready()
        {
            _components.Ready();
        }


        public void SetupCurrentIndex(int index)
        {
            _components.SetupCurrentIndex(index);
        }


        public void OnClick()
        {
            var controller = (IUnitController) _components;
            _target.SetTarget(controller);
        }
    }
}