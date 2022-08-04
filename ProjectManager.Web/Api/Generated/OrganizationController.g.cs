
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
    [Route("api/Organization")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class OrganizationController
        : BaseApiController<ProjectManager.Data.Models.Organization, OrganizationDtoGen, ProjectManager.Data.AppDbContext>
    {
        public OrganizationController(ProjectManager.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<ProjectManager.Data.Models.Organization>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<OrganizationDtoGen>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Organization> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<OrganizationDtoGen>> List(
            ListParameters parameters,
            IDataSource<ProjectManager.Data.Models.Organization> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<ProjectManager.Data.Models.Organization> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<OrganizationDtoGen>> Save(
            OrganizationDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<ProjectManager.Data.Models.Organization> dataSource,
            IBehaviors<ProjectManager.Data.Models.Organization> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<OrganizationDtoGen>> Delete(
            string id,
            IBehaviors<ProjectManager.Data.Models.Organization> behaviors,
            IDataSource<ProjectManager.Data.Models.Organization> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
