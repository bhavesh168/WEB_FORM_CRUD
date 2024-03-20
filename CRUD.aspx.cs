using System;
using System.Data;

namespace WEB_FORM_CRUD
{
    public partial class CRUD : System.Web.UI.Page
    {
        protected string FRMID= "", FirstName = "", LastName = "", MobileNo = "";
        protected DataTable dt = new DataTable();
        protected DataTable dt1 = new DataTable();
        protected clsCRUD objCRUD = new clsCRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = "0", Action = "";

            if (!string.IsNullOrEmpty(Request.Params["ID"]))
            {
                ID = Convert.ToString(Request.Params["ID"]);
            }

            if (!string.IsNullOrEmpty(Request.Params["Action"]))
            {
                Action = Convert.ToString(Request.Params["Action"]);
            }

            if (Action.ToLower() == "edit" && !string.IsNullOrEmpty(ID) && Request.HttpMethod != "POST")
            {
                dt1 = objCRUD.GetDataByID(Convert.ToInt32(ID));
                if (dt1.Rows.Count > 0)
                {
                    FirstName = dt1.Rows[0]["FirstName"].ToString();
                    LastName = dt1.Rows[0]["LastName"].ToString();
                    MobileNo = dt1.Rows[0]["MobileNo"].ToString();
                }
            }

            if (Action.ToLower() == "delete" && !string.IsNullOrEmpty(ID) && Request.HttpMethod != "POST")
            {
                objCRUD.DeleteRecord(Convert.ToInt32(ID));
            }

            if (Request.HttpMethod == "POST")
            {
                FirstName = Request.Form["FirstName"];
                LastName = Request.Form["LastName"];
                MobileNo = Request.Form["MobileNo"];

                if (Action.ToLower() != "edit" && (string.IsNullOrEmpty(ID) || ID == "0"))
                {
                    objCRUD.InsertRecord(FirstName, LastName, MobileNo);
                    Response.Redirect("CRUD.aspx");
                }
                else
                {
                    objCRUD.UpdateRecord(Convert.ToInt32(ID), FirstName, LastName, MobileNo);
                    Response.Redirect("CRUD.aspx");
                }
            }

            dt = objCRUD.GetData();

        }
    }
}