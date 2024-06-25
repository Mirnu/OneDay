using Level;
using Model;
using Saving;
using Zenject;

namespace Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            bindInput();
            bindSaving();
            bindModels();
            bindLevel();
        }

        private void bindInput()
        {
            Container.BindInterfacesAndSelfTo<KeyboardInput>().AsSingle();
        }

        private void bindSaving()
        {
            Container.Bind<ISavingService>().To<SavingService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SaveInitializer>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SaveModel>().AsSingle().NonLazy();
        }

        private void bindModels()
        {
            Container.BindInterfacesAndSelfTo<DialogsModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ChoisesModel>().AsSingle().NonLazy();
        }

        private void bindLevel()
        {
            Container.Bind<ILevelService>().To<LevelService>().AsSingle().NonLazy();
        }
    }
}
