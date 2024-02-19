namespace BackendCore.Utils.RequestFeatures.EntityParameters
{
    public class BuildingServiceParameter : RequestParameters
    {
        public BuildingServiceParameter() => OrderBy = "FullName";
        public string? SearchTerm { get; set; }
    }
}
