using Survey4030360.Views;

namespace Survey4030360;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(SurveyDetailsView), typeof (SurveyDetailsView));
    }
}