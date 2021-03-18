using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Classes
{
    internal static class PermissionManagement
    {
        public static void ManageMenuAccessByUserPermissions(object menu, List<long> permissions)
        {
            //if (menu.GetType() == typeof(ToolStripMenuItem))
            //{
                //int permissionId = 0;
                //int.TryParse((string)((ToolStripMenuItem)menu).Tag, out permissionId);
                //if ((permissions.Contains(permissionId)) || (permissionId == -1))
                //{
                //    ((ToolStripMenuItem)menu).Visible = true;
                //    var menuItems = ((ToolStripMenuItem)menu).DropDownItems;
                //    foreach (object item in menuItems)
                //    {
                //        if (item.GetType() == typeof(ToolStripMenuItem))
                //        {
                //            ManageMenuAccessByUserPermissions(item, permissions);
                //        }
                //    }
                //}
                //else
                //{
                //    ((ToolStripMenuItem)menu).Visible = false;
                //}
            //}
            //else
            //{
            //    if (menu.GetType() == typeof(MenuStrip))
            //    {
            //        var menuItems = ((MenuStrip)menu).Items;
            //        foreach (ToolStripMenuItem item in menuItems)
            //        {
            //            ManageMenuAccessByUserPermissions(item, permissions);
            //        }
            //    }
            //}

        }

        public static void ManageControlsAccessByUserPermissions(Control control, List<long> userPermissions)
        {
            //IEnumerable<Control> allControls = GetAllChildControls(control);
            //IEnumerable<Control> tagIsLongControls = GetTagIsLongChildControls(control);
            //HiddenControls(allControls);
            //ChooseUnHiddenControls(tagIsLongControls, userPermissions);
        }

        private static void ChooseUnHiddenControls(IEnumerable<Control> controls, List<long> userPermissions)
        {
            foreach (Control control in controls)
            {
                int permissionId = 0;
                int.TryParse(control.Tag.ToString(), out permissionId);
                if (userPermissions.Contains(permissionId) || (permissionId == -1))
                {
                    UnHiddenControlAndParentControl(control);
                }
            }
        }

        private static void UnHiddenControlAndParentControl(Control control)
        {
            //if (control.Visible)
            //{
            //    return;
            //}
            //else
            //{
            //    control.Visible = true;
            //    if (control.Parent != null)
            //    {
            //        UnHiddenControlAndParentControl(control.Parent);
            //    }
            //}
        }

        private static void HiddenControls(IEnumerable<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.Visible = false;
            }
        }

        private static IEnumerable<Control> GetTagIsLongChildControls(Control control)
        {
            long tag;
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetTagIsLongChildControls(ctrl)).Concat(controls).
                Where(t => t.Tag != null && long.TryParse(t.Tag.ToString(), out tag));

        }

        private static IEnumerable<Control> GetAllChildControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllChildControls(ctrl)).Concat(controls);
        }

        private static IEnumerable<Control> GetTagIsLongChildControlsByType(Control control, Type type = null)
        {
            long tag;
            var controls = control.Controls.Cast<Control>();
            if (type == null)
            {
                return controls.SelectMany(ctrl => GetTagIsLongChildControlsByType(ctrl, type)).Concat(controls).
                    Where(t => t.Tag != null && long.TryParse(t.Tag.ToString(), out tag));
            }
            else
            {
                return controls.SelectMany(ctrl => GetTagIsLongChildControlsByType(ctrl, type)).Concat(controls).
                    Where(t => t.GetType() == type && t.Tag != null && long.TryParse(t.Tag.ToString(), out tag));
            }
        }

        private static IEnumerable<Control> GetAllChildControlsByType(Control control, Type type = null)
        {
            var controls = control.Controls.Cast<Control>();
            if (type == null)
            {
                return controls.SelectMany(ctrl => GetAllChildControlsByType(ctrl, type)).Concat(controls);
            }
            else
            {
                return controls.SelectMany(ctrl => GetAllChildControlsByType(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
            }
        }
    }
}
