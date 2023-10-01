using System.Collections.Generic;
using Input.Interactions;
using Input.Interactors.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils.Camera;

namespace Input.Interactors
{
    public class MouseHandler
    {
        private MouseHandlerConfigSO _configSO;
        private MainActions.MouseMapActions _mouseActions;

        private IClickable _currentClickable;
        private IDraggable _currentDraggable;

        private Vector2 _dragOffSet;

        public MouseHandler(MouseHandlerConfigSO configSO, MainActions.MouseMapActions mouseActions)
        {
            _configSO = configSO;
            _mouseActions = mouseActions;
        }

        public void Bind()
        {
            _mouseActions.Click.started += Pressed;
            _mouseActions.Click.canceled += Released;
        }

        private void Pressed(InputAction.CallbackContext ctx)
        {
            var worldPoint = GetMouseWorldPos();

            var raycastHits = new List<RaycastHit2D>();
            if (Physics2D.Raycast(worldPoint, Vector2.zero, _configSO.InteractionFilter, raycastHits) < 1)
                return;
            
            var hit = raycastHits[0];
            if (hit.rigidbody == null || !hit.rigidbody.TryGetComponent(out _currentClickable))
                return;

            _currentClickable.Pressed(worldPoint);

            if (!hit.transform.TryGetComponent(out _currentDraggable))
                return;

            _dragOffSet = hit.transform.position - (Vector3)worldPoint;
            _mouseActions.Drag.performed += Drag;
        }

        private void Drag(InputAction.CallbackContext ctx) => _currentDraggable.Drag(GetMouseWorldPos() + _dragOffSet);

        private void Released(InputAction.CallbackContext ctx)
        {
            if (_currentDraggable != null)
            {
                _mouseActions.Drag.performed -= Drag;
                _currentDraggable = null;
            }

            if (_currentClickable != null)
            {
                _currentClickable.Released(GetMouseWorldPos());
                _currentClickable = null;
            }
        }

        private Vector2 GetMouseWorldPos()
        {
            var screenPoint = _mouseActions.Drag.ReadValue<Vector2>();
            CameraService.UpdateCamera();
            return CameraService.ScreenToWorldPoint(screenPoint);
        }
    }
}