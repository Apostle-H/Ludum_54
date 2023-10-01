using System;
using UnityEngine;

namespace Memories.Puzzle.Data
{
    [Serializable]
    public class PuzzleScope
    {
        [field: SerializeField] public PuzzlePartConfigSO PuzzlePartConfigSO { get; private set; }
    }
}