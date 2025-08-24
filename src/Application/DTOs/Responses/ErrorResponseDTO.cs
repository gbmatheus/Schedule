namespace Application.DTOs.Responses
{
    public class ErrorResponseDTO
    {
        public List<string> ErrorMessages { get; set; }

        public ErrorResponseDTO(string errorMensage)
        {
            ErrorMessages = new List<string> { errorMensage };
        }

        public ErrorResponseDTO(List<string> errorMensages)
        {
            ErrorMessages = errorMensages;
        }
    }
}
