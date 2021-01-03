using Project_DAL.Data.Repositories;
using Project_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Category> _categoryRepo;
        private IRepository<Customer> _customerRepo;
        private IRepository<Description> _descriptionRepo;
        private IRepository<Location> _locationRepo;
        private IRepository<LocationCustomer> _locationCustomerRepo;
        private IRepository<Preview> _previewRepo;
        public UnitOfWork(DuiklocatiesBeheerEntities duiklocatiesBeheerEntities)
        {
            this.DuiklocatiesBeheerEntities = duiklocatiesBeheerEntities;

        }
        private DuiklocatiesBeheerEntities DuiklocatiesBeheerEntities { get; }
        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (_categoryRepo == null)
                {
                    _categoryRepo = new Repository<Category>(this.DuiklocatiesBeheerEntities);
                }
                return _categoryRepo;
            }
        }



        public IRepository<Customer> CustomerRepo
        {
            get
            {
                if (_customerRepo == null)
                {
                    _customerRepo = new Repository<Customer>(this.DuiklocatiesBeheerEntities);
                }
                return _customerRepo;
            }
        }

        public IRepository<Description> DescriptionRepo
        {
            get
            {
                if (_descriptionRepo == null)
                {
                    _descriptionRepo = new Repository<Description>(this.DuiklocatiesBeheerEntities);
                }
                return _descriptionRepo;
            }
        }

        public IRepository<Location> LocationRepo
        {
            get
            {
                if (_locationRepo == null)
                {
                    _locationRepo = new Repository<Location>(this.DuiklocatiesBeheerEntities);
                }
                return _locationRepo;
            }
        }

        public IRepository<LocationCustomer> LocationCustomerRepo
        {
            get
            {
                if (_locationCustomerRepo == null)
                {
                    _locationCustomerRepo = new Repository<LocationCustomer>(this.DuiklocatiesBeheerEntities);
                }
                return _locationCustomerRepo;
            }
        }

        public IRepository<Preview> PreviewRepo
        {
            get
            {
                if (_previewRepo == null)
                {
                    _previewRepo = new Repository<Preview>(this.DuiklocatiesBeheerEntities);
                }
                return _previewRepo;
            }
        }


        public void Dispose()
        {
            DuiklocatiesBeheerEntities.Dispose();
        }

        public int Save()
        {
            return DuiklocatiesBeheerEntities.SaveChanges();
        }
    }
}
