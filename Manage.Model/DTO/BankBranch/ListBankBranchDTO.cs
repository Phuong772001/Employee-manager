namespace Manage.Model.DTO.BankBranch
{
    public class ListBankBranch
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Address { get; set; }
        public int BankID { get; set; }
        public string Bankname { get; set; }
    }
    public class ListBankBranchDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Address { get; set; }
        public string Bankname { get; set; }
    }

}
