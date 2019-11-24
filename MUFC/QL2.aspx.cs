using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MUFC
{
    public partial class QL2 : System.Web.UI.Page
    {
        string conString = @"Data Source = (local); Initial Catalog = MUFC; Integrated Security = True";
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcom2 = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

          
       
      

        protected void btTk_Click(object sender, EventArgs e)
        {
            if (tbTen.Text.Trim() == "")

            {
                Response.Write("<br/><br/>Hãy nhập tối thiểu 1 điều kiện tìm kiếm!!! <br/><br/>");
                return;

            }
            string where = " WHERE 1=1 ";
            if (tbTen.Text.Trim() != "")
                where = string.Format(" {0} AND Ten LIKE N'%{1}%'", where, tbTen.Text.Trim());
           
            try
            {
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    //Response.Write("</br>Kết nối thành công! </br>");
                    sqlcom2.Connection = sqlcon;
                    sqlcom2.CommandType = System.Data.CommandType.Text;
                    sqlcom2.CommandText = string.Format("SELECT Player.ID AS 'ID CẦU THỦ',Player.Ten AS 'TÊN CẦU THỦ',  Player.NamSinh AS 'NĂM SINH', Player.QueQuan AS 'QUÊ QUÁN', Player.GiaTri AS 'GIÁ TRỊ' , VItri.VItri 'VỊ TRÍ' FROM Player INNER JOIN VItri ON Player.ID_VT = VItri.ID_VT  {0}", where);

                    //Response.Write(string.Format("SQL: {0}", sqlcomm4.CommandText));

                    DataTable dt = new DataTable("DSplayer");
                    SqlDataAdapter da3 = new SqlDataAdapter(sqlcom2);
                    //dt.Rows.
                    da3.Fill(dt);
                    Gv1.DataSource = dt;
                    //gHangHoa.PageIndex = pageIndex;
                    Gv1.DataBind();
                }
                else
                {
                }
            }
            catch (Exception exc)
            {
                Response.Write(string.Format("<br/>Lỗi: {0}. <br/>Code: {1}",
                    exc.Message, exc.StackTrace));
            }
            finally
            {

                sqlcom2.Dispose();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                    sqlcon.Close();
            }
        }
        private void DocDuLieu()
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcom2 = new SqlCommand();
            try
            {
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    sqlcom2.Connection = sqlcon;
                    sqlcom2.CommandType = System.Data.CommandType.Text;
                    sqlcom2.CommandText = "SELECT Player.ID AS 'ID CẦU THỦ',Player.Ten AS 'TÊN CẦU THỦ',  Player.NamSinh AS 'NĂM SINH', Player.Tuoi AS 'TUỔI', Player.GiaTri AS 'GIÁ TRỊ', Player.QueQuan 'QUÊ QUÁN', Player.ID_VT 'ID VỊ TRÍ', VItri.VItri AS 'VỊ TRÍ'"
                        + "FROM Player INNER JOIN VItri ON Player.ID_VT = VItri.ID_VT ";
                    DataTable dt = new DataTable("DS");
                    SqlDataAdapter da = new SqlDataAdapter(sqlcom2);
                    //dt.Rows.
                    da.Fill(dt);
                    Gv1.DataSource = dt;
                    Gv1.DataBind();
                }
            }
            catch (Exception exc)
            {

            }
            finally
            {
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    sqlcon.Close();

                }
            }
        }


    }

}