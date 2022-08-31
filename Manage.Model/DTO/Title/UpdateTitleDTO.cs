using System;

namespace Manage.Model.DTO.Title
{
    public class UpdateTitleDTO
    {
        public int Id { get; set; }
        public UpdateTitle updateData { get; set; }
    }
    public class UpdateTitle
    {
        public string Name { get; set; }
    }
}
