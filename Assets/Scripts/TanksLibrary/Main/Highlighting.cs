using UnityEngine;

namespace TanksLibrary.Main
{
    public class Highlighting : MonoBehaviour
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