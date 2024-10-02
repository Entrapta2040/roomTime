namespace roomTime;

public partial class EditPlanLekcjiPage : ContentPage
{
	public EditPlanLekcjiPage()
	{
		InitializeComponent();
	}

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}