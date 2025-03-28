using Sources.Services.InputService;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Sources.UI.Bank
{
    public class IgnoreInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService) =>
            _inputService = inputService;

        public void OnPointerEnter(PointerEventData eventData) =>
            _inputService.SetActive(false);

        public void OnPointerExit(PointerEventData eventData) =>
            _inputService.SetActive(true);
    }
}