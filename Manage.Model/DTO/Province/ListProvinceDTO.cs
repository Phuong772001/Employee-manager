namespace Manage.Model.DTO.Province
{
    public class ListProvince
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }

        public int NationId { get; set; }
    }
    public class ListProvinceDTO
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }

    }
}
