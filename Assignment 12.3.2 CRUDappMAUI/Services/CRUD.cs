using Assignment_12._3._2_CRUDappMAUI.Data;
using Assignment_12._3._2_CRUDappMAUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12._3._2_CRUDappMAUI.Services
{
    public interface ICRUD <T>
    {
        void Add(T person);
        void Update(int ID, T person);
        void Delete(T person);
        List<T> GetList();
        T GetbyID(int person);
    }

    public class ChildCRUD: ICRUD <Child>
    {
        private DataContext _dataContext;
        public ChildCRUD(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(Child child)
        {
            _dataContext.children.Add(child);
            _dataContext.SaveChanges();
        }
        public void Update(int Id, Child updatedChild)
        {
            var existingChild = _dataContext.children.Find(Id);
            if (existingChild != null)
            {
                existingChild.FirstName = updatedChild.FirstName; 
                existingChild.LastName = updatedChild.LastName;
                existingChild.DateofBirth = updatedChild.DateofBirth;
                existingChild.GuardianID = updatedChild.GuardianID;
            }

        }
        public void Delete(Child child)
        {
            if (child != null)
            {
                _dataContext.children.Remove(child);
                _dataContext.SaveChanges();
            }
        }
        public List<Child> GetList()
        {
            return _dataContext.children.ToList();
        }
        public Child GetbyID(int ID)
        {
            return _dataContext.children.Find(ID);
        }

    }

    public class GuardianCRUD : ICRUD<Guardian>
    {
        private DataContext _dataContext;
        public GuardianCRUD(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(Guardian guardian)
        {
            _dataContext.guardian.Add(guardian);
            _dataContext.SaveChanges();
        }
        public void Update(int Id, Guardian guardian)
        {
            var existingGuardian = _dataContext.guardian.Find(Id);
            if (existingGuardian != null)
            {
                existingGuardian.FullName = guardian.FullName;
                existingGuardian.PhoneNumber = guardian.PhoneNumber;
                existingGuardian.Address = guardian.Address;
            }

        }
        public void Delete(Guardian guardian)
        {
            if (guardian != null)
            {
                _dataContext.guardian.Remove(guardian);
                _dataContext.SaveChanges();
            }
        }
        public List<Guardian> GetList()
        {
            return _dataContext.guardian.ToList();
        }
        public Guardian GetbyID(int ID)
        {
            return _dataContext.guardian.Find(ID);
        }

    }
}
