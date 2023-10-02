using Input.Interactions;
using UnityEngine;

namespace Memories.Meta
{
    public class MemoryCloser : MonoBehaviour, IClickable
    {
        [SerializeField] private MemoryShower _shower;
        
        public void Pressed(Vector2 pos)
        {
            
        }

        public void Released(Vector2 pos)
        {
            _shower.Hide();
        }
    }
}