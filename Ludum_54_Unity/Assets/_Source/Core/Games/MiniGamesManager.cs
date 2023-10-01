using MiniGames;
using MiniGames.Connect;
using MiniGames.Flipper;
using MiniGames.Repeater;
using UnityEngine;
using VContainer;

namespace Core.Games
{
    public class MiniGamesManager : MonoBehaviour
    {
        private ConnectGame _connectGame;
        private FlipperGame _flipperGame;
        private RepeaterGame _repeaterGame;

        [SerializeField] private GameObject connectGameParent;
        [SerializeField] private GameObject flipperGameParent;
        [SerializeField] private GameObject repeaterGameParent;

        private bool _hasStartGame;

        [Inject]
        public void Init(ConnectGame connectGame, FlipperGame flipperGame, RepeaterGame repeaterGame)
        {
            _connectGame = connectGame;
            _flipperGame = flipperGame;
            _repeaterGame = repeaterGame;

            _connectGame.OnWin += CloseGame;
            _connectGame.OnLose += CloseGame;
            _repeaterGame.OnWin += CloseGame;
            _repeaterGame.OnLose += CloseGame;
            _flipperGame.OnWin += CloseGame;
            _flipperGame.OnLose += CloseGame;
        }

        public void CloseGame()
        {
            connectGameParent.gameObject.SetActive(false);
            flipperGameParent.gameObject.SetActive(false);
            repeaterGameParent.gameObject.SetActive(false);
            _hasStartGame = false;
        }

        public void StartConnectGame()
        {
            if (_hasStartGame)
                return;
            
            ((IMiniGame)_connectGame).Start();
            connectGameParent.gameObject.SetActive(true);
            _hasStartGame = true;
        }
        
        public void StartFlipperGame()
        {
            if (_hasStartGame)
                return;
            
            ((IMiniGame)_flipperGame).Start();
            flipperGameParent.gameObject.SetActive(true);
            _hasStartGame = true;
        }
        
        public void StartRepeaterGame()
        {
            if (_hasStartGame)
                return;
            
            ((IMiniGame)_repeaterGame).Start();
            repeaterGameParent.gameObject.SetActive(true);
            _hasStartGame = true;
        }

        private void Win()
        {
            
        }
    }
}