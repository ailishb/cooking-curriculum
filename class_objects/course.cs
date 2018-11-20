/* Usage: 
 * Create a new Course by calling new Course(<id of course>)
 * then the class will populate the fields. This class
 * should be immutable (read-only) once initialized by the constructor
 */
 
public class Course
{
    private int id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Author { get; }
    public Recipe[] Recipes { get; }

    public Course(int CourseID)
    {
        if (validCourseID(CourseID) == true)
        {
            id = CourseID;
            Name = CourseDB.getNameById(id);
            Description = CourseDB.getDescriptionById(id);
            Author = CourseDB.getAuthorById(id);
            PopulateRecipes();
        }
    }

    private void PopulateRecipes()
    {
        int ListOfRecipeID = CourseDB.getListOfRecipeID(id);
        foreach (int i in ListOfRecipeID)
        {
            Recipes.Add(Recipe(i));
        }
    }
}
