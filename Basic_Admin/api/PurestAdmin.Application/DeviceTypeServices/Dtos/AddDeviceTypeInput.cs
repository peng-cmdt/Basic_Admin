
namespace PurestAdmin.Application.DeviceTypeServices.Dtos;
public class AddDeviceTypeInput
{
	/// <summary>
	/// 设备类型Id
	/// </summary>
	[Required(ErrorMessage = "设备类型Id不能为空"), MaxLength(10, ErrorMessage = "设备类型Id最大长度为：10")]
	public string DeviceTypeId { get; set; }
	/// <summary>
	/// 设备名称（真实展示的）
	/// </summary>
	[Required(ErrorMessage = "设备名称（真实展示的）不能为空"), MaxLength(255, ErrorMessage = "设备名称（真实展示的）最大长度为：255")]
	public string Name { get; set; }
	/// <summary>
	/// 
	/// </summary>
	[MaxLength(1000, ErrorMessage = "最大长度为：1000")]
	public string Remarks { get; set; }
	/// <summary>
	/// 设备类型（字典中的）
	/// </summary>
	[Required(ErrorMessage = "设备类型（字典中的）不能为空"), MaxLength(50, ErrorMessage = "设备类型（字典中的）最大长度为：50")]
	public string Class { get; set; }
	/// <summary>
	/// 设备类型Id的int形式
	/// </summary>
	[Required(ErrorMessage = "设备类型Id的int形式不能为空"), MaxLength(19, ErrorMessage = "设备类型Id的int形式最大长度为：19")]
	public long DeviceTypeIdInt { get; set; }
}
