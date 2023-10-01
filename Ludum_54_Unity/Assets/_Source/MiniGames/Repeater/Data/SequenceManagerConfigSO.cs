using UnityEditor;
using UnityEngine;

namespace MiniGames.Repeater.Data
{
    [CreateAssetMenu(menuName = "SO/MiniGames/Repeater/SequenceManagerConfigSO", fileName = "NewSequenceManagerConfigSO")]
    public class SequenceManagerConfigSO : ScriptableObject
    {
        [field: SerializeField] public int StepsCount { get; private set; }
    }
}