using DataAccesLayer.Enums;

namespace DataAccessLayer.Models;

public class GlobalViewModel
{
    public class ResultModel
    {
        public ResultModel()
        {
            Id = (int)GlobalEnums.EnumResultValues.Failed;
            Message = "Failed";
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public string Additions { get; set; }
    }

    public class DropdownListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}