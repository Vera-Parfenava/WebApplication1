using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    /// <summary>
    /// Interface for a work with guests
    /// </summary>
    interface IGuestsData
    {
        ///<summary>
        ///Get the list of guests
        ///</summary>
        ///<returns></returns>
        IEnumerable<GuestsView> GetAll();

        ///<summary>
        ///Get a guest by id
        ///</summary>
        ///<param name="id">Id</param>
        ///<returns></returns>
        GuestsView GetById(int id);

        ///<summary>
        ///Save changing
        ///</summary>
        void Commit();

        ///<summary>
        ///Add new one
        ///</summary>
        ///<param name="model">Id</param>
        ///<returns></returns>
        void AddNew(GuestsView model);

        ///<summary>
        ///Delete one
        ///</summary>
        ///<param name="id">Id</param>
        ///<returns></returns>
        void Delete(int id);
    }
}
