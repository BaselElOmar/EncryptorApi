using Microsoft.AspNetCore.Mvc;
using CryptoWeb.Service;
using CryptoWeb.Models;

namespace CryptoWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class cryptController : ControllerBase
    {
        private readonly VigenereService _vigenereService;
        

        public cryptController(VigenereService vigenereService)
        {
            _vigenereService = vigenereService;
        }

        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] cryptionRequest request)
        {
            if (string.IsNullOrEmpty(request.Text) || string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("Text and key are required!");
            }

            string encryptedText = _vigenereService.Encrypt(request.Text, request.Key);
            return Ok(encryptedText);
        }
        [HttpPost("decrypt")]
        public ActionResult<string> Decrypt([FromBody] cryptionRequest request)
        {
            if (string.IsNullOrEmpty(request.Text) || string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("Text and key are required!");
            }

            string decryptedText = _vigenereService.Decrypt(request.Text, request.Key);
            return Ok(decryptedText);
        }
    }
}
