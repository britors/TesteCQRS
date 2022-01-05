namespace TesteCQRS.MessageBroker.Domain
{
    public enum ProcessStatusEnum
    {
        Queue,
        Cancel,
        Done,
        Error = -1
    }
}
