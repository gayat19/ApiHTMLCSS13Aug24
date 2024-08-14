namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class UnableToAddException :Exception
    {
        string message;
        public UnableToAddException(string entityName)
        {
            message = "Unable to add "+entityName;
        }
        public override string Message => message;
    }
}
