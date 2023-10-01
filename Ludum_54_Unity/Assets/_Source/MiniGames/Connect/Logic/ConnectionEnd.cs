using System.Collections.Generic;
using Input.Interactions;
using MiniGames.Connect.Data;
using MiniGames.Connect.Signals;
using Snapping;
using UnityEngine;
using VContainer;

namespace MiniGames.Connect.Logic
{
    public class ConnectionEnd : MonoBehaviour, IDraggable
    {
        [SerializeField] private Block block;
        [SerializeField] private Socket startSocket;

        [SerializeField] private Socket correctSocket;

        private Socket _currentSocket;
        
        private ConnectionEndConfigSO _configSO;

        private ConnectionEndPlacedCorrectSignal _placedCorrectSignal;
        private ConnectionEndPlacedWrongSignal _placedWrongSignal;

        [Inject]
        private void Init(ConnectionEndConfigSO configSO) => _configSO = configSO;
        
        private void Awake()
        {
            _placedCorrectSignal = deVoid.Utils.Signals.Get<ConnectionEndPlacedCorrectSignal>();
            _placedWrongSignal = deVoid.Utils.Signals.Get<ConnectionEndPlacedWrongSignal>();
        }

        public void Pressed(Vector2 pos)
        {
            block.Disconnect();
        }

        public void Released(Vector2 pos)
        {
            if (!TryPlace())
            {
                ToStart();
            }
        }

        public void ToStart()
        {
            _currentSocket?.Disconnect();
            
            block.Connect(startSocket);
            startSocket.Connect(block);
        }

        public void Drag(Vector2 pos) => Move(pos);

        private bool TryPlace()
        {
            var raycastHits = new List<Collider2D>();
            if (Physics2D.OverlapBox(block.transform.position, block.BoxCollider2D.size, 0f, 
                    _configSO.SocketFilter, raycastHits) < 1)
                return false;

            var socketCollider = raycastHits[0];
            if (!socketCollider.TryGetComponent(out Socket socket) || socket.Taken)
                return false;

            _currentSocket = socket;
            
            block.Connect(socket);
            _currentSocket.Connect(block);

            if (socket == correctSocket)
                _placedCorrectSignal.Dispatch(this);
            else
                _placedWrongSignal.Dispatch(this);
            
            return true;
        }

        private void Move(Vector3 newPos) => transform.position = newPos;
    }
}