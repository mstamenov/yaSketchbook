using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;
using yaSketchbook.Data.Repositories;
using yaSketchbook.Models.Models;

namespace yaSketchbook.MVVM.ViewModels;

public partial class DrawingViewModel : BaseViewModel
{
    private readonly IDrawingsRepository _drawingsRepository;
    private readonly int _currentId = 1;
    
    public ObservableCollection<DrawingLine> Lines { get; set; } = new();

    public DrawingViewModel(IDrawingsRepository drawingsRepository)
    {
        this._drawingsRepository = drawingsRepository;
    }
    
    [RelayCommand]
    async void DrawLineCompleted()
    {
        var drawing = await _drawingsRepository.FindAsync(_currentId);
        drawing.Json = JsonSerializer.Serialize(Lines);

        await _drawingsRepository.UpdateAsync(drawing);
    }

    [RelayCommand]
    void PageAppearing()
    {
    }
}
