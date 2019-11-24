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
    public partial class QL3 : System.Web.UI.Page
    {
        string conString = @"Data Source = (local); Initial Catalog = MUFC; Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {
            DocDanhSach();
            Gv1.AutoGenerateColumns = false;
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


                    if (sqlreader.HasRows)//true/false toi thieu co 1 ban ghi nao ko
                    {
                        while (sqlreader.Read())//duyet theo dong gặp true thì duyệt dòng tiếp theo false end
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

        protected void btThem_Click1(object sender, EventArgs e)
        {
            lThongBao.Text = "";
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd1 = new SqlCommand();
            try
            {

                if (tbID.Text.Trim() == "" || tbTen.Text.Trim() == "" || dsVT.SelectedIndex == 0 || tbNS.Text.Trim() == "" || tbTuoi.Text.Trim() == ""
                    || tbQQ.Text.Trim() == "" || tbGT.Text.Trim() == "")
                {
                    lThongBao.Text = "Phải nhập đủ dữ liệu!";
                    return;
                }
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    //lThongBao.Text = "Kết nối CSDL thành công!";
                    sqlcmd1.Connection = sqlcon;
                    sqlcmd1.CommandType = System.Data.CommandType.Text;
                    sqlcmd1.CommandText = "INSERT INTO Player(ID, Ten, NamSinh, Tuoi, QueQuan, GiaTri, ID_VT) VALUES"+"('" +tbID.Text.Trim() + "', '" + tbTen.Text.Trim() + "', '"+ tbNS.Text.Trim() + "', '" + tbTuoi.Text.Trim() + "', '" + tbQQ.Text.Trim() + "', '" + tbGT.Text.Trim() + "', '"+ dsVT.SelectedValue + "')";
                    lThongBao.Text = sqlcmd1.CommandText;
                   
                    int cnt = sqlcmd1.ExecuteNonQuery();//tra ve so luong ban ghi duoc thuc thi
                    lThongBao.Text = cnt.ToString() + " đã được thêm thành công!";
                }
                else lThongBao.Text = "Kết nối CSDL thất bại!";
            }
            catch (Exception exc)
            {
                lThongBao.Text = "Kết nối CSDL thất bại! Lỗi: " + exc.Message + ". " + exc.StackTrace;

            }
            finally
            {
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    sqlcon.Close();
                    sqlcmd1.Dispose();
                }

            }
            Gv1.AutoGenerateColumns = true;
            DocDuLieu();
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