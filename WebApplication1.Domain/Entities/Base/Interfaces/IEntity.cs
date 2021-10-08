using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities.Base.Interfaces
{
    public interface IEntity //Cущность
    {
        int Id { get; }
    }
    //public interface INamedEntity: IEntity //Именованная сущность
    //{
    //    string Name { get; }
    //}
    //public interface IOrderedEntity:IEntity //Упорядоченная сущность
    //{
    //    int Order { get; }
    //}
}
