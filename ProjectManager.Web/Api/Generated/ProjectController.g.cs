
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
    [Route("api/Project")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ProjectController
        : BaseApiController<ProjectManager.Data.Models.Project, ProjectDtoGen, ProjectManager.Data.AppDbContext>
    {
        public ProjectController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.Project>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ProjectDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Project> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ProjectDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.Project> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.Project> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ProjectDtoGen>> Save(
            ProjectDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Project> dataSource,
            IBehaviors<ProjectManager.Data.Models.Project> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ProjectDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.Project> behaviors,
            IDataSource<ProjectManager.Data.Models.Project> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
