
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
    [Route("api/ProjectRole")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ProjectRoleController
        : BaseApiController<ProjectManager.Data.Models.ProjectRole, ProjectRoleDtoGen, ProjectManager.Data.AppDbContext>
    {
        public ProjectRoleController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.ProjectRole>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ProjectRoleDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectRole> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ProjectRoleDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectRole> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectRole> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ProjectRoleDtoGen>> Save(
            ProjectRoleDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectRole> dataSource,
            IBehaviors<ProjectManager.Data.Models.ProjectRole> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ProjectRoleDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.ProjectRole> behaviors,
            IDataSource<ProjectManager.Data.Models.ProjectRole> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
