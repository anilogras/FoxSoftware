﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.Ortak.Base
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseClass AnaModel { get; set; }

        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
