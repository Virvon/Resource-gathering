using Sources.Services.InputService;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.BasicLogic.Character
{
    public class MovementComponent
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly IInputService _inputService;

        public MovementComponent(NavMeshAgent navMeshAgent, IInputService inputService)
        {
            _navMeshAgent = navMeshAgent;
            _inputService = inputService;
        }

        public void Move(Vector3 position)
        {
            _navMeshAgent.SetDestination(position);
        }
    }
}