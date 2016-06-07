using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Backpack.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            insightspath.Text = AppDomain.CurrentDomain.BaseDirectory + @"nodeapp\public\docs\audience\insights.md";
        }
    }
}