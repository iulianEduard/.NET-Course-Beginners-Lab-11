using Synkron.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Synkron.DAL.Repository
{
    public class TaskRepository : IRepository<Task>
    {
        #region Attributes

        private readonly SynkronEntities _context = null;

        #endregion Attributes

        #region Constructor

        public TaskRepository(SynkronEntities context)
        {
            _context = context;
        }

        #endregion Constructor

        #region CRUD

        public bool Delete(Task entity)
        {
            _context.Task.Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public List<Task> GetAll()
        {
            return _context.Task.ToList();
        }

        public Task GetById(int id)
        {
            return _context.Task.Where(t => t.ID == id).FirstOrDefault();
        }

        public int Insert(Task entity)
        {
            _context.Task.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            _context.SaveChanges();

            return entity.ID;
        }

        public void Update(Task entity)
        {
            _context.Task.Add(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<usp_GetAllTasks_Result> GetTasksList()
        {
            return _context.usp_GetAllTasks().ToList();
        }

        public List<usp_GetUnassignedTasks_Result> GetUnassignedTasks()
        {
            return _context.usp_GetUnassignedTasks().ToList();
        }

        public List<usp_GetTaskByStatus_Result> GetTasksByStatus(int statusId)
        {
            return _context.usp_GetTaskByStatus(statusId).ToList();
        }

        #endregion CRUD
    }
}
