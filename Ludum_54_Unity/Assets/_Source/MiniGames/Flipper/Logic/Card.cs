using System;
using DG.Tweening;
using Input.Interactions;
using UnityEngine;

namespace MiniGames.Flipper.Logic
{
    public class Card : MonoBehaviour, IClickable
    {
        [SerializeField] private Animator _animator;
        public event Action<Card> OnSelected;

        private bool interactable = true;

        private Sequence openSequence;
        private Sequence closeSequence;

        public int index;

        private void Awake()
        {
            InitSequence();
        }

        private void OnEnable()
        {
            interactable = true;
        }

        private void InitSequence()
        {
            openSequence = DOTween.Sequence();
            openSequence.SetAutoKill(false);
            openSequence.Pause();

            openSequence.AppendCallback(() => _animator.SetTrigger("Open"));
            openSequence.AppendInterval(0.4f);
            openSequence.AppendCallback(() => OnSelected?.Invoke(this));
            openSequence.AppendCallback(() => interactable = false);
            
            closeSequence = DOTween.Sequence();
            closeSequence.SetAutoKill(false);
            closeSequence.Pause();
            
            closeSequence.AppendCallback(() => _animator.SetTrigger("Close"));
            closeSequence.AppendInterval(0.2f);
            closeSequence.AppendCallback(() => interactable = true);
        }

        public void Pressed(Vector2 pos) { }

        public void Released(Vector2 pos)
        {
            if (!interactable)
                return;
            
            openSequence.Restart();
        }

        public void Close()
        {
            closeSequence.Restart();
        }

        public void Match()
        {
            gameObject.SetActive(false);
        }
    }
}