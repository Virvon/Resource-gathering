using Sources.BasicLogic.Building;
using Sources.BasicLogic.Character;
using Sources.BasicLogic.Sound;
using Sources.Infrastructure;
using Sources.Services.AssetMenagement;
using Sources.Services.InputService;
using Sources.Services.SaveLoadService;
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
        public override void InstallBindings()
        {
            BindInputService();
            BindCharacterFactory();
            BindCamera();
            BindBank();
            Container.BindFactory<ResourceView, Building, BuildingPresenter, BuildingPresenter.Factory>();
            Container.BindInterfacesTo<BankPresenter>().AsSingle().WithArguments(_bankResourcesListView).NonLazy();
            Container.Bind<SaveLoadService>().AsSingle();
            Container.BindInstance(_soundManagment).AsSingle();
        }

        private void BindBank()
        {
            Container.Bind<ResourcesBank>().AsSingle().WithArguments(_cells);
        }

        private void BindCamera()
        {
            Container.BindInstance(_camera).AsSingle();
        }

        private void BindCharacterFactory()
        {
            Container
                .BindFactory<string, Character, Character.Factory>()
                .FromFactory<KeyPrefabFactory<Character>>();
        }

        private void BindInputService()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                
            }
            else if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                Container.BindInterfacesTo<DesktopInputService>().AsSingle();
            }
        }
    }
}