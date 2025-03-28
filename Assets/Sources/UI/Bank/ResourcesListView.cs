using UnityEngine;

namespace Sources.UI.Bank
{
    public class ResourcesListView : ListView<ResourceView>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        
        public void Show()
        {
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
        }
    }
}