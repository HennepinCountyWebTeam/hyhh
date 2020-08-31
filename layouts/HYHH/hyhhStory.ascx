<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="hyhhStory.ascx.cs" Inherits="Hennepin.SCWeb.HYHH.layouts.HYHH.hyhhStory" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Repeater ID="rptModules" runat="server" OnItemDataBound="rptModules_ItemDataBound">
    <HeaderTemplate>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:PlaceHolder ID="phSections" runat="server"></asp:PlaceHolder>

    </ItemTemplate>
    <FooterTemplate>
    </FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptStory" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>
    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptStoryHero" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>

        <!--<div class="hyhh-full-story-view">-->
        <div class="hyhh-full-story-hero wrap-view">
            <sc:Image ID="fldHeroImage" runat="server" Field="Hero Image" CssClass="" />
        </div>


    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptStoryIntro" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>

        <div class="hyhh-full-story-intro wrap-view">
            <h2>
                <sc:Text ID="fldTitle" runat="server" Field="Title" />
            </h2>
            <h3>
                <!--<sc:Date ID="fldDate" runat="server" Field="Date" Format="MMMM yyyy" />-->
                <asp:Literal ID="litDate" runat="server"></asp:Literal>
            </h3>
            <p>
                <sc:Text ID="fldDescription" runat="server" Field="Description" />
            </p>
        </div>


    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>


<asp:Repeater ID="rptStoryQuote" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>

        <div class="hyhh-full-story-quote unwrapped">
           
                
                <asp:Literal ID="litQuote" runat="server" Text=""></asp:Literal>
                    <!--<sc:Text ID="fldQuote" runat="server" Field="Quote" />-->
                
                <asp:Literal ID="litCitation" runat="server" Text=""></asp:Literal>
                    <!--<sc:Text ID="fldCitation" runat="server" Field="Citation" />-->
                
            
        </div>


    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptSectionContainer" runat="server" OnItemDataBound="rptSectionContainer_ItemDataBound">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>

        <div class="hyhh-story-section unwrapped">

            <asp:Repeater ID="rptSectionRow" runat="server" OnItemDataBound="rptSectionRow_ItemDataBound">
                <HeaderTemplate></HeaderTemplate>
                <ItemTemplate>

                    <div class="hyhh-story-section-row cf">
                        <div class="hyhh-story-fact">
                            <sc:Text ID="fldFact" runat="server" Field="Fact" />
                        </div>
                        <div class="hyhh-story-section-copy">
                            <p>
                                <sc:Text ID="fldCopy" runat="server" Field="Copy" />
                            </p>
                        </div>
                        <div class="hyhh-story-info">
                            <sc:Image ID="fldInfoImage" runat="server" Field="Info Image" CssClass="" />
                            <p>
                                <sc:Text ID="fldInfoContent" runat="server" Field="Info Content" />
                            </p>
                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>

        </div>


    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptStoryFullWidthImage" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>

        <div class="hyhh-image-row">
            <sc:Image ID="fldImage" runat="server" Field="Image" CssClass="" data-pin-no-hover="true" />
        </div>

    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptStorySplitImage" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>

        <div class="hyhh-split-image-row hyhh-split-image-share cf">
            <div class="hyhh-split-pin-container">
                <sc:Image ID="fldImageLeft" runat="server" Field="Image Left" CssClass="" />
            </div>
            <div class="hyhh-split-pin-container">
                <sc:Image ID="fldImageRight" runat="server" Field="Image Right" CssClass="" />
            </div>
        </div>


    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptBlueBarAbout" runat="server" OnItemDataBound="rptBlueBarAbout_ItemDataBound">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>

        <div class="hyhh-blue-bar about">
            <sc:Text ID="fldBarContent" runat="server" Field="Text Content" />
        </div>

    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
</asp:Repeater>


<div class="hyhh-story-social-share">
      <h2>Share this story</h2>
      <ul class="hyhh-social-share-links"><!--
      --><!--<li><a href="https://www.facebook.com/sharer/sharer.php?u=" target="_blank"><img src="/hyhh-assets/images/icon-facebook.png" alt="Share on Facebook" target="_blank" title="Share on Facebook"></a></li>-->
          <li><asp:Literal ID="fbLink" runat="server" Text=""></asp:Literal></li><!--
      --><li><asp:Literal ID="twLink" runat="server" Text=""></asp:Literal></li><!--
      --></ul>


    

</div>

