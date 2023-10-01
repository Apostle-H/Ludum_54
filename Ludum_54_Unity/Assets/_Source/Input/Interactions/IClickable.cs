
using UnityEngine;

namespace Input.Interactions
{
    public interface IClickable
    {
        public void Pressed(Vector2 pos);
        public void Released(Vector2 pos);
    }
}