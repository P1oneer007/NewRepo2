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
using System.Linq;

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
   // private MainWindowViewModel _dicomFileViewModel;
    private Window _localWindow;
    // public void SetDicomFileViewModel(MainWindowViewModel value)
    // {
    //     this.RaiseAndSetIfChanged(ref _dicomFileViewModel, value);
    //  }
    private string _filePath;
    public string FilePath
    {
        get => _filePath;
        set => this.RaiseAndSetIfChanged(ref _filePath, value);
    }
    public ReactiveCommand<Unit, Unit> OpenDicomCommand { get; }

    public MainWindowViewModel(Window localWindow)
    {
        OpenDicomCommand = ReactiveCommand.CreateFromTask(OpenDicom);
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filters.Add(new FileDialogFilter() { Name = "DICOM Files", Extensions = { "dcm" } });
        //var result = openFileDialog.ShowAsync(this);

        // Обновление свойства CurrentDicomPath во ViewModel
      //  ViewModel.CurrentDicomPath = result.Result.FirstOrDefault();
        // OpenDicomCommand.ThrownExceptions.Subscribe(ex => Console.WriteLine(ex));
        // SetDicomFileViewModel(this);
        _localWindow = localWindow;
    }

    private async Task OpenDicom()
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filters.Add(new FileDialogFilter { Extensions = { "dcm" }, Name = "DICOM Dump" });
       // var window = _localWindow;
       // var result = await openFileDialog.ShowAsync(window);
        //var result = await openFileDialog.ShowAsync((Window)Application.Current.MainWindow);
       //  if (result != null)
       //  {
        //   CurrentDicomPath = result[0];
        //  }
    }

    private async Task OpenFileAsync()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filters.Add(new FileDialogFilter { Extensions = { "dcm" }, Name = "DICOM Dump" });
        var window = _localWindow;
        var result = await openFileDialog.ShowAsync(window);
        foreach (var filePath in result)
        {
            FilePath = filePath;
        }
    }

}