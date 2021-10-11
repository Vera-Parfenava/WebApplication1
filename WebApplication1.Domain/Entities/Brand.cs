using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Base;
using WebApplication1.Domain.Entities.Base.Interfaces;



namespace WebApplication1.Domain.Entities
{
    [Index(nameof(Name),/*nameof(order),*/IsUnique = true)]
    //[Table("Brands")
    public class Brand: NamedEntity, IOrderedEntity
    {
        //[Column("BrandOrder")]
        public int Order { get; set; }
    }
}
