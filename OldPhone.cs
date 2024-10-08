using System;
using System.Collections.Generic;

public class OldPhone
{
    private readonly Dictionary<char, string> digitToCharacters;

    public OldPhone()
    {
        digitToCharacters = new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
        };
    }

    private char getCharacterFromDigit(char digit, int pressCount)
    {
        // 7 and 9 buttons have 4 characters
        if (digit == '9' || digit == '7') pressCount = pressCount % 4;
        else pressCount = pressCount % 3;

        return digitToCharacters[digit][pressCount - 1];
    }

    private static string popBack(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return "";
        }

        return str.Substring(0, str.Length - 1);
    }

    public string OldPhonePad(string input)
    {
        string result = "";
        int pressCount = 0;
        char lastDigit = '\0';

        foreach (char ch in input)
        {
            if (ch == '#') break;
            else if (ch == '*')
            {
                if (lastDigit != '\0')
                {
                    lastDigit = '\0';
                    pressCount = 0;
                }
                else
                {
                    result = popBack(result);
                }
            }
            else if (ch == ' ')
            {
                if (lastDigit == '\0') continue;
                else
                {
                    result += getCharacterFromDigit(lastDigit, pressCount);
                }
                lastDigit = '\0';
                pressCount = 0;
            }
            else if (char.IsDigit(ch))
            {
                if (lastDigit != '\0' && lastDigit != ch)
                {
                    result += getCharacterFromDigit(lastDigit, pressCount);
                    lastDigit = ch;
                    pressCount = 1;
                }
                else
                {
                    lastDigit = ch;
                    pressCount += 1;
                }
            }
        }

        // Process any remaining digit at the end of input
        if (lastDigit != '\0')
        {
            result += getCharacterFromDigit(lastDigit, pressCount);
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        OldPhone oldPhone = new OldPhone();
        Console.WriteLine($"OldPhonePad(\"33#\") => {oldPhone.OldPhonePad("33#")}"); // Output: E
        Console.WriteLine($"OldPhonePad(\"227*#\") => {oldPhone.OldPhonePad("227*#")}"); // Output: B
        Console.WriteLine($"OldPhonePad(\"4433555 555666#\") => {oldPhone.OldPhonePad("4433555 555666#")}");
    }
}
