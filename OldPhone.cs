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
        //Console.WriteLine(digit);
        //Console.WriteLine(pressCount);

        // 7 and 9 buttons have 4 characters
        // we created a dictionary for each digit where the char are 0 based indexed, so we need to subtract 1 from pressCount
        if (digit == '9' || digit == '7') pressCount = (pressCount - 1) % 4;
        else pressCount = (pressCount - 1) % 3;

        return digitToCharacters[digit][pressCount];
    }

    private string popBack(string str)
    {
        return string.IsNullOrEmpty(str) ? "" : str.Substring(0, str.Length - 1);
    }

    private bool isFoundDigitBefore(char lastDigit)
    {
        return lastDigit != '\0';
    }

    public string OldPhonePad(string input)
    {
        string result = "";
        char lastDigit = '\0';
        int pressCount = 0;
        foreach (char currentChr in input)
        {
            switch (currentChr)
            {
                case '#':
                    break;
                case '*':
                    if (isFoundDigitBefore(lastDigit))
                    {
                        lastDigit = '\0';
                        pressCount = 0;
                    }
                    else
                    {
                        result = popBack(result);
                    }
                    break;
                case ' ':
                    if (!isFoundDigitBefore(lastDigit)) continue;
                    else
                    {
                        result += getCharacterFromDigit(lastDigit, pressCount);
                    }
                    lastDigit = '\0';
                    pressCount = 0;
                    break;
                default:
                    if (char.IsDigit(currentChr))
                    {
                        if (isFoundDigitBefore(lastDigit) && lastDigit != currentChr)
                        {
                            result += getCharacterFromDigit(lastDigit, pressCount);
                            lastDigit = currentChr;
                            pressCount = 1;
                        }
                        else
                        {
                            lastDigit = currentChr;
                            pressCount += 1;
                        }
                    }
                    break;
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

        // Test cases
        Console.WriteLine($"OldPhonePad(\"227*#\") => {oldPhone.OldPhonePad("227*#")}"); // Output: B
        Console.WriteLine($"OldPhonePad(\"8 88777444666*664#\") => {oldPhone.OldPhonePad("8 88777444666*664#")}"); // Output: TURING
        Console.WriteLine($"OldPhonePad(\"9999 9999 9999 9999#\") => {oldPhone.OldPhonePad("9999 9999 9999 9999#")}"); // Output: ZZZZ
        Console.WriteLine($"OldPhonePad(\"23456789#\") => {oldPhone.OldPhonePad("23456789#")}"); // Output: ADGJMPTW
        Console.WriteLine($"OldPhonePad(\"***   #\") => {oldPhone.OldPhonePad("***   #")}"); // Output:
        Console.WriteLine($"OldPhonePad(\"***   2#\") => {oldPhone.OldPhonePad("***   2#")}"); // Output: A
        Console.WriteLine($"OldPhonePad(\"***#\") => {oldPhone.OldPhonePad("***#")}"); // Output:
        Console.WriteLine($"OldPhonePad(\"#\") => {oldPhone.OldPhonePad("#")}"); // Output:
    }
}
