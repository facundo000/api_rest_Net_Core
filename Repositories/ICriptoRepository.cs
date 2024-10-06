using ParcialWebApi.DTOs;
using ParcialWebApi.Models;

namespace ParcialWebApi.Repositories
{
    public interface ICriptoRepository
    {
        bool Save(CriptomonedaDTO cripto);
        bool Delete(int id);
        bool Update(string simbolo, CriptomonedaDTO cripto);
        List<Criptomoneda> GetAll();
        List<Categoria> GetAllCategorias();
        Criptomoneda Get(int id);
    }
}
