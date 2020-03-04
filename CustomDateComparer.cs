using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp
{
    class CustomDateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            AgendaEntry entryToCompare1 = (AgendaEntry)x;
            AgendaEntry entryToCompare2 = (AgendaEntry)y;
            return DateTime.Compare(Validators.GetDateTime(entryToCompare1.date), Validators.GetDateTime(entryToCompare2.date));
        }
    }
}
