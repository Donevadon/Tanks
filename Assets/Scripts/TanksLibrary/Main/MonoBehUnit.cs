using UnityEngine;

namespace TanksLibrary.Main
{
    public class MonoBehUnit : MonoBehaviour
    {
        //private Tank _tank;
        
        private void Awake()
        {
            /*_tank = new Tank(this,
                new Target(),
                GetComponentInChildren<Highlighting>());*/
        }

        /*public ITowerController GetTowerController()
        {
            return new MockTower(); //transform.GetComponentInChildren<ITowerController>();
        }
        */

        /*public ITransmissionController GetTransmissionController()
        {
            return GetComponentInChildren<ITransmissionController>();
        }
        */

        /*public void Play(int index)
        {
            _tank.Play(index);
        }

        public void Ready()
        {
            _tank.Ready();
        }

        private void OnMouseDown()
        {
            _tank.OnClick();
        }*/
    }

    public class MockTower 
    {
        public void Play(int index)
        {
            
        }

        public void Ready()
        {
            
        }
    }
}