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
            await DisplayAlert("Falta el del nombre de encuestado", "Ingrese el nombre del encuestado", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Item.Dia))
        {
            await DisplayAlert("Falta el d�a en la fecha de nacimiento de encuestado", "Ingrese el d�a en la fecha de nacimiento del encuestado", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Item.Mes))
        {
            await DisplayAlert("Falta el mes en la fecha de nacimiento de encuestado", "Ingrese el mes en la fecha de nacimiento del encuestado", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Item.A�o))
        {
            await DisplayAlert("Falta el a�o en la fecha de nacimiento de encuestado", "Ingrese el a�o en la fecha de nacimiento del encuestado", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Item.EquipoFavorito))
        {
            await DisplayAlert("Falta el equipo favorito", "Ingrese un nombre de alg�n equipo", "Ok");
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