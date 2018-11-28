using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using GameBin;
using Ninject;
using Ninject.Modules;
using UI.ViewModels;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public static StandardKernel Ninjectkernel { get; private set; }

        public App()
        {
            IocConfiguration configuration = new IocConfiguration();
            Ninjectkernel = new StandardKernel(configuration);
        }
    }

    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<GameViewModel>().ToSelf().InTransientScope();
            Bind<MainMenuViewModel>().ToSelf().InSingletonScope();
        }
    }
}
