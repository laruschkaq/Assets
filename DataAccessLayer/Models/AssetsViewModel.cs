using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public class AssetsViewModel
{
    public AssetsViewModel()
    {
        DeviceGroupList = new List<GlobalViewModel.DropdownListViewModel>();
    }
    public int Id { get; set; }
    
    [StringLength(512, MinimumLength = 1, ErrorMessage = "Must be between 1 and 512 characters")]
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = new string("");
    
    [StringLength(512, MinimumLength = 1, ErrorMessage = "Must be between 1 and 512 characters")]
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Serial Number")]
    public string SerialNumber { get; set; } = new string("");
    
    [StringLength(5, MinimumLength = 1, ErrorMessage = "Must be between 1 and 5 characters")]
    [Required(ErrorMessage = "Required")]
    [Display(Name = "Firmware Version")]
    public string FirmwareVersion { get; set; } = new string("");
    
    [Display(Name = "Device Group")]
    public int? DeviceGroupId { get; set; }
    public List<GlobalViewModel.DropdownListViewModel> DeviceGroupList { get; set; }
    
    [Display(Name = "Status")]
    public bool Active { get; set; }
    
}

public class AssetsGridViewModel
{
    public int Id { get; set; }
    
    [Display(Name = "Name")]
    public string Name { get; set; } = new string("");
    
    [Display(Name = "Serial Number")]
    public string SerialNumber { get; set; } = new string("");
    
    [Display(Name = "Firmware Version")]
    public string FirmwareVersion { get; set; } = new string("");
    
    [Display(Name = "Device Group")]
    public string DeviceGroup { get; set; }
    
    [Display(Name = "Status")]
    public bool Active { get; set; }
}