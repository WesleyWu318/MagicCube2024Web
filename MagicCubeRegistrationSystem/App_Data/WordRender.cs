using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Examples
{
    public static class WordRender
    {
        static void ReplaceParserTag(this OpenXmlElement elem, Dictionary<string, string> data)
        {
            var pool = new List<Run>();
            var matchText = string.Empty;
            var allRuns = elem.Descendants<Run>().ToList();
            //var hiliteRuns = elem.Descendants<Run>().Where(o => o.RunProperties?.Elements<Highlight>().Any() ?? false).ToList();

            foreach (var run in allRuns)
            {
                var t = run.InnerText;
                if (t.StartsWith("["))
                {
                    pool = new List<Run> { run };
                    matchText = t;
                }
                else
                {
                    matchText += t;
                    pool.Add(run);
                }
                if (t.EndsWith("]"))
                {
                    var m = Regex.Match(matchText, @"\[\$(?<n>\w+)\$\]");
                    if (m.Success && data.ContainsKey(m.Groups["n"].Value))
                    {
                        var firstRun = pool.First();
                        firstRun.RemoveAllChildren<Text>();
                        //firstRun.RunProperties.RemoveAllChildren<Highlight>();
                        var newText = data[m.Groups["n"].Value];
                        var firstLine = true;
                        foreach (var line in Regex.Split(newText, @"\\n"))
                        {
                            if (firstLine) firstLine = false;
                            else firstRun.Append(new Break());
                            firstRun.Append(new Text(line));
                        }
                        pool.Skip(1).ToList().ForEach(o => o.Remove());
                    }
                }

            }
        }

        public static byte[] GenerateDocx(byte[] template, Dictionary<string, string> data)
        {
            using (var ms = new MemoryStream())
            {
                ms.Write(template, 0, template.Length);
                using (var docx = WordprocessingDocument.Open(ms, true))
                {
                    var mainPart = docx.MainDocumentPart;

                    // 檢查是否有 Header 部分
                    if (!mainPart.HeaderParts.Any())
                    {
                        Console.WriteLine("No headers found.");
                    }

                    // 檢查是否有 Footer 部分
                    if (!mainPart.FooterParts.Any())
                    {
                        Console.WriteLine("No footers found.");
                    }

                    // 替換主文檔中的標記
                    mainPart.Document.Body.ReplaceParserTag(data);

                    // 替換頭部中的標記
                    foreach (var headerPart in mainPart.HeaderParts)
                    {
                        headerPart.Header.ReplaceParserTag(data);
                    }

                    // 替換底部中的標記
                    foreach (var footerPart in mainPart.FooterParts)
                    {
                        footerPart.Footer.ReplaceParserTag(data);
                    }

                    docx.Save();
                }
                return ms.ToArray();
            }
        }
    }
}