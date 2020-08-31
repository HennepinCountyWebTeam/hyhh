using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using Sitecore.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using Sitecore.Data.Fields;

namespace Hennepin.SCWeb.HYHH.layouts.HYHH
{
    using System;

    public partial class hyhhMetadata : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            try
            {
                Item currentItem = Sitecore.Context.Item;

                string strSchemaDescription = string.Empty;
                string strDescription = string.Empty;
                string strSchemaTitle = string.Empty;
                string strTitle = string.Empty;
                string strKeywords = string.Empty;
                string strSchemaImage = string.Empty;
                string strImage = string.Empty;
                string strSchemaURL = string.Empty;
                string strURL = string.Empty;
                string strSummary = string.Empty;
                string strType = string.Empty;
                string strSiteName = string.Empty;

                //Set default Titles and Images for fallbacks
                strTitle = string.Format("<meta property=\"og:title\" content=\"{0}\" />", "Healthy You, Healthy Hennepin");
                strSchemaTitle = string.Format("<meta itemprop=\"name\" content=\"{0}\" />", "Healthy You, Healthy Hennepin");

                strImage = string.Format("<meta property=\"og:image\" content=\"{0}\" />", "/hyhh-assets/images/hyhh-logo.png");
                strSchemaImage = string.Format("<meta itemprop=\"image\" content=\"{0}\" />", "/hyhh-assets/images/hyhh-logo.png"); 

                if (currentItem.Fields["Description"].Value != "")
                {
                    string result = Regex.Replace(currentItem.Fields["Description"].Value, @"<(.|\n)*?>", string.Empty);

                    strDescription = string.Format("<meta name=\"description\" content=\"{0}\" />", result);
                    strSchemaDescription = string.Format("<meta itemprop=\"description\" content=\"{0}\" />", result);
                }

                if (currentItem.Fields["Keywords"].Value != "")
                {
                    strKeywords = string.Format("<meta name=\"keywords\" content=\"{0}\" />", currentItem.Fields["Keywords"].Value);
                }

                if (currentItem.Fields["Rollup Image"].Value != "")
                {
                   
                    Sitecore.Data.Fields.ImageField imgField = ((Sitecore.Data.Fields.ImageField)currentItem.Fields["Rollup Image"]);
                    string imgURL = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);

                    strImage = string.Format("<meta property=\"og:image\" content=\"{0}\" />", imgURL);
                    strSchemaImage = string.Format("<meta itemprop=\"image\" content=\"{0}\" />", imgURL);   
                }

                if (currentItem.Fields["Title"].Value != "")
                {
                    string result = Regex.Replace(currentItem.Fields["Title"].Value, @"<(.|\n)*?>", string.Empty);

                    strTitle = string.Format("<meta property=\"og:title\" content=\"{0}\" />", result);
                    strSchemaTitle = string.Format("<meta itemprop=\"name\" content=\"{0}\" />", result);
                }

                if (currentItem.Fields["Title"].Value != "")
                {
                    strURL = string.Format("<meta property=\"og:url\" content=\"{0}\" />", Sitecore.Links.LinkManager.GetItemUrl(currentItem));
                    strSchemaURL = string.Format("<meta itemprop=\"url\" content=\"{0}\" />", Sitecore.Links.LinkManager.GetItemUrl(currentItem));
                    strType = string.Format("<meta property=\"og:type\" content=\"website\" />");
                    strSiteName = string.Format("<meta property=\"og:site_name\" content=\"Healthy You Healthy Hennepin\" />");
                }

                if (currentItem.Fields["Rollup Summary"].Value != "")
                {
                    string result = Regex.Replace(currentItem.Fields["Rollup Summary"].Value, @"<(.|\n)*?>", string.Empty);
                    strSummary = string.Format("<meta property=\"og:description\" content=\"{0}\" />", result);
                }

                //set descriptions
                litDescription.Text = strDescription;
                litSchemaDescription.Text = strSchemaDescription;
                litOGDescription.Text = strSummary;

                //set URLs
                litSchemaURL.Text = strSchemaURL;
                //litOGURL.Text = strURL;

                //set Keywords
                litKeywords.Text = strKeywords;

                //set Titles
                litSchemaName.Text = strSchemaTitle;
                litOGTitle.Text = strTitle;

                //set Type
                litOGType.Text = strType;

                //set site name
                litOGSiteName.Text = strSiteName;

                //set images
                litOGImage.Text = strImage;
                litSchemaImage.Text = strSchemaImage;
                
            }

            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("error metadata hyhhMetadata", ex, this);
            }





        }
    }
}