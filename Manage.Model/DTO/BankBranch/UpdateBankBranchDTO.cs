using System;

namespace Manage.Model.DTO.BankBranch
{
    public class UpdateBankBranchDTO
    {
        public int Id { get; set; }
        public UpdateBankBranch updateData { get; set; }
    }
    public class UpdateBankBranch
    {
        public string Address { get; set; }
        public string BankName { get; set; }
      
    }
}
