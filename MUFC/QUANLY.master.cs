﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUFC
{
    public partial class QUANLY : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["role"] != "QT")
                Response.Redirect("DANGNHAP.aspx");
        }
    }
}