using System;
using System.Collections;
using System.Windows.Forms;


namespace definitions
{
    enum Language
    {
        Deutsch,
        English
    }
    public struct Settings
    {
        public int Language;
    }
    public struct Entry
    {
        public DateTime date;
        public int location;
        public bool sickday;
    }

    public class ListViewItemColumnSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            string a = ((ListViewItem)y).SubItems[0].Text;
            string b = ((ListViewItem)x).SubItems[0].Text;

            return DateTime.Compare(DateTime.Parse(a), DateTime.Parse(b));
        }
    }
}