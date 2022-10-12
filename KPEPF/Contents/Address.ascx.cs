using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Contents_Address : System.Web.UI.UserControl
{
    public ArrayList Arr = new ArrayList();
    //public string intEmpID
    //{
    //    get
    //    {
    //        if (this.txtEmpID.Text != "")
    //            return this.txtEmpID.Text;
    //        else
    //            return "";
    //    }
    //    set { this.txtEmpID.Text = value.ToString(); }
    //}
    //public int intWardNo
    //{
    //    get
    //    {
    //        if (Convert.ToInt16(txtWardNo.Text.ToString()) != 0)
    //        {
    //            return Convert.ToInt16(this.txtWardNo.Text.ToString());
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //    set
    //    {
    //        this.txtWardNo.Text = value.ToString();
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void btnAddClose_Click(object sender, EventArgs e)
    //{
    //    SaveToArray();
    //    this.Visible = false;
    //}
    //public void SaveToArray()
    //{
    //    Arr.Add(Convert.ToInt16(txtWardNo.Text.ToString()));
    //    Arr.Add(txtDoorNo1.Text.ToString());
    //    Arr.Add(txtBldgNm.Text.ToString());
    //    Arr.Add(txtLocalPlace.Text.ToString());

    //    Arr.Add(txtMainPlace.Text.ToString());
    //    Arr.Add(Convert.ToInt16(txtPincode.Text.ToString()));
    //    Arr.Add(txtPostoffice.Text.ToString());
    //    Arr.Add(Convert.ToInt16(ddlDist.SelectedValue));
        
    //}
}
