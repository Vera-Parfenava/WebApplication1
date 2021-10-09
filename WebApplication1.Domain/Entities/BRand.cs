using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Base;
using WebApplication1.Domain.Entities.Base.Interfaces;


namespace WebApplication1.Domain.Entities
{
    public class Brand: NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
