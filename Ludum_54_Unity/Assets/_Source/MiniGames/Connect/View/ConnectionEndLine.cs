using System;
using Snapping;
using UnityEngine;
using UnityEngine.Serialization;

namespace MiniGames.Connect.View
{
    public class ConnectionEndLine : MonoBehaviour
    {
        [SerializeField] private Block block;
        [SerializeField] private Socket socket;

        [SerializeField] private LineRenderer lineRenderer;
        
        public void Update()
        {
            lineRenderer.SetPosition(0, block.transform.position);
            lineRenderer.SetPosition(1, socket.transform.position);
        }
    }
}