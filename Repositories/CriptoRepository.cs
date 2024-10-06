using ParcialWebApi.DTOs;
using ParcialWebApi.Models;

namespace ParcialWebApi.Repositories
{
    public class CriptoRepository : ICriptoRepository
    {
        private readonly CriptoContext _context;

        public CriptoRepository(CriptoContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var oCripto = _context.Criptomonedas.Find(id);
            if (oCripto != null && oCripto.Estado == "H")
            {
                oCripto.UltimaActualizacion = DateTime.Now;
                oCripto.Estado = "NH";

                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Criptomoneda Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Criptomoneda> GetAll()
        {
            
            DateTime fechaActual = DateTime.Now;

            var lCripto = _context.Criptomonedas.Where(f => f.UltimaActualizacion < fechaActual).OrderByDescending(n => n.Nombre).ToList();

            return lCripto;
        }

        public List<Categoria> GetAllCategorias()
        {
            var lCategoria = _context.Categorias.OrderByDescending(n => n.Nombre).ToList();

            return lCategoria;
        }

        public bool Save(CriptomonedaDTO cripto)
        {
            throw new NotImplementedException();
        }

        public bool Update(string simbolo, CriptomonedaDTO cripto)
        {
            var oCripto = _context.Criptomonedas.FirstOrDefault(s => s.Simbolo == simbolo);
            if (oCripto != null)
            {
                //oCripto.Nombre = cripto.Nombre;
                oCripto.ValorActual = cripto.ValorActual;
                oCripto.Categoria = cripto.Categoria;
                oCripto.UltimaActualizacion = cripto.UltimaActualizacion;

                if ((DateTime.Now - oCripto.UltimaActualizacion).TotalHours > 24)
                {
                    return false;
                }
                oCripto.Estado = "H";

                return _context.SaveChanges() > 0;
            }

            return false;
        }
    }
}
