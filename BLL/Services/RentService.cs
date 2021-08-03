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
    public interface IRentService
    {
        IEnumerable<Rent> GetAll();
        void Add(Rent rent);
        void Remove(Rent rent);
        void Update(Rent rent);
    }
    public class RentService : IRentService
    {
        IUnitOfWork unitOfWork;
        IRepository<Rent> rents;
        IMapper mapper;
        RentServiceModel context = new RentServiceModel();

        public RentService()
        {
            unitOfWork = new UnitOfWork(context);
            rents = unitOfWork.RentRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rent, Rent>();
            });

            mapper = new Mapper(config);
        }

        public void Add(Rent rent)
        {
            unitOfWork.RentRepository.Insert(rent);
            unitOfWork.Save();
        }

        public IEnumerable<Rent> GetAll()
        {
            foreach (var item in rents.Get())
            {
                yield return new Rent()
                {
                    Id = item.Id,
                    IsAviable = item.IsAviable,
                    HouseName = item.HouseName,
                    DateFrom = item.DateFrom,
                    DateTo = item.DateTo,
                    UserId = item.UserId,
                    DepartmentId = item.DepartmentId
                };
            }
        }

        public void Remove(Rent rent)
        {
            unitOfWork.RentRepository.Delete(rent);
            unitOfWork.Save();
        }

        public void Update(Rent rent)
        {
            unitOfWork.RentRepository.Update(rent);
            unitOfWork.Save();
        }
    }
}
