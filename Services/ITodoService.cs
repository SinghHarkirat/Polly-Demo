
namespace Polly_Demo.Services
{
    public interface ITodoService
    {
        Task<HttpResponseMessage> GetTodos();
    }
}