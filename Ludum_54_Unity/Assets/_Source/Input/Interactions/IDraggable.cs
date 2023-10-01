using UnityEngine;

namespace Input.Interactions
{
    public interface IDraggable : IClickable
    {
        public void Drag(Vector2 pos);
    }
}