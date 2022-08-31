using System;

namespace Manage.Model.DTO.Province
{
    public class UpdateProvinceDTO
    {
        public int Id { get; set; }
        public UpdateProvince updateData { get; set; }
    }
    public class UpdateProvince
    {
        public string Name { get; set; }
        public string Nation { get; set; }
    }
}
