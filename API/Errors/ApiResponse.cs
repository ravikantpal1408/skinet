namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatus(statusCode) ; // Coalesce operator 👉 that means bcoz if false run the code at right side 
        }

        private string GetDefaultMessageForStatus(in int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made. 👀",
                401 => "Un-Authorized, you are not authorized 👽",
                404 => "Resource not found 🤷‍♂️😱",
                500 => "Server errors, you are fucked - debug your backend shit hole ❌",
                _ => null
            };
        }
    }
}