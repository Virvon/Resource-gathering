using Sources.BasicLogic.Building;
using Sources.BasicLogic.Character;
using Sources.BasicLogic.Sound;
using Sources.Infrastructure;
using Sources.Services.AssetMenagement;
using Sources.UI;
using Sources.UI.Bank;
using UnityEngine;
using Zenject;

namespace Sources.Installellers
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private ResourceCell[] _cells;
        [SerializeField] private ResourcesListView _bankResourcesListView;
        [SerializeField] private SoundManagment _soundManagment;
        [SerializeField] private BuildingData[] _buildingDatas;
        [SerializeField] private ResourceView _buildingViewPrefab;
        
        public override void InstallBindings()
        {
            BindCharacterFactory();
            BindCamera();
            BindBank();
            BindBuildingPresenterFactory();
            BindBankPresenter();
            BindSoundMeangment();
            BindBuidlings();
        }

        private void BindBuidlings()
        {
            Container.BindInstance(_buildingDatas).AsSingle();
            Container.BindInstance(_buildingViewPrefab).AsSingle();
        }

        private void BindSoundMeangment() =>
            Container.BindInstance(_soundManagment).AsSingle();

        private void BindBankPresenter() =>
            Container.BindInterfacesTo<BankPresenter>().AsSingle().WithArguments(_bankResourcesListView).NonLazy();

        private void BindBuildingPresenterFactory() =>
            Container.BindFactory<ResourceView, Building, BuildingPresenter, BuildingPresenter.Factory>();

        private void BindBank() =>
            Container.Bind<ResourcesBank>().AsSingle().WithArguments(_cells);

        private void BindCamera() =>
            Container.BindInstance(_camera).AsSingle();

        private void BindCharacterFactory()
        {
            Container
                .BindFactory<string, Character, Character.Factory>()
                .FromFactory<KeyPrefabFactory<Character>>();
        }
    }
}