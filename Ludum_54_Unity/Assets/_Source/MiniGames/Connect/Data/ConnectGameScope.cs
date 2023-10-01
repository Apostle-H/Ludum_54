using System;
using UnityEngine;

namespace MiniGames.Connect.Data
{
    [Serializable]
    public class ConnectGameScope
    {
        [field: SerializeField] public ConnectGameSceneConfig ConnectGameSceneConfig { get; private set; }
        [field: SerializeField] public ConnectionEndConfigSO ConnectionEndConfigSO { get; private set; }
    }
}