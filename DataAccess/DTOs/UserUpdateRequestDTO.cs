namespace EmployeeManagement.DataAccess.DTOs
{
    public class UserUpdateRequestDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public double? ContractSalary { get; set; }
        public int RoleId { get; set; }
    }
}
