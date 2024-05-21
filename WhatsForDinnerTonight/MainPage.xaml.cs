namespace WhatsForDinnerTonight;

public partial class MainPage : ContentPage
{
	int count = 0;
	private string[] Recipes = new string[] {
		"Redang", 
		"Lentilles Saucisses", 
		"Quiche Lorraine"
		} ;
	Random random = new Random();

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private void OnReceipRequest(object sender, EventArgs e)
	{ 
		int randomIndex = random.Next(0,Recipes.Length);
		System.Console.WriteLine("index: " + randomIndex);
		SelectedRecipe.Text	 = $" {Recipes[randomIndex]}";
		SemanticScreenReader.Announce(SelectedRecipe.Text);


	}
}

