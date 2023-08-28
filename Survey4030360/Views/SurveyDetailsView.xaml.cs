using Survey4030360.Data;
using Survey4030360.Models;

namespace Survey4030360.Views;

[QueryProperty("Item", "Item")]

public partial class SurveyDetailsView : ContentPage
{
    SurveyItem item;
    public SurveyItem Item
    {
        get => BindingContext as SurveyItem;
        set => BindingContext = value;
    }

    SurveyItemDatabase database;
    public SurveyDetailsView(SurveyItemDatabase surveyItemDatabase)
    {
        InitializeComponent();
        database = surveyItemDatabase;

    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please insert a name for To Do item", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}