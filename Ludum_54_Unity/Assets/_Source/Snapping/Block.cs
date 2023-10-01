using UnityEngine;

namespace Snapping
{
    public class Block : MonoBehaviour
    {
        [field: SerializeField] public BoxCollider2D BoxCollider2D { get; private set; }
        
        private Socket _currentSocket;
        
        public bool Connected { get; private set; }
        public Socket CurrentSocket => _currentSocket;

        public void Connect(Socket socket)
        {
            _currentSocket = socket;
            
            transform.position = _currentSocket.transform.position;
            Connected = true;
        }

        public void Disconnect()
        {
            if (!Connected)
                return;

            _currentSocket.Disconnect();
            _currentSocket = default;
            Connected = false;
        }
    }
}