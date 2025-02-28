// System.Net.HttpWebRequest.BeginGetResponse  System.Net.HttpWebRequest.EndGetResponse

/**
 * Snippet1,Snippet2,Snippet3 go together.
 * This program shows how to use BeginGetResponse and EndGetResponse methods of the
 * HttpWebRequest class.
 * It uses an asynchronous approach to get the response for the HTTP Web Request.
 * The RequestState class is defined to chekc the state of the request.
 * After a HttpWebRequest object is created, its BeginGetResponse method is used to start
 * the asynchronous response phase.
 * Finally, the EndGetResponse method is used to end the asynchronous response phase .*/
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

public class RequestState
{
    // This class stores the State of the request.
    const int BUFFER_SIZE = 1024;
    public StringBuilder RequestBuilder;
    public byte[] ReadBuffer;
    public WebRequest Request;
    public WebResponse Response;
    public Stream ResponseStream;
    public RequestState()
    {
        ReadBuffer = new byte[BUFFER_SIZE];
        RequestBuilder = new StringBuilder();
        Request = null;
        ResponseStream = null;
    }
}

class HttpWebRequest_BeginGetResponse
{
    public static ManualResetEvent allDone = new ManualResetEvent(false);
    const int BUFFER_SIZE = 1;

    static void Main()
    {
        // <Snippet1>
        // <Snippet2>
        try
        {

            // Create a HttpWebrequest object to the desired URL.
            WebRequest myHttpWebRequest1 = WebRequest.Create("http://www.contoso.com");

            // Create an instance of the RequestState and assign the previous myHttpWebRequest1
            // object to it's request field.
            RequestState myRequestState = new RequestState();
            myRequestState.Request = myHttpWebRequest1;

            // Start the asynchronous request.
            IAsyncResult result =
              (IAsyncResult)myHttpWebRequest1.BeginGetResponse(new AsyncCallback(RespCallback), myRequestState);

            allDone.WaitOne();

            // Release the HttpWebResponse resource.
            myRequestState.Response.Close();
        }
        catch (WebException e)
        {
            Console.WriteLine("\nException raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
            Console.WriteLine("Press any key to continue..........");
        }
        catch (Exception e)
        {
            Console.WriteLine("\nException raised!");
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
            RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
            HttpWebRequest myHttpWebRequest2 = myRequestState.Request;
            myRequestState.Response = (HttpWebResponse)myHttpWebRequest2.EndGetResponse(asynchronousResult);

            // Read the response into a Stream object.
            Stream responseStream = myRequestState.Response.GetResponseStream();
            myRequestState.ResponseStream = responseStream;

            // Begin the Reading of the contents of the HTML page and print it to the console.
            IAsyncResult asynchronousInputRead = responseStream.BeginRead(myRequestState.ReadBuffer, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
        }
        catch (WebException e)
        {
            Console.WriteLine("\nException raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
        }
    }
    private static void ReadCallBack(IAsyncResult asyncResult)
    {
        try
        {

            RequestState myRequestState = (RequestState)asyncResult.AsyncState;
            Stream responseStream = myRequestState.ResponseStream;
            int read = responseStream.EndRead(asyncResult);
            // Read the HTML page and then print it to the console.
            if (read > 0)
            {
                myRequestState.RequestBuilder.Append(Encoding.ASCII.GetString(myRequestState.ReadBuffer, 0, read));
                IAsyncResult asynchronousResult = responseStream.BeginRead(myRequestState.ReadBuffer, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
            }
            else
            {
                Console.WriteLine("\nThe contents of the Html page are : ");
                if (myRequestState.RequestBuilder.Length > 1)
                {
                    string stringContent;
                    stringContent = myRequestState.RequestBuilder.ToString();
                    Console.WriteLine(stringContent);
                }
                Console.WriteLine("Press any key to continue..........");
                Console.ReadLine();

                responseStream.Close();
                allDone.Set();
            }
        }
        catch (WebException e)
        {
            Console.WriteLine("\nException raised!");
            Console.WriteLine("\nMessage:{0}", e.Message);
            Console.WriteLine("\nStatus:{0}", e.Status);
        }
    }
    // </Snippet2>
    // </Snippet1>
}
