
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.Web.Api
{
    [Route("api/Assignment")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class AssignmentController
        : BaseApiController<ProjectManager.Data.Models.Assignment, AssignmentDtoGen, ProjectManager.Data.AppDbContext>
    {
        public AssignmentController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.Assignment>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AssignmentDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Assignment> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<AssignmentDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.Assignment> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.Assignment> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<AssignmentDtoGen>> Save(
            AssignmentDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Assignment> dataSource,
            IBehaviors<ProjectManager.Data.Models.Assignment> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AssignmentDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.Assignment> behaviors,
            IDataSource<ProjectManager.Data.Models.Assignment> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        // Methods from data class exposed through API Controller.

        /// <summary>
        /// Method: GetUsersWithSkills
        /// </summary>
        [HttpPost("GetUsersWithSkills")]
        [Authorize]
        public virtual async Task<ItemResult<System.Collections.Generic.ICollection<OrganizationUserDtoGen>>> GetUsersWithSkills([FromServices] IDataSourceFactory dataSourceFactory, int id)
        {
            var dataSource = dataSourceFactory.GetDataSource<ProjectManager.Data.Models.Assignment, ProjectManager.Data.Models.Assignment>("Default");
            var (itemResult, _) = await dataSource.GetItemAsync(id, new ListParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult<System.Collections.Generic.ICollection<OrganizationUserDtoGen>>(itemResult);
            }
            var item = itemResult.Object;
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(User);
            var _methodResult = item.GetUsersWithSkills(Db);
            await Db.SaveChangesAsync();
            var _result = new ItemResult<System.Collections.Generic.ICollection<OrganizationUserDtoGen>>();
            _result.Object = _methodResult?.ToList().Select(o => Mapper.MapToDto<ProjectManager.Data.Models.OrganizationUser, OrganizationUserDtoGen>(o, _mappingContext, includeTree)).ToList();
            return _result;
        }
    }
}
