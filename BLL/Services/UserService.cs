using AutoMapper;
using DAL;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        void Add(User user);
        void Remove(User user);
        void Update(User user);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetLogin();
        IEnumerable<User> GetPassword();
        void Authorization(string login, string password);
    }
    public class UserService : IUserService
    {

        IUnitOfWork unitOfWork;
        IRepository<User> users;
        IMapper mapper;
        RentServiceModel context = new RentServiceModel();
        public bool IsAuthorizate = false;

        public UserService()
        {
            unitOfWork = new UnitOfWork(context);
            users = unitOfWork.UserRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, User>();
            });

            mapper = new Mapper(config);
        }
        public void Add(User user)
        {
            unitOfWork.UserRepository.Insert(user);
            unitOfWork.Save();
        }

        public void Authorization(string login, string password)
        {
            var user = unitOfWork.UserRepository.Get().Where(u => u.Login == login && u.Password == password).First();

            if(user == null)
            {
                throw new NullReferenceException("Null");
            }
            else if(user.Login == login && user.Password == password)
            {
                throw new Exception("Welcome!");
                IsAuthorizate = true;
            }
            else
            {
                throw new Exception("BlyaaaaaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAA!");
            }

        }

        public IEnumerable<User> GetAll()
        {
            foreach (var item in users.Get())
            {
                yield return new User()
                {
                    Id = item.Id,
                    Login = item.Login,
                    Password = item.Password,
                    Rents = item.Rents
                };
            }
        }

        public IEnumerable<User> GetLogin()
        {
            foreach (var item in users.Get())
            {
                yield return new User()
                {
                    Login = item.Login,
                };
            }
        }

        public IEnumerable<User> GetPassword()
        {
            foreach (var item in users.Get())
            {
                yield return new User()
                {
                    Password = item.Password,
                };
            }
        }

        public void Remove(User user)
        {
            unitOfWork.UserRepository.Delete(user);
            unitOfWork.Save();
        }
        public void Update(User user)
        {
            unitOfWork.UserRepository.Update(user);
            unitOfWork.Save();
        }
    }
}
