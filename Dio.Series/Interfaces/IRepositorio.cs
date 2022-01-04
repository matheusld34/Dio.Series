using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface IRepositório <T>
    {
         List<T> Lista();
         T RetornaPorId(int id);

         Void Insere(T entidade);

         Void Exclui(int id);

         Void atualiza(int id, T entidade);

         int ProximoId();
        
    }
}