using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfClient.Contracts;

namespace WolfClient.Services
{
    public class GitService : IGitService    
    {
        public string CloneAsync(string repositoryUrl, string path)
        {
            try
            {
                var clonedRepo = Repository.Clone(repositoryUrl, path);

                return clonedRepo;
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to clone repository: {ex.Message}");
            }
        }

        public string InitNewRepositoryAsync(string path)
        {
            try
            {
                var intitializedRepo = Repository.Init(path);
                return intitializedRepo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to initialize repository: {ex.Message}");
            }
        }
    }
}
