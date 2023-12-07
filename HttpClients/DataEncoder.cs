namespace HttpClients;

public static class DataEncoder
{
    
    public static string HandleSpecialCharacters(string check)
    {
        string returnString = check;

        if (returnString.Contains("Ø") || returnString.Contains("ø"))
        {
            returnString = returnString.Replace("Ø", ".OE.");
            returnString = returnString.Replace("ø", ".oe.");
        }

        if (returnString.Contains("Æ") || returnString.Contains("æ"))
        {
            returnString = returnString.Replace("Æ", ".AE.");
            returnString = returnString.Replace("æ", ".ae.");
        }
        if (returnString.Contains("Å") || returnString.Contains("å"))
        {
            returnString = returnString.Replace("Å", ".AA.");
            returnString = returnString.Replace("å", ".aa.");
        }
        if (returnString.Contains("+45"))
        {
            returnString = returnString.Replace("+45", "");
        }

        return returnString;
    }
    
}