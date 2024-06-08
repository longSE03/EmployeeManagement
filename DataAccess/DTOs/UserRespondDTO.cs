namespace EmployeeManagement.DataAccess.DTOs
{
    public class UserRespondDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; }
        public double? ContractSalary { get; set; }
        public int? DaysOff { get; set; }
        public int? RoleId { get; set; }
    }
}
