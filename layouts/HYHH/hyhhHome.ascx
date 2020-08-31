<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="hyhhHome.ascx.cs" Inherits="Hennepin.SCWeb.HYHH.layouts.HYHH.hyhhHome" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>




<!-- Stories Repeater-->
<asp:Repeater ID="rptStoryCards" runat="server" OnItemDataBound="rptStoryCards_ItemDataBound">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>
        <div class="hyhh-story-teaser">
            <asp:HyperLink ID="storyLink" runat="server">

                <figure>
                    <sc:Image ID="fldHomeImage" runat="server" Field="Home Image" CssClass="desktopImage" />
                    <sc:Image ID="fldRollupImage" runat="server" Field="Home Mobile Image" CssClass="mobileImage" />
                    <figcaption>
                        <h2>
                            <sc:Text ID="fldTitle" runat="server" Field="Title" />
                        </h2>
                        <p>
                            <sc:Text ID="fldRollupSummary" runat="server" Field="Rollup Summary" />
                        </p>
                        <span class="hyhh-read-more">Read More</span>
                    </figcaption>
                </figure>
            </asp:HyperLink>
        </div>

         <asp:Literal ID="litBlueBarContent" runat="server" Text=""></asp:Literal>
    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>
<!-- end stories repeater-->

 


<div class="hyhh-upcoming-story-feature">
    <h2 class="close">Coming Next</h2>
    <div class="hyhh-upcoming-body-container cf">
        <!--<img src="/hyhh-assets/images/upcoming-thumbnail.jpg" alt="Coming Next">-->
        <div class="hyhh-upcoming-body">
        <sc:Image ID="fldImage" runat="server" Field="Image" CssClass="" />
        <div class="hyhh-upcoming-story-info">
            <h3><sc:Text ID="fldTitle" runat="server" Field="Title" /></h3>
            <p><sc:Text ID="fldCopyText" runat="server" Field="Copy Text" /></p>
            <!--<h3>Ride along with a local EMT</h3>
            <p>Want our stories in your inbox? Sign up for our newsletter:</p>-->
            
            <!-- button link, width 250px, padding-top: 6px, border-radius: 0;-->
               
            <!-- <asp:Literal ID="litComingNextLink" runat="server" Text=""></asp:Literal> -->

            <!--
            <form action="https://public.govdelivery.com/accounts/MNHENNE/subscriber/new?topic_id=MNHENNE_547">
              <label for="email">Email</label>
              <input id="email" type="email" placeholder="Email" class="hyhh-newsletter-field">
              <button class="hyhh-newsletter-submit">Go</button>
            </form>
            -->
        </div>
            </div>
        <div class="hyhh-subscribe-form">
            <form accept-charset="UTF-8" action="https://public.govdelivery.com/accounts/MNHENNE/subscribers/qualify" id="GD-snippet-form" method="post" target="_blank"><input name="utf8" type="hidden" value="✓" /><input name="authenticity_token" type="hidden" value="Zj1KQIqR6etM/bKWpaHTfgbE+XLPrgdSN63rYUy9JqA=" />
                <input id="topic_id" name="topic_id" type="hidden" value="MNHENNE_547" />
                <label for="email">Email</label>
                <input class="hyhh-newsletter-field" id="email" name="email" type="email" placeholder="Email address" />
                <button id="hyhh-newsletter-submit">Subscribe</button>
            </form>
            <div id="hyhh-subscribe-success" style="display:none;">
                THANK YOU! You have successfully signed up and will start receiving updates.
            </div>
            <div id="hyhh-subscribe-invalid-email" style="display:none;">
                Please enter a valid email address.
            </div>
        </div>
    </div>
</div>


<div class="hyhh-story-social-share">
      <h2>Share This</h2>
      <ul class="hyhh-social-share-links"><!--
      --><!--<li><a href="https://www.facebook.com/sharer/sharer.php?u=" target="_blank"><img src="/hyhh-assets/images/icon-facebook.png" alt="Share on Facebook" target="_blank" title="Share on Facebook"></a></li>-->
          <li><asp:Literal ID="fbLink" runat="server" Text=""></asp:Literal></li><!--
      --><li><asp:Literal ID="twLink" runat="server" Text=""></asp:Literal></li><!--
      --></ul>
</div>