
namespace PurestAdmin.Application.AssetServices.Dtos;
public class AddAssetInput
{
	/// <summary>
	/// 
	/// </summary>
	public string AssetId { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public long AssetType { get; set; }
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
	/// 
	/// </summary>
	public int Warranty { get; set; }
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
	public long LastUser { get; set; }
}
