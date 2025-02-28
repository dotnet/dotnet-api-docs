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

public class RequestState
{
    // This class stores the State of the request.
    const int BUFFER_SIZE = 1024;
    public StringBuilder ResponseBuilder;
    public byte[] ReadBuffer;
    public HttpWebRequest Request;
    public HttpWebResponse Response;
    public Stream ResponseStream;
    public RequestState()
    {
        ReadBuffer = new byte[BUFFER_SIZE];
        ResponseBuilder = new StringBuilder();
        Request = null;
        ResponseStream = null;
    }
    public void OnResponseBytesRead(int read) => ResponseBuilder.Append(Encoding.UTF8.GetString(ReadBuffer, 0, read));
}

class HttpWebRequest_BeginGetResponse
{
    public static ManualResetEvent allDone = new ManualResetEvent(false);
    const int BUFFER_SIZE = 1;
    const int DefaultTimeout = 2 * 60 * 1000; // 2 minutes timeout

    // Abort the request if the timer fires.
    private static void TimeoutCallback(object state, bool timedOut)
    {
        if (timedOut)
        {
            HttpWebRequest request = state as HttpWebRequest;
            if (request != null)
            {
                request.Abort();
            }
        }
    }

    static void Main()
    {

        try
        {
            // Create a HttpWebrequest object to the desired URL.
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");

            // Create an instance of the RequestState and assign the previous myHttpWebRequest
            // object to its request field.
            RequestState myRequestState = new RequestState();
            myRequestState.Request = httpWebRequest;

            // Start the asynchronous request.
            IAsyncResult result = httpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback), myRequestState);

            // this line implements the timeout, if there is a timeout, the callback fires and the request becomes aborted
            ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), httpWebRequest, DefaultTimeout, true);

            // The response came in the allowed time. The work processing will happen in the
            // callback function.
            allDone.WaitOne();

            // Release the HttpWebResponse resource.
            myRequestState.Response.Close();
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
    private static void RespCallback(IAsyncResult asynchronousResult)
    {
        try
        {
            // State of request is asynchronous.
            RequestState requestState = (RequestState)asynchronousResult.AsyncState;
            HttpWebRequest request = requestState.Request;
            requestState.Response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);

            // Read the response into a Stream object.
            Stream responseStream = requestState.Response.GetResponseStream();
            requestState.ResponseStream = responseStream;

            // Begin the Reading of the contents of the HTML page and print it to the console.
            IAsyncResult asynchronousReadResult = responseStream.BeginRead(requestState.ReadBuffer, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), requestState);
            while (asynchronousReadResult.CompletedSynchronously)
            {
                int read = responseStream.EndRead(asynchronousReadResult);
                // Read the HTML page and then print it to the console.
                if (read > 0)
                {
                    requestState.OnResponseBytesRead(read);
                    asynchronousReadResult = responseStream.BeginRead(requestState.ReadBuffer, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), requestState);
                }
                else
                {
                    OnReadComplete(requestState);
                }
            }

            return;
        }
        catch (WebException e)
        {
            Console.WriteLine("\nRespCallback Exception raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
        }
        allDone.Set();
    }

    private static void OnReadComplete(RequestState requestState)
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
                IAsyncResult asynchronousResult = responseStream.BeginRead(requestState.ReadBuffer, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), requestState);
                return;
            }
            else
            {
                OnReadComplete(requestState);
            }
        }
        catch (WebException e)
        {
            Console.WriteLine("\nReadCallBack Exception raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
        }
        allDone.Set();
    }
    // </Snippet1>
}
