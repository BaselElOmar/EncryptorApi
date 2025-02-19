﻿using System.Text;

namespace CryptoWeb.Service
{
    public class VigenereService
    {
        public string Encrypt(string text, string key)
        {
            //om input är tom retunerar den en tom sträng.
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key)) return "";

            text = text.ToUpper();      // gör om hela ordet & key till versaler
            key = key.ToUpper();

            // Använder StringBuilder för att effektivt använda stränghantering
            StringBuilder encryptedText = new StringBuilder();
            int keyIndex = 0;       

            foreach (char letter in text)
            {
                if (letter >= 'A' && letter <= 'Z')    
                {
                    int letterIndex = letter - 'A';     
                    int keyIndexValue = key[keyIndex % key.Length] - 'A';   // hämtar motsvarande keybokstav och omvandlar till 0-25
                    int encryptedIndex = (letterIndex + keyIndexValue) % 26;    

                    encryptedText.Append((char)('A' + encryptedIndex)); //gör om till bokstav igen

                    keyIndex++;
                }

                else
                {
                    encryptedText.Append(letter);   // ifall det är t.ex mellanslag, punkt osv så behåller den som den är
                }
            }
            return encryptedText.ToString();
        }

        public string Decrypt(string text, string key)
        {
            //om input är tom retunerar den en tom sträng.
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key)) return "";

            text = text.ToUpper();      
            key = key.ToUpper();

            // Använder StringBuilder för att effektivt använda stränghantering
            StringBuilder encryptedText = new StringBuilder();
            int keyIndex = 0;       

            foreach (char letter in text)
            {
                if (letter >= 'A' && letter <= 'Z')     
                {
                    int letterIndex = letter - 'A';     
                    int keyIndexValue = key[keyIndex % key.Length] - 'A';   // hämtar motsvarande keybokstav och omvandlar till 0-25
                    int encryptedIndex = (letterIndex - keyIndexValue + 26) % 26;    

                    encryptedText.Append((char)('A' + encryptedIndex)); //gör om till bokstav igen

                    keyIndex++;
                }

                else
                {
                    encryptedText.Append(letter);   // ifall det är t.ex mellanslag, punkt osv så behåller den som den är
                }
            }
            return encryptedText.ToString();
        }
    }
}
