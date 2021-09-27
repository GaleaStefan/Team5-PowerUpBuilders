using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PowerUpBuildersWeb.Models;

namespace PowerUpBuildersWeb.ViewModel
{
    public class TaskEditorViewModel
    {
        public int ProjectId { get; set; }
        public Models.Task Task { get; set; } = new();
        //public IEnumerable<Employee> AssignedEmployees { get; set; } = new List<Employee>();
        public IEnumerable<int> LinkedEmployees { get; set; } = new List<int>();
        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();

        public IEnumerable<IFormFile> Uploads { get; set; } = new List<IFormFile>();

        //public IEnumerable<string> ImagePaths { get; set; } = new List<string>();

        //public IEnumerable<string> FilePaths { get; set; } = new List<string>();

        public ModalMode ModalMode { get; set; }

    }
}
