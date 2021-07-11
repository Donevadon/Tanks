using LevelCore.MovePointManagement;
using UnityEngine;
using Vector2 = LevelCore.MovePointManagement.Vector2;

namespace TanksLibrary.Main.UICommandPanel
{
    public class MovePointUI : MonoBehaviour
    {
        private TargetManagement _targetController;

        private void Awake()
        { 
            _targetController = new TargetManagement();
        }

        
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _targetController.SetMove(new Vector2(){X = pos.x,Y = pos.y});
            }
        }
    }
}
