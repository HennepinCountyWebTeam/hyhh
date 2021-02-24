<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="hyhhAllStories.ascx.cs" Inherits="Hennepin.SCWeb.HYHH.layouts.HYHH.hyhhAllStories" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>


<div class="hyhh-stories-container cf">
    <!-- Stories Repeater-->
    <asp:Repeater ID="rptStoryCards" runat="server" OnItemDataBound="rptStoryCards_ItemDataBound">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <div class="hyhh-story">

                <asp:HyperLink ID="storyLink" runat="server">
                    <!--<h1 class="hyhh-story-callout-heading"></h1> Featured Story-->
                    <asp:Literal ID="litFeatured" runat="server" Text=""></asp:Literal>
                    <asp:Literal ID="litComingNext" runat="server" Text=""></asp:Literal>
                    <sc:Image ID="fldRollupImage" runat="server" Field="Rollup Image" CssClass="" />
                    <!-- image tag <img src="images/feature-story-thumb.jpg" alt="{Alt Text Here}" data-pin-no-hover="true"> -->
                    <div class="hyhh-specific-story-info">
                        <h2>
                            <sc:Text ID="fldTitle" runat="server" Field="Title" />
                        </h2>
                        <p>
                            <sc:Text ID="fldRollupSummary" runat="server" Field="Rollup Summary" />
                        </p>
                        <asp:Literal ID="litReadStory" runat="server">
                            <span class="hyhh-read-story">Read Story
                            <img src="/hyhh-assets/images/read-story-arrow-blue.png" alt="Right pointing arrow" /></span>
                        </asp:Literal>
                    </div>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    <!-- end stories repeater-->
</div>
