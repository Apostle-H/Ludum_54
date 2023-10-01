using System;
using UnityEngine;

namespace Input.Interactors.Data
{
    [Serializable]
    public class InteractionsScope
    {
        [field: SerializeField] public MouseHandlerConfigSO MouseHandlerConfigSO { get; private set; }
    }
}