using System;
using deVoid.Utils;
using Memories.Meta;
using Memories.Meta.Data;
using Memories.Puzzle;
using Memories.Puzzle.Signals;
using UnityEngine;

namespace Memories
{
    public class MemoriesGame : MonoBehaviour
    {
        [SerializeField] private MemoryPool _memoryPool;

        [SerializeField] private GameObject parentHolder;

        [SerializeField] private Transform[] pivotPoints;

        private PuzzleBlockPlacedSignal _puzzleBlockPlacedSignal;
        private PuzzlePartDisconnectedSignal _puzzlePartDisconnectedSignal;

        public event Action OnGameEnded; 
        
        private void Awake()
        {
            _puzzleBlockPlacedSignal = Signals.Get<PuzzleBlockPlacedSignal>();
            _puzzlePartDisconnectedSignal = Signals.Get<PuzzlePartDisconnectedSignal>();
            
            _puzzleBlockPlacedSignal.AddListener(Save);
            _puzzlePartDisconnectedSignal.AddListener(Unsave);
        }

        public void Open()
        {
            parentHolder.SetActive(true);

            _memoryPool.ObtainedMemories[MemoryType.Family][0].gameObject.SetActive(true);
            _memoryPool.ObtainedMemories[MemoryType.Family][0].transform.position = pivotPoints[0].position;
            _memoryPool.ObtainedMemories[MemoryType.Personal][0].gameObject.SetActive(true);
            _memoryPool.ObtainedMemories[MemoryType.Personal][0].transform.position = pivotPoints[1].position;
            _memoryPool.ObtainedMemories[MemoryType.Gang][0].gameObject.SetActive(true);
            _memoryPool.ObtainedMemories[MemoryType.Gang][0].transform.position = pivotPoints[2].position;
        }

        public void Close()
        {
            parentHolder.SetActive(false);
            
            _memoryPool.DeleteMemories();
            
            OnGameEnded?.Invoke();
        }

        private void Save(PuzzlePart puzzlePart)
        {
            _memoryPool.SaveMemory(puzzlePart.Memory);
        }

        private void Unsave(PuzzlePart puzzlePart)
        {
            _memoryPool.UnSaveMemory(puzzlePart.Memory);
        }
    }
}