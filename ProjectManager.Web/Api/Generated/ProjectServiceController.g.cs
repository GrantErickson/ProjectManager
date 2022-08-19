
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
    [Route("api/ProjectService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ProjectServiceController : Controller
    {
        protected ProjectManager.Data.Services.ProjectService Service { get; }

        public ProjectServiceController(ProjectManager.Data.Services.ProjectService service)
        {
            Service = service;
        }

        /// <summary>
        /// Method: GetProjects
        /// </summary>
        [HttpPost("GetProjects")]
        [Authorize]
        public virtual ItemResult<System.Collections.Generic.ICollection<ProjectInfoDtoGen>> GetProjects(string search = default)
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(User);
            var _methodResult = Service.GetProjects(search);
            var _result = new ItemResult<System.Collections.Generic.ICollection<ProjectInfoDtoGen>>();
            _result.Object = _methodResult?.ToList().Select(o => Mapper.MapToDto<ProjectManager.Data.Services.ProjectService.ProjectInfo, ProjectInfoDtoGen>(o, _mappingContext, includeTree)).ToList();
            return _result;
        }
    }
}
