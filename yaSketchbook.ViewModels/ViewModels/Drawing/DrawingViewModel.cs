using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text.Json;
using yaSketchbook.Data.Repositories;
using yaSketchbook.Models.Models;
using yaSketchbook.ViewModels.Core;

namespace yaSketchbook.ViewModels;

public partial class DrawingViewModel : BaseViewModel
{
    private readonly IDrawingsRepository drawingsRepository;

    [ObservableProperty]
    private int maxId;
    
    [ObservableProperty]
    ObservableCollection<IDrawingLine> lines;

    public DrawingViewModel(IDrawingsRepository drawingsRepository)
    {
        this.MaxId = 1;
        this.Lines = new ();
        this.drawingsRepository = drawingsRepository;
    }
    
    [RelayCommand]
    async Task DrawLineCompleted()
    {
        this.MaxId = (await this.drawingsRepository.ToListAsync()).Count;
        await Task.FromResult(0);
    }

    [RelayCommand]
    async Task SaveAsync() 
    {
        var allDrawings = await this.drawingsRepository.ToListAsync();
        var drawing = new Drawing
        {
            ModifyDate = DateTime.Now,
            CreateDate = DateTime.Now,
            Name = $"Test {allDrawings.Count + 1}",
            Json = JsonSerializer.Serialize(this.Lines)
        };

        await this.drawingsRepository.AddAsync(drawing);
    }

    public async Task ReloadDrawingAsync(int id)
    {
        var drawing = await this.drawingsRepository.FindAsync(id);
        var savedLines = JsonSerializer.Deserialize<List<DrawingLine>>(drawing.Json);

        this.Lines.Clear();
        savedLines.ForEach(x => this.Lines.Add(x));
    }
}
