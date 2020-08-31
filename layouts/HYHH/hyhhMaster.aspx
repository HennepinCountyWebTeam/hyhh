<%@ Page language="c#" Codepage="65001" AutoEventWireup="true" Inherits="Hennepin.SCWeb.HYHH.layouts.HYHH.hyhhMaster" CodeBehind="hyhhMaster.aspx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html>
<html class="no-js" lang="en">
<head>
    <link rel="canonical" href="#" />
    <meta charset="utf-8" />
    <title>Healthy You Healthy Hennepin</title>
    <link rel="stylesheet" href="/hyhh-assets/css/styles.css?v=2" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <sc:Placeholder ID="phMetadata" runat="server" Key="phMetadata"></sc:Placeholder>

    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="/hyhh-assets/images/favicon.ico" />
    <!-- Start Apple Specific -->
    <!-- 
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <link rel="apple-touch-icon" sizes="60x60" href="touch-icon-iphone.png">
    <link rel="apple-touch-icon" sizes="76x76" href="touch-icon-ipad.png">
    <link rel="apple-touch-icon" sizes="120x120" href="touch-icon-iphone-retina.png">
    <link rel="apple-touch-icon" sizes="152x152" href="touch-icon-ipad-retina.png">
    -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js"></script>
   </head>
<body>
    <h1 class="hyhh-title">Healthy You Healthy Hennepin</h1>
    <header class="hyhh-main-header">
      <nav class="hyhh-navigation-container cf">
        <a href="/" class="hyhh-logo" title="Healthy You Healthy Hennepin">
          <img src="/hyhh-assets/images/hyhh-logo.png" alt="Healthy You Healthy Hennepin" />
        </a>
        <ul class="hyhh-primary-navigation">
            <li><a href="/" title="Home">Home</a></li>
            <li><a href="/about" title="About">About</a></li>
            <li><a href="/stories" title="All Stories"><span>All</span> Stories</a></li>
        </ul>
      </nav>
    </header>

    <!-- body content here -->
    <sc:placeholder ID="phContent" runat="server" key="phContent"></sc:placeholder>



    <div class="hyhh-story-questions">
      <a href="mailto:healthyhennepin@hennepin.us"><h3>QUESTIONS OR COMMENTS? healthyhennepin@hennepin.us</h3></a>
    </div>


    <footer class="hyhh-footer">
       
      <a href="//hennepin.us" target="_blank" title="Visit hennepin.us">
        <img src="/hyhh-assets/images/hc-logo.png" alt="Hennepin County">
      </a>
      <small>&copy;2015 Hennepin County</small>
    </footer>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="/hyhh-assets/js/jquery.matchHeight-min.js"></script>
    <script src="/hyhh-assets/js/app.js"></script>
    <script type="text/javascript" async defer data-pin-color="white" data-pin-height="28" src="//assets.pinterest.com/js/pinit.js" data-pin-hover="true"></script>
    
    <script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-2606969-32', 'auto');
  ga('send', 'pageview');

</script>

</body>
</html>

