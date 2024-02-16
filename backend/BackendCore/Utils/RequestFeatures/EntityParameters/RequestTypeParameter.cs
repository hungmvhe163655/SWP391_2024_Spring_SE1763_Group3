namespace BackendCore.Utils.RequestFeatures.EntityParameters
{
    public class RequestTypeParameter : RequestParameters
    {
        public RequestTypeParameter() => OrderBy = "Id";
        public string? Type { get; set; }
    }
}

