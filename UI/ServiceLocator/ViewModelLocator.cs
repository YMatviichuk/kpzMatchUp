using Ninject;
using UI.ViewModels;

namespace UI.ServiceLocator
{
    class ViewModelLocator
    {
        public GameViewModel GameViewModel => App.Ninjectkernel.Get<GameViewModel>();
        public MainMenuViewModel MainMenuViewModel => App.Ninjectkernel.Get<MainMenuViewModel>();
    }
}
