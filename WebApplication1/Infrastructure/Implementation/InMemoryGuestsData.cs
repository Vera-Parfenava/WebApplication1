using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;


namespace WebApplication1.Implementation
{
    ///<inheritdoc/>
    /// <summary>
    /// The implementation of the interface stores information in memory
    /// </summary>
    public class InMemoryGuestsData: IGuestsData
    {
        private readonly List<GuestsView> _guestsView;

        public InMemoryGuestsData()
        {
            _guestsView = new List<GuestsView>(3)
            {
                new GuestsView()
                {
                    Id = 1,
                    FirstName = "Иван",
                    SurName = "Туранков",
                    Partronymic = "Андреевич",
                    Age = 31,
                    Relation = "BIM-мастер",
                    Side = "BIM"
                },
                new GuestsView()
                {
                    Id = 2,
                    FirstName = "Владислав",
                    SurName = "Попков",
                    Partronymic = "Эдуардович",
                    Age = 24,
                    Relation = "Программист",
                    Side = "WEB"
                },
                new GuestsView()
                {
                    Id = 3,
                    FirstName = "Вера",
                    SurName = "Ярешко",
                    Partronymic = "Вадимовна",
                    Age = 26,
                    Relation = "Руководитель",
                    Side = "IT"
                }
            };
        }

        public IEnumerable<GuestsView> GetAll()
        {
            return _guestsView;
        }

        public GuestsView GetById(int id)
            {
                return _guestsView.FirstOrDefault(e => e.Id.Equals(id));
            }
        public void Commit()
        {

        }
        public void AddNew (GuestsView model)
        {
            model.Id = _guestsView.Max(e => e.Id) + 1;
            _guestsView.Add(model);
        }
        public void Delete(int id)
        {
            var guests = GetById(id);
            if (guests != null)
            {
                _guestsView.Remove(guests);
            }
        }
    }
}
