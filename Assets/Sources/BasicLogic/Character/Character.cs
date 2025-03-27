using System;
using Sources.Services.InputService;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Sources.BasicLogic.Character
{
    public class Character : EntitiObject
    {
        private const float RaycastDistance = 50;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        private Camera _camera;
        private IInputService _inputService;
        
        private MovementComponent _moveComponent;

        [Inject]
        private void Construct(IInputService inputService, Camera camera)
        {
            _camera = camera;
            _inputService = inputService;

            _moveComponent = new MovementComponent(_navMeshAgent, inputService);
        }

        private void OnEnable()
        {
            _inputService.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            _inputService.Clicked -= OnClicked;
        }

        private void OnClicked(Vector2 position)
        {
            Ray ray = _camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, RaycastDistance))
            {
                _moveComponent.Move(hitInfo.point);
            }
        }

        public class Factory : PlaceholderFactory<string, Character>
        {
            
        }
    }
}