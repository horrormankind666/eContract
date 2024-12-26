using System;
using System.Web.UI;

namespace eContract {
    public partial class DetectBrowser : Page {
        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            string path = Myconfig.GetVirtualPath();

            Myconfig.GetMeteriaUi(Page, path);
        }
    }
}