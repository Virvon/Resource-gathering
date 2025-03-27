using Sources.BasicLogic.Character;
using Sources.Services.AssetMenagement;
using Sources.Services.InputService;
using UnityEngine;
using Zenject;

namespace Sources.Installellers
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindCharacterFactory();
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