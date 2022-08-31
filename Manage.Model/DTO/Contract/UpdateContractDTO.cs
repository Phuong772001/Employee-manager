using System;

namespace Manage.Model.DTO.Contract
{
   public class UpdateContractDTO
    {
        public int Id { get; set; }
        public UpdateContract updateData { get; set; }
    }

   public class UpdateContract
    {
       public string Name { get; set; }
       public string Note { get; set; }
       public int? NumberOfMonth { get; set; }
       public double? Money { get; set; }
    }
}
