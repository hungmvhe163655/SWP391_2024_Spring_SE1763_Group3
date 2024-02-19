namespace BackendCore.Utils.RequestFeatures.EntityParameters
{
    public class RequestStatusParameter : RequestParameters
    {
        public RequestStatusParameter() => OrderBy = "Id";
        public string? Status { get; set; }
    }
}
