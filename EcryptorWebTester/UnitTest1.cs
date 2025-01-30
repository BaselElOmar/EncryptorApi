using Xunit;
using CryptoWeb.Service;
using CryptoWeb.Models;

namespace EcryptorWebTester
{
    public class CryptorTestes
    {
        [Fact]
        public void Encrypt_ShouldEncryptTextCorrectly()
        {
            //arrange
            var encrypt = new VigenereService();
            string text = "HELLO";
            string key = "KEY";

            // Act
            string result = encrypt.Encrypt(text, key);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(text, result);
        }

        [Fact]
        public void Decrypt_shouldDecryptTextCorrectly()
        {
            var decrypt = new VigenereService();
            string originalText = "HELLO";
            string key = "KEY";

            string encryptedText = decrypt.Encrypt(originalText, key);
            string decryptedText = decrypt.Decrypt(encryptedText, key);

            Assert.Equal(originalText, decryptedText);
        }

        [Fact]
        public void Encrypt_WithSpecialCharacters()
        {
            var encrypt = new VigenereService();
            string text = "HELLO, WORLD!!:D";
            string key = "KEY";

            string encryptedText = encrypt.Encrypt(text, key);
            string decryptedText = encrypt.Decrypt(encryptedText, key);

            Assert.Equal(text, decryptedText);
        }
    }
}