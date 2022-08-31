using System;

namespace Manage.Model.DTO.Welface
{
    public class UpdateWelfaceDTO
    {
        public int Id { get; set; }
        public UpdateWelface updateData { get; set; }
    }
    public class UpdateWelface
    {
        public string Name { get; set; }
    }
}
