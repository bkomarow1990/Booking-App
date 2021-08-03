using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<Department> DepartmentRepository { get; }
        GenericRepository<Rent> RentRepository { get; }
        GenericRepository<User> UserRepository { get; }
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        RentServiceModel context;

        private GenericRepository<Department> departmentRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Rent> rentRepository;

        public UnitOfWork(RentServiceModel context)
        {
            this.context = context;
        }
        
        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<Rent> RentRepository
        {
            get
            {
                if (this.rentRepository == null)
                {
                    this.rentRepository = new GenericRepository<Rent>(context);
                }
                return rentRepository;
            }
        }


        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
