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


public partial class Contents_MsgBox : System.Web.UI.UserControl
{
    public Label lblMsgAssgn { get { return this.lblMsg; } set { this.lblMsg.Text = value.ToString(); } }
    public Panel pnlSingleAssgn { get { return this.pnlSingle; } set { this.pnlSingle.Visible = true; } }
    public Panel pnlYesNoAssgn { get { return this.pnlYesNo; } set { this.pnlYesNo.Visible = true; } }
    public Panel pnlOkCancelAssgn { get { return this.pnlOkCancel; } set { this.pnlOkCancel.Visible = true; } }

    public event EventHandler BtnClick;
    public event EventHandler BtnYesClick;
    public event EventHandler BtnNoClick;
    public event EventHandler BtnOkClick;
    public event EventHandler BtnCancelClick;

    protected void OnBtnClick(EventArgs e)
    {
        if (BtnClick != null)
        {
            BtnClick(this, e);
        }
    }
    protected void OnBtnYesClick(EventArgs e)
    {
        if (BtnYesClick != null)
        {
            BtnYesClick(this, e);
        }
    }
    protected void OnBtnNoClick(EventArgs e)
    {
        if (BtnNoClick != null)
        {
            BtnNoClick(this, e);
        }
    }
    protected void OnBtnOkClick(EventArgs e)
    {
        if (BtnOkClick != null)
        {
            BtnOkClick(this, e);
        }
    }
    protected void OnBtnCancelClick(EventArgs e)
    {
        if (BtnCancelClick != null)
        {
            BtnCancelClick(this, e);
        }
    }


    override protected void OnInit(EventArgs e)
    {
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        if (BtnClick != null)
            BtnClick(this, EventArgs.Empty);
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        this.Visible = false;
        if (BtnClick != null)
        {
            BtnClick(this, EventArgs.Empty);
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        this.Visible = false;
        if (BtnYesClick != null)
        {
            BtnYesClick(this, EventArgs.Empty);
        }
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        this.Visible = false;
        if (BtnNoClick != null)
        {
            BtnNoClick(this, EventArgs.Empty);
        }
    }
    protected void btnOk1_Click(object sender, EventArgs e)
    {
        this.Visible = false;
        if (BtnOkClick != null)
        {
            BtnOkClick(this, EventArgs.Empty);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.Visible = false;
        if (BtnCancelClick != null)
        {
            BtnCancelClick(this, EventArgs.Empty);
        }
    }

    public enum MessageType
    {
        single = 1,
        yesno = 2,
        okcancel = 3
    }
    public void Show(MessageType messageType, string messageMn, string messageSb)
    {
        lblMsgCtrl.Text = messageMn;
        lblMsg.Text = messageSb;
        switch (messageType)
        {
            case MessageType.single :
                pnlSingle.Visible = true;
                pnlYesNo.Visible = false;
                pnlOkCancel.Visible = false;
                break;
            case MessageType.yesno:
                pnlSingle.Visible = false;
                pnlYesNo.Visible = true;
                pnlOkCancel.Visible = false;
                break;
            case MessageType.okcancel:
                pnlSingle.Visible = false;
                pnlYesNo.Visible = false;
                pnlOkCancel.Visible = true; ;
                break;
        }
        this.Visible = true;
    }
}
