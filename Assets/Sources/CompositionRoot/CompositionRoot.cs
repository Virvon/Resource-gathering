using System;
using Sources.BasicLogic.Character;
using Sources.Services.AssetMenagement;
using UnityEngine;
using Zenject;

namespace Sources.CompositionRoot
{
    public class CompositionRoot : MonoBehaviour
    {
        private Character.Factory _characterFactory;

        [Inject]
        private void Construct(Character.Factory characterFactory)
        {
            _characterFactory = characterFactory;
        }
        
        private void Start()
        {
            _characterFactory.Create(AssetPathes.Character);
        }
    }
}