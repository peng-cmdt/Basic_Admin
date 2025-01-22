
namespace PurestAdmin.Application.AssetServices.Dtos;
public class AssetOutput
{
    /// <summary>
    /// 
    /// </summary>
    public long? Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string AssetId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long AssetType { get; set; }

    public string AssetTypeName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string AssetBrand { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string AssetModel { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string AssetSeries { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ServerTag { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long AssignUser { get; set; }
    /// <summary>
    /// Ãû³Æ
    /// </summary>
    public string? AssignUserName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long Warranty { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? PurchaseDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Remark { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string AssetName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int AssetStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? AssetStatusText { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public long LastUser { get; set; }

    public string LastUserName { get; set; }
}
