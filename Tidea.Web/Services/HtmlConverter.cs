using System.Text.RegularExpressions;

namespace Tidea.Web.Services
{
    public class HtmlConverter
    {
        //Convert text with tags <> to normal text
        public string ConvertHtmlToPlainText(string html)
        {
            return Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
        }
    }
}