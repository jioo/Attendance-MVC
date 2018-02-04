using AttendanceGpi.Core;
using AttendanceGpi.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web._Repository
{
    public interface IEmployee
    {
        List<Employee> Show();

        bool UpdatePassword(string userId, string newPassword);
        bool ChangeStatus(string id, string cardNo, byte status);

        EmployeeEditViewModel Find(string id);

        void Create(EmployeeViewModel employee);

        void Edit(EmployeeEditViewModel employee);

        string DisplayName(string id);

        bool ValidateEmail(string id, string username);

        bool ValidateCard(string id, string cardNo);
    }

    
}