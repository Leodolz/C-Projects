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
            AgendaEntry xA = (AgendaEntry)x;
            AgendaEntry yA = (AgendaEntry)y;
            return DateTime.Compare(Validators.GetDateTime(xA.date), Validators.GetDateTime(yA.date));
        }
    }
}
