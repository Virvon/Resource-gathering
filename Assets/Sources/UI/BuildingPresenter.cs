using System;
using Sources.BasicLogic.Building;
using Sources.Infrastructure;
using Zenject;

namespace Sources.UI
{
    public class BuildingPresenter : IDisposable
    {
        private readonly ResourceView _view;
        private readonly Building _model;
        private readonly ResourcesBank _resourcesBank;

        public BuildingPresenter(ResourceView view, Building model, ResourcesBank resourcesBank)
        {
            _view = view;
            _model = model;
            _resourcesBank = resourcesBank;
            
            _view.SetName(_resourcesBank.GetCell(_model.ResourceType).Name);
            _view.Setup(_model.Amount.ToString());

            _model.AmountChanged += OnAmountChanged;
        }

        void IDisposable.Dispose() =>
            _model.AmountChanged -= OnAmountChanged;

        private void OnAmountChanged(int amount) =>
            _view.ChangeAmount(amount.ToString());

        public class  Factory : PlaceholderFactory<ResourceView, Building, BuildingPresenter>
        {
        }
    }
}