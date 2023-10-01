using Data;
using UnityEngine;

namespace Snapping
{
    public class Socket : MonoBehaviour
    {
        [field: SerializeField] public Socket TopNeighbour { get; private set; }
        [field: SerializeField] public Socket BottomNeighbour { get; private set; }
        [field: SerializeField] public Socket LeftNeighbour { get; private set; }
        [field: SerializeField] public Socket RightNeighbour { get; private set; }

        public bool Taken { get; private set; }

        public Block CurrentBlock { get; private set; }
        
        public void Connect(Block block)
        {
            if (Taken)
                return;

            CurrentBlock = block;
            Taken = true;
        }

        public void Disconnect()
        {
            if (!Taken)
                return;

            CurrentBlock = default;
            Taken = false;
        }

        public Socket this[Side side] =>
            side switch
            {
                Side.Top => TopNeighbour,
                Side.Bottom => BottomNeighbour,
                Side.Left => LeftNeighbour,
                Side.Right => RightNeighbour,
                _ => null
            };
    }
}