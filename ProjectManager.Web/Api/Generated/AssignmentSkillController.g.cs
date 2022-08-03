
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
    [Route("api/AssignmentSkill")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class AssignmentSkillController
        : BaseApiController<ProjectManager.Data.Models.AssignmentSkill, AssignmentSkillDtoGen, ProjectManager.Data.AppDbContext>
    {
        public AssignmentSkillController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.AssignmentSkill>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AssignmentSkillDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.AssignmentSkill> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<AssignmentSkillDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.AssignmentSkill> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.AssignmentSkill> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<AssignmentSkillDtoGen>> Save(
            AssignmentSkillDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.AssignmentSkill> dataSource,
            IBehaviors<ProjectManager.Data.Models.AssignmentSkill> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AssignmentSkillDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.AssignmentSkill> behaviors,
            IDataSource<ProjectManager.Data.Models.AssignmentSkill> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
