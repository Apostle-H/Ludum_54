using Input.Interactions;
using UnityEngine;

namespace Memories.Puzzle
{
    public class MemoriesGameEnder : MonoBehaviour, IClickable
    {
        [SerializeField] private MemoriesGame memoriesGame;
        
        public void Pressed(Vector2 pos)
        {
            
        }

        public void Released(Vector2 pos)
        {
            memoriesGame.Close();
        }
    }
}