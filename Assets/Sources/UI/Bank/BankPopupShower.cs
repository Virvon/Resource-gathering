using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Bank
{
    public class BankPopupShower : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private ResourcesListView _resourcesListView;

        private bool _isShowed;

        private void Start()
        {
            _isShowed = false;
            
            ChangeBankPopupState(_isShowed);
        }

        private void OnEnable() =>
            _button.onClick.AddListener(OnButtonClicked);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnButtonClicked);

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