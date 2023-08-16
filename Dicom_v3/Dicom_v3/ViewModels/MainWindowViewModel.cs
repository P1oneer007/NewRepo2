using ReactiveUI;
using System;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Dialogs;
using System.Threading.Tasks;
using System.Windows;
using Window = Avalonia.Controls.Window;
using Dicom_v3;
using Dicom_v3.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private DicomInfoViewModel _dicomInfoViewModel;
    public DicomInfoViewModel DicomInfoViewModel
    {
        get => _dicomInfoViewModel;
        set => this.RaiseAndSetIfChanged(ref _dicomInfoViewModel, value);
    }

    private string _currentDicomPath;
    public string CurrentDicomPath
    {
        get => _currentDicomPath;
        set => this.RaiseAndSetIfChanged(ref _currentDicomPath, value);
    }

    public ReactiveCommand<Unit, Unit> OpenDicomCommand { get; }

    public MainWindowViewModel()
    {
        OpenDicomCommand = ReactiveCommand.CreateFromTask(OpenDicom);
    }

    private async Task OpenDicom()
    {
        var openFileDialog = new OpenFileDialog();
        //var result = await openFileDialog.ShowAsync((Window)Application.Current.MainWindow);
       // if (result != null)
       // {
        //   CurrentDicomPath = result[0];
      //  }
    }
}