// <snippet60>
using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

public class ServerSink : BaseChannelSinkWithProperties, IServerChannelSink
{
    // This class inherits from BaseChannelSinkWithProperties
    // to get an implementation of IChannelSinkBase.

// <snippet61>
    // The next sink in the chain.
    private IServerChannelSink nextSink;
// </snippet61>

// <snippet62>
    public IServerChannelSink NextChannelSink
    {
        get
        {
            return(nextSink);
        }
    }
// </snippet62>

// <snippet63>
    public Stream GetResponseStream (IServerResponseChannelSinkStack sinkStack,
                                     Object state,
                                     IMessage message,
                                     ITransportHeaders responseHeaders)
    {
        return(null);
    }
// </snippet63>

// <snippet64>
    public ServerProcessing ProcessMessage (IServerChannelSinkStack sinkStack,
                                            IMessage requestMessage,
                                            ITransportHeaders requestHeaders,
                                            Stream requestStream,
                                            out IMessage responseMessage,
                                            out ITransportHeaders responseHeaders,
                                            out Stream responseStream)
    {

        // Hand off to the next sink for processing.
        sinkStack.Push(this, null);
        ServerProcessing status = nextSink.ProcessMessage(
          sinkStack, requestMessage, requestHeaders, requestStream,
          out responseMessage, out responseHeaders, out responseStream
        );

        // Print the response message properties.
        Console.WriteLine("---- Message from the server ----");
        IDictionary dictionary = responseMessage.Properties;
        foreach (Object key in dictionary.Keys)
        {
            Console.WriteLine("{0} = {1}", key, dictionary[key]);
        }
        Console.WriteLine("---------------------------------");

        return(status);
    }
// </snippet64>

// <snippet65>
    public void AsyncProcessResponse (IServerResponseChannelSinkStack sinkStack,
                                      Object state,
                                      IMessage message,
                                      ITransportHeaders responseHeaders,
                                      Stream responseStream)
    {
        throw new NotImplementedException();
    }
// </snippet65>

    // Constructor
    public ServerSink (IServerChannelSink sink) {
      if (sink == null) throw new ArgumentNullException("sink");
      nextSink = sink;
    }
}
// </snippet60>

// <snippet70>
public class ServerSinkProvider : IServerChannelSinkProvider
{

// <snippet71>
    // The next provider in the chain.
    private IServerChannelSinkProvider nextProvider;
// </snippet71>

// <snippet72>
    public IServerChannelSinkProvider Next
    {
        get
        {
            return(nextProvider);
        }
        set
        {
            nextProvider = value;
        }
    }
// </snippet72>

// <snippet73>
    public IServerChannelSink CreateSink (IChannelReceiver channel)
    {
        Console.WriteLine("Creating ServerSink");

        // Create the next sink in the chain.
        IServerChannelSink nextSink = nextProvider.CreateSink(channel);

        // Hook our sink up to it.
        return( new ServerSink(nextSink) );
    }
// </snippet73>

// <snippet74>
    public void GetChannelData (IChannelDataStore channelData) {}
// </snippet74>

    // This constructor is required in order to use the provider in file-based configuration.
    // It need not do anything unless you want to use the information in the parameters.
    public ServerSinkProvider (IDictionary properties, ICollection providerData) {}
}
// </snippet70>
