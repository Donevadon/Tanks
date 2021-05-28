using UnityEngine;

namespace TanksLibrary.Main
{
    [CreateAssetMenu(menuName = "LevelSettings", fileName = "LevelSettings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField]private MonoBehUnit[] units;
        [SerializeField]private Vector2[] positions;

        public int Count => units.Length;

        public (MonoBehUnit, Vector2) GetUnitPosition(int index)
        {
            var unit = units[index];
            var position = positions[index];
            return (unit, position);
        }
    }
}