using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public class DeviceGroupViewModel
{
    public DeviceGroupViewModel()
    {
        ParentDeviceGroupList = new List<GlobalViewModel.DropdownListViewModel>();
    }
    public int Id { get; set; }
    
    [Display(Name = "Parent Device Group")]
    public int? ParentDeviceGroupId { get; set; }
    public List<GlobalViewModel.DropdownListViewModel> ParentDeviceGroupList { get; set; }
    
    [StringLength(512, MinimumLength = 1, ErrorMessage = "Must be between 1 and 512 characters")]
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = new string("");
    
    [Display(Name = "Status")]
    public bool Active { get; set; }
}
public class DeviceGroupGridViewModel
{
    public int Id { get; set; }
    
    [Display(Name = "Parent Device Group")]
    public string? ParentDeviceGroup { get; set; }
    
    [Display(Name = "Name")]
    public string Name { get; set; } = new string("");
    
    [Display(Name = "Status")]
    public bool Active { get; set; }
}