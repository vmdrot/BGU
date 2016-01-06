using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace BGU.DRPL.SignificantOwnership.Tests.www2
{
    [TestFixture]
    public class BGUWeb2NavTests
    {
        
        [Test]
        public void NotesSplit()
        {
            string[] lines = File.ReadAllLines(@"D:\home\vmdrot\BGU\Var\www2.0\Pres_20150824\qu_BGU_Nav_IdNotes.txt");
            StringBuilder sbRslt = new StringBuilder();
            foreach (string line in lines)
            {
                if(string.IsNullOrEmpty(line) || string.IsNullOrEmpty(line.Trim()))
                    continue;
                string[] fields = line.Split('\t');
                if (fields.Length < 2)
                    continue;
                string currId = fields[0].Trim();
                string currNotes = fields[1].Trim();
                string[] aNotes = currNotes.Split(';');
                foreach (string subNoteRaw in aNotes)
                {
                    if (string.IsNullOrEmpty(subNoteRaw) || string.IsNullOrEmpty(subNoteRaw.Trim()))
                        continue;
                    string subNote = subNoteRaw.Trim();
                    if (subNote.IndexOf("\"\"") != -1)
                        subNote = subNote.Replace("\"\"", "\"");
                    if (subNote[0] == '"')
                        subNote = subNote.Substring(1);
                    if (subNote[subNote.Length - 1] == '"')
                        subNote = subNote.Substring(0, subNote.Length - 1);
                    sbRslt.AppendLine(string.Format("{0}\t{1}", currId, subNote));
                }
            }
            File.WriteAllText(@"D:\home\vmdrot\BGU\Var\www2.0\Pres_20150824\qu_BGU_Nav_IdNotes.split.txt", sbRslt.ToString(),Encoding.Unicode);
            Console.WriteLine(sbRslt.ToString());
        }
    }
}
