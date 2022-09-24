using Microsoft.AspNetCore.Mvc;
using MultiTableView.BussinessLayer;
using MultiTableView.Models;

namespace MultiTableView.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeeBL _EmployeeBL;
        public EmployeeController(EmployeeBL employeeBL )
        {
            _EmployeeBL=employeeBL;
        }
        public IActionResult Index()
        {
            var result = _EmployeeBL.getEmployee();
            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var EmpDetail = new EmpDetail();
            EmpDetail.addressDetail = new AddressDetail();
            EmpDetail.familyDetail = new FamilyDetail();
            var address = _EmployeeBL.getEmployeeAddress(id);
            var family = _EmployeeBL.getEmployeeFamily(id);
            if(family.Id==0)
            {
                EmpDetail.familyDetail.EmpId = id;
            }
            else
            {
                EmpDetail.familyDetail = family;
            }
            if (address.Id == 0)
            {
                EmpDetail.addressDetail.EmpId = id;
            }
            
            else
            {
                EmpDetail.addressDetail = address;
            }
           
            return View(EmpDetail);
        }
        [HttpPost]
        public IActionResult SaveAddress(AddressDetail addressDetail)
        {
            var result = _EmployeeBL.SaveAddressDetail(addressDetail);
            ViewData["AddressMessage"] = "Address added successfully";
            return PartialView("_Address",addressDetail);
        }

        [HttpPost]
        public IActionResult SaveFamily(FamilyDetail familyDetail)
        {
            var result = _EmployeeBL.SaveFamilyDetail(familyDetail);
            ViewData["FamilyMessage"] = "Family added successfully";
            return PartialView("_Family", familyDetail);
        }
    }
}
