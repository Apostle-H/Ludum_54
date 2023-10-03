using System.Collections.Generic;
using Memories.Meta.Data;
using UnityEngine;

namespace Memories.Meta
{
    public class MemoryPool : MonoBehaviour
    {
        [SerializeField] private Memory[] memories;

        public Dictionary<MemoryType, List<Memory>> MemoriesByType { get; private set; }
        public Dictionary<MemoryType, List<Memory>> ObtainedMemories { get; private set; }
        public Dictionary<MemoryType, List<Memory>> SavedMemories { get; private set; }
        
        private void Awake()
        {
            MemoriesByType = new Dictionary<MemoryType, List<Memory>>();
            ObtainedMemories = new Dictionary<MemoryType, List<Memory>>();
            SavedMemories = new Dictionary<MemoryType, List<Memory>>();
            
            foreach (var memory in memories)
            {
                if (!MemoriesByType.ContainsKey(memory.MemoryType))
                    MemoriesByType.Add(memory.MemoryType, new List<Memory>());

                MemoriesByType[memory.MemoryType].Add(memory);
            }
            
            ObtainedMemories.Add(MemoryType.Family, new List<Memory>());
            ObtainedMemories.Add(MemoryType.Personal, new List<Memory>());
            ObtainedMemories.Add(MemoryType.Gang, new List<Memory>());
            
            SavedMemories.Add(MemoryType.Family, new List<Memory>());
            SavedMemories.Add(MemoryType.Personal, new List<Memory>());
            SavedMemories.Add(MemoryType.Gang, new List<Memory>());
        }

        public void ObtainMemory(MemoryType memoryType)
        {
            ObtainedMemories[memoryType].Add(MemoriesByType[memoryType][0]);
            
            MemoriesByType[memoryType].RemoveAt(0);
        }

        public void SaveMemory(Memory memory)
        {
            SavedMemories[memory.MemoryType].Add(memory);
            
            ObtainedMemories[memory.MemoryType].Remove(memory);
            Debug.Log(1);
        }

        public void UnSaveMemory(Memory memory)
        {
            ObtainedMemories[memory.MemoryType].Add(memory);
            
            SavedMemories[memory.MemoryType].Remove(memory);
        }

        public void DeleteMemories()
        {
            foreach (var memory in ObtainedMemories[MemoryType.Family])
                memory.gameObject.SetActive(false);
            
            foreach (var memory in ObtainedMemories[MemoryType.Personal])
                memory.gameObject.SetActive(false);
            
            foreach (var memory in ObtainedMemories[MemoryType.Gang])
                memory.gameObject.SetActive(false);
            
            ObtainedMemories[MemoryType.Family].Clear();
            ObtainedMemories[MemoryType.Personal].Clear();
            ObtainedMemories[MemoryType.Gang].Clear();
        }
    }
}