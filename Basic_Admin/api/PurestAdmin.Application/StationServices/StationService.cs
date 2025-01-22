
using PurestAdmin.Application.StationServices.Dtos;

namespace PurestAdmin.Application.StationServices;
/// <summary>
/// Station服务
/// </summary>
[ApiExplorerSettings(GroupName = ApiExplorerGroupConst.MES)]
public class StationService(ISqlSugarClient db) : ApplicationService
{
    private readonly ISqlSugarClient _db = db;

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedList<StationOutput>> GetPagedListAsync(GetPagedListInput input)
    {
        var pagedList = await _db.Queryable<StationEntity>().ToPurestPagedListAsync(input.PageIndex, input.PageSize);
        return pagedList.Adapt<PagedList<StationOutput>>();
    }

    /// <summary>
    /// 单条查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<StationOutput> GetAsync(long id)
    {
        var entity = await _db.Queryable<StationEntity>().FirstAsync(x => x.Id == id);
        return entity.Adapt<StationOutput>();
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<long> AddAsync(AddStationInput input)
    {
        var entity = input.Adapt<StationEntity>();
        return await _db.Insertable(entity).ExecuteReturnSnowflakeIdAsync();
    }

    /// <summary>
    /// 编辑
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task PutAsync(long id, PutStationInput input)
    {
        var entity = await _db.Queryable<StationEntity>().FirstAsync(x => x.Id == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
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
        var entity = await _db.Queryable<StationEntity>().FirstAsync(x => x.Id == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
        _ = await _db.Deleteable(entity).ExecuteCommandAsync();
    }
}
