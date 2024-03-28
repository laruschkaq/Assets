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
            AdditionalId = 0;
            UpdatedDdl = new DropdownListViewModel();
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public string Additions { get; set; }
        public string Data { get; set; }

        public long LongId { get; set; }
        public int IntId { get; set; }
        public int AdditionalId { get; set; }

        public DropdownListViewModel UpdatedDdl { get; set; }
    }

    public class DropdownListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}