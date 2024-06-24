using Saving;
using Zenject;

namespace Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            bindSaving();
        }

        private void bindSaving()
        {
            Container.Bind<ISavingService>().To<SavingService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SaveInitializer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SaveModel>().AsSingle().NonLazy();
        }
    }
}
