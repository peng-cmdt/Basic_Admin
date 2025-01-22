
namespace PurestAdmin.Application.StationServices.Dtos;
public class StationOutput
{
	/// <summary>
	/// 工位唯一标识
	/// </summary>
	public string StationId { get; set; }
	/// <summary>
	/// 工位名称
	/// </summary>
	public string StationName { get; set; }
	/// <summary>
	/// 工位IP
	/// </summary>
	public string StationIp { get; set; }
	/// <summary>
	/// 工位端口
	/// </summary>
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
