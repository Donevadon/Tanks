using UnityEngine;

namespace TanksLibrary.Main
{
    public class MovePointUI : MonoBehaviour
    {
        //private TargetController _targetController;

        private void Awake()
        {
           // _targetController = new TargetController();
        }

        void Start()
        {
        
        }

    
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //_targetController.MoveTo(new Vector2(){X = pos.x,Y = pos.y});
            }
        }
    }
}
