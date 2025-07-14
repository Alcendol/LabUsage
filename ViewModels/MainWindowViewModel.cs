using Avalonia.Controls;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using LabUsage.Views;
using Microsoft.VisualBasic;

namespace LabUsage.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public string Greeting { get; } = "Welcome to Avalonia Coy!";
    public Interaction<Unit, Unit> ShowLoginInteraction { get; } = new();

    public ReactiveCommand<Unit, Unit> ShowLoginCommand { get; }

    public MainWindowViewModel()
    {
        ShowLoginCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await ShowLoginInteraction.Handle(Unit.Default).ToTask();
        });
    }
}
