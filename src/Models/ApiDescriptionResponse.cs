namespace Src.Models;

public class ApiDescriptionResponse()
{
    public required string Status { get; set; }
    public required string Version { get; set; }
    public required string Description { get; set; }
    public required string GithubAuthor { get; set; }
    public required string GithubRepository { get; set; }
}