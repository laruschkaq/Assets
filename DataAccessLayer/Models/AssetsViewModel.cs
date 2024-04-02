namespace DataAccessLayer.Models;

public class AssetsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = new string("");
    public string SerialNumber { get; set; } = new string("");
    public int DeviceGroupId { get; set; }
    public bool Active { get; set; }
}