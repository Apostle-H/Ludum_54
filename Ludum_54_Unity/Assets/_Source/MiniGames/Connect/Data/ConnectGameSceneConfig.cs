using System;
using MiniGames.Connect.Logic;
using UnityEngine;

namespace MiniGames.Connect.Data
{
    [Serializable]
    public class ConnectGameSceneConfig
    {
        [field: SerializeField] public EndSocketsRandomizer EndSocketsRandomizer { get; private set; }
        [field: SerializeField] public ConnectionEnd[] ConnectionEnds { get; private set; }
    }
}