using System.Text.Json.Serialization;

namespace API.Models.Response
{
    public class Response
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; } = null;
        [JsonIgnore]
        public bool Success { get; set; } = true;

        public Response()
        {
        }

        public Response(int StatusCode, string Message, object? Data = null, bool Success = false)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Data = Data;
            this.Success = Success;
        }

        public Response SetStatusCode(int code)
        {
            StatusCode = code;
            return this;
        }

        public Response SetMessage(string message)
        {
            Message = message;
            return this;
        }

        public Response SetData(object? data)
        {
            Data = data;
            return this;
        }

        public Response IsSuccess(bool success)
        {
            Success = success;
            return this;
        }
    }
}
