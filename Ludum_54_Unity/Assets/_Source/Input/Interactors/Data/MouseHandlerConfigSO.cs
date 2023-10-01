using UnityEngine;

namespace Input.Interactors.Data
{
    [CreateAssetMenu(menuName = "SO/Input/MouseHandlerConfigSO", fileName = "NewMouseHandlerConfigSO")]
    public class MouseHandlerConfigSO : ScriptableObject
    {
        [field: SerializeField] public ContactFilter2D InteractionFilter { get; private set; }
    }
}