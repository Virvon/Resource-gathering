using Sources.BasicLogic.Building;
using Sources.BasicLogic.Character;
using Sources.Infrastructure;
using Sources.Services.AssetMenagement;
using Sources.Services.InputService;
using Sources.UI;
using UnityEngine;
using Zenject;

namespace Sources.Installellers
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private ResourceCell[] _cells;
        [SerializeField] private Transform _uiConatainer;
        public override void InstallBindings()
        {
            BindInputService();
            BindCharacterFactory();
            BindCamera();
            BindBank();
            Container.BindInstance(_uiConatainer).AsSingle();
            Container.BindFactory<BuildingView, Building, BuildingPresenter, BuildingPresenter.Factory>();
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