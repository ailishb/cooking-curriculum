/* Usage: 
 * Create a new Recipe by calling new Recipe(<id of recipe>)
 * then the class will populate the fields. This class
 * should be immutable (read-only) once initialized by the constructor
 */
 
public class Recipe
{
    public int id { get; }
	public string Name { get; }
	public string Author { get; }
	//public string RecipeCoverImageURL { get; }
	public string[] RecipeSteps { get; }
	public int DifficultyLevel { get; }
	public int Description {get; }
	
	//Dictionary of recipes as <ingredient name, quantity>
	public Dictionary<string, double> Ingredients { get; }
	
	//Dictionary of recipe image as <step number, image URL>
	//public Dictionary<int, string> RecipeImages { get; }
	
	// Read-only property of numberOfSteps
	public int NumberOfSteps
	{
		get
		{
			return RecipeSteps.Length;
		}
	}
	
	// Constructor that matches the recipe name to the DB and populates class fields members
	public Recipe(int RecipeID)
	{
        if (CookingDB.verifyRecipeID(RecipeID) == true)
		{
		    id = RecipeID;
		    Name = RecipeDB.getTitleById(id);
		    Author = RecipeDB.getAuthorById(id);
		    //RecipeCoverImageURL = RecipeDB.getRecipeCoverImageById(id);
		    RecipeSteps = RecipeDB.getRecipesById(id);
		    Ingredients = RecipeDB.getIngredientsById(id);
		    //RecipeImages = RecipeDB.getRecipeImagesById(id);
		}
		else
		{
			//Throw Error
		}
	}
}
