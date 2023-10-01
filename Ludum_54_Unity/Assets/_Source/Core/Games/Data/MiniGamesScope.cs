using System;
using UnityEngine;

namespace Core.Games.Data
{
    [Serializable]
    public class MiniGamesScope
    {
        [field: SerializeField] public MiniGamesManager MiniGamesManager { get; private set; }
    }
}