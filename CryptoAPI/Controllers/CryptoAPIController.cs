using Microsoft.AspNetCore.Mvc;

namespace CryptoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {   /*
        // Encryption endpoint
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string plainText)
        {
            // Implement encryption logic 
            char[] chars = plainText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = (char)(chars[i] + 3);
                    if (!char.IsLetter(chars[i]))
                    {
                        chars[i] = (char)(chars[i] - 26);
                    }
                }
            }
            string encryptedText = new string(chars);

            return Ok(new { encryptedText });
        }*/
        // Decryption endpoint
        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string encryptedText)
        {
            //reverse of encryption
            char[] chars = encryptedText.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = (char)(chars[i] - 3);
                    if (!char.IsLetter(chars[i]))
                    {
                        chars[i] = (char)(chars[i] + 26);
                    }
                }
            }
            string decryptedText = new string(chars);

            return Ok(new { decryptedText });
        }

        // GET /encrypt endpoint
        [HttpGet("encrypt")]
        public IActionResult Encrypt([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Text parameter is required.");
            }

            // Implement encryption logic 
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = (char)(chars[i] + 3);
                    if (!char.IsLetter(chars[i]))
                    {
                        chars[i] = (char)(chars[i] - 26);
                    }
                }
            }
            string encryptedText = new string(chars);

            return Ok(new { encryptedText });
        }

    }
}