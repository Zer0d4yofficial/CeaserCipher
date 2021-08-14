using System.Data.SqlTypes;
using System;
public class CesarShipher
{
    const string alph = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    private string CodeEncode(string text, int k)
    {
        var fullAlph = alph + alph.ToLower(); 
        var letterQty = fullAlph.Length;
        var retVal = "";
        for(int i = 0; i < text.Length;i++)
        {
            var c = text[i];
            var index = fullAlph.IndexOf(c);
            if(index < 0)
            {
                retVal += c.ToString();
            }
            else
            {
                var codeIndex = (letterQty + index + k) % letterQty;
                retVal += fullAlph[codeIndex];
            }
        }
        return retVal;
    }
    public string Encrypt(string plainMessage, int key) => CodeEncode(plainMessage, key);
    public string Decrypt(string encryptedMessage, int key) => CodeEncode(encryptedMessage, -key);   
}
class Program
{
    static void Main(string[] args)
    {
        var cipher = new CesarShipher();
        Console.WriteLine("Ведите текст: ");
        var message = Console.ReadLine();
        Console.WriteLine("Введите ключ: ");
        var secretKey = Convert.ToUInt32(Console.ReadLine());
        var encryptedText = cipher.Encrypt(message, secretKey);
        Console.WriteLine("Зашифрованное сообщение: {0}", encryptedText);
        Console.WriteLine("Расшифрованое сообщение: {0}", encryptedText);
        Console.ReadLine();
    }
}
