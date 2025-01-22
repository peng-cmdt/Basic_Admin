
namespace PurestAdmin.Application.DeviceServices.Dtos;
public class AddDeviceInput
{
	/// <summary>
	/// 设备唯一标识
	/// </summary>
	[Required(ErrorMessage = "设备唯一标识不能为空"), MaxLength(19, ErrorMessage = "设备唯一标识最大长度为：19")]
	public string DeviceId { get; set; }
	/// <summary>
	/// 设备绑定的工位ID，引用Station表
	/// </summary>
	[Required(ErrorMessage = "设备绑定的工位ID，引用Station表不能为空"), MaxLength(19, ErrorMessage = "设备绑定的工位ID，引用Station表最大长度为：19")]
	public string StationId { get; set; }
	/// <summary>
	/// 设备类型ID，引用Device_type表
	/// </summary>
	[Required(ErrorMessage = "设备类型ID，引用Device_type表不能为空"), MaxLength(10, ErrorMessage = "设备类型ID，引用Device_type表最大长度为：10")]
	public string DeviceTypeId { get; set; }
	/// <summary>
	/// 设备名称
	/// </summary>
	[Required(ErrorMessage = "设备名称不能为空"), MaxLength(10, ErrorMessage = "设备名称最大长度为：10")]
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
	[Required(ErrorMessage = "设备地址不能为空"), MaxLength(20, ErrorMessage = "设备地址最大长度为：20")]
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
