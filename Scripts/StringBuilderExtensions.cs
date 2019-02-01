using System.Text;

namespace UnityExtensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendLineFormat(this StringBuilder self, string format, params object[] args)
        {
            return self.AppendLine(string.Format(format, args));
        }

        public static StringBuilder AppendLineLF(this StringBuilder self, object value)
        {
            return self.Append(value).Append("\n");
        }
    }
}
