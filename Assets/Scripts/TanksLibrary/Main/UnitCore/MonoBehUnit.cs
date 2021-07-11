using LevelCore;
using LevelCore.MovePointManagement;
using LevelCore.UnitSystem;
using TanksLibrary.Main.UnitCore.Components;
using UnityEngine;
using Vector2 = LevelCore.MovePointManagement.Vector2;

namespace TanksLibrary.Main.UnitCore
{
    public class MonoBehUnit : MonoBehaviour,IComponentFacade
    {
        private Unit _tank;

        private IHighlighting _highlighting;
        private MonoBehTransmission _transmission;
        
        private void Awake()
        {
            _tank = new Unit(this);
            _highlighting = GetComponentInChildren<IHighlighting>();
            _transmission = GetComponentInChildren<MonoBehTransmission>();
        }


        void IUnitLauncher.Play()
        {
            _transmission.Play();
        }
        
        void IUnitLauncher.Ready()
        {
            _transmission.Ready();
        }
        
        void IUnitLauncher.SetupCurrentIndex(int index)
        {
            _transmission.SetupCurrentIndex(index);
        }
        

        void IUnitController.MoveTo(Vector2 movePoint)
        {
            _transmission.MoveTo(new UnityEngine.Vector2(movePoint.X,movePoint.Y));
        }
        
        void IUnitController.EnableHighlighting()
        {
            _highlighting.EnableHighlighting();
        }
        
        void IUnitController.DisableHighlighting()
        {
            _highlighting.DisableHighlighting();
        }
        
        
        private void OnMouseDown()
        {
            _tank.OnClick();
        }
    }
}