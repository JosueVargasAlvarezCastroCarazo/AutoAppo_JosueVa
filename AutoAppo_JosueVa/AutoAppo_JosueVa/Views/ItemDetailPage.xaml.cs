using AutoAppo_JosueVa.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AutoAppo_JosueVa.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}