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

public partial class Contents_MsgUCtrl : System.Web.UI.UserControl
{
    //public bool ShowCloseButton { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
    //    if (ShowCloseButton)
    //        CloseButton.Attributes.Add("onclick", "document.getElementById('" +
    //        MessageBox.ClientID + "').style.display = 'none'");
    }
    public enum MessageType
    {
        Error = 1,
        Info = 2,
        Success = 3,
        Warning = 4
    }
    public void Show(MessageType messageType, string message)
    {
      //  CloseButton.Visible = ShowCloseButton;
        litMessage.Text = message;
        switch (messageType)
        {
            case MessageType.Error:
                MessageBox.CssClass = "error";
                break;
            case MessageType.Info:
                MessageBox.CssClass = "info";
                break;
            case MessageType.Success:
                MessageBox.CssClass = "success";
                break;
            case MessageType.Warning:
                MessageBox.CssClass = "warning";
                break;
        }
        this.Visible = true;
    }
    public void ShowError(string message)
    {
        Show(MessageType.Error, message);
    }
    public void ShowInfo(string message)
    {
        Show(MessageType.Info, message);
    }
    public void ShowSuccess(string message)
    {
        Show(MessageType.Success, message);
    }
    public void ShowWarning(string message)
    {
        Show(MessageType.Warning, message);
    } 

}
