using CRUDinCore.Classes;

namespace CRUDinCore.Interfaces
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(Message message);
    }
}
