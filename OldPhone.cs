public class OldPhone
{
    private dictionary<char, string> digitToCharacters;
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

    private char GetCharacterFromDigit(char digit, int pressCount)
    {
        // 7 and 9 button have 4 characters
        if (digit == '9' || digit '7') pressCount = pressCount % 4;
        else pressCount = pressCount % 3;

        return digitToCharacters[digit][pressCount - 1];
    }

    private static string PopBack(string str)
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
        for (char ch: input)
        {
            if (ch == '#') return result;
            if (ch == '*')
            {

            }
        }
        return result;
    }
}