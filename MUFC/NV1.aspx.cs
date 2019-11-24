﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUFC
{
    public partial class NV1 : System.Web.UI.Page
    {
        List<NV> nvlist;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Khai báo danh sách các phần tử kiểu SV, class SV được định nghĩa bên dưới
            nvlist = new List<NV>();
            if (!IsPostBack) //Lần đầu tiên gọi trang. Sau này click phân trang...là lần gọi sau...
            {
                //Thêm phần tử vào danh sách
                int n = 100;
                Random rd = new Random();
                for (int i = 0; i < n; i++)
                {
                    nvlist.Add(new NV(i + 1, "NHÂN VIÊN", rd.Next(1, n).ToString()));
                }
                
                ViewState["nvlist"] = nvlist;
                
                BindDataToGridView(-1);
            }
        }

        public void BindDataToGridView(int pageIndex)
        {
            nvlist = (ViewState["nvlist"] != null) ? (ViewState["nvlist"] as List<NV>) : null;
            GridView1.DataSource = nvlist;
            if (pageIndex >= 0) GridView1.PageIndex = pageIndex;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Mã NV";
            GridView1.HeaderRow.Cells[1].Text = "Họ lót";
            GridView1.HeaderRow.Cells[2].Text = "Tên";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Xử lý phân trang ở đây
            BindDataToGridView(e.NewPageIndex);
        }
    }

    [Serializable]
    class NV
    {
        public int iD { get; set; }
        public string hoLot { get; set; }
        public string ten { get; set; }
        public NV(int id, string hl, string t)
        {
            iD = id;
            hoLot = hl;
            ten = t;
        }
        
    }
}