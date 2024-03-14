using E_Commerc.Data;

namespace E_Commerc.Service
{
    public class TshirtService : ITshirtService
    {
        private readonly IApiService _apiService;
        public TshirtService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<TshirtDTO> Add(TshirtDTO tshirtDTO) =>
            await _apiService.HttpPOST<TshirtDTO>($"Tshirt/Add", tshirtDTO);
        public async Task<TshirtDTO> Delete(int id) =>
            await _apiService.HttpPOST<TshirtDTO>($"Tshirt/Delete{0}", id);
        public async Task<List<TshirtDTO>> GetTshirtAsync() =>
            await _apiService.HttpGET<List<TshirtDTO>>($"Tshirt/GetTshirt");
        public async Task<TshirtDTO> GetTshirtById(int id) =>
      await _apiService.HttpGET<TshirtDTO>($"Tshirt/GetTshirtbyId/{id}");

        public async Task<List<TshirtDTO>> Serche(string name) =>
            await _apiService.HttpGET<List<TshirtDTO>>($"Tshirt/Serche/{name}");
        public async Task Update(TshirtDTO tshirtDTO) =>
            await _apiService.HttpPOST<TshirtDTO>($"Tshirt/Update", tshirtDTO);
    }
}
