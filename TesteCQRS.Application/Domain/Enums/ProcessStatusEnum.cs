namespace TesteCQRS.Application.Domain.Enums
{
    public enum ProcessStatusEnum
    {
        Queue,
        Cancel,
        Done,
        Error = -1
    }
}
