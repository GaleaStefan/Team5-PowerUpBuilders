using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerUpBuildersWeb.Models
{
    public interface ITaskLocalFileRepository
    {
        IEnumerable<TaskLocalFile> GetTaskLocalFiles();
    }
}
