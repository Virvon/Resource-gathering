using Sources.Services.InputService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Sources.UI.Bank
{
    public class BankPopupShower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Button _button;
        [SerializeField] private ResourcesListView _resourcesListView;

        private bool _isShowed;
        private IInputService _inputService;


        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _isShowed = false;
            
            ChangeBankPopupState(_isShowed);
        }

        private void OnEnable() =>
            _button.onClick.AddListener(OnButtonClicked);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnButtonClicked);

        public void OnPointerEnter(PointerEventData eventData) =>
            _inputService.SetActive(false);

        public void OnPointerExit(PointerEventData eventData) =>
            _inputService.SetActive(true);

        private void OnButtonClicked() =>
            ChangeBankPopupState(_isShowed == false);

        private void ChangeBankPopupState(bool isActive)
        {
            if (isActive)
                _resourcesListView.Show();
            else
                _resourcesListView.Hide();

            _isShowed = isActive;
        }

        
    }
}