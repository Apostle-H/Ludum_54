using Core.Games;
using Input.Interactions;
using UnityEngine;
using VContainer;

namespace MiniGames.Flipper
{
    public class FlipperGameStarter : MonoBehaviour, IClickable
    {
        private MiniGamesManager _miniGamesManager;

        [Inject]
        private void Init(MiniGamesManager miniGamesManager) => _miniGamesManager = miniGamesManager;

        public void Pressed(Vector2 pos)
        {
            
        }

        public void Released(Vector2 pos)
        {
            _miniGamesManager.StartFlipperGame();
        }
    }
}