
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
    [Route("api/Skill")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class SkillController
        : BaseApiController<ProjectManager.Data.Models.Skill, SkillDtoGen, ProjectManager.Data.AppDbContext>
    {
        public SkillController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.Skill>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<SkillDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Skill> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<SkillDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.Skill> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.Skill> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<SkillDtoGen>> Save(
            SkillDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Skill> dataSource,
            IBehaviors<ProjectManager.Data.Models.Skill> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<SkillDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.Skill> behaviors,
            IDataSource<ProjectManager.Data.Models.Skill> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
