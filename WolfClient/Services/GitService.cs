using LibGit2Sharp;
using WolfClient.Contracts;

namespace WolfClient.Services
{
    public class GitService : IGitService
    {
        public Task<string> CloneAsync(string repositoryUrl, string path) =>
            Task.Run(() =>
            {
                try
                {
                    return Repository.Clone(repositoryUrl, path);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to clone repository: {ex.Message}", ex);
                }
            });

        public Task<string> InitNewRepositoryAsync(string path) =>
            Task.Run(() =>
            {
                try
                {
                    return Repository.Init(path);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to initialize repository: {ex.Message}", ex);
                }
            });
    }
}
