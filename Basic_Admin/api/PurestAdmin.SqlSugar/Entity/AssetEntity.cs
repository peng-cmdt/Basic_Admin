namespace PurestAdmin.SqlSugar.Entity;

/// <summary>
/// 
/// </summary>
[SugarTable("PUREST_ASSET")]
public partial class AssetEntity : BaseEntity
{
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSET_ID")]
	public string AssetId { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSET_TYPE")]
	public long AssetType { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSET_BRAND")]
	public string AssetBrand { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSET_MODEL")]
	public string AssetModel { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSET_SERIES")]
	public string AssetSeries { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "SERVER_TAG")]
	public string ServerTag { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSIGN_USER")]
	public long AssignUser { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "WARRANTY")]
	public string Warranty { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "PURCHASE_DATE")]
	public DateTime? PurchaseDate { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSET_NAME")]
	public string AssetName { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "ASSET_STATUS")]
	public int AssetStatus { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "LAST_USER")]
	public long LastUser { get; set; }
}