using System;
using UnityEngine;

namespace MiniGames.Flipper.Data
{
    [Serializable]
    public class FlipperScope
    {
        [field: SerializeField] public FlipperGameSceneConfig FlipperGameSceneConfig { get; private set; }
    }
}