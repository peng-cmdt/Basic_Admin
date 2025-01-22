
namespace PurestAdmin.Application.StationServices.Dtos;
public class AddStationInput
{
	/// <summary>
	/// 工位唯一标识
	/// </summary>
	[Required(ErrorMessage = "工位唯一标识不能为空"), MaxLength(19, ErrorMessage = "工位唯一标识最大长度为：19")]
	public string StationId { get; set; }
	/// <summary>
	/// 工位名称
	/// </summary>
	[Required(ErrorMessage = "工位名称不能为空"), MaxLength(10, ErrorMessage = "工位名称最大长度为：10")]
	public string StationName { get; set; }
	/// <summary>
	/// 工位IP
	/// </summary>
	[Required(ErrorMessage = "工位IP不能为空"), MaxLength(255, ErrorMessage = "工位IP最大长度为：255")]
	public string StationIp { get; set; }
	/// <summary>
	/// 工位端口
	/// </summary>
	[Required(ErrorMessage = "工位端口不能为空")]
	public int StationEstablishPort { get; set; }
	/// <summary>
	/// 工位描述
	/// </summary>
	public string StationDescription { get; set; }
	/// <summary>
	/// 记录创建时间
	/// </summary>
	public DateTime? Createdat { get; set; }
	/// <summary>
	/// 记录更新时间
	/// </summary>
	public DateTime? Updatedat { get; set; }
	/// <summary>
	/// 关联Assambly_line表
	/// </summary>
	public string AssLineId { get; set; }
	/// <summary>
	/// 关联station_mode表
	/// </summary>
	public string StationModeId { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Part1 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Part2 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Part3 { get; set; }
	/// <summary>
	/// 
	/// </summary>
	public string Part4 { get; set; }
}
