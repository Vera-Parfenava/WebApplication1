using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using WebApplication1.Data;
using Microsoft.Extensions.Logging;



namespace WebApplication1.Infrastructure.InMemory
{
    ///<inheritdoc/>
    /// <summary>
    /// The implementation of the interface stores information in memory
    /// </summary>
    public class InMemoryGuestsData: IGuestsData
    {
        private readonly ILogger<InMemoryGuestsData> _Logger;
        private int _CurrentMaxId;

        public InMemoryGuestsData(ILogger<InMemoryGuestsData> Logger)
        {
            _Logger = Logger;
            _CurrentMaxId = TestData.GuestsViews.Max(e => e.Id);
        }

        public IEnumerable<GuestsView> GetAll()
        {
            return TestData.GuestsViews;
        }

        public GuestsView GetById(int id)
            {
                return TestData.GuestsViews.FirstOrDefault(e => e.Id.Equals(id));
            }
        public void Commit()
        {

        }
        public int AddNew (GuestsView model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            if (TestData.GuestsViews.Contains(model)) return model.Id;

            model.Id = _CurrentMaxId + 1;
            TestData.GuestsViews.Add(model);

            return model.Id;
        }
        public void UpDate(GuestsView model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));
            if (TestData.GuestsViews.Contains(model)) return;

            var db_guests = GetById(model.Id);
            if (db_guests is null) return;
            db_guests.FirstName = model.FirstName;
            db_guests.SurName = model.SurName;
            db_guests.Age = model.Age;
            db_guests.Partronymic = model.Partronymic;
            db_guests.Relation = model.Relation;
            db_guests.Side = model.Side;
        }


        public bool Delete(int id)
        {
            var db_guests = GetById(id);
            if (db_guests is null) return false;
            TestData.GuestsViews.Remove(db_guests);
            return true;
        }
    }
}
