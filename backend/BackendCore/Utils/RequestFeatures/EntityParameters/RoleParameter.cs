namespace BackendCore.Utils.RequestFeatures.EntityParameters
{
    public class RoleParameter : RequestParameters
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? SearchTerm { get; set; }
    }
}