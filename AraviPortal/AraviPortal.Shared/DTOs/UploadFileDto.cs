using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AraviPortal.Shared.DTOs;

public class UploadFileDto
{
    [Required]
    public IFormFile? File { get; set; }

    //[Required]
    public string? SheetName { get; set; }
}