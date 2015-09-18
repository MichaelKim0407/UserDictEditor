using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDictEditor
{
    class WordInfo
    {
        public string Word { get; private set; }
        public int Count { get; private set; }
        public string Pinyin { get; private set; }

        public WordInfo(string line)
        {
            var elements = line.Split('\t');
            Word = elements[0];
            Count = int.Parse(elements[1]);
            Pinyin = elements[2];
        }

        public string ToString(string format)
        {
            return string.Format(format, Pinyin, Word, Count);
        }

        public const string DisplayFormat = "{0,-32}{1,-8}\t{2,8}";
        public const string FileFormat = "{1}\t{2}\t{0}";

        public string DisplayString { get { return ToString(DisplayFormat); } }
        public string FileString { get { return ToString(FileFormat); } }

        public override string ToString()
        {
            return DisplayString;
        }

        public int Compare(WordInfo other)
        {
            int p = string.Compare(Pinyin, other.Pinyin);
            if (p == 0)
            {
                int w = string.Compare(Word, other.Word);
                if (w == 0)
                {
                    int c = Count - other.Count;
                    if (c == 0)
                        return 0;
                    else if (c > 0)
                        return 1;
                    else
                        return -1;
                }
                else if (w > 0)
                    return 2;
                else
                    return -2;
            }
            else if (p > 0)
                return 3;
            else
                return -3;
        }

        public bool SameWord(WordInfo other)
        {
            var compare = Compare(other);
            return compare >= -1 && compare <= 1;
        }

        IEnumerable<string> PinyinChrs { get { return Pinyin.Split(' ').Reverse(); } }

        static int ComparePinyin(IEnumerable<string> py1, IEnumerable<string> py2)
        {
            var e1 = py1.Count() == 0;
            var e2 = py2.Count() == 0;
            if (e1 && e2)
                return 0;
            else if (e1)
                return 1;
            else if (e2)
                return -1;
            else
            {
                var i = string.Compare(py1.ElementAt(0), py2.ElementAt(0));
                if (i != 0)
                    return i;
                else
                    return ComparePinyin(py1.Skip(1), py2.Skip(1));
            }
        }

        static public IEnumerable<WordInfo> Sorted(IEnumerable<WordInfo> words)
        {
            var list = words.ToList();
            list.Sort((w1, w2) => ComparePinyin(w1.PinyinChrs, w2.PinyinChrs));
            return list;
        }
    }
}
