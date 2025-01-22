
using PurestAdmin.Application.DeviceServices.Dtos;

namespace PurestAdmin.Application.DeviceServices;
/// <summary>
/// Device服务
/// </summary>
[ApiExplorerSettings(GroupName = ApiExplorerGroupConst.SYSTEM)]
public class DeviceService(ISqlSugarClient db) : ApplicationService
{
    private readonly ISqlSugarClient _db = db;

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedList<DeviceOutput>> GetPagedListAsync(GetPagedListInput input)
    {
        var pagedList = await _db.Queryable<DeviceEntity>().ToPurestPagedListAsync(input.PageIndex, input.PageSize);
        return pagedList.Adapt<PagedList<DeviceOutput>>();
    }

    /// <summary>
    /// 单条查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<DeviceOutput> GetAsync(long id)
    {
        var entity = await _db.Queryable<DeviceEntity>().FirstAsync(x => x.Id == id);
        return entity.Adapt<DeviceOutput>();
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<long> AddAsync(AddDeviceInput input)
    {
        var entity = input.Adapt<DeviceEntity>();
        return await _db.Insertable(entity).ExecuteReturnSnowflakeIdAsync();
    }

    /// <summary>
    /// 编辑
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task PutAsync(long id, PutDeviceInput input)
    {
        var entity = await _db.Queryable<DeviceEntity>().FirstAsync(x => x.Id == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
        var newEntity = input.Adapt(entity);
        _ = await _db.Updateable(newEntity).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteAsync(long id)
    {
        var entity = await _db.Queryable<DeviceEntity>().FirstAsync(x => x.Id == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
        _ = await _db.Deleteable(entity).ExecuteCommandAsync();
    }
}
