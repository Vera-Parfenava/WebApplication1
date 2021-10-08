using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities.Base.Interfaces
{
    interface IOrderedEntity : IEntity //Упорядоченная сущность
    {
        public interface IOrderedEntity 
        {
            int Order { get; }
        }
    }
}
