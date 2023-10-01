using System;
using UnityEngine;

namespace MiniGames.Flipper.Data
{
    [Serializable]
    public class FlipperGameSceneConfig
    {
        [field: SerializeField] public FlipperGame FlipperGame { get; private set; }
    }
}