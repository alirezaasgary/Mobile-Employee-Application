using Employee.DataServices;

namespace Employee;

public partial class MainPage : ContentPage
{ 
    private readonly IRestDataServices _dataServices;

    public MainPage(IRestDataServices dataServices)
	{
		InitializeComponent();
        _dataServices = dataServices;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		collectionView.ItemsSource=await _dataServices.GetCompanyListAsync();
	}

	async void OnAddCompanyClick(object sender,EventArgs e)
	{

	}

    async void OnSelectionChange(object sender, EventArgs e)
    {

    }

}

