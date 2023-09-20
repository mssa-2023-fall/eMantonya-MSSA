using System.Security.Cryptography;
using System.Numerics;

namespace MSSAExtension
{
    public static class MssaExtensions
    {
        public enum StringFormat { Base64, Hex }
        public static string GetSHAString(this FileInfo _file, StringFormat format)
        {
#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
            using (var sha1 = SHA1.Create())
            {
                byte[] fileHash = sha1.ComputeHash(_file.OpenRead());
                switch (format)
                {
                    case StringFormat.Base64:
                        return Convert.ToBase64String(fileHash);
                    case StringFormat.Hex:
                        return Convert.ToHexString(fileHash).ToLower();
                    default:
                        return Convert.ToHexString(fileHash).ToLower();
                }
            };
#pragma warning restore CA5350 // Do Not Use Weak Cryptographic Algorithms
        }

        public static float Median(this IEnumerable<int> _arr)
        {
            var sorted = _arr.OrderBy(x => x).ToList();
            var middleItem = sorted.Count / 2;
            if (sorted.Count % 2 == 1)
            {
                return sorted[middleItem];
                
            }
            else 
            {
                return ((float)sorted[middleItem] + (float)sorted[middleItem - 1]) / 2; }
        }
        public static T Median<T>(this IEnumerable<T> _arr)
        {
            var sorted = _arr.OrderBy(x => x).ToList();
            var middleItem = sorted.Count / 2;
            return sorted[middleItem];
        }

    }
}
