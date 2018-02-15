using Synkron.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Synkron.DAL.Repository
{
    public class TaskManageRepository: IRepository<TaskManage>
    {
        #region Attributes

        private readonly SynkronEntities _context = null;

        #endregion Attributes

        #region Constructor

        public TaskManageRepository(SynkronEntities context)
        {
            _context = context;
        }

        #endregion Constructor

        #region CRUD

        public bool Delete(TaskManage entity)
        {
            _context.TaskManage.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<TaskManage> GetAll()
        {
            return _context.TaskManage.ToList();
        }

        public TaskManage GetById(int id)
        {
            return _context.TaskManage.Where(tm => tm.ID == id).FirstOrDefault();
        }

        public int Insert(TaskManage entity)
        {
            _context.TaskManage.Add(entity);
            _context.SaveChanges();

            return entity.ID;
        }

        public void Update(TaskManage entity)
        {
            _context.TaskManage.Add(entity);
            _context.SaveChanges();
        }

        public List<usp_GetAllTaskManage_Result> GetAllTaskManage()
        {
            return _context.usp_GetAllTaskManage().ToList();
        }

        #endregion CRUD
    }
}
