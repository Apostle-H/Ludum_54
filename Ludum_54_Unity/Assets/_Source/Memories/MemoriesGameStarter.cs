using Input.Interactions;
using UnityEngine;

namespace Memories
{
    public class MemoriesGameStarter : MonoBehaviour, IClickable
    {
        [SerializeField] private MemoriesGame memoriesGame;

        public void Pressed(Vector2 pos) { }

        public void Released(Vector2 pos)
        {
            memoriesGame.Open();
            gameObject.SetActive(false);
        }
    }
}