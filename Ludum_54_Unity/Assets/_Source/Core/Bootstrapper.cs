using System;
using Input;
using Input.Interactors;
using MiniGames;
using MiniGames.Connect;
using MiniGames.Flipper;
using MiniGames.Flipper.Data;
using MiniGames.Repeater;
using UnityEngine;
using VContainer;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private MainActions _inputActions;
        private MouseHandler _mouseHandler;
        
        [Inject]
        private void Init(MainActions inputActions, MouseHandler mouseHandler, RepeaterGame repeaterGame, ConnectGame connectGame, FlipperGame flipperGame)
        {
            _inputActions = inputActions;
            _mouseHandler = mouseHandler;
        }
        
        private void Awake()
        {
            _inputActions.Enable();
            _mouseHandler.Bind();
        }
    }
}