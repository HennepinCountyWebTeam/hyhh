using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore.Collections;
using System.Linq;
using Sitecore.Data.Fields;

namespace Hennepin.SCWeb.HYHH.layouts.HYHH
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class hyhhMaster : Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {

            try
            {
                Item currentItem = Sitecore.Context.Item;
                //ChildList childItems = currentItem.Children;


                //string pageURL = Sitecore.Links.LinkManager.GetItemUrl(currentItem);
                //string pageTitle = currentItem.Fields["Title"].ToString();
                ////string pageIntro = childItems

                //fbLink.Text = string.Format("<a href=\"https://www.facebook.com/sharer/sharer.php?u={0}\" target=\"_blank\"><img src=\"/hyhh-assets/images/icon-facebook.png\" alt=\"Share on Facebook\" target=\"_blank\" title=\"Share on Facebook\"></a>", pageURL);
                ////<a href="https://www.facebook.com/sharer/sharer.php?u=" target="_blank"><img src="/hyhh-assets/images/icon-facebook.png" alt="Share on Facebook" target="_blank" title="Share on Facebook"></a>

                //string ogText = string.Empty;
                string ogTitle = string.Empty;
                string ogURL = string.Empty;
                string ogDescription = string.Empty;

                if(currentItem.Fields["Title"].ToString() != null){
                    ogTitle = currentItem.Fields["Title"].ToString();
                }

                if(currentItem.Fields["Description"].ToString() != null){
                    ogTitle = currentItem.Fields["Description"].ToString();
                }

                ogURL = Sitecore.Links.LinkManager.GetItemUrl(currentItem);

                //litOpenGraph.Text = string.Format("<meta property=\"og:title\" content=\"{0}\"/>", ogTitle);
                //litOpenGraph.Text = string.Format("<meta property=\"og:title\" content=\"{0}\"/><meta property=\"og:url\" content=\"{1}\"/><meta property=\"og:description\" content=\"{2}\"/>", ogTitle, ogURL, ogDescription);

                //test.Item = currentItem;

               
            }
            catch (Exception ex)
            {
                bool exHandled = handleException(ex);
            }






        }

        Boolean handleException(Exception ex)
        {
            bool handled = false;
            try
            {
                handled = true;
            }
            catch (Exception e)
            {

            }

            return handled;
        }
    }
}
