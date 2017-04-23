using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedSetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IEnumerable<string> files = Directory.EnumerateFiles(@"C:\Users\Ян Мороз\Desktop\Docs", "*", SearchOption.AllDirectories);
                SortedSet<string> mediaFiles = new SortedSet<string>(new ByFileExtensionComparer());

                // Adding file names.
                foreach (var file in files)
                {
                    mediaFiles.Add(file.Substring(file.LastIndexOf(@"\") + 1));
                }

                // Remove elements that have non-media extensions.
                Console.WriteLine("Remove docs from the set.");
                Console.WriteLine($"Count before: {mediaFiles.Count}");
                mediaFiles.RemoveWhere(IsDocument);
                Console.WriteLine($"Count after: {mediaFiles.Count}\n");
            }
            catch (IOException ioException)
            {
                Console.WriteLine(ioException.Message);
            }
            catch (UnauthorizedAccessException authException)
            {
                Console.WriteLine(authException.Message);
            }
        }

        /// <summary>
        /// Defines a predicate delegate to use for the SortedSet.RemoveWhere method.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool IsDocument(string fileName)
        {
            if (fileName.ToLower().EndsWith(".txt") || fileName.ToLower().EndsWith(".doc") ||
                fileName.ToLower().EndsWith(".xls") || fileName.ToLower().EndsWith(".xlsx") ||
                fileName.ToLower().EndsWith(".pdf") || fileName.ToLower().EndsWith(".docx"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Defines a comparer to create a sorted set that is sorted by the file extensions.
    /// </summary>
    public class ByFileExtensionComparer : IComparer<string>
    {
        string xExtension, yExtension;
        CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

        public int Compare(string x, string y)
        {
            // Parse the extension from the file name.
            xExtension = x.Substring(x.LastIndexOf(".") + 1);
            yExtension = y.Substring(y.LastIndexOf(".") + 1);

            // Compare the file extensions.
            var comparisonResult = comparer.Compare(xExtension, yExtension);

            if (comparer.Compare(xExtension, yExtension) != 0)
            {
                return comparisonResult;
            }
            else
            {
                // The extension is the same, so compare the filenames. 
                return comparer.Compare(x, y);
            }
        }
    }
}
