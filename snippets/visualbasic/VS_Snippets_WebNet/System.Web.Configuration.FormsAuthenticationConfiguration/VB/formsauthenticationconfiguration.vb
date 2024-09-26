Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Class UsingFormsAuthentication

    Public Shared Sub Main()

        ' <Snippet1>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration =
        WebConfigurationManager.OpenWebConfiguration(
        "/aspnetTest")

        ' Get the external Authentication section.
        Dim authenticationSection _
        As AuthenticationSection =
        CType(configuration.GetSection(
        "system.web/authentication"), AuthenticationSection)

        ' Get the external Forms section .
        Dim formsAuthentication _
        As FormsAuthenticationConfiguration =
        authenticationSection.Forms
        '</Snippet1>

        ' <Snippet2>
        ' Create a new FormsAuthentication object.
        Dim newformsAuthentication _
        As New FormsAuthenticationConfiguration()
        ' </Snippet2>

        ' <Snippet3>
        ' Get the current LoginUrl.
        Dim currentLoginUrl As String =
        formsAuthentication.LoginUrl

        ' Set the LoginUrl. 
        formsAuthentication.LoginUrl = "newLoginUrl"
        ' </Snippet3>

        ' <Snippet4>
        ' Get current DefaultUrl.
        Dim currentDefaultUrl As String =
        formsAuthentication.DefaultUrl

        ' Set current DefaultUrl.
        formsAuthentication.DefaultUrl = "newDefaultUrl"
        ' </Snippet4>

        ' <Snippet5>
        ' Get current Cookieless.
        Dim currentCookieless _
        As System.Web.HttpCookieMode =
        formsAuthentication.Cookieless

        ' Set current Cookieless.
        formsAuthentication.Cookieless = HttpCookieMode.AutoDetect
        ' </Snippet5>

        ' <Snippet6>
        ' Get the current Domain.
        Dim currentDomain As String = formsAuthentication.Domain

        ' Set the current Domain
        formsAuthentication.Domain = "newDomain"
        ' </Snippet6>

        ' <Snippet7>
        ' Get the current SlidingExpiration.
        Dim currentSlidingExpiration As Boolean =
        formsAuthentication.SlidingExpiration

        ' Set the SlidingExpiration.
        formsAuthentication.SlidingExpiration = False
        ' </Snippet7>

        ' <Snippet8>
        ' Get the current EnableCrossAppRedirects.
        Dim currentEnableCrossAppRedirects As Boolean =
        formsAuthentication.EnableCrossAppRedirects

        ' Set the EnableCrossAppRedirects.
        formsAuthentication.EnableCrossAppRedirects = False
        ' </Snippet8>

        ' <Snippet9>
        ' Get the current Path.
        Dim currentPath As String = formsAuthentication.Path
        ' Set the Path property.
        formsAuthentication.Path = "newPath"
        ' </Snippet9>

        ' <Snippet10>
        ' Get the current Timeout.
        Dim currentTimeout As System.TimeSpan =
        formsAuthentication.Timeout

        ' Set the Timeout.
        formsAuthentication.Timeout =
        System.TimeSpan.FromMinutes(10)
        ' </Snippet10>

        ' <Snippet11>
        ' Get the current Protection.
        Dim currentProtection As FormsProtectionEnum =
        formsAuthentication.Protection

        ' Set the Protection property.
        formsAuthentication.Protection = FormsProtectionEnum.All
        ' </Snippet11>

        ' <Snippet12>
        ' Get the current RequireSSL.
        Dim currentRequireSSL As Boolean =
        formsAuthentication.RequireSSL

        ' Set the RequireSSL property value.
        formsAuthentication.RequireSSL = True
        ' </Snippet12>

        ' <Snippet13>
        ' Get the current Name property value.
        Dim currentName As String =
        formsAuthentication.Name
        ' Set the Name property value.
        formsAuthentication.Name = "newName"
        ' </Snippet13>

    End Sub
End Class

