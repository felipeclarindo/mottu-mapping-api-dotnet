using Microsoft.AspNetCore.Mvc;
using Src.Models;

namespace Src.Controllers;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
    [HttpGet]
    public Task<ApiDescriptionResponse> GetApiDescription()
    {
        ApiDescriptionResponse response = new ApiDescriptionResponse()
        {
            Status = "Api is running.",
            Version = "1.0.0",
            Description = "This is a sample API for managing patios, sectors, and motorcycles.",
            GithubAuthor = "https://github.com/felipeclarindo",
            GithubRepository = "https://github.com/felipeclarindo/mottu-mapping-api-dotnet"
        };

        return Task.FromResult(response);
    }
}
