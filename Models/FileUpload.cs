using Microsoft.AspNetCore.Http;

namespace University.Models
{
    public class FileUpload
    {
        public IFormFile file { get; set; }
        public string Student { get; set; }
    }
}
