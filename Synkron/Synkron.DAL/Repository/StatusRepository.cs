using Synkron.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Synkron.DAL.Repository
{
    public class StatusRepository: IRepository<Status>
    {
        #region Attributes

        private readonly SynkronEntities _context = null;

        #endregion Attributes

        #region Constructor

        public StatusRepository(SynkronEntities context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Public Methods

        public bool Delete(Status entity)
        {
            throw new NotImplementedException();
        }

        public List<Status> GetAll()
        {
            return _context.Status.ToList();
        }

        public Status GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Status entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Status entity)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
