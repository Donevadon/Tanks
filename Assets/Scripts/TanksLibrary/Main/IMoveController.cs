using UnityEngine;
namespace TanksLibrary.Main
{
    internal interface IMoveController
    {
        void Play(int index);
        void MoveTo(Vector2 movePPoint);
        void RotateTo(Vector2 vector2);
        void Ready();
    }
}