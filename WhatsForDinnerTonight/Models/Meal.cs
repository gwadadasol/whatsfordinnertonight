using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;

namespace WhatsForDinnerTonight;

public class Meal : EqualityComparer<Meal>
{
    // public int Id { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Recipe { get; set; }

    public override bool Equals(Meal? b1, Meal? b2)
    {
           if (b1 == null && b2 == null)
            return true;
        else if (b1 == null || b2 == null)
            return false;

        return (b1.Name == b2.Name && b1.Ingredients == b2.Ingredients && b1.Recipe == b2.Recipe);
    }

    public override int GetHashCode([DisallowNull] Meal obj)
    {
      
        if (obj == null)
            return 0;
        int hashName = obj.Name == null ? 0 : obj.Name.GetHashCode();
        int hashIngredients = obj.Ingredients == null ? 0 : obj.Ingredients.GetHashCode();
        int hashRecipe = obj.Recipe == null ? 0 : obj.Recipe.GetHashCode();
        return hashName ^ hashIngredients ^ hashRecipe;
    }
}

