using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUFC
{
    public partial class QL5 : System.Web.UI.Page
    {
     
        string conString = @"Data Source = (local); Initial Catalog = MUFC; Integrated Security = True";
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcom2 = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            DocDuLieu();
        }
        private void DocDuLieu()
        {
            
            try
            {
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    sqlcom2.Connection = sqlcon;
                    sqlcom2.CommandType = System.Data.CommandType.Text;
                    sqlcom2.CommandText = "SELECT Player.ID AS 'ID CẦU THỦ',Player.Ten AS 'TÊN CẦU THỦ',  Player.NamSinh AS 'NĂM SINH', Player.QueQuan AS 'QUÊ QUÁN', Player.GiaTri AS 'GIÁ TRỊ' , VItri.VItri 'VỊ TRÍ' "
                        + "FROM Player INNER JOIN VItri ON Player.ID_VT = VItri.ID_VT ";
                    DataTable dt = new DataTable("DS");
                    SqlDataAdapter da = new SqlDataAdapter(sqlcom2);
                    //dt.Rows.
                    da.Fill(dt);
                    Gv3.DataSource = dt;
                    Gv3.DataBind();
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

        protected void Gv3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    string id = e.Values["ID CẦU THỦ"].ToString();
                    sqlcom2.CommandType = System.Data.CommandType.Text;
                    sqlcom2.CommandText = "delete from Player where ID = '" + id + "'"; ;
                    int cnt = sqlcom2.ExecuteNonQuery();
                    lThongBao.Text = String.Format("{0} cầu thủ đã được thanh lý thành công!", cnt);
                    DocDuLieu();
                }
            }

            catch (Exception exc)
            {
                lThongBao.Text = String.Format("Lỗi: {0}. Chi tiết: {1}", exc.Message, exc.StackTrace);
            }
            finally
            {
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
        }

        protected void Gv3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv3.PageIndex = e.NewPageIndex;
            DocDuLieu();
        }
    }
}