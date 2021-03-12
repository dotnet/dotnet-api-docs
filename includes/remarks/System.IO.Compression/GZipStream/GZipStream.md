This class represents the gzip data format, which uses an industry-standard algorithm for lossless file compression and decompression. The format includes a cyclic redundancy check value for detecting data corruption. The gzip data format uses the same algorithm as the <xref:System.IO.Compression.DeflateStream> class, but can be extended to use other compression formats. The format can be readily implemented in a manner not covered by patents.

Starting with the .NET Framework 4.5, the <xref:System.IO.Compression.DeflateStream> class uses the zlib library for compression. As a result, it provides a better compression algorithm and, in most cases, a smaller compressed file than it provides in earlier versions of the .NET Framework.

Compressed <xref:System.IO.Compression.GZipStream> objects written to a file with an extension of .gz can be decompressed using many common compression tools; however, this class does not inherently provide functionality for adding files to or extracting files from zip archives.

The compression functionality in <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> is exposed as a stream. Data is read on a byte-by-byte basis, so it is not possible to perform multiple passes to determine the best method for compressing entire files or large blocks of data. The <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> classes are best used on uncompressed sources of data. If the source data is already compressed, using these classes may actually increase the size of the stream.

## Examples

The following example shows how to use the <xref:System.IO.Compression.GZipStream> class to compress and decompress a directory of files.

[!code-csharp[IO.Compression.GZip1#1](~/samples/snippets/csharp/VS_Snippets_CLR/IO.Compression.GZip1/CS/gziptest.cs#1)]
[!code-vb[IO.Compression.GZip1#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/IO.Compression.GZip1/VB/gziptest.vb#1)]
