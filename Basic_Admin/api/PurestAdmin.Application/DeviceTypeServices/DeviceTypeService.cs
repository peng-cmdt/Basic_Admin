
using System.Linq;
using PurestAdmin.Application.DeviceTypeServices.Dtos;

namespace PurestAdmin.Application.DeviceTypeServices;
/// <summary>
/// DeviceType服务
/// </summary>
[ApiExplorerSettings(GroupName = ApiExplorerGroupConst.SYSTEM)]
public class DeviceTypeService(ISqlSugarClient db) : ApplicationService
{
    private readonly ISqlSugarClient _db = db;

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedList<DeviceTypeOutput>> GetPagedListAsync(GetPagedListInput input)
    {
        var pagedList = await _db.Queryable<DeviceTypeEntity>().WhereIF(!input.DeviceTypeId.IsNullOrEmpty(), a => a.DeviceTypeId.Contains(input.DeviceTypeId))
            .WhereIF(input.Class != null, a => a.DeviceTypeIdInt == input.Class).ToPurestPagedListAsync(input.PageIndex, input.PageSize);
        //var pagedList = await _db.Queryable<DeviceTypeEntity>().ToListAsync();
        return pagedList.Adapt<PagedList<DeviceTypeOutput>>();
        //
    }

    /// <summary>
    /// 单条查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<DeviceTypeOutput> GetAsync(string id)
    {
        var entity = await _db.Queryable<DeviceTypeEntity>().FirstAsync(x => x.DeviceTypeId == id);
        return entity.Adapt<DeviceTypeOutput>();
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<long> AddAsync(AddDeviceTypeInput input)
    {
        var entity = input.Adapt<DeviceTypeEntity>();
        return await _db.Insertable(entity).ExecuteReturnSnowflakeIdAsync();
    }

    /// <summary>
    /// 编辑
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task PutAsync(string id, PutDeviceTypeInput input)
    {
        var entity = await _db.Queryable<DeviceTypeEntity>().FirstAsync(x => x.DeviceTypeId == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
        var newEntity = input.Adapt(entity);
        _ = await _db.Updateable(newEntity).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(string id)
    {
        var entity = await _db.Queryable<DeviceTypeEntity>().FirstAsync(x => x.DeviceTypeId == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
        _ = await _db.Deleteable(entity).ExecuteCommandAsync();
    }
}
