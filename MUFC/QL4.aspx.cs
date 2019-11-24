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
    public partial class QL4 : System.Web.UI.Page
    {
        string conString = @"Data Source = (local); Initial Catalog = MUFC; Integrated Security = True";
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcom2 = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Gv1.Visible = false;// an bang gridview
                DocID();
                DocDanhSach();
            }
        }
        protected void DocDuLieu()
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
        private void DocDanhSach()
        {
            dsVT.Items.Clear();
            ListItem item0 = new ListItem();
            item0.Value = "-1";
            item0.Text = "Chọn vị trí";
            dsVT.Items.Add(item0);

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
                    sqlcom2.CommandText = "SELECT ID_VT,VItri FROM VItri";
                    SqlDataReader sqlreader = sqlcom2.ExecuteReader();


                    if (sqlreader.HasRows)
                    {
                        while (sqlreader.Read())
                        {
                            ListItem item = new ListItem();
                            item.Value = sqlreader.GetSqlString(0).ToString();
                            item.Text = sqlreader.GetSqlString(1).ToString();
                            dsVT.Items.Add(item);
                        }
                    }

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
        private void DocID()
        {
            dsID.Items.Clear();
            ListItem item0 = new ListItem();
            item0.Value = "-1";
            item0.Text = "Chọn id cần cập nhập";
            dsID.Items.Add(item0);

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
                    sqlcom2.CommandText = "SELECT ID FROM Player";
                    SqlDataReader sqlreader = sqlcom2.ExecuteReader();


                    if (sqlreader.HasRows)
                    {
                        while (sqlreader.Read())
                        {
                            ListItem item = new ListItem();
                            item.Value = sqlreader.GetSqlString(0).ToString();
                            item.Text = sqlreader.GetSqlString(0).ToString();
                            dsID.Items.Add(item);
                        }
                    }

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

        protected void btCapnhat_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(conString);//Dùng constructor khác
            SqlCommand sqlcom3 = new SqlCommand();
            try
            {
                sqlcon.Open();
                if (dsID.SelectedIndex==0)
                {
                    lThongBao.Text = "Phải nhập đủ dữ liệu!";
                    return;
                }
                
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    sqlcom3.Connection = sqlcon;
                    sqlcom3.CommandText = "UPDATE  Player SET Ten = @ten,NamSinh=@ns,QueQuan=@qq,GiaTri=@gt,Tuoi=@t,ID_VT=@vt where ID=@id";
                    sqlcom3.Parameters.Add("ten", System.Data.SqlDbType.NVarChar);//dung parameter//tuong dong du lieu vs cot sql
                    sqlcom3.Parameters["ten"].Value = tbTen.Text.Trim();
                    sqlcom3.Parameters.Add("ns", System.Data.SqlDbType.NVarChar);
                    sqlcom3.Parameters["ns"].Value = tbNS.Text.Trim();
                    sqlcom3.Parameters.Add("qq", System.Data.SqlDbType.NVarChar);//dung parameter
                    sqlcom3.Parameters["qq"].Value = tbQQ.Text.Trim();
                    sqlcom3.Parameters.Add("gt", System.Data.SqlDbType.NVarChar);//dung parameter
                    sqlcom3.Parameters["gt"].Value = tbGT.Text.Trim();
                    sqlcom3.Parameters.Add("t", System.Data.SqlDbType.Int);/*System.Data.SqlDbType.Int day la kieu du lieu tuong ung trong db,ghi dung ms chay dk*/
                    sqlcom3.Parameters["t"].Value = tbTuoi.Text.Trim();
                    sqlcom3.Parameters.Add("vt", System.Data.SqlDbType.NVarChar);//dung parameter
                    sqlcom3.Parameters["vt"].Value = dsVT.SelectedValue;
                    sqlcom3.Parameters.Add("id", System.Data.SqlDbType.NVarChar);//dung parameter
                    sqlcom3.Parameters["id"].Value = dsID.SelectedValue;
                    int cnt = sqlcom3.ExecuteNonQuery();//so luong ban ghi bi tac dong
                    lThongBao.Text = String.Format("{0} bản ghi đã được cập nhật thành công!", cnt);
                    Gv1.Visible = true;
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
    }

}