using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Raporlar
{
    public partial class frmgirilensiparis : DevExpress.XtraEditors.XtraForm
    {
        public frmgirilensiparis()
        {
            InitializeComponent();
        }

        private void frmgirilensiparis_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
        }
    }
}
