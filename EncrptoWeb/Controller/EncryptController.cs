using Microsoft.AspNetCore.Mvc;
using EncrptoWeb.Service;
using EncrptoWeb.Models;

namespace EncrptoWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : ControllerBase
    {
        private readonly VigenereService _vigenereService;
        

        public EncryptController(VigenereService vigenereService)
        {
            _vigenereService = vigenereService;
        }

        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] EncryptionRequest request)
        {
            if (string.IsNullOrEmpty(request.Text) || string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("Text and key are required!");
            }

            string encryptedText = _vigenereService.Encrypt(request.Text, request.Key);
            return Ok(encryptedText);
        }
    }

    
}
