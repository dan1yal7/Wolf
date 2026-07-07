using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClient.Contracts
{
    public interface IGitService
    {
       Task<string> CloneAsync(string repositoryUrl, string path);
       Task<string> InitNewRepositoryAsync(string path);
    }
}
