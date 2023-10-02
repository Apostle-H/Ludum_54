using System.Collections.Generic;
using System.Linq;
using Input.Interactions;
using Memories.Meta;
using Memories.Puzzle.Data;
using Memories.Puzzle.Signals;
using Snapping;
using UnityEngine;
using VContainer;

namespace Memories.Puzzle
{
    public class PuzzlePart : MonoBehaviour, IDraggable
    {
        [field: SerializeField] public Block[] Blocks { get; private set; }
        [field: SerializeField] public Memory Memory { get; private set; }
        
        private PuzzlePartConfigSO _configSO;

        private MemoryShower _shower;

        private PuzzleBlockPlacedSignal _placedSignal;
        private PuzzleBlockMissedSignal _missedSignal;
        private PuzzlePartDisconnectedSignal _disconnectedSignal;

        private Vector2 startPos;
        
        public Socket[] Sockets { get; private set; }
        
        [Inject]
        private void Init(PuzzlePartConfigSO configSO, MemoryShower shower)
        {
            _configSO = configSO;
            _shower = shower;
        }

        private void Awake()
        {
            _placedSignal = deVoid.Utils.Signals.Get<PuzzleBlockPlacedSignal>();
            _missedSignal = deVoid.Utils.Signals.Get<PuzzleBlockMissedSignal>();

            Sockets = new Socket[Blocks.Length];
        }

        public void PickUp()
        {
            startPos = transform.position;
            
            foreach (var block in Blocks)
                block.Disconnect();
            
            _disconnectedSignal?.Dispatch(this);
        }

        public void Move(Vector3 newPos) => transform.position = newPos;
        
        public bool TryPlace()
        {
            for (var i = 0; i < Blocks.Length; i++)
            {
                var raycastHits = new List<Collider2D>();
                if (Physics2D.OverlapBox(Blocks[i].transform.position, Blocks[i].BoxCollider2D.size, 0f, 
                        _configSO.SocketFilter, raycastHits) < 1)
                    return false;

                var socketCollider = raycastHits[0];
                if (!socketCollider.TryGetComponent(out Socket socket) || socket.Taken)
                    return false;

                Sockets[i] = socket;
            }

            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].Connect(Sockets[i]);
                Sockets[i].Connect(Blocks[i]);
            }
            
            return true;
        }

        public void Pressed(Vector2 _) => PickUp();

        public void Drag(Vector2 pos) => Move(pos);

        public void Released(Vector2 _)
        {
            if (((Vector2)transform.position - startPos).magnitude < .2f)
            {
                _shower.Show(Memory);
            }
            
            if (TryPlace())
                _placedSignal?.Dispatch(this);
            else
                _missedSignal?.Dispatch(this);
        }
    }
}