using System.Linq;
using Snapping;
using UnityEngine;

namespace MiniGames.Connect.Logic
{
    public class EndSocketsRandomizer : MonoBehaviour
    {
        [SerializeField] private Transform[] pivotPoints;
        [SerializeField] private Socket[] endSockets;

        public void Randomize()
        {
            var randomSockets = endSockets.OrderBy(socket => Random.value).ToArray();
            for (int i = 0; i < randomSockets.Length; i++)
                randomSockets[i].transform.position = pivotPoints[i].position;
        }
    }
}