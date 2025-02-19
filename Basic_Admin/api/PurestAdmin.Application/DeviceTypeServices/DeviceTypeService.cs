
using System.Linq;
using PurestAdmin.Application.DeviceTypeServices.Dtos;

namespace PurestAdmin.Application.DeviceTypeServices;
/// <summary>
/// DeviceType服务
/// </summary>
[ApiExplorerSettings(GroupName = ApiExplorerGroupConst.SYSTEM)]
public class DeviceTypeService(ISqlSugarClient db, Repository<DictDataEntity> dicRepository) : ApplicationService
{
    private readonly ISqlSugarClient _db = db;
    private readonly Repository<DictDataEntity> _dicRepository = dicRepository;

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="input">当前传进来的参数中，名称是Class，实际上值是Id</param>
    /// <returns></returns>
    public async Task<PagedList<DeviceTypeOutput>> GetPagedListAsync(GetPagedListInput input)
    {
        //var asc = _db.Queryable<DictDataEntity>().WhereIF(!input.Class.IsNullOrEmpty(), a => a.Id.Equals(input.Class)).First();
        //var pagedList = await _db.Queryable<DeviceTypeEntity>()
        //    .WhereIF(asc is not null, p => p.Class.Equals(asc.Name))
        //    .WhereIF(!input.DeviceTypeId.IsNullOrEmpty(), a => a.DeviceTypeId.Contains(input.DeviceTypeId))
        //    .ToPurestPagedListAsync(input.PageIndex, input.PageSize);
        //return pagedList.Adapt<PagedList<DeviceTypeOutput>>();


        var pagedList = await _db.Queryable<DeviceTypeEntity>()
            .LeftJoin<DictDataEntity>((dte, dde) => dte.Class == dde.Name) // 假设 DeviceTypeEntity 的 Class 字段存储的是 DictDataEntity 的 Name
            .WhereIF(!input.Class.IsNullOrEmpty(), (dte, dde) => dde.Id.Equals(input.Class))
            .WhereIF(!input.DeviceTypeId.IsNullOrEmpty(), (dte) => dte.DeviceTypeId.Contains(input.DeviceTypeId))
            .Select((dte, dde) => new DeviceTypeOutput
            {
                // 假设 DeviceTypeOutput 有这些属性，根据实际情况调整
                //DeviceTypeIdInt = dde.Id,
                Name = dte.Name,
                Class = dde.Name,
                DeviceTypeId = dte.DeviceTypeId,
                Remarks = dte.Remarks,
                // 可以添加其他需要的属性
            })
            .OrderBy(dte => dte.Name) // 可以根据实际需求调整排序规则
            .ToPurestPagedListAsync(input.PageIndex, input.PageSize);

        return pagedList;




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
        //var id = await _deviceTypeRepository.InsertReturnSnowflakeIdAsync(entity); //此种写法仅仅支持主键为Long格式的插入，非long格式的无法插入
        entity.DeviceTypeIdInt = _dicRepository.GetSingle(o=>o.Name == input.Class).Id;
        return await _db.Insertable(entity).ExecuteCommandAsync();
    }

    /// <summary>
    /// 编辑
    /// </summary>             
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task PutAsync(string id, PutDeviceTypeInput input)
    {
        var entity = await _db.Queryable<DeviceTypeEntity>().FirstAsync(x => x.DeviceTypeIdInt.ToString() == id) ?? throw PersistdValidateException.Message(ErrorTipsEnum.NoResult);
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
