namespace PowerUpBuildersWeb.ViewModel
{
    public class TaskModalEditVM
    {
        public Models.Task Task { get; set; } = new();
        //public IEnumerable<IFormFile> Uploads = new List<IFormFile>();
        public ModalMode ModalMode { get; set; }

    }
}
