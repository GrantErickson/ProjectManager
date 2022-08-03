
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
    [Route("api/TimeEntry")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class TimeEntryController
        : BaseApiController<ProjectManager.Data.Models.TimeEntry, TimeEntryDtoGen, ProjectManager.Data.AppDbContext>
    {
        public TimeEntryController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.TimeEntry>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<TimeEntryDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.TimeEntry> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<TimeEntryDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.TimeEntry> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.TimeEntry> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<TimeEntryDtoGen>> Save(
            TimeEntryDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.TimeEntry> dataSource,
            IBehaviors<ProjectManager.Data.Models.TimeEntry> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<TimeEntryDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.TimeEntry> behaviors,
            IDataSource<ProjectManager.Data.Models.TimeEntry> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
