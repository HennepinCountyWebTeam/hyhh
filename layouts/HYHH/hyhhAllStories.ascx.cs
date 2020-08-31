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

    public partial class hyhhAllStories : System.Web.UI.UserControl
    {
        Item comingNext = null;

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Item currentItem = Sitecore.Context.Item;

                Item[] storyItems = currentItem.Axes.SelectItems("descendant::*[@@templatename='Story' and @@name!='about' and @@name!='About']");

                IEnumerable<Item> storyItemList = storyItems.ToList().OrderBy(i => i["Date"]);

                comingNext = storyItemList.Last();

                //Text fldComingNextTitle = (Text)comingNext.FindControl("fldComingNextTitle");

                rptStoryCards.DataSource = storyItems;
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

                    Literal litFeatured = (Literal)e.Item.FindControl("litFeatured");
                    Literal litComingNext = (Literal)e.Item.FindControl("litComingNext");
                    string featuredText = string.Empty;
                    string comingNextText = string.Empty;

                    if (nodeItm.Fields["Featured Story"] != null)
                    {
                        Sitecore.Data.Fields.CheckboxField fldIsFeatured = nodeItm.Fields["Featured Story"];
                        if (fldIsFeatured.Checked == true)
                        {
                            featuredText = "<h1 class=\"hyhh-story-callout-heading\">Feature Story</h1>";
                            litFeatured.Text = featuredText;
                        }
                    }

                    if (comingNext.ID == nodeItm.ID)
                    {
                        comingNextText = "<h1 class=\"hyhh-story-callout-heading\">Coming Next</h1>";
                        litComingNext.Text = comingNextText;

                        //To remove later after coming next is fully implemented
                        //HyperLink storyLink = (HyperLink)e.Item.FindControl("storyLink");
                        //storyLink.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(nodeItm);
                    }
                    else {
                        HyperLink storyLink = (HyperLink)e.Item.FindControl("storyLink");
                        storyLink.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(nodeItm);
                    
                    }
                    //only add a hyperlink to the stories that aren't "Coming Next"
                    
                   
                    
                    Text fldTitle = (Text)e.Item.FindControl("fldTitle");
 
                    Sitecore.Web.UI.WebControls.Image fldRollupImage = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldRollupImage");

                    Text fldRollupSummary = (Text)e.Item.FindControl("fldRollupSummary");

                    fldTitle.Item = nodeItm;

                    fldRollupImage.Item = nodeItm;
                    fldRollupSummary.Item = nodeItm;
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }

            }
        }

    }
}