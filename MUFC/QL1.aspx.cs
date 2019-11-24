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
    public partial class QL1 : System.Web.UI.Page
    {
        string conString;
        protected void Page_Load(object sender, EventArgs e)
        {
            conString = WebClass.getConnectionStringByName("sqlSConString");
          
            if (!Page.IsPostBack)
            {
           
                DocDuLieu();
               
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

                    
                    da.Fill(dt);
                    Gv2.DataSource = dt;
                    Gv2.DataBind();
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

        protected void Gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv2.PageIndex = e.NewPageIndex;
            DocDuLieu();
        }
    }
}