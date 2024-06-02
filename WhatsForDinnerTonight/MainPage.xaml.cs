namespace WhatsForDinnerTonight;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "meals.db3");
        var mealDatabase = new MealDatabase(dbPath);
        mealDatabase.SeedData(); // Seed the database with sample data
        BindingContext = new MainViewModel(mealDatabase);
    }
}
