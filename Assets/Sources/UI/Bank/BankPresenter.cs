using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Infrastructure;
using UnityEngine.Events;
using Zenject;

namespace Sources.UI.Bank
{
    public class BankPresenter : IInitializable, IDisposable
    {
        private readonly ResourcesBank _model;
        private readonly ResourcesListView _listView;

        private List<ResourcePresenter> _presenters;

        public BankPresenter(ResourcesBank model, ResourcesListView listView)
        {
            _model = model;
            _listView = listView;

            _presenters = new();
        }
        
        public void Initialize()
        {
            foreach(ResourceCell cell in _model)
            {
                ResourceView view = _listView.SpawnItem();
                ResourcePresenter resourcePresenter = new(cell, view);

                _presenters.Add(resourcePresenter);
            }
        }

        public void Dispose()
        {
            foreach(var presenter in _presenters)
            {
                presenter.Dispose();
                _listView.UnspawnItem(presenter.View);
            }
        }
    }
}