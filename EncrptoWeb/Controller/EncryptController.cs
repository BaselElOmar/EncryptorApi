using Microsoft.AspNetCore.Mvc;

namespace EncrptoWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptController : ControllerBase
    {
        private readonly VigenereCipher _vigenereCipher;
        

        public EncryptController(VigenereCipher vigenereCipher)
        {
            _vigenereCipher = vigenereCipher;
        }

        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] EncryptionRequest request)
        {
            if (string.IsNullOrEmpty(request.Text) || string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("Text and key are required!");
            }

            string encryptedText = _vigenereCipher.Encrypt(request.Text, request.Key);
            return Ok(encryptedText);
        }
    }

    
}
