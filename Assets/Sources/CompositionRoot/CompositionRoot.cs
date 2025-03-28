using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sources.BasicLogic.Building;
using Sources.BasicLogic.Character;
using Sources.Services.AssetMenagement;
using Sources.UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Sources.CompositionRoot
{
    public class CompositionRoot : MonoBehaviour
    {
        private readonly Vector3 _viewOffset = new Vector3(0, 2, 0);
        
        [SerializeField] private BuildingData[] _buildings;
        [FormerlySerializedAs("_resourceViewPrefab")] [SerializeField] private BuildingView buildingViewPrefab;
        
        private Character.Factory _characterFactory;
        private BuildingPresenter.Factory _buildingPresenterFactory;
        
        private List<IDisposable> _disposables;

        [Inject]
        private void Construct(Character.Factory characterFactory, BuildingPresenter.Factory buildingPresenterFactory)
        {
            _characterFactory = characterFactory;
            _buildingPresenterFactory = buildingPresenterFactory;

            _disposables = new();
        }

        private void OnDestroy()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
            
            _disposables.Clear();
        }

        private void Start()
        {
            _characterFactory.Create(AssetPathes.Character);

            foreach (BuildingData _buildingData in _buildings)
            {
                Building building = Instantiate(_buildingData.Prefab, _buildingData.Position, Quaternion.identity);
                BuildingView buildingView = Instantiate(
                    buildingViewPrefab,
                    _buildingData.Position + _viewOffset,
                    Quaternion.Euler(30, 45, 0));

                _disposables.Add(_buildingPresenterFactory.Create(buildingView, building));
            }
        }
    }
}