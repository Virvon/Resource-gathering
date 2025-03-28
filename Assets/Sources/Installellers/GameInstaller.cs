using Sources.Services.InputService;
using Sources.Services.SaveLoadService;
using UnityEngine;
using Zenject;

namespace Sources.Installellers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindSaveLoadService();
        }

        private void BindSaveLoadService() =>
            Container.Bind<SaveLoadService>().AsSingle();


        private void BindInputService()
        {
            if (SystemInfo.deviceType == DeviceType.Desktop)
                Container.BindInterfacesTo<DesktopInputService>().AsSingle();
            else
                Container.BindInterfacesTo<MobileInputService>().AsSingle();
        }
    }
}