
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
    [Route("api/UserSkill")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class UserSkillController
        : BaseApiController<ProjectManager.Data.Models.UserSkill, UserSkillDtoGen, ProjectManager.Data.AppDbContext>
    {
        public UserSkillController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.UserSkill>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<UserSkillDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.UserSkill> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<UserSkillDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.UserSkill> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.UserSkill> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<UserSkillDtoGen>> Save(
            UserSkillDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.UserSkill> dataSource,
            IBehaviors<ProjectManager.Data.Models.UserSkill> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<UserSkillDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.UserSkill> behaviors,
            IDataSource<ProjectManager.Data.Models.UserSkill> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
