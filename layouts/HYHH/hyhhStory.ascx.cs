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

    public partial class hyhhStory : System.Web.UI.UserControl
    {

        private void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Item currentItem = Sitecore.Context.Item;
                ChildList childItems = currentItem.Children;

                
                string pageURL = Sitecore.Links.LinkManager.GetItemUrl(currentItem);
                string pageTitle = currentItem.Fields["Title"].ToString();
                //string pageIntro = childItems
                      
                fbLink.Text = string.Format("<a href=\"https://www.facebook.com/sharer/sharer.php?u={0}\" target=\"_blank\"><img src=\"/hyhh-assets/images/icon-facebook.png\" alt=\"Share on Facebook\" target=\"_blank\" title=\"Share on Facebook\"></a>", pageURL);
                //<a href="https://www.facebook.com/sharer/sharer.php?u=" target="_blank"><img src="/hyhh-assets/images/icon-facebook.png" alt="Share on Facebook" target="_blank" title="Share on Facebook"></a>

                twLink.Text = string.Format("<a href=\"https://twitter.com/home?status={0} - {1}\" target=\"_blank\"><img src=\"/hyhh-assets/images/icon-twitter.png\" alt=\"Share on Twitter\" target=\"_blank\" title=\"Share on Twitter\"></a>", pageTitle, pageURL);
                //<a href="https://twitter.com/home?status=" target="_blank"><img src="/hyhh-assets/images/icon-twitter.png" alt="Share on Twitter" target="_blank" title="Share on Twitter"></a>
                
                rptModules.DataSource = childItems;
                rptModules.DataBind();
            }
            catch (Exception ex)
            {
                bool exHandled = handleException(ex);
            }
        }

        protected void rptModules_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    PlaceHolder phSections = (PlaceHolder)e.Item.FindControl("phSections");

                    String moduleTemplate = nodeItm.TemplateID.ToString();
                    bool success = switchModule(phSections, moduleTemplate, nodeItm);
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
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

        protected void rptStory_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                   
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        protected void rptStoryHero_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                    Sitecore.Web.UI.WebControls.Image fldHeroImage = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldHeroImage");

                    fldHeroImage.Item = nodeItm;
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        protected void rptStoryIntro_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                    //Text fldDate = (Text)e.Item.FindControl("fldDate");
                    Literal litDate = (Literal)e.Item.FindControl("litDate");
                    litDate.Text = "Hello World";
                    //Literal eventDateFld = (Literal)e.Item.FindControl("eventDateFld");
                    //eventDateFld.Text = scDateField.DateTime.ToString("MMM dd");
                    Item storyItem = nodeItm.Parent;
                    DateField nodeDateField = storyItem.Fields["Date"];
                    litDate.Text = nodeDateField.DateTime.ToString("MMMM yyyy");
                    Text fldDescription = (Text)e.Item.FindControl("fldDescription");
                    //fldDate.Item = nodeItm;
                    fldDescription.Item = nodeItm;
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        protected void rptStoryQuote_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                    //Text fldQuote = (Text)e.Item.FindControl("fldQuote");
                    Text fldCitation = (Text)e.Item.FindControl("fldCitation");

                    //Literal litFeatured = (Literal)e.Item.FindControl("litFeatured");
                    //Literal litComingNext = (Literal)e.Item.FindControl("litComingNext");

                    Literal litQuote = (Literal)e.Item.FindControl("litQuote");
                    Literal litCitation = (Literal)e.Item.FindControl("litCitation");

                    string quoteText = string.Empty;
                    string citationText = string.Empty;

                    if (nodeItm.Fields["Quote"] != null)
                    {
                        Sitecore.Data.Fields.CheckboxField fldIsQuote = nodeItm.Fields["Not Quote"];
                        if (fldIsQuote.Checked == true)
                        {
                            //quote text is p text
                            quoteText = string.Format("<{0}>{1}</{0}>","p",nodeItm.Fields["Quote"]);
                            litQuote.Text = quoteText;
                        }
                        else {
                            quoteText = string.Format("<{0}><{1}>{2}</{1}></{0}>", "blockquote", "q", nodeItm.Fields["Quote"]);
                            litQuote.Text = quoteText;
                        }
                    }

                    if (nodeItm.Fields["Citation"].Value == "")
                    {
                            citationText = string.Format("<{0}>{1}</{0}>", "div", nodeItm.Fields["Citation"]);
                            litCitation.Text = citationText;
                    }
                    else
                    {
                            citationText = string.Format("<{0}>{1}</{0}>", "cite", nodeItm.Fields["Citation"]);
                            litCitation.Text = citationText;
                    }
                    


                    //fldQuote.Item = nodeItm;
                    //fldCitation.Item = nodeItm;
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        protected void rptSectionContainer_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    Repeater rptSectionRow = (Repeater)e.Item.FindControl("rptSectionRow");
                    rptSectionRow.DataSource = nodeItm.Children;
                    rptSectionRow.DataBind();
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        protected void rptSectionRow_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                    Text fldFact = (Text)e.Item.FindControl("fldFact");
                    Text fldCopy = (Text)e.Item.FindControl("fldCopy");

                    Sitecore.Web.UI.WebControls.Image fldInfoImage = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldInfoImage");
                    Text fldInfoContent = (Text)e.Item.FindControl("fldInfoContent");

                    fldFact.Item = nodeItm;
                    fldCopy.Item = nodeItm;
                    fldInfoImage.Item = nodeItm;
                    fldInfoContent.Item = nodeItm;
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        protected void rptStoryFullWidthImage_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    Sitecore.Web.UI.WebControls.Image fldImage = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldImage");

                    fldImage.Item = nodeItm;
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        protected void rptStorySplitImage_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;

                    Sitecore.Web.UI.WebControls.Image fldImageLeft = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldImageLeft");
                    Sitecore.Web.UI.WebControls.Image fldImageRight = (Sitecore.Web.UI.WebControls.Image)e.Item.FindControl("fldImageRight");

                    fldImageLeft.Item = nodeItm;
                    fldImageRight.Item = nodeItm;
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }
        protected void rptBlueBarAbout_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Item nodeItm = (Item)e.Item.DataItem;
                    Text fldBarContent = (Text)e.Item.FindControl("fldBarContent");

                    fldBarContent.Item = nodeItm;
                  
                }
                catch (Exception ex)
                {
                    bool exHandled = handleException(ex);
                }
            }
        }

        //rptModules  
        //template id                                
        //rptStory                  {94EE3FC1-C997-490C-A1B5-74EEBE51CD77}  USE?
        //rptStoryHero              {965B591B-265F-4BCF-AB71-5BEC06278698}
        //rptStoryIntro             {94A69D24-8444-4282-A32D-8BE1F707D75E}
        //rptStoryQuote             {3A8892C9-57DF-4FF5-840F-89B2339434F6}
        //rptSectionContainer       {0F94EA49-4022-4843-8A35-D43A3B7A5202}
        //rptSectionRow             {A73A7D55-32A5-42F1-AE9B-5620AC540FB6}
        //rptStoryFullWidthImage    {E03A073F-F8C2-48DA-90DF-741DD7A69B95}
        //rptStorySplitImage        {3954627A-01A2-4D82-BEB9-3DB27F1DF2D1} 
        //rptBlueBarAbout           {F2737D1D-9943-4FA7-86D0-C3B78067C413}


        Boolean switchModule(PlaceHolder phModules, string templateId, Item childItem)
        {
            bool success = false;
            try
            {
                Repeater rptModule = new Repeater();
                switch (templateId)
                {
                    //Story
                    case "{94EE3FC1-C997-490C-A1B5-74EEBE51CD77}":
                        List<Item> storyItem = new List<Item>();
                        storyItem.Add(childItem);
                        rptModule.DataSource = storyItem;
                        rptModule.HeaderTemplate = rptStory.HeaderTemplate;
                        rptModule.ItemTemplate = rptStory.ItemTemplate;
                        rptModule.FooterTemplate = rptStory.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptStory_ItemDataBound);
                        break;
                    //StoryHero
                    case "{965B591B-265F-4BCF-AB71-5BEC06278698}":
                        List<Item> storyHeroItem = new List<Item>();
                        storyHeroItem.Add(childItem);
                        rptModule.DataSource = storyHeroItem;
                        rptModule.HeaderTemplate = rptStoryHero.HeaderTemplate;
                        rptModule.ItemTemplate = rptStoryHero.ItemTemplate;
                        rptModule.FooterTemplate = rptStoryHero.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptStoryHero_ItemDataBound);
                        break;
                    //StoryIntro
                    case "{94A69D24-8444-4282-A32D-8BE1F707D75E}":
                        List<Item> storyIntroItem = new List<Item>();
                        storyIntroItem.Add(childItem);
                        rptModule.DataSource = storyIntroItem;
                        rptModule.HeaderTemplate = rptStoryIntro.HeaderTemplate;
                        rptModule.ItemTemplate = rptStoryIntro.ItemTemplate;
                        rptModule.FooterTemplate = rptStoryIntro.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptStoryIntro_ItemDataBound);
                        break;
                    //StoryQuote
                    case "{3A8892C9-57DF-4FF5-840F-89B2339434F6}":
                        List<Item> storyQuoteItem = new List<Item>();
                        storyQuoteItem.Add(childItem);
                        rptModule.DataSource = storyQuoteItem;
                        rptModule.HeaderTemplate = rptStoryQuote.HeaderTemplate;
                        rptModule.ItemTemplate = rptStoryQuote.ItemTemplate;
                        rptModule.FooterTemplate = rptStoryQuote.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptStoryQuote_ItemDataBound);
                        break;
                    //SectionContainer
                    case "{0F94EA49-4022-4843-8A35-D43A3B7A5202}":
                        List<Item> sectionContainerItem = new List<Item>();
                        sectionContainerItem.Add(childItem);
                        rptModule.DataSource = sectionContainerItem;
                        rptModule.HeaderTemplate = rptSectionContainer.HeaderTemplate;
                        rptModule.ItemTemplate = rptSectionContainer.ItemTemplate;
                        rptModule.FooterTemplate = rptSectionContainer.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptSectionContainer_ItemDataBound);
                        break;

                    /*//SectionRow
                    case "{A73A7D55-32A5-42F1-AE9B-5620AC540FB6}":
                        List<Item> sectionRowItem = new List<Item>();
                        sectionRowItem.Add(childItem);
                        rptModule.DataSource = sectionRowItem;
                        rptModule.HeaderTemplate = rptSectionRow.HeaderTemplate;
                        rptModule.ItemTemplate = rptSectionRow.ItemTemplate;
                        rptModule.FooterTemplate = rptSectionRow.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptSectionRow_ItemDataBound);
                        break;
                    */

                    //rptStoryFullWidthImage
                    case "{E03A073F-F8C2-48DA-90DF-741DD7A69B95}":
                        List<Item> storyFullWidthImageItem = new List<Item>();
                        storyFullWidthImageItem.Add(childItem);
                        rptModule.DataSource = storyFullWidthImageItem;
                        rptModule.HeaderTemplate = rptStoryFullWidthImage.HeaderTemplate;
                        rptModule.ItemTemplate = rptStoryFullWidthImage.ItemTemplate;
                        rptModule.FooterTemplate = rptStoryFullWidthImage.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptStoryFullWidthImage_ItemDataBound);
                        break;

                    //rptStorySplitImage
                    case "{3954627A-01A2-4D82-BEB9-3DB27F1DF2D1}":
                        List<Item> storySplitImageItem = new List<Item>();
                        storySplitImageItem.Add(childItem);
                        rptModule.DataSource = storySplitImageItem;
                        rptModule.HeaderTemplate = rptStorySplitImage.HeaderTemplate;
                        rptModule.ItemTemplate = rptStorySplitImage.ItemTemplate;
                        rptModule.FooterTemplate = rptStorySplitImage.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptStorySplitImage_ItemDataBound);
                        break;
                    //rptBlueBarAbout
                    case "{F2737D1D-9943-4FA7-86D0-C3B78067C413}":
                        List<Item> blueBarAboutItem = new List<Item>();
                        blueBarAboutItem.Add(childItem);
                        rptModule.DataSource = blueBarAboutItem;
                        rptModule.HeaderTemplate = rptBlueBarAbout.HeaderTemplate;
                        rptModule.ItemTemplate = rptBlueBarAbout.ItemTemplate;
                        rptModule.FooterTemplate = rptBlueBarAbout.FooterTemplate;
                        rptModule.ItemDataBound += new RepeaterItemEventHandler(rptBlueBarAbout_ItemDataBound);
                        break;  

                }
                phModules.Controls.Add(rptModule);
                rptModule.DataBind();
            }
            catch (Exception ex)
            {
                bool exHandled = handleException(ex);
            }

            return success;
        }
    }
}