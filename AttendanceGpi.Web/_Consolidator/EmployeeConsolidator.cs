using AttendanceGpi.Core;
using AttendanceGpi.Web._Infrastructure;
using AttendanceGpi.Web._Repository;
using AttendanceGpi.Web.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AttendanceGpi.Web._Consolidator
{
    public class EmployeeConsolidator : IEmployee
    {
        private DefaultDbContext _ctx = new DefaultDbContext();

        public List<Employee> Show()
        {
            return (from emp in _ctx.Employees
                    join inf in _ctx.EmployeesInfo
                        on emp.Id equals inf.UserId
                    join schd in _ctx.Schedules
                        on emp.SchedId equals schd.SchedId
                    orderby inf.IsResigned ascending
                    select emp).ToList();
        }

        public bool UpdatePassword(string userId, string newPassword)
        {
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                userManager.RemovePassword(userId);
                userManager.AddPassword(userId, newPassword);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeStatus(string id, string cardNo, byte status)
        {
            try
            {
                //Check if card is already in use before activating the employee.
                if (status == 0)
                {
                    var result = _ctx.EmployeesInfo
                        .Where(u => u.CardNo == cardNo && u.IsResigned != 1)
                        .FirstOrDefault();
                    if (result != null)
                    {
                        return false;
                    }
                }

                //Update employee status
                var employee = _ctx.EmployeesInfo.Find(id);
                employee.IsResigned = status;
                _ctx.Entry(employee).State = EntityState.Modified;
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public EmployeeEditViewModel Find(string id)
        {
            var viewEmployee = new EmployeeEditViewModel();
            var employee = (from emp in _ctx.Employees
                            join inf in _ctx.EmployeesInfo
                                on emp.Id equals inf.UserId
                            join schd in _ctx.Schedules
                                on emp.SchedId equals schd.SchedId
                            where emp.Id == id
                            select emp).SingleOrDefault();

            viewEmployee.Id = employee.Id;
            viewEmployee.UserName = employee.UserName;
            viewEmployee.CardNo = employee.EmployeeInfo.CardNo;
            viewEmployee.Name = employee.EmployeeInfo.Name;
            viewEmployee.Picture = employee.EmployeeInfo.Picture;
            viewEmployee.Position = employee.EmployeeInfo.Position;
            viewEmployee.SchedId = employee.SchedId;
            viewEmployee.IsResigned = employee.EmployeeInfo.IsResigned;
            viewEmployee.Created = employee.EmployeeInfo.Created;

            return viewEmployee;
        }

        public void Create(EmployeeViewModel employee)
        {
            //Synchronize Schedule ID in Account.
            var currentEmployee = _ctx.Employees.Find(employee.Id);
            currentEmployee.SchedId = employee.SchedId;
            _ctx.Entry(currentEmployee).State = EntityState.Modified;
            _ctx.SaveChanges();

            //Insert Addition employee information.
            EmployeeInfo info = new EmployeeInfo();
            info.UserId = employee.Id;
            info.CardNo = employee.CardNo;
            info.Name = employee.Name;
            info.Picture = employee.Picture;
            info.Position = employee.Position;
            info.IsResigned = 0;
            info.Created = DateTime.Now;

            _ctx.EmployeesInfo.Add(info);
            _ctx.SaveChanges();
        }

        public void Edit(EmployeeEditViewModel employee)
        {
            //Update Employee
            var newEmp = new Employee
            {
                Id = employee.Id,
                UserName = employee.UserName,
                SchedId = employee.SchedId
            };
            _ctx.Entry(newEmp).State = EntityState.Modified;
            _ctx.SaveChanges();

            //Update Employee Info
            var newEmpInfo = new EmployeeInfo
            {
                UserId = employee.Id,
                CardNo = employee.CardNo,
                Name = employee.Name,
                Picture = employee.Picture,
                Position = employee.Position,
                Created = employee.Created,
                IsResigned = employee.IsResigned,
                Updated = DateTime.Now
            };
            _ctx.Entry(newEmpInfo).State = EntityState.Modified;

            //Save Changes
            _ctx.SaveChanges();
        }



        public string DisplayName(string id)
        {
            return _ctx.EmployeesInfo.Find(id).Name;
        }

        public bool ValidateEmail(string id, string username)
        {
            var result = (from user in _ctx.Employees
                          where user.Id != id
                          && user.UserName == username
                          select user).FirstOrDefault();
            return (result != null) ? true : false;
        }

        public bool ValidateCard(string id, string cardNo)
        {
            var result = (from user in _ctx.EmployeesInfo
                          where user.CardNo == cardNo
                          && user.IsResigned == 0
                          && user.UserId != id
                          select user).FirstOrDefault();
            return (result != null) ? true : false;
        }
    }
}