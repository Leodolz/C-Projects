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
            AgendaEntry dateToCompare1 = (AgendaEntry)x;
            AgendaEntry dateToCompare2 = (AgendaEntry)y;
            return DateTime.Compare(Validators.GetDateTime(dateToCompare1.date), Validators.GetDateTime(dateToCompare2.date));
        }
    }
}
