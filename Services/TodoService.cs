

namespace Polly_Demo.Services
{
    public class TodoService : ITodoService
    {
      
        private IHttpClientFactory _clientFactory;

        public TodoService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<HttpResponseMessage> GetTodos()
        {
           
            var client = _clientFactory.CreateClient("JsonPlaceholder");
            var response = await client.GetAsync("/todos/1");
            return response;
        }
    }
}
