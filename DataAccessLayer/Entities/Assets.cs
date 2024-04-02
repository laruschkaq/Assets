namespace DataAccesLayer.Entities;

public class Assets
{
    public int Id { get; set; }
    public string Name { get; set; } = new string("");
    public string SerialNumber { get; set; } = new string("");
    public string FirmwareVersion { get; set; } = new string("");
    public int? DeviceGroupId { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedOnDateTime { get; set; }
    public DateTime LastModifiedOnDateTime { get; set; }
    public DeviceGroup NavDeviceGroups { get; set; }
}