using System;
using MiniGames.Repeater.Logic;
using MiniGames.Repeater.View;
using UnityEngine;

namespace MiniGames.Repeater.Data
{
    [Serializable]
    public class RepeatedGameSceneConfig
    {
        [field: SerializeField] public SequenceElement[] Elements { get; private set; }
        [field: SerializeField] public SequenceElementFlasher[] ElementsFlashers { get; private set; }
    }
}