using MVVM;
using MVVM.ViewModels;
using Zenject;
using ZenjectClasses.Example;

namespace ZenjectClasses
{
    public class GameplayInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMvvm();
                
            Container.Bind<string>().FromInstance("Hello World!");
            Container.Bind<FooClass>().AsSingle().NonLazy();
        }

        private void BindMvvm()
        {
            Container.Bind<Model>().AsSingle().NonLazy();
            Container.Bind<ExampleViewModel>().AsSingle().NonLazy();
            Container.Bind<SkillsViewModel>().AsSingle().NonLazy();
        }
    }
}