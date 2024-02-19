namespace BackendCore.Utils.RequestFeatures.EntityParameters
{
    public class ContractParameter : RequestParameters
    {
        public ContractParameter() => OrderBy = "CreatedAt";
        public DateTime? StartCreatedDate { get; set; }
        public DateTime? EndCreatedDate { get; set; }

        public bool ValidDateRange => EndCreatedDate > StartCreatedDate;

        public decimal? Deposit { get; set; }
    }
}
