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

    public partial class hyhhHome : System.Web.UI.UserControl
    {

        Item comingNext = null;
        int storyCounter = 0;
        string blueBarText = string.Empty;

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Item currentItem = Sitecore.Context.Item;
                //ChildList childItems = currentItem.Children;

                string pageURL = Sitecore.Links.LinkManager.GetItemUrl(currentItem);
                string pageTitle = "Healthy You, Healthy Hennepin";

                fbLink.Text = string.Format("<a href=\"https://www.facebook.com/sharer/sharer.php?u={0}\" target=\"_blank\"><img src=\"/hyhh-assets/images/icon-facebook.png\" alt=\"Share on Facebook\" target=\"_blank\" title=\"Share on Facebook\"></a>", pageURL);
                //<a href="https://www.facebook.com/sharer/sharer.php?u=" target="_blank"><img src="/hyhh-assets/images/icon-facebook.png" alt="Share on Facebook" target="_blank" title="Share on Facebook"></a>

                twLink.Text = string.Format("<a href=\"https://twitter.com/home?status={0} - {1}\" target=\"_blank\"><img src=\"/hyhh-assets/images/icon-twitter.png\" alt=\"Share on Twitter\" target=\"_blank\" title=\"Share on Twitter\"></a>", pageTitle, pageURL);
                //<a href="https://twitter.com/home?status=" target="_blank"><img src="/hyhh-assets/images/icon-twitter.png" alt="Share on Twitter" target="_blank" title="Share on Twitter"></a>
                

                blueBarText = currentItem.Fields["Blue Bar Content"].Value;

                Item[] storyItems = currentItem.Axes.SelectItems("descendant::*[@@templatename='Story' and @@name!='about' and @@name!='About']");

                IEnumerable<Item> storyItemList = storyItems.ToList().OrderByDescending(i => i["Date"]);

                comingNext = storyItemList.First();

                //List<Item> storyItemsTruncated = storyItemList.Skip(1).ToList();
                //storyItemsTruncated.OrderBy(i => i["NodeOrder"]);

                //fldComingNextTitle.Item = comingNext;
                //fldComingNextImage.Item = comingNext;


                //fldImage.Item = currentItem;
                //fldTitle.Item = currentItem;
                //fldCopyText.Item = currentItem;

                string comingNextLink = currentItem.Fields["Link"].ToString();
                
                litComingNextLink.Text = string.Format(" <a href='{0}' target=\"_blank\"><div class=\"hyhh-newsletter-submit\">Click to subscribe</div></a>", comingNextLink);

                rptStoryCards.DataSource = storyItemList.Skip(1);

                //rptStoryCards.DataSource = currentItem.Axes.SelectItems("descendant::*[@@templatename='Story' and @@name!='about' and @@name!='About']");
                rptStoryCards.DataBind();

                

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

        protected void rptStoryCards_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    //Item childItem = nodeItm.Axes.SelectSingleItem("descendant::*[@@templatename='Story - Hero']");

                    //Item[] childrenItems = nodeItm.Axes.SelectItems("descendant::*[@@templatename='Story - Hero']");
                    //Item childHero = childrenItems[0];

                    Text fldTitle = (Text)e.Item.FindControl("fldTitle");
                    
                    HyperLink storyLink = (HyperLink)e.Item.FindControl("storyLink");
                    storyLink.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(nodeItm);

                    //Sitecore.Web.UI.WebControls.Image fldRollupImage = childItem.Fields["Hero Image"] as Sitecore.Web.UI.WebControls.Image;

                    Sitecore.Web.UI.WebControls.Image fldHomeImage = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldHomeImage");
                    Sitecore.Web.UI.WebControls.Image fldRollupImage = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldRollupImage");

                    Text fldRollupSummary = (Text)e.Item.FindControl("fldRollupSummary");

                    fldTitle.Item = nodeItm;

                    //fldHeroImage.Item = childHero;
                    fldHomeImage.Item = nodeItm;
                    fldRollupImage.Item = nodeItm;
                    fldRollupSummary.Item = nodeItm;

                    Literal litBlueBarContent = (Literal)e.Item.FindControl("litBlueBarContent");

                    if (storyCounter == 0 && blueBarText != string.Empty)
                    {
                        litBlueBarContent.Text = string.Format("<div class=\"hyhh-blue-bar close js-cookie-bar\" style=\"display: block;\"><span class=\"hyhh-close-marker\">x</span><p>{0}</p></div>", blueBarText);
                        storyCounter++; //increment after first story is displayed
                    }
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }

            }
        }
    }
}