
namespace PurestAdmin.Application.AssetServices.Dtos;
public class GetPagedListInput : PaginationParams
{
    public string AssetId { get; set; }
    /// <summary>
    /// ×Ê²ú×´Ì¬
    /// </summary>
    public long? AssetStatus { get; set; }


}
