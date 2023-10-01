using UnityEngine;

namespace Memories.Puzzle.Data
{
    [CreateAssetMenu(menuName = "SO/Memories/Puzzle/PuzzleBlockConfigSO", fileName = "NewPuzzleBlockConfigSO")]
    public class PuzzlePartConfigSO : ScriptableObject
    {
        [field: SerializeField] public ContactFilter2D SocketFilter { get; private set; }
    }
}