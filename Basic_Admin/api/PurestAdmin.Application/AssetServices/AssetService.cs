
using PurestAdmin.Application.AssetServices.Dtos;

namespace PurestAdmin.Application.AssetServices;
/// <summary>
/// Asset服务
/// </summary>
/// <param name="db"></param>
/// <param name="_assetRepository"></param>
[ApiExplorerSettings(GroupName = ApiExplorerGroupConst.SYSTEM)]
public class AssetService(ISqlSugarClient db, Repository<AssetEntity> _assetRepository) : ApplicationService
{
    private readonly ISqlSugarClient _db = db;
    private readonly Repository<AssetEntity> assetRepository = _assetRepository;

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagedList<AssetOutput>> GetPagedListAsync(GetPagedListInput input)
    {
        //var pagedList = await _db.Queryable<AssetEntity>().ToPurestPagedListAsync(input.PageIndex, input.PageSize);
        //return pagedList.Adapt<PagedList<AssetOutput>>();

        var pagedList = await _db.Queryable<AssetEntity>()
            .LeftJoin<UserEntity>((a, u) => a.AssignUser == u.Id).InnerJoin<UserEntity>((a,u,u1)=>a.LastUser == u1.Id)
            .WhereIF(!input.AssetId.IsNullOrEmpty(), a => a.AssetId.Contains(input.AssetId))
            .WhereIF(input.AssetStatus != null, a => a.AssetStatus == input.AssetStatus)
            .Select((a, u,u1) => new AssetEntity
            {
                Id = a.Id.SelectAll(),
                AssetTypeName = a.AssetType.GetConfigValue<DictDataEntity>(),
                AssignUserName = u.Name,
                LastUserName = u1.Name
                //LastUserName = SqlFunc.Subqueryable<UserEntity>().Where(o => o.Id == a.LastUser).Select(o => o.Name) 此方法也可行，但是略微复杂，改用上述查询
            })
            .OrderBy(a => a.PurchaseDate)
            .ToPurestPagedListAsync(input.PageIndex, input.PageSize);
        return pagedList.Adapt<PagedList<AssetOutput>>();
    }
    
    /// <summary>
    /// 单条查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<AssetOutput> GetAsync(long id)
    {
        var entity = await _db.Queryable<AssetEntity>().FirstAsync(x => x.Id == id);
        return entity.Adapt<AssetOutput>();
    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<long> AddAsync(AddAssetInput input)
    {
        var entity = input.Adapt<AssetEntity>();
        var id = await assetRepository.InsertReturnSnowflakeIdAsync(entity);
        //return await _db.Insertable(entity).ExecuteReturnSnowflakeIdAsync();
        return id;
    }

    /// <summary>
    /// 编辑
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task PutAsync(long id, PutAssetInput input)
    {
        var entity = await _db.Queryable<AssetEntity>().FirstAsync(x => x.Id == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
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
        var entity = await _db.Queryable<AssetEntity>().FirstAsync(x => x.Id == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
        _ = await _db.Deleteable(entity).ExecuteCommandAsync();
    }
}
