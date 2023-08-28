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
        Item.Birthdate = BirthdatePicker.Date;
        
        if (string.IsNullOrWhiteSpace(Item.Name) && string.IsNullOrWhiteSpace(Item.EquipoFavorito))
        {
            await DisplayAlert("Ingrese los datos requeridos", "Por favor completa todos los datos solicitados", "OK");
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

    private void ExpandirClicked (object sender, EventArgs e)
    {
        RealMadrid.IsVisible = true;
        BayerMunchen.IsVisible = true;
        Barcelona.IsVisible = true;
        ManCity.IsVisible = true;
        ManU.IsVisible = true;
        BVB.IsVisible = true;
    }

    private void RealMadrid_Clicked(object sender, EventArgs e)
    {
        Equipo.Text = "Real Madrid CF";
        RealMadrid.IsVisible = false;
        BayerMunchen.IsVisible = false;
        Barcelona.IsVisible = false;
        ManCity.IsVisible = false;
        ManU.IsVisible = false;
        BVB.IsVisible = false;
    }

    private void BayerMunchen_Clicked(object sender, EventArgs e)
    {
        Equipo.Text = "FC Bayern Múnchen";
        RealMadrid.IsVisible = false;
        BayerMunchen.IsVisible = false;
        Barcelona.IsVisible = false;
        ManCity.IsVisible = false;
        ManU.IsVisible = false;
        BVB.IsVisible = false;
    }

    private void Barcelona_Clicked(object sender, EventArgs e)
    {
        Equipo.Text = "FC Barcelona";
        RealMadrid.IsVisible = false;
        BayerMunchen.IsVisible = false;
        Barcelona.IsVisible = false;
        ManCity.IsVisible = false;
        ManU.IsVisible = false;
        BVB.IsVisible = false;
    }

    private void ManCity_Clicked(object sender, EventArgs e)
    {
        Equipo.Text = "Manchester City";
        RealMadrid.IsVisible = false;
        BayerMunchen.IsVisible = false;
        Barcelona.IsVisible = false;
        ManCity.IsVisible = false;
        ManU.IsVisible = false;
        BVB.IsVisible = false;
    }

    private void ManU_Clicked(object sender, EventArgs e)
    {
        Equipo.Text = "Manchester United";
        RealMadrid.IsVisible = false;
        BayerMunchen.IsVisible = false;
        Barcelona.IsVisible = false;
        ManCity.IsVisible = false;
        ManU.IsVisible = false;
        BVB.IsVisible = false;
    }

    private void BVB_Clicked(object sender, EventArgs e)
    {
        Equipo.Text = "Borussia Dortmund";
        RealMadrid.IsVisible = false;
        BayerMunchen.IsVisible = false;
        Barcelona.IsVisible = false;
        ManCity.IsVisible = false;
        ManU.IsVisible = false;
        BVB.IsVisible = false;
    }
}