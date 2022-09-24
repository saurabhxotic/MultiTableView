using MultiTableView.Repos;
using MultiTableView.Models;
using System.Data;
using System.Data.SqlClient;

namespace MultiTableView.DataLayer
{
    public class EmployeeDL
    {
        public readonly db _db;
        public EmployeeDL(db db)
        {
            _db = db;
        }

        public List<FixityEmp> getEmployee()
        {
            FixityEmp fixtyEmp;
            var FixityEmplist = new List<FixityEmp>();
            var result = _db.GetData("SP_getEmpdata");


            foreach (DataRow item in result.Rows)
            {
                fixtyEmp = new FixityEmp();
                fixtyEmp.Id = Convert.ToInt32(item["Id"]);
                fixtyEmp.Name = Convert.ToString(item["Name"]);
                fixtyEmp.Gender = Convert.ToString(item["Gender"]);
                fixtyEmp.Age = Convert.ToInt32(item["Age"]);
                fixtyEmp.Position = Convert.ToString(item["Position"]);
                fixtyEmp.Office = Convert.ToString(item["Office"]);
                fixtyEmp.Salary = Convert.ToInt32(item["Salary"]);

                FixityEmplist.Add(fixtyEmp);

            }

            return FixityEmplist;
        }


        public AddressDetail getEmployeeAddress(int empId)
        {
            AddressDetail address=new AddressDetail();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@EmpId";
            parameter.Value = empId;
            parameter.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(parameter);

            var result = _db.GetData("SP_GET_ADDRESS", sqlParameters);


            foreach (DataRow item in result.Rows)
            {
                address.Id = Convert.ToInt32(item["Id"]);
                address.Country = Convert.ToString(item["Country"]);
                address.State = Convert.ToString(item["State"]);
                address.District = Convert.ToString(item["District"]);
                address.Area = Convert.ToString(item["Area"]);
                address.LandMark = Convert.ToString(item["LandMark"]);
                address.Pincode = Convert.ToString(item["Pincode"]);
                address.EmpId = Convert.ToInt32(item["EmpId"]);

            }

            return address;
        }

        public FamilyDetail getEmployeeFamily(int empId)
        {
            FamilyDetail family = new FamilyDetail();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@EmpId";
            parameter.Value = empId;
            parameter.SqlDbType = SqlDbType.Int;
            sqlParameters.Add(parameter);

            var result = _db.GetData("SP_GET_FAMILY", sqlParameters);


            foreach (DataRow item in result.Rows)
            {
                family.Id = Convert.ToInt32(item["Id"]);
                family.FatherName = Convert.ToString(item["FatherName"]);
                family.FatherEd = Convert.ToString(item["FatherEd"]);
                family.fatherPhn = Convert.ToString(item["fatherPhn"]);
                family.FatherOccup = Convert.ToString(item["FatherOccup"]);
                family.MotherName = Convert.ToString(item["MotherName"]);
                family.MotherEd = Convert.ToString(item["MotherEd"]);
                family.EmpId = Convert.ToInt32(item["EmpId"]);

            }

            return family;
        }

        public bool SaveAddressDetail(AddressDetail address)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Country";
            parameter.Value = address.Country;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@State";
            parameter.Value = address.State;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@District";
            parameter.Value = address.District;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Area";
            parameter.Value = address.Area;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@LandMark";
            parameter.Value = address.LandMark;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Pincode";
            parameter.Value = address.Pincode;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@EmpId";
            parameter.Value = address.EmpId;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);


            return _db.PostData("SP_save_Emp_Address", sqlParameters);
        }


        public bool SaveFamilyDetail(FamilyDetail family)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@FatherName";
            parameter.Value = family.FatherName;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@FatherEd";
            parameter.Value = family.FatherEd;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@MotherName";
            parameter.Value = family.MotherName;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@MotherEd";
            parameter.Value = family.MotherEd;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@fatherPhn";
            parameter.Value = family.fatherPhn;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@FatherOccup";
            parameter.Value = family.FatherOccup;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@EmpId";
            parameter.Value = family.EmpId;
            parameter.SqlDbType = SqlDbType.NVarChar;
            sqlParameters.Add(parameter);

            return _db.PostData("SP_save_Emp_family_detail", sqlParameters);

        }
    }
}
