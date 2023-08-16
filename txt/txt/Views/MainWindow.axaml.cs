using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;
using Microsoft.Win32;
using ReactiveUI;
using System;
using txt.ViewModels;

namespace txt.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new TxtViewModel();
        }


        public async Task GetPath()
        {

            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "Text", Extensions = { "txt" } });
            dialog.AllowMultiple = true;
            var result = await dialog.ShowAsync(this);
            
           // if (result != null)
           // {
           //     await GetPath();
           // }

        }

        public void OnBrowseClicked(object sender, RoutedEventArgs args)
        {
            var context = this.DataContext as TxtViewModel;
           // context.Path = "path";
            GetPath();
        }
    }
}