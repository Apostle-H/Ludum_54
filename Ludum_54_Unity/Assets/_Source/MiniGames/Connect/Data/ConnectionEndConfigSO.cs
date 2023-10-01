using UnityEngine;

namespace MiniGames.Connect.Data
{
    [CreateAssetMenu(menuName = "SO/MiniGames/Connect/ConnectionEndConfigSO", fileName = "NewConnectionEndConfigSO")]
    public class ConnectionEndConfigSO : ScriptableObject
    {
        [field: SerializeField] public ContactFilter2D SocketFilter { get; private set; }
    }
}