namespace BackendCore.Utils.RequestFeatures.EntityParameters
{
    public class NewsParameter : RequestParameters
    {
        public NewsParameter() => OrderBy = "CreateDate";
        public DateTime? StartCreatedDate { get; set; }
        public DateTime? EndCreatedDate { get; set; }

        public bool ValidDateRange => EndCreatedDate > StartCreatedDate;
    }
}
