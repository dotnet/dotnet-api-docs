' NclMailSync

Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

Public Class Mail

    ' <snippet2>
    Public Shared Sub CreateTestMessage2(ByVal server As String)
        Dim [to] As String = "jane@contoso.com"
        Dim from As String = "ben@contoso.com"
        Dim message As MailMessage = New MailMessage(from, [to])
        message.Subject = "Using the new SMTP client."
        message.Body = "Using this new feature, you can send an email message from an application very easily."
        Dim client As SmtpClient = New SmtpClient(server)
        ' Credentials are necessary if the server requires the client
        ' to authenticate before it will send email on the client's behalf.
        client.UseDefaultCredentials = True

        Try
            client.Send(message)
        Catch ex As Exception
            Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString())
        End Try
    End Sub
    ' </snippet2>

    ' <snippet3>
    Public Shared Sub CreateTimeoutTestMessage(ByVal server As String)
        Dim [to] As String = "jane@contoso.com"
        Dim from As String = "ben@contoso.com"
        Dim subject As String = "Using the new SMTP client."
        Dim body As String = "Using this new feature, you can send an email message from an application very easily."
        Dim message As MailMessage = New MailMessage(from, [to], subject, body)
        Dim client As SmtpClient = New SmtpClient(server)
        Console.WriteLine("Changing time out from {0} to 100.", client.Timeout)
        client.Timeout = 100
        ' Credentials are necessary if the server requires the client
        ' to authenticate before it will send email on the client's behalf.
        client.Credentials = CredentialCache.DefaultNetworkCredentials
        client.Send(message)
    End Sub
    ' </snippet3>

    ' <snippet4>
    Public Shared Sub CreateTestMessage3()
        Dim [to] As MailAddress = New MailAddress("jane@contoso.com")
        Dim from As MailAddress = New MailAddress("ben@contoso.com")
        Dim message As MailMessage = New MailMessage(from, [to])
        message.Subject = "Using the new SMTP client."
        message.Body = "Using this new feature, you can send an email message from an application very easily."
        'Use the application or machine configuration to get the
        ' host, port, And credentials.
        Dim client As SmtpClient = New SmtpClient()
        Console.WriteLine("Sending an email message to {0} at {1} by using the SMTP host={2}.", [to].User, [to].Host, client.Host)
        client.Send(message)
    End Sub
    ' </snippet4>

    ' <snippet5>
    Public Shared Sub CreateMessageWithMultipleViews(ByVal server As String, ByVal recipients As String)
        ' Create a message and set up the recipients.
        Dim message As MailMessage = New MailMessage(
            "jane@contoso.com",
            recipients,
            "This email message has multiple views.",
            "This is some plain text.")

        ' Construct the alternate body as HTML.
        Dim body As String = "<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">"
        body += "<HTML><HEAD><META http-equiv=Content-Type content=""text/html; charset=iso-8859-1"">"
        body += "</HEAD><BODY><DIV><FONT face=Arial color=#ff0000 size=2>this is some HTML text"
        body += "</FONT></DIV></BODY></HTML>"

        Dim mimeType As ContentType = New System.Net.Mime.ContentType("text/html")

        ' Add the alternate body to the message.
        Dim alternate As AlternateView = AlternateView.CreateAlternateViewFromString(body, mimeType)
        message.AlternateViews.Add(alternate)

        ' Send the message.
        Dim client As SmtpClient = New SmtpClient(server)
        client.Credentials = CredentialCache.DefaultNetworkCredentials

        Try
            client.Send(message)
        Catch ex As Exception
            Console.WriteLine("Exception caught in CreateMessageWithMultipleViews(): {0}", ex.ToString())
        End Try

        ' Display the values in the ContentType for the attachment.
        Dim c As ContentType = alternate.ContentType
        Console.WriteLine("Content type")
        Console.WriteLine(c.ToString())
        Console.WriteLine("Boundary {0}", c.Boundary)
        Console.WriteLine("CharSet {0}", c.CharSet)
        Console.WriteLine("MediaType {0}", c.MediaType)
        Console.WriteLine("Name {0}", c.Name)
        Console.WriteLine("Parameters: {0}", c.Parameters.Count)

        For Each d As DictionaryEntry In c.Parameters
            Console.WriteLine("{0} = {1}", d.Key, d.Value)
        Next

        Console.WriteLine()
        alternate.Dispose()
    End Sub
    ' </snippet5>

    ' <snippet6>
    Public Shared Sub CreateMessageWithAttachment(ByVal server As String)
        ' Specify the file to be attached And sent.
        ' This example assumes that a file named Data.xls exists in the
        ' current working directory.
        Dim file As String = "data.xls"
        ' Create a message and set up the recipients.
        Dim message As MailMessage = New MailMessage(
            "jane@contoso.com",
            "ben@contoso.com",
            "Quarterly data report.",
            "See the attached spreadsheet.")

        ' Create  the file attachment for this email message.
        Dim data As Attachment = New Attachment(file, MediaTypeNames.Application.Octet)
        ' Add time stamp information for the file.
        Dim disposition As ContentDisposition = data.ContentDisposition
        disposition.CreationDate = System.IO.File.GetCreationTime(file)
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(file)
        disposition.ReadDate = System.IO.File.GetLastAccessTime(file)
        ' Add the file attachment to this email message.
        message.Attachments.Add(data)

        ' Send the message
        Dim client As SmtpClient = New SmtpClient(server)
        ' Add credentials if the SMTP server requires them.
        client.Credentials = CredentialCache.DefaultNetworkCredentials

        Try
            client.Send(message)
        Catch ex As Exception
            Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", ex.ToString())
        End Try

        ' Display the values in the ContentDisposition for the attachment.
        Dim cd As ContentDisposition = data.ContentDisposition
        Console.WriteLine("Content disposition")
        Console.WriteLine(cd.ToString())
        Console.WriteLine("File {0}", cd.FileName)
        Console.WriteLine("Size {0}", cd.Size)
        Console.WriteLine("Creation {0}", cd.CreationDate)
        Console.WriteLine("Modification {0}", cd.ModificationDate)
        Console.WriteLine("Read {0}", cd.ReadDate)
        Console.WriteLine("Inline {0}", cd.Inline)
        Console.WriteLine("Parameters: {0}", cd.Parameters.Count)

        For Each d As DictionaryEntry In cd.Parameters
            Console.WriteLine("{0} = {1}", d.Key, d.Value)
        Next

        data.Dispose()
    End Sub
    ' </snippet6>

    ' <snippet7>
    Public Shared Sub CreateTestMessage4(ByVal server As String)
        Dim from As MailAddress = New MailAddress("ben@contoso.com")
        Dim [to] As MailAddress = New MailAddress("Jane@contoso.com")
        Dim message As MailMessage = New MailMessage(from, [to])
        message.Subject = "Using the SmtpClient class."
        message.Body = "Using this feature, you can send an email message from an application very easily."
        Dim client As SmtpClient = New SmtpClient(server)
        Console.WriteLine("Sending an email message to {0} by using SMTP host {1} port {2}.", [to].ToString(), client.Host, client.Port)

        Try
            client.Send(message)
        Catch ex As Exception
            Console.WriteLine("Exception caught in CreateTestMessage4(): {0}", ex.ToString())
        End Try
    End Sub
    ' </snippet7>

    ' <snippet9>
    Public Shared Sub CreateBccTestMessage(ByVal server As String)
        Dim from As MailAddress = New MailAddress("ben@contoso.com", "Ben Miller")
        Dim [to] As MailAddress = New MailAddress("jane@contoso.com", "Jane Clayton")
        Dim message As MailMessage = New MailMessage(from, [to])
        message.Subject = "Using the SmtpClient class."
        message.Body = "Using this feature, you can send an email message from an application very easily."
        Dim bcc As MailAddress = New MailAddress("manager1@contoso.com")
        message.Bcc.Add(bcc)
        Dim client As SmtpClient = New SmtpClient(server)
        client.Credentials = CredentialCache.DefaultNetworkCredentials
        Console.WriteLine("Sending an email message to {0} and {1}.", [to].DisplayName, message.Bcc.ToString())

        Try
            client.Send(message)
        Catch ex As Exception
            Console.WriteLine("Exception caught in CreateBccTestMessage(): {0}", ex.ToString())
        End Try
    End Sub
    ' </snippet9>

    ' <snippet10>
    Public Shared Sub CreateCopyMessage(ByVal server As String)
        Dim from As MailAddress = New MailAddress("ben@contoso.com", "Ben Miller")
        Dim [to] As MailAddress = New MailAddress("jane@contoso.com", "Jane Clayton")
        Dim message As MailMessage = New MailMessage(from, [to])
        message.Subject = "Using the SmtpClient class."
        message.Body = "Using this feature, you can send an email message from an application very easily."
        ' Add a carbon copy recipient.
        Dim copy As MailAddress = New MailAddress("Notification_List@contoso.com")
        message.CC.Add(copy)
        Dim client As SmtpClient = New SmtpClient(server)
        ' Include credentials if the server requires them.
        client.Credentials = CredentialCache.DefaultNetworkCredentials
        Console.WriteLine("Sending an email message to {0} by using the SMTP host {1}.", [to].Address, client.Host)

        Try
            client.Send(message)
        Catch ex As Exception
            Console.WriteLine("Exception caught in CreateCopyMessage(): {0}", ex.ToString())
        End Try
    End Sub
    ' </snippet10>

    ' <snippet24>
    Public Shared Sub CreateMessageWithAttachment4(ByVal server As String, ByVal [to] As String)
        ' Specify the file to be attached And sent.
        ' This example uses a file on a UNC share.
        Dim file As String = "\\share3\c$\reports\data.xls"
        Dim message As MailMessage = New MailMessage("ReportMailer@contoso.com", [to], "Quarterly data report", "See the attached spreadsheet.")
        ' Create  the file attachment for this email message.
        Dim data As Attachment = New Attachment("qtr3.xls", MediaTypeNames.Application.Octet)
        ' Add time stamp information for the file.
        Dim disposition As ContentDisposition = data.ContentDisposition
        disposition.CreationDate = System.IO.File.GetCreationTime(file)
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(file)
        disposition.ReadDate = System.IO.File.GetLastAccessTime(file)
        disposition.DispositionType = DispositionTypeNames.Attachment
        ' Add the file attachment to this email message.
        message.Attachments.Add(data)
        'Send the message.
        Dim client As SmtpClient = New SmtpClient(server)
        ' Add credentials if the SMTP server requires them.
        client.Credentials = CType(CredentialCache.DefaultNetworkCredentials, ICredentialsByHost)
        client.Send(message)
        ' Display the message headers.
        Dim keys As String() = message.Headers.AllKeys
        Console.WriteLine("Headers")

        For Each s As String In keys
            Console.WriteLine("{0}:", s)
            Console.WriteLine("    {0}", message.Headers(s))
        Next

        data.Dispose()
    End Sub
    ' </snippet24>

End Class
