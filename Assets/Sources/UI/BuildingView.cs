using TMPro;
using UnityEngine;

namespace Sources.UI
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _amountText;

        public void SetName(string name)
        {
            _nameText.text = name;
        }

        public void SetupAmount(string amount)
        {
            ChangeAmount(amount);
        }

        public void ChangeAmount(string amount)
        {
            _amountText.text = amount;
        }
    }
}