
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
    [Route("api/OrganizationUser")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class OrganizationUserController
        : BaseApiController<ProjectManager.Data.Models.OrganizationUser, OrganizationUserDtoGen, ProjectManager.Data.AppDbContext>
    {
        public OrganizationUserController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.OrganizationUser>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<OrganizationUserDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.OrganizationUser> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<OrganizationUserDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.OrganizationUser> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.OrganizationUser> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<OrganizationUserDtoGen>> Save(
            OrganizationUserDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.OrganizationUser> dataSource,
            IBehaviors<ProjectManager.Data.Models.OrganizationUser> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<OrganizationUserDtoGen>> Delete(
            int id,
            IBehaviors<ProjectManager.Data.Models.OrganizationUser> behaviors,
            IDataSource<ProjectManager.Data.Models.OrganizationUser> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
