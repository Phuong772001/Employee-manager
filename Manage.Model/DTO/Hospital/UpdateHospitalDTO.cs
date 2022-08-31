using System;

namespace Manage.Model.DTO.Hospital
{
    public class UpdateHospitalDTO
    {
        public int Id { get; set; }
        public UpdateHospital updateData { get; set; }
    }
    public class UpdateHospital
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
