namespace Manage.Model.DTO.Ward
{
    public class ListWard
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public int DistrictId { get; set; }
    }
    public class ListWardDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
    }
}
