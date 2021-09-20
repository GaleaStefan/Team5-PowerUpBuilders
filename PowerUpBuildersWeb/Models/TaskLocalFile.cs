using System;
using System.ComponentModel.DataAnnotations;

namespace PowerUpBuildersWeb.Models
{
    public class TaskLocalFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Task Task { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public FileType FileType { get; set; }

    }
}