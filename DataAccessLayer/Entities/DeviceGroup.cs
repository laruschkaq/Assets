namespace DataAccesLayer.Entities;

public class DeviceGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = new string("");
    public int? ParentDeviceGroupId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedOnDateTime { get; set; }
    public DateTime LastModifiedOnDateTime { get; set; }
    public ICollection<Assets> NavAssets { get; set; } = new HashSet<Assets>();
    public DeviceGroup? NavParentDeviceGroups { get; set; }
}