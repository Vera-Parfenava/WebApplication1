using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Base.Interfaces;

namespace WebApplication1.Domain.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity //Именованная сущность
    {
       public string Name { get; set; }
    }
}
 
