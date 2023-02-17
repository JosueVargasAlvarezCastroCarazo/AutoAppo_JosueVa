using AutoAppo_JosueVa.Services;
using AutoAppo_JosueVa.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_JosueVa
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            App.Current.UserAppTheme = OSAppTheme.Light;
            MainPage = new NavigationPage(new AppoLoginPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
