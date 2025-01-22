namespace PurestAdmin.SqlSugar.Entity;

/// <summary>
/// 设备
/// </summary>
[SugarTable("MES_DEVICE")]
public partial class DeviceEntity : BaseEntity
{
	/// <summary>
	/// 设备唯一标识
	/// </summary>
	[SugarColumn(ColumnName = "DEVICE_ID", IsPrimaryKey = true)]
	public string DeviceId { get; set; }
	/// <summary>
	/// 设备绑定的工位ID，引用Station表
	/// </summary>
	[SugarColumn(ColumnName = "STATION_ID")]
	public string StationId { get; set; }
	/// <summary>
	/// 设备类型ID，引用Device_type表
	/// </summary>
	[SugarColumn(ColumnName = "DEVICE_TYPE_ID")]
	public string DeviceTypeId { get; set; }
	/// <summary>
	/// 设备名称
	/// </summary>
	[SugarColumn(ColumnName = "DEVICE_NAME")]
	public string DeviceName { get; set; }
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
	/// 设备地址
	/// </summary>
	[SugarColumn(ColumnName = "ADDRESS")]
	public string Address { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "PORT")]
	public string Port { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "INIT1")]
	public string Init1 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[SugarColumn(ColumnName = "INIT2")]
	public string Init2 { get; set; }
}