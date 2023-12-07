namespace HttpClients;

public static class DataDecoder
{
    
    public static string HandleSpecialCharacters(string check)
    {
        string returnString = check;

        if (returnString.Contains(".OE.") || returnString.Contains(".oe."))
        {
            returnString = returnString.Replace(".OE.", "Ø");
            returnString = returnString.Replace(".oe.", "ø");
        }

        if (returnString.Contains(".AE.") || returnString.Contains(".ae."))
        {
            returnString = returnString.Replace(".AE.", "Æ");
            returnString = returnString.Replace(".ae.", "æ");
        }
        if (returnString.Contains(".AA.") || returnString.Contains(".aa."))
        {
            returnString = returnString.Replace(".AA.", "Å");
            returnString = returnString.Replace(".aa.", "å");
        }

        return returnString;
    }
    
}