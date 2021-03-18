using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementApplication.Classes
{
    public static class FindControl
    {
        public static int GetTabPageIndex(System.Windows.Forms.TabControl tabControl, string name)
        {
            int result = -1;
            int tabPagesCount = tabControl.TabPages.Count;
            for (int i = 0; i < tabPagesCount; i++)
            {
                if (tabControl.TabPages[i].Name == name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static System.Windows.Forms.Form FindForm(System.Windows.Forms.Form[] forms, string name)
        {
            System.Windows.Forms.Form result = null;
            int formsCount = forms.Count();
            for (int i = 0; i < formsCount; i++)
            {
                if (forms[i].Name == name)
                {
                    result = forms[i];
                    break;
                }
            }
            return result;
        }

        public static System.Windows.Forms.Control GetControl(System.Windows.Forms.Form form, string name)
        {
            System.Windows.Forms.Control result = null;
            int controlsCount = form.Controls.Count;
            for (int i = 0; i < controlsCount; i++)
            {
                if (form.Controls[i].Name == name)
                {
                    result = form.Controls[i];
                    break;
                }
            }
            return result;
        }
    }
}
