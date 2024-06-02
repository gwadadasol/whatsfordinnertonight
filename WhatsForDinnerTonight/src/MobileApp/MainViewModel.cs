using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WhatsForDinnerTonight;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly MealDatabase _mealDatabase;
    private Meal _currentMeal;

    public Meal CurrentMeal
    {
        get => _currentMeal;
        set
        {
            _currentMeal = value;
            OnPropertyChanged(nameof(CurrentMeal));
        }
    }

    public ICommand GetSuggestionCommand { get; }
    public ICommand AcceptSuggestionCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public MainViewModel(MealDatabase mealDatabase)
    {
        _mealDatabase = mealDatabase;
        GetSuggestionCommand = new Command(async () => GetMealSuggestion());
        AcceptSuggestionCommand = new Command(() => AcceptMealSuggestion());
    }

    private void GetMealSuggestion()
    {
        var meals =  _mealDatabase.GetMeals().ToArray();
        var random = new Random();
        if (meals.Count() > 0 )
        {
            CurrentMeal = meals[random.Next(meals.Count())];
        }
    }

    private void AcceptMealSuggestion()
    {
        // Logic to accept meal suggestion
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
