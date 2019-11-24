using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 
/// </summary>
using System.Data;
using System.Data.SqlClient;


namespace MUFC
{
    public partial class TTCT : System.Web.UI.Page
    {
        string conString;
        protected void Page_Load(object sender, EventArgs e)
        {
            conString = WebClass.getConnectionStringByName("sqlSConString");
            if (!Page.IsPostBack)
            {
                DocDanhSach();
                BindDataToDataList();
            }
        }
        protected void DocDanhSach()
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
        protected void FileUploadControl_Load(object sender, EventArgs e)
        {
            //FileUploadControl.PostedFile.ContentType
        }

        protected void BindDataToDataList()
        {

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
                        sqlcom2.CommandText = "SELECT Player.ID,Player.Ten , Player.ID_VT,hinhAnh from Player";

                        DataTable dt = new DataTable("DS");
                        SqlDataAdapter da = new SqlDataAdapter(sqlcom2);
                        //dt.Rows.
                        da.Fill(dt);
                        DataList1.DataSource = dt;
                        DataList1.DataBind();
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

        protected void bThemMoi_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcom2 = new SqlCommand();
            lThongBao.Text = "";
            try
            {
                
                if (tbID.Text.Trim() == "" || tbTen.Text.Trim() == ""
                    || dsVT.SelectedIndex == 0 || !FileUploadControl.HasFile)
                {
                    lThongBao.Text = "Phải nhập đủ dữ liệu!";
                    return;
                }
                sqlcon.ConnectionString = conString;
                sqlcon.Open();

                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    //lThongBao.Text = "Kết nối CSDL thành công!";
                    sqlcom2.Connection = sqlcon;
                    sqlcom2.CommandType = System.Data.CommandType.Text;
                    sqlcom2.CommandText = "INSERT INTO Player(ID, Ten, ID_VT,hinhAnh) VALUES" + "('" + tbID.Text.Trim() + "', '" + tbTen.Text.Trim()  + "', '" + dsVT.SelectedValue + "', '" + string.Format("hinhAnh_{0}.jpg", tbID.Text.Trim())+ "')";
                    lThongBao.Text = sqlcom2.CommandText;

                    int cnt = sqlcom2.ExecuteNonQuery();
                    lThongBao.Text = cnt.ToString() + " đã được thêm thành công!";
                    FileUploadControl.SaveAs(string.Format("{0}/files/img/hinhAnh_{1}.jpg",
                  Server.MapPath("~"), tbID.Text.Trim()));
                }
              
              

                BindDataToDataList();
            }
            catch (Exception exc)
            {
                lThongBao.Text = "Kết nối CSDL thất bại! Lỗi: " + exc.Message + ". " + exc.StackTrace;

            }
            finally
            {
                
            }
        }
    }
    
}