using System.Collections.Generic;
using Memories.Meta;
using Memories.Meta.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Ending
{
    public class EndingShower : MonoBehaviour
    {
        [SerializeField] private MemoryPool _memoryPool;

        [SerializeField] private GameObject endingPanel;
        [SerializeField] private Image endingImage;
        
        [SerializeField] private Sprite familyEnding;
        [SerializeField] private Sprite personalEnding;
        [SerializeField] private Sprite gangEnding;

        public void Show()
        {
            endingPanel.SetActive(true);
            
            switch (Analise())
            {
                case MemoryType.Family:
                    endingImage.sprite = familyEnding;
                    break;
                case MemoryType.Personal:
                    endingImage.sprite = personalEnding;
                    break;
                case MemoryType.Gang:
                    endingImage.sprite = gangEnding;
                    break;
            }
        }

        private MemoryType Analise()
        {
            Dictionary<MemoryType, int> memoriesCount = new Dictionary<MemoryType, int>();
            foreach (var savedMemory in _memoryPool.SavedMemories)
            {
                if (!memoriesCount.ContainsKey(savedMemory.Key))
                {
                    memoriesCount.Add(savedMemory.Key, 0);
                }

                memoriesCount[savedMemory.Key]++;
            }

            if (memoriesCount[MemoryType.Family] > memoriesCount[MemoryType.Personal])
            {
                return memoriesCount[MemoryType.Family] > memoriesCount[MemoryType.Gang] ? MemoryType.Family : MemoryType.Gang;
            }
            
            return memoriesCount[MemoryType.Personal] > memoriesCount[MemoryType.Gang] ? MemoryType.Personal : MemoryType.Gang;
        }
    }
}