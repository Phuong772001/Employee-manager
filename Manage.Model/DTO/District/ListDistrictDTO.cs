namespace Manage.Model.DTO.District
{
    public class ListDistrict
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
    public class ListDistrictDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string ProvinceName { get; set; }
    }
}
