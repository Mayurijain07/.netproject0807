using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;

public partial class _Default : System.Web.UI.Page
{
    string constr = "Data Source= LAPTOP-9TDHBB6P;Initial Catalog= web18july;Integrated Security= true ";
    private object ddlCourse;
    protected void Page_Load(object sender, EventArgs e)
    {
        Show();
    }
    public void Show()//view
    {
        SqlConnection conn = new SqlConnection(constr);
        string query = "select *from web18Table";
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.CommandType = System.Data.CommandType.Text;
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        grid.DataSource = ds;
        grid.DataBind();
        conn.Close();
    }
    protected void btnsave_Click(object sender, EventArgs e)//insert
    {

        string Box = "";
        for(int i=0;i<chkCity.Items.Count; i++)
        {
            if (chkCity.Items[i].Selected==true)
            {
                Box += chkCity.Items[i].Text + ",";
            }
       }
        Box = Box.TrimEnd(',');


        if(btnsave.Text=="Submit")
        {
            string Name = txtName.Text;
            string Age = txtAge.Text;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into  web18Table(name,age,courses,gender,city) Values(@Name,@Age,@Courses,@Gender,@City)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Age", Age);
            cmd.Parameters.AddWithValue("@Courses",ddleCourses.SelectedValue);
            cmd.Parameters.AddWithValue("@Gender", rdGender.SelectedValue);
            cmd.Parameters.AddWithValue("@City", Box);
;            cmd.ExecuteNonQuery();
            conn.Close();
        }
        else if (btnsave.Text == "update")
        {
            SqlConnection conn = new SqlConnection(constr);
            string query = "update web18Table set  name=@Name,age=@Age  ,courses=@Courses,gender=@Gender,city=@City where id=@Id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", hdn.Value); 
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Age", txtAge.Text);
            cmd.Parameters.AddWithValue("@Courses", ddleCourses.SelectedValue);
            cmd.Parameters.AddWithValue("@Gender", rdGender.SelectedValue);
            cmd.Parameters.AddWithValue("@City", Box);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        Show();
        btnsave.Text = "Submit";
        txtName.Text = txtAge.Text = ddleCourses.SelectedValue=rdGender.SelectedValue=Box= "";
    }
     
    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteData")
        {
            SqlConnection conn = new SqlConnection(constr);
            string query = "Delete  web18Table where id=@Id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
            cmd.ExecuteNonQuery();
            conn.Close();



           
        }
        else if(e.CommandName=="EditRecord")
        {
            SqlConnection conn = new SqlConnection(constr);
            string query = "Select * from  web18Table where id=@Id";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", e.CommandArgument);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dta = new DataTable();
            sda.Fill(dta);
            conn.Close();
            txtName.Text = dta.Rows[0]["name"].ToString();
            txtAge.Text = dta.Rows[0]["age"].ToString();
            btnsave.Text = "update";//
            hdn.Value = e.CommandArgument.ToString();//

            if (dta. Rows [0]["Courses"]!=DBNull.Value && !string.IsNullOrEmpty(dta.Rows[0]["Courses"].ToString()))//Dropdown
            {
                string course = dta.Rows[0]["Courses"].ToString();
                if (ddleCourses.Items.FindByValue(course) != null)
                {
                    ddleCourses.SelectedValue = course;

                }
                btnsave.Text = "update";
                hdn.Value = e.CommandArgument.ToString();
            }
            if (dta.Rows[0]["Gender"] != DBNull.Value && !string.IsNullOrEmpty(dta.Rows[0]["Gender"].ToString()))
            {
                string gender = dta.Rows[0]["Gender"].ToString();
                if (rdGender.Items.FindByValue(gender) != null)
                {
                   rdGender.SelectedValue = gender;

                }
                if (dta.Rows[0]["city"] != DBNull.Value)
                {
                    string[] city = dta.Rows[0]["city"].ToString().Split(',');
                    foreach(ListItem item in chkCity.Items)
                    {
                        item.Selected = city.Contains(item.Text);
                    }
                }
                btnsave.Text = "update";
                hdn.Value = e.CommandArgument.ToString();
            }
        }
    }
}