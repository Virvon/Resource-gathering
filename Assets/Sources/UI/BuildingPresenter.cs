using System;
using Sources.BasicLogic.Building;
using Sources.Infrastructure;
using Zenject;

namespace Sources.UI
{
    public class BuildingPresenter : IDisposable
    {
        private readonly BuildingView _view;
        private readonly Building _model;
        private readonly ResourcesBank _resourcesBank;

        public BuildingPresenter(BuildingView view, Building model, ResourcesBank resourcesBank)
        {
            _view = view;
            _model = model;
            _resourcesBank = resourcesBank;
            
            _view.SetName(_resourcesBank.GetCell(_model.ResourceType).Name);

            _model.AmountChanged += OnAmountChanged;
        }
        
        public void Dispose()
        {
            _model.AmountChanged -= OnAmountChanged;
        }

        private void OnAmountChanged(int amount)
        {
            _view.ChangeAmount(amount.ToString());
        }
        
        public class  Factory : PlaceholderFactory<BuildingView, Building, BuildingPresenter>
        {
        }
    }
}