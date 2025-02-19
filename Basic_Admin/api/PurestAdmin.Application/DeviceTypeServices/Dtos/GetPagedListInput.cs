
namespace PurestAdmin.Application.DeviceTypeServices.Dtos;
public class GetPagedListInput : PaginationParams
{
    public string DeviceTypeId { get; set; }
    /// <summary>
    /// ×Ê²ú×´Ì¬
    /// </summary>
    public string Class { get; set; }
}
