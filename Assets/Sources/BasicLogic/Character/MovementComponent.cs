using Sources.Services.InputService;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.BasicLogic.Character
{
    public class MovementComponent
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly IInputService _inputService;
        private readonly Animator _animator;

        private bool _isMoved;

        public MovementComponent(NavMeshAgent navMeshAgent, IInputService inputService, Animator animator)
        {
            _navMeshAgent = navMeshAgent;
            _inputService = inputService;
            _animator = animator;

            _isMoved = false;
        }

        public void Move(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
        }

        public void Tick()
        {
            if (_isMoved && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _isMoved = false;
                _animator.SetBool(AnimationPathes.IsMovening, _isMoved);
            }
            else if (_isMoved == false && _navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
            {
                _isMoved = true;
                _animator.SetBool(AnimationPathes.IsMovening, _isMoved);
            }
        }
    }
}