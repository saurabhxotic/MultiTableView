using MultiTableView.DataLayer;
using MultiTableView.Models;

namespace MultiTableView.BussinessLayer
{
    public class EmployeeBL
    {
        public readonly EmployeeDL _employeeDL;
        public EmployeeBL(EmployeeDL employeeDL)
        {
            _employeeDL = employeeDL;
        }

        public List<FixityEmp> getEmployee()
        {
            return _employeeDL.getEmployee();
        }
        public bool SaveAddressDetail(AddressDetail address)
        {
            return _employeeDL.SaveAddressDetail(address);
        }


        public bool SaveFamilyDetail(FamilyDetail family)
        {
            return (_employeeDL.SaveFamilyDetail(family));
        }


        public AddressDetail getEmployeeAddress(int empId)
        {
            return _employeeDL.getEmployeeAddress(empId);
        }

        public FamilyDetail getEmployeeFamily(int empId)
        {
            
            return _employeeDL.getEmployeeFamily(empId);
        }
    }
}
