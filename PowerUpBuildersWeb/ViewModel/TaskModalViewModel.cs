namespace PowerUpBuildersWeb.ViewModel
{
    public class TaskModalViewModel
    {
        public Models.Task Task { get; set; } = new();
        public ModalMode ModalMode { get; set; }

    }
}
