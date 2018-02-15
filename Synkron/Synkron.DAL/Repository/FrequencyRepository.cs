using Synkron.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Synkron.DAL.Repository
{
    public class FrequencyRepository : IRepository<Frequency>
    {
        #region Attributes

        private readonly SynkronEntities _context = null;

        #endregion Attributes

        #region Constructor

        public FrequencyRepository(SynkronEntities context)
        {
            _context = context;
        }

        #endregion Constructor

        public bool Delete(Frequency entity)
        {
            throw new NotImplementedException();
        }

        public List<Frequency> GetAll()
        {
            return _context.Frequency.ToList();
        }

        public Frequency GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Frequency entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Frequency entity)
        {
            throw new NotImplementedException();
        }
    }
}
