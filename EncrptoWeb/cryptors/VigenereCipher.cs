using System;

public class VigenereCipher
{
    public string Encrypt(string word, string key)
    {
        if (string.IsNullOrEmpty(word)) return "";

        word = word.ToUpper();
        key = key.ToUpper();

        StringBuilder encryptedText = new StringBuilder();
        int keyIndex = 0;

        foreach (char letter in word)
        {
            if (word >= 'A' && word <= 'Z')
            {
                int letterIndex = letter - 'A';
                int keyIndexValue = key[keyIndex % key.Length] - 'A';
                int encryptedIndex = (letterIndex + keyIndexValue) % 26;

                encryptedText.Append((char)('A' + encryptedIndex));

                keyIndex++;
            }

            else
            {
                encryptedText.Append(letter);
            }


            return encryptedText.Append(letter);
        }
    }

    public string Decrypt(string text, string key)
    {
        return;
    }


}
