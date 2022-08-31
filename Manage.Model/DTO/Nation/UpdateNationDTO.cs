using System;

namespace Manage.Model.DTO.Nation
{
    public class UpdateNationDTO
    {
        public int Id { get; set; }
        public UpdateNation updateData { get; set; }
    }
    public class UpdateNation
    {
        public string Name { get; set; }
    }
}
