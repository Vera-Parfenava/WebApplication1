using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities.Base.Interfaces
{
    interface INamedEntity : IEntity //Именованная сущность
    {
        public interface INamedEntity 
        {
            string Name { get; }
        }

    }
}
