<h1>ReCaptcha.NET</h1>
ASP.NET MVC library for easy access to Google ReCaptcha v2.0 verification service (<a href="https://www.google.com/recaptcha">https://www.google.com/recaptcha</a>).

[![Build status](https://ci.appveyor.com/api/projects/status/d96jglcys906l2ei?svg=true)](https://ci.appveyor.com/project/vbatrla/recaptcha-net)
[![Build Status](https://travis-ci.org/vbatrla/ReCaptcha.NET.svg?branch=master)](https://travis-ci.org/vbatrla/ReCaptcha.NET)
<h2>Get an API key</h2>
<p>To get started using ReCaptcha obtain API key from google <a href="https://www.google.com/recaptcha/admin#list">https://www.google.com/recaptcha/admin</a>.</p>
<h2>Installation</h2>
<h3>Nuget Package</h3>
<h4>ASP.NET MVC</h4>
<pre><code>PM&gt; Install-Package VB.ReCaptcha.MVC</code></pre>
<h4>ASP.NET Core MVC</h4>
<pre><code>PM&gt; Install-Package VB.ReCaptcha.Core.MVC</code></pre>
<h2>Quick Start</h2>
<p>After you create your ReCaptcha <a href="https://www.google.com/recaptcha/admin">https://google.com/recaptcha/admin</a></p>
<ul>
<li>
<p>Firstly, init it with your <i>Secret</i> and <i>SiteKey</i> in <b>GLOBAL</b>.asax file.</p>
<h4>ASP.NET MVC</h4>
<pre>
<code>
void Application_Start(object sender, EventArgs e)
{
  ReCaptchaConfiguration.Init("Secret", "SiteKey");
}
</code>
</pre>
<h4>ASP.NET Core MVC</h4>
<pre>
<code>
public Startup(IHostingEnvironment env)
{
  ReCaptchaConfiguration.Init("Secret", "SiteKey");
}
</code>
</pre>
<p>Note: This solution is better for webfarm implementation.</p>
</li>
<li>
<p>Decorate your post <b>ACTION</b> in controller with attribute and check if <i>ModelState</i> is valid.</p>
<pre>
<code>[ReCaptchaVerification]
public ActionResult SomeAction(SomeModel model)
{
  if(this.ModelState.IsValid){
    ...
  }
}</code></pre>
</li>
<li>
<p>In <b>VIEW</b> file render javascript and google handler element at somewhere of form.</p>
<pre>
<code>
@using(Html.BeginForm())
{
  ...
  @Html.ReCaptcha()
}
</code>
</pre>
<h4>ASP.NET Core MVC</h4>
<pre>
<code>
@using(Html.BeginForm())
{
  ...
  @Html.ReCaptcha()
}
</code>
</pre>
or by using Tag helpers feature
<pre>
<code>
&lt;ReCaptcha&gt;&lt;/ReCaptcha&gt;
</code>
And add code below to _ViewImports.cshtml
<code>
@using VB.ReCaptcha.Core.MVC
@addTagHelper *, VB.ReCaptcha.Core.MVC
</code>
</pre>
</li>
</ul>
<h2>Logging</h2>
<p>Create your own logger implementing interface <i>IReCaptchaLogger</i> and register in:</p>
<pre><code>ReCaptchaConfiguration.Instance.Logger = ...</code></pre>
<h2>Errors</h2>
<p>If verification from Google failed <i>ModelState</i> will contain new error under key <i>ReCaptcha</i>. Detailed error strings will be stored in <i>TempData</i> under key <i>ReCaptchaErrors</i>.
<p>That's all :-)</p>

# Roadmap
- ASP.NET Core version in active development
