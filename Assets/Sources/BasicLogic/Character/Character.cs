using Sources.Infrastructure;
using Sources.Services.InputService;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Zenject;

namespace Sources.BasicLogic.Character
{
    public class Character : MonoBehaviour
    {
        private const float RaycastDistance = 100;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _runAudioSource;
        [SerializeField] private AudioSource _picupAudioSource;
        
        private Camera _camera;
        private IInputService _inputService;

        private bool _isMoved;
        private Building.Building _targetBuilding;
        private ResourcesBank _resourcesBank;

        [Inject]
        private void Construct(IInputService inputService, Camera camera, ResourcesBank resourcesBank)
        {
            _camera = camera;
            _inputService = inputService;
            _resourcesBank = resourcesBank;

            _isMoved = false;
        }
        
        private void OnEnable()
        {
            _inputService.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            _inputService.Clicked -= OnClicked;
        }

        private void Update()
        {
            if (_isMoved && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _isMoved = false;
                _animator.SetBool(AnimationPathes.IsMovening, _isMoved);
                _runAudioSource.Stop();

                if (_targetBuilding != null)
                    Pickup();
            }
            else if (_isMoved == false && _navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
            {
                _isMoved = true;
                _animator.SetBool(AnimationPathes.IsMovening, _isMoved);
                _runAudioSource.Play();
            }
        }

        private void Pickup()
        {
            if(_targetBuilding.Amount <= 0)
                return;
            
            _animator.SetTrigger(AnimationPathes.Pickup);
            _picupAudioSource.Play();
            _targetBuilding.CollectResorces(_resourcesBank);
            _targetBuilding = null;
        }

        private void OnClicked(Vector2 position)
        {
            Ray ray = _camera.ScreenPointToRay(position);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, RaycastDistance))
            {
                _navMeshAgent.SetDestination(hitInfo.point);
                hitInfo.transform.TryGetComponent(out _targetBuilding);
            }
        }

        public class Factory : PlaceholderFactory<string, Character>
        {
            
        }
    }
}