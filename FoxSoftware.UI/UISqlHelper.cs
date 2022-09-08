using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.UI
{
    class UISqlHelper
    {
        public static string DateFormatForSql1(DateTime date)
        {
            return $"'{date.Year}-{date.Month.ToString().PadLeft(2, '0')}-{date.Day.ToString().PadLeft(2, '0')}"+" 00:00:00'";
        }
        public static string DateFormatForSql2(DateTime date)
        {
            return $"'{date.Year}-{date.Month.ToString().PadLeft(2, '0')}-{date.Day.ToString().PadLeft(2, '0')}" + " 23:59:59'";
        }
        public static void NowDateTime(DateEdit dateEdit1, DateEdit dateEdit2)
        {
            dateEdit1.EditValue = System.DateTime.Now.AddDays(-7);
            dateEdit2.EditValue = System.DateTime.Now;
        }
    }
}
