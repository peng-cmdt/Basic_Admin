namespace PurestAdmin.SqlSugar.Entity;

/// <summary>
/// 
/// </summary>
[SugarTable("MES_STATION")]
public partial class StationEntity : BaseEntity
{
	/// <summary>
	/// 工位唯一标识
	/// </summary>
	[SugarColumn(ColumnName = "STATION_ID", IsPrimaryKey = true)]
	public string StationId { get; set; }
	/// <summary>
	/// 工位名称
	/// </summary>
	[SugarColumn(ColumnName = "STATION_NAME")]
	public string StationName { get; set; }
	/// <summary>
	/// 工位IP
	/// </summary>
	[SugarColumn(ColumnName = "STATION_IP")]
	public string StationIp { get; set; }
	/// <summary>
	/// 工位端口
	/// </summary>
	[SugarColumn(ColumnName = "STATION_ESTABLISH_PORT")]
	public int StationEstablishPort { get; set; }
	/// <summary>
	/// 工位描述
	/// </summary>
	[SugarColumn(ColumnName = "STATION_DESCRIPTION")]
	public string StationDescription { get; set; }
	/// <summary>
	/// 记录创建时间
	/// </summary>
	[SugarColumn(ColumnName = "CreatedAt")]
	public DateTime? Createdat { get; set; }
	/// <summary>
	/// 记录更新时间
	/// </summary>
	[SugarColumn(ColumnName = "UpdatedAt")]
	public DateTime? Updatedat { get; set; }
	/// <summary>
	/// 关联Assambly_line表
	/// </summary>
	[SugarColumn(ColumnName = "ASS_LINE_ID")]
	public string AssLineId { get; set; }
	/// <summary>
	/// 关联station_mode表
	/// </summary>
	[SugarColumn(ColumnName = "STATION_MODE_ID")]
	public string StationModeId { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "part1")]
	public string Part1 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "part2")]
	public string Part2 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "part3")]
	public string Part3 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "part4")]
	public string Part4 { get; set; }
}