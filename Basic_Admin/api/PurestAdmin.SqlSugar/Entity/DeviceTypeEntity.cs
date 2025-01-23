namespace PurestAdmin.SqlSugar.Entity;

/// <summary>
/// 
/// </summary>
[SugarTable("MES_DEVICE_TYPE")]
public partial class DeviceTypeEntity
{
	/// <summary>
	/// 设备类型Id
	/// </summary>
	[SugarColumn(ColumnName = "DEVICE_TYPE_ID", IsPrimaryKey = true)]
	public string DeviceTypeId { get; set; }
	/// <summary>
	/// 设备名称（真实展示的）
	/// </summary>
	[SugarColumn(ColumnName = "NAME")]
	public string Name { get; set; }
	/// <summary>
	/// 设备类型（字典中的）
	/// </summary>
	[SugarColumn(ColumnName = "CLASS")]
	public string Class { get; set; }
	/// <summary>
	/// 设备类型Id的int形式
	/// </summary>
	[SugarColumn(ColumnName = "DEVICE_TYPE_ID_INT")]
	public long DeviceTypeIdInt { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    [SugarColumn(ColumnName = "REMARKS")]
    public string Remarks { get; set; }
}