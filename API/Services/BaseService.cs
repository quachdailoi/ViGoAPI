namespace API.Services
{
    public class BaseService<T> where T : BaseService<T>
    {
        protected readonly ILogger _logger;

        public BaseService(ILogger<BaseService<T>> logger)
        {
            _logger = logger;
        }
    }
}
