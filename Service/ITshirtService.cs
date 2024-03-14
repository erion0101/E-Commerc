using E_Commerc.Data;

namespace E_Commerc.Service
{
    public interface ITshirtService
    {
        Task<List<TshirtDTO>> GetTshirtAsync();
        Task<TshirtDTO> GetTshirtById(int id);
        Task Update(TshirtDTO tshirtDTO);
        Task<List<TshirtDTO>> Serche(string name);
        Task<TshirtDTO> Add(TshirtDTO tshirtDTO);
        Task<TshirtDTO> Delete(int id);
    }
}
