
namespace PurestAdmin.Application.DeviceServices.Dtos;
public class DeviceOutput
{
	/// <summary>
	/// 设备唯一标识
	/// </summary>
	public string DeviceId { get; set; }
	/// <summary>
	/// 设备绑定的工位ID，引用Station表
	/// </summary>
	public string StationId { get; set; }
	/// <summary>
	/// 设备类型ID，引用Device_type表
	/// </summary>
	public string DeviceTypeId { get; set; }
	/// <summary>
	/// 设备名称
	/// </summary>
	public string DeviceName { get; set; }
	/// <summary>
	/// 记录创建时间
	/// </summary>
	public DateTime? Createdat { get; set; }
	/// <summary>
	/// 记录更新时间
	/// </summary>
	public DateTime? Updatedat { get; set; }
	/// <summary>
	/// 设备地址
	/// </summary>
	public string Address { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Port { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Init1 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Init2 { get; set; }
}
