using Sources.Services.InputService;
using UnityEngine;
using Zenject;

namespace Sources.BasicLogic.Sound
{
    public class ClickSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audio;
        
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void OnEnable() =>
            _inputService.Clicked += OnClicked;

        private void OnDisable() =>
            _inputService.Clicked -= OnClicked;

        private void OnClicked(Vector2 obj) =>
            _audio.Play();
    }
}