namespace PowerUpBuildersWeb.ViewModel
{
    public class TaskModalEditVM
    {
        public Models.Task Task { get; set; } = new();
        public ModalMode ModalMode { get; set; }

    }
}
