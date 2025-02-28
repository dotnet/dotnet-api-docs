/**
 * File name: Begingetresponse.cs
 * This program shows how to use BeginGetResponse and EndGetResponse methods of the
 * HttpWebRequest class. It also shows how to create a customized timeout.
 * This is important in case od asynchronous request, because the NCL classes do
 * not provide any off-the-shelf asynchronous timeout.
 * It uses an asynchronous approach to get the response for the HTTP Web Request.
 * The RequestState class is defined to chekc the state of the request.
 * After a HttpWebRequest object is created, its BeginGetResponse method is used to start
 * the asynchronous response phase.
 * Finally, the EndGetResponse method is used to end the asynchronous response phase .*/
// <Snippet1>
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

public static class WebRequestAPMSample
{
    private const int BufferSize = 1024;

    private class RequestState
    {
        public StringBuilder ResponseBuilder { get; }
        public byte[] ReadBuffer { get; }
        public WebRequest Request { get; }
        public WebResponse Response { get; set; }
        public Stream ResponseStream { get; set; }
        public RequestState(WebRequest request)
        {
            ReadBuffer = new byte[BufferSize];
            ResponseBuilder = new StringBuilder();
            Request = request;
        }
        public void OnResponseBytesRead(int read) => ResponseBuilder.Append(Encoding.UTF8.GetString(ReadBuffer, 0, read));
    }

    public static ManualResetEvent allDone = new ManualResetEvent(false);
    

    public static void Main()
    {
        try
        {
            // Create a HttpWebrequest object to the desired URL.
            WebRequest httpWebRequest = WebRequest.Create("http://www.contoso.com");
            httpWebRequest.Timeout = 10_000; // Set 10sec timeout.

            // Create an instance of the RequestState and assign the previous myHttpWebRequest
            // object to its request field.
            RequestState requestState = new RequestState(httpWebRequest);

            // Start the asynchronous request.
            IAsyncResult result = httpWebRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), requestState);

            // The response came in the allowed time. The work processing will happen in the
            // callback function.
            allDone.WaitOne();

            // Release the HttpWebResponse resource.
            requestState.Response?.Close();
        }
        catch (WebException e)
        {
            Console.WriteLine("\nMain(): WebException raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
            Console.WriteLine("Press any key to continue..........");
            Console.Read();
        }
        catch (Exception e)
        {
            Console.WriteLine("\nMain Exception raised!");
            Console.WriteLine("Source :{0} ", e.Source);
            Console.WriteLine("Message :{0} ", e.Message);
            Console.WriteLine("Press any key to continue..........");
            Console.Read();
        }
    }

    private static void HandleSyncResponseReadCompletion(IAsyncResult asyncResult)
    {
        RequestState requestState = (RequestState)asyncResult.AsyncState;
        Stream responseStream = requestState.ResponseStream;

        bool readComplete = false;
        while (asyncResult.CompletedSynchronously && !readComplete)
        {
            int read = responseStream.EndRead(asyncResult);
            if (read > 0)
            {
                requestState.OnResponseBytesRead(read);
                asyncResult = responseStream.BeginRead(requestState.ReadBuffer, 0, BufferSize, new AsyncCallback(ReadCallBack), requestState);
            }
            else
            {
                readComplete = true;
                HandleReadCompletion(requestState);
            }
        }
    }

    private static void ResponseCallback(IAsyncResult asynchronousResult)
    {
        try
        {
            // State of request is asynchronous.
            RequestState requestState = (RequestState)asynchronousResult.AsyncState;
            WebRequest request = requestState.Request;
            requestState.Response = request.EndGetResponse(asynchronousResult);

            // Read the response into a Stream object.
            Stream responseStream = requestState.Response.GetResponseStream();
            requestState.ResponseStream = responseStream;

            // Begin the Reading of the contents of the HTML page and print it to the console.
            IAsyncResult asynchronousReadResult = responseStream.BeginRead(requestState.ReadBuffer, 0, BufferSize, new AsyncCallback(ReadCallBack), requestState);
            HandleSyncResponseReadCompletion(asynchronousReadResult);
        }
        catch (WebException e)
        {
            Console.WriteLine("\nRespCallback Exception raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
            allDone.Set();
        }   
    }

    // Print the webpage to the standard output, close the stream and signal completion.
    private static void HandleReadCompletion(RequestState requestState)
    {
        Console.WriteLine("\nThe contents of the Html page are : ");
        if (requestState.ResponseBuilder.Length > 1)
        {
            string stringContent;
            stringContent = requestState.ResponseBuilder.ToString();
            Console.WriteLine(stringContent);
        }
        Console.WriteLine("Press any key to continue..........");
        Console.ReadLine();

        requestState.ResponseStream.Close();
        allDone.Set();
    }

    private static void ReadCallBack(IAsyncResult asyncResult)
    {
        if (asyncResult.CompletedSynchronously)
        {
            // To avoid recursive synchronous calls into ReadCallBack,
            // synchronous completion is handled at the BeginRead call-site.
            return;
        }

        try
        {
            RequestState requestState = (RequestState)asyncResult.AsyncState;
            Stream responseStream = requestState.ResponseStream;
            int read = responseStream.EndRead(asyncResult);
            // Read the HTML page and then print it to the console.
            if (read > 0)
            {
                requestState.OnResponseBytesRead(read);
                IAsyncResult asynchronousResult = responseStream.BeginRead(requestState.ReadBuffer, 0, BufferSize, new AsyncCallback(ReadCallBack), requestState);
                HandleSyncResponseReadCompletion(asynchronousResult);
            }
            else
            {
                HandleReadCompletion(requestState);
            }
        }
        catch (WebException e)
        {
            Console.WriteLine("\nReadCallBack Exception raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
            allDone.Set();
        }
    }
}
// </Snippet1>
