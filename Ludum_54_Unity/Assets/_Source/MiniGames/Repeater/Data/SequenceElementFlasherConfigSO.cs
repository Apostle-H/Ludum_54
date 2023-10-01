using UnityEngine;

namespace MiniGames.Repeater.Data
{
    [CreateAssetMenu(menuName = "SO/MiniGames/Repeater/SequenceElementFlasherConfigSO", fileName = "NewSequenceElementFlasherConfigSO")]
    public class SequenceElementFlasherConfigSO : ScriptableObject
    {
        [field: SerializeField] public Color ShowFlashColor { get; private set; }
        [field: SerializeField] public float ShowFlashTime { get; private set; }
        [field: SerializeField] public float ShowStayTime { get; private set; }
        [field: SerializeField] public float ShowFadeTime { get; private set; }

        public float FullShowFlashDuration => ShowFlashTime + ShowStayTime + ShowFadeTime;
        
        [field: SerializeField] public Color PressFlashColor { get; private set; }
        [field: SerializeField] public float PressFlashTime { get; private set; }
        [field: SerializeField] public float PressStayTime { get; private set; }
        [field: SerializeField] public float PressFadeTime { get; private set; }
        
        public float FullPressFlashDuration => PressFlashTime + PressStayTime + PressFadeTime;
    }
}