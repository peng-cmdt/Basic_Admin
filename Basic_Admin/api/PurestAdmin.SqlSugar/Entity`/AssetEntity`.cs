// Copyright © 2023-present https://github.com/dymproject/purest-admin作者以及贡献者

namespace PurestAdmin.SqlSugar.Entity;
public partial class AssetEntity
{
    /// <summary>
    /// 用户名称
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public string AssignUserName { get; set; }

    /// <summary>
    /// 上一位用户名称
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public string LastUserName { get; set; }

    /// <summary>
    /// 资产类型名称
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public string AssetTypeName { get; set; }
}
