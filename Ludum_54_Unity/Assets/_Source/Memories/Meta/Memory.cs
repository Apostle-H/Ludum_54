using Memories.Meta.Data;
using UnityEngine;

namespace Memories.Meta
{
    public class Memory : MonoBehaviour
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: TextArea, SerializeField] public string Text { get; private set; }
        [field: SerializeField] public MemoryType MemoryType { get; private set; }
    }
}