namespace VCManager.Core
{
    public static class StringExtensions
    {
        public static string ReplaceAfterLastOccurence(this string str, char c, string newStr)
        {
            int occurence = str.LastIndexOf(c);
            return str.Substring(0, occurence + 1) + newStr;
        }

        public static string GetUrlPartFromEnd(this string url, int index)
        {
            string[] parts = url.Split('/');
            return parts[parts.Length - index - 1];
        }
    }   
}
