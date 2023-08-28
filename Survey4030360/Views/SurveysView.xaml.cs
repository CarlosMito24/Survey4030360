using Survey4030360.Data;
using Survey4030360.Models;
using System.Collections.ObjectModel;

namespace Survey4030360.Views;

public partial class SurveysView : ContentPage
{
    SurveyItemDatabase database;
    public ObservableCollection<SurveyItem> Items { get; set; } = new();
    public SurveysView(SurveyItemDatabase surveyItemDatabase)
	{
		InitializeComponent();
        database = surveyItemDatabase;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);
        });
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SurveyDetailsView), true, new Dictionary<string, object>
        {
            ["Item"] = new SurveyItem()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not SurveyItem item)
            return;

        await Shell.Current.GoToAsync(nameof(SurveyDetailsView), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}