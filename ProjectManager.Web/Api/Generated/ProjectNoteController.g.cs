
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
    [Route("api/ProjectNote")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ProjectNoteController
        : BaseApiController<ProjectManager.Data.Models.ProjectNote, ProjectNoteDtoGen, ProjectManager.Data.AppDbContext>
    {
        public ProjectNoteController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.ProjectNote>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ProjectNoteDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectNote> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ProjectNoteDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectNote> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectNote> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ProjectNoteDtoGen>> Save(
            ProjectNoteDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.ProjectNote> dataSource,
            IBehaviors<ProjectManager.Data.Models.ProjectNote> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ProjectNoteDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.ProjectNote> behaviors,
            IDataSource<ProjectManager.Data.Models.ProjectNote> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
