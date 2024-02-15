namespace BackendCore.Utils.RequestFeatures.EntityParameters
{
    public class TenantParameter : RequestParameters
    {
        public TenantParameter() => OrderBy = "FullName";

        public bool? IsMale { get; set; }
        public DateTime? StartCreatedDate { get; set; }
        public DateTime? EndCreatedDate { get; set; }

        public bool ValidDateRange => EndCreatedDate > StartCreatedDate;

        public string? SearchTerm { get; set; }
    }
}
