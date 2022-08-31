using System;

namespace Manage.Model.DTO.Ward
{
    public class UpdateWardDTO
    {
        public int Id { get; set; }
        public UpdateWard updateData { get; set; }
    }
    public class UpdateWard
    {
        public string Name { get; set; }
        public string DistrictName { get; set; }

    }
    //public class UpadteWardMap
    //{
    //    public string Name { get; set; }
    //    public string Districname { get; set; }
    //    public int DistrictId { get; set; }
    //}
}
