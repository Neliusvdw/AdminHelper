namespace AdminHelper.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string EmployeeFirstName { get; set; } = string.Empty;
        public string EmployeeLastName { get; set; } = string.Empty;
        public string EmployeeAddress { get; set; } = string.Empty;
        public string CellNo { get; set; } = string.Empty;
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactNo { get; set; } = string.Empty;

    }
}
