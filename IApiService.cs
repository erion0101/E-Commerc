namespace E_Commerc
{
    public interface IApiService
    {
        Task<T> HttpGET<T>(string url);
        Task HttpDELETE(string url);
        Task<T> HttpPOST<T>(string url, object postData);

    }
}
