using TanksLibrary.Main.UnitCore;
using UnityEngine;

namespace TanksLibrary.Main.Highlighting
{
    public class Lighting : MonoBehaviour, IHighlighting
    {
        public void EnableHighlighting()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void DisableHighlighting()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}