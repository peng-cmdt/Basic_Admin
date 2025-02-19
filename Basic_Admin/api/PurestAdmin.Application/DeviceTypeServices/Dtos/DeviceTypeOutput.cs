
namespace PurestAdmin.Application.DeviceTypeServices.Dtos;
public class DeviceTypeOutput
{
	/// <summary>
	/// 设备类型Id
	/// </summary>
	public string DeviceTypeId { get; set; }
	/// <summary>
	/// 设备名称（真实展示的）
	/// </summary>
	public string Name { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Remarks { get; set; }
	/// <summary>
	/// 设备类型（字典中的）
	/// </summary>
	public string Class { get; set; }
	/// <summary>
	/// 设备类型Id的int形式
	/// </summary>
	public long DeviceTypeIdInt { get; set; }
}
