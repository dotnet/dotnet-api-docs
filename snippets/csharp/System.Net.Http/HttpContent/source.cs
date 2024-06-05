using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

class HttpContent_Example
{
// <Snippet1>
    public class MyContent : HttpContent
    {
        private readonly string _data;
        public MyContent(string data)
        {
            _data = data;
        }

        // Minimal implementation needed for an HTTP request content,
        // i.e. a content that will be sent via HttpClient, contains the 2 following methods.
        protected override bool TryComputeLength(out long length)
        {
            // This content doesn't support pre-computed length and
            // the request will NOT contain Content-Length header.
            length = 0;
            return false;
        }

        // SerializeToStream* methods are internally used by CopyTo* methods
        // which in turn are used to copy the content to the NetworkStream.
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            => stream.WriteAsync(Encoding.UTF8.GetBytes(_data)).AsTask();

        // Override SerializeToStreamAsync overload with CancellationToken
        // if the content serialization supports cancellation, otherwise the token will be dropped.
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
            => stream.WriteAsync(Encoding.UTF8.GetBytes(_data), cancellationToken).AsTask();

        // In rare cases when synchronous support is needed, e.g. synchronous CopyTo used by HttpClient.Send,
        // implement synchronous version of SerializeToStream.
        protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
            => stream.Write(Encoding.UTF8.GetBytes(_data));

        // CreateContentReadStream* methods, if implemented, will be used by ReadAsStream* methods
        // to get the underlying stream and avoid buffering.
        // These methods will not be used by HttpClient on a custom content.
        // They are for content receiving and HttpClient uses its own internal implementation for an HTTP response content.
        protected override Task<Stream> CreateContentReadStreamAsync()
            => Task.FromResult<Stream>(new MemoryStream(Encoding.UTF8.GetBytes(_data)));

        // Override CreateContentReadStreamAsync overload with CancellationToken
        // if the content serialization supports cancellation, otherwise the token will be dropped.
        protected override Task<Stream> CreateContentReadStreamAsync(CancellationToken cancellationToken)
            => Task.FromResult<Stream>(new MemoryStream(Encoding.UTF8.GetBytes(_data))).WaitAsync(cancellationToken);

        // In rare cases when synchronous support is needed, e.g. synchronous ReadAsStream,
        // implement synchronous version of CreateContentRead.
        protected override Stream CreateContentReadStream(CancellationToken cancellationToken)
            => new MemoryStream(Encoding.UTF8.GetBytes(_data));
    }
// </Snippet1>
}

#nullable disable
