

using System;
using System.Collections;
using System.Windows.Forms;


namespace definitions
{
    public struct Settings
    {
        public int language;
    }

    public struct Entry
    {
        public bool isActive;
        public bool isVacation;
        public bool isHoliday;
        public bool isWork;
        public DateTime date;
        public int location;
        public bool sickday;
    };

    public class ListViewItemColumnSorter : IComparer
    {
        public int curColumn = 0;
        public int Compare(object x, object y)
        {
            string a = ((ListViewItem)y).SubItems[curColumn].Text;
            string b = ((ListViewItem)x).SubItems[curColumn].Text;

            return DateTime.Compare(DateTime.Parse(a), DateTime.Parse(b));
        }
    }
}