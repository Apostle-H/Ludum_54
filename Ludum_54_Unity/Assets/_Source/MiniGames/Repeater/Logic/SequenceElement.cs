using System;
using Input.Interactions;
using UnityEngine;
using VContainer;

namespace MiniGames.Repeater.Logic
{
    public class SequenceElement : MonoBehaviour, IClickable
    {
        public Guid Guid { get; private set; }

        public event Action<Guid> OnChosen; 

        [Inject]
        public void Init() => Guid = Guid.NewGuid();

        public void Pressed(Vector2 pos) { }

        public void Released(Vector2 pos) => OnChosen?.Invoke(Guid);
    }
}