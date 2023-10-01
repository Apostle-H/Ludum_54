using System;
using UnityEngine;

namespace MiniGames.Repeater.Data
{
    [Serializable]
    public class RepeaterGameScope
    {
        [field: SerializeField] public RepeatedGameSceneConfig RepeatedGameSceneConfig { get; private set; }
        [field: SerializeField] public SequenceManagerConfigSO SequenceManagerConfigSO { get; private set; }
        [field: SerializeField] public SequenceElementFlasherConfigSO SequenceElementFlasherConfigSO { get; private set; }
    }
}