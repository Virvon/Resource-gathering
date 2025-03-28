using Sources.Services.InputService;
using UnityEngine;
using Zenject;

namespace Sources.BasicLogic.CameraLogic
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _sensiviety;
        [SerializeField] private Vector2 _bordersX;
        [SerializeField] private Vector2 _bordersZ;

        private Vector2 _lastHandlePosition;
        
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void OnEnable()
        {
            _inputService.Dragged += OnDragged;
            _inputService.ClickStarted += OnClickStarted;
        }
        
        private void OnDisable()
        {
            _inputService.Dragged -= OnDragged;
            _inputService.ClickStarted -= OnClickStarted;
        }

        private void OnDragged(Vector2 handlePosition)
        {
            Vector2 hangleDelta = _lastHandlePosition - handlePosition;
            Vector3 delta = new Vector3(hangleDelta.x, 0, hangleDelta.y);
            
            _lastHandlePosition = handlePosition;

            delta *= _sensiviety;
            delta = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * delta;

            Vector3 position = new Vector3(
                transform.position.x + delta.x,
                transform.position.y,
                transform.position.z + delta.z);

            position = new Vector3(
                Mathf.Clamp(position.x, _bordersX.x, _bordersX.y),
                position.y,
                Mathf.Clamp(position.z, _bordersZ.x, _bordersZ.y));
            
            transform.localPosition = position;
        }
        
        private void OnClickStarted(Vector2 handlePosition) =>
            _lastHandlePosition = handlePosition;
    }
}