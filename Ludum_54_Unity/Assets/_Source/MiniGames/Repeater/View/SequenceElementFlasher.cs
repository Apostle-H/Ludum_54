using DG.Tweening;
using MiniGames.Repeater.Data;
using MiniGames.Repeater.Logic;
using UnityEngine;
using VContainer;

namespace MiniGames.Repeater.View
{
    public class SequenceElementFlasher : MonoBehaviour
    {
        [field: SerializeField] public SequenceElement Element { get; private set; }

        [SerializeField] private SpriteRenderer showRenderer;
        [SerializeField] private SpriteRenderer pressRenderer;

        private SequenceElementFlasherConfigSO _configSO;

        public Sequence ShowFlashSequence { get; private set; }
        public Sequence PressFlashSequence { get; private set; }

        [Inject]
        private void Init(SequenceElementFlasherConfigSO configSO)
        {
            _configSO = configSO;
            InitSequence();
        }

        private void InitSequence()
        {
            ShowFlashSequence = GetNewShowFlashSequence();

            PressFlashSequence = GetNewPressFlashSequence();
        }

        private Sequence GetNewShowFlashSequence()
        {
            var showFlashSequence = DOTween.Sequence();
            showFlashSequence.SetAutoKill(false);
            showFlashSequence.Pause();
            
            showFlashSequence.Append(showRenderer.DOColor(_configSO.ShowFlashColor, _configSO.ShowFlashTime));
            showFlashSequence.AppendInterval(_configSO.ShowStayTime);
            showFlashSequence.Append(showRenderer.DOColor(Color.white, _configSO.ShowFadeTime));
            return showFlashSequence;
        }
        
        private Sequence GetNewPressFlashSequence()
        {
            var pressFlashSequence = DOTween.Sequence();
            pressFlashSequence.SetAutoKill(false);
            pressFlashSequence.Pause();

            pressFlashSequence.Append(pressRenderer.DOColor(_configSO.PressFlashColor, _configSO.PressFlashTime));
            pressFlashSequence.AppendInterval(_configSO.PressStayTime);
            pressFlashSequence.Append(pressRenderer.DOColor(Color.white, _configSO.PressFadeTime));
            return pressFlashSequence;
        }
    }
}