using Sources.Infrastructure;

namespace Sources.UI.Bank
{
    public class ResourcePresenter
    {
        public readonly ResourceView View;
        
        private readonly ResourceCell _model;
        
        public ResourcePresenter(ResourceCell model, ResourceView view)
        {
            _model = model;
            View = view;

            View.Setup(_model.Amount.ToString());
            View.SetName(_model.Name);
            
            _model.OnAmountChanged += OnAmountChanged;
        }

        public void Dispose()
        {
            _model.OnAmountChanged -= OnAmountChanged;
        }

        private void OnAmountChanged(int amount)
        {
            View.ChangeAmount(amount.ToString());
        }
    }
}