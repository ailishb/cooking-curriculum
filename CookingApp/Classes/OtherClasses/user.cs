/*
public class User
{
    public int id { get; }
    public string Name { get; }
    public string Status { get; }
    public int EnrolledCourseId { get; }
    public string CurrentCourseStatus { get; set; }

    //Constructor
    public User(string username)
    {
        if (validUsername(username) == true)
        {
            id = UserDN.getIdByName(username);
            Name = UserDB.getNameById(id);
            Status = UserDB.getStatusById(id);
            if (isUserEnrolledInCourse(id) == true)
            {
                EnrolledCourseId = UserDB.getEnrolledCourseIdByUserId(id);
                CurrentCourseStatus = UserDB.getCurrentCourseStatusByUserId(id);
            }
        }
        else
        {
            //Throw error: invalid user
        }
    }

    public void SwitchCourse(Course newCourse)
    {
        EnrolledCourse = newCourse.id;
    }

    public void UpdateUserStatus(int newStatus)
    {
        Status = newStatus;
    }

    public void UpdateCurrentCourseStatus(int newCourseStatus)
    {
        CurrentCourseStatus = newStatus;
    }
}*/