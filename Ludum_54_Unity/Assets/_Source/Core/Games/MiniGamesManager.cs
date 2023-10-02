using System;
using Memories.Meta;
using Memories.Meta.Data;
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

        [SerializeField] private int maxLost;

        private MemoryPool _memoryPool;

        private bool _hasStartGame;

        private bool _playedConnected;
        private bool _playerFlipper;
        private bool _playerRepeater;

        private int _counter;

        public event Action OnGamesComplete;
        public event Action OnGamesLost;

        [Inject]
        public void Init(ConnectGame connectGame, FlipperGame flipperGame, RepeaterGame repeaterGame, MemoryPool memoryPool)
        {
            _connectGame = connectGame;
            _flipperGame = flipperGame;
            _repeaterGame = repeaterGame;

            _memoryPool = memoryPool;

            _connectGame.OnWin += WinConnected;
            _connectGame.OnLose += Lose;
            _repeaterGame.OnWin += WinRepeater;
            _repeaterGame.OnLose += Lose;
            _flipperGame.OnWin += WinFlipper;
            _flipperGame.OnLose += Lose;
        }

        public void Restart()
        {
            _playedConnected = false;
            _playerFlipper = false;
            _playerRepeater = false;
        }

        private void WinConnected()
        {
            _memoryPool.ObtainMemory(MemoryType.Personal);
            _playedConnected = true;
            
            Win();
        }

        private void WinRepeater()
        {
            _memoryPool.ObtainMemory(MemoryType.Gang);
            _playerRepeater = true;
            Win();
        }

        private void WinFlipper()
        {
            _memoryPool.ObtainMemory(MemoryType.Family);
            _playerFlipper = true;
            Win();
        }

        private void Win()
        {
            CloseGame();

            if (_playedConnected && _playerRepeater && _playerFlipper)
                OnGamesComplete?.Invoke();
        }

        private void Lose()
        {
            CloseGame();

            _counter++;
            if (_counter >= maxLost)
                OnGamesLost?.Invoke();
        }

        private void CloseGame()
        {
            connectGameParent.gameObject.SetActive(false);
            flipperGameParent.gameObject.SetActive(false);
            repeaterGameParent.gameObject.SetActive(false);
            _hasStartGame = false;
        }

        public void StartConnectGame()
        {
            if (_hasStartGame || _playedConnected)
                return;
            
            connectGameParent.gameObject.SetActive(true);
            ((IMiniGame)_connectGame).Start();
            
            _hasStartGame = true;
        }
        
        public void StartFlipperGame()
        {
            if (_hasStartGame || _playerFlipper)
                return;
            
            flipperGameParent.gameObject.SetActive(true);
            ((IMiniGame)_flipperGame).Start();
            _hasStartGame = true;
        }
        
        public void StartRepeaterGame()
        {
            if (_hasStartGame || _playerRepeater)
                return;
            
            repeaterGameParent.gameObject.SetActive(true);
            ((IMiniGame)_repeaterGame).Start();
            
            _hasStartGame = true;
        }
    }
}