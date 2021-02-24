This class represents the Deflate algorithm, which is an industry-standard algorithm for lossless file compression and decompression. Starting with the [!INCLUDE[net_v45](~/includes/net-v45-md.md)], the <xref:System.IO.Compression.DeflateStream> class uses the zlib library. As a result, it provides a better compression algorithm and, in most cases, a smaller compressed file than it provides in earlier versions of the .NET Framework.

This class does not inherently provide functionality for adding files to or extracting files from zip archives. To work with zip archives, use the <xref:System.IO.Compression.ZipArchive> and the <xref:System.IO.Compression.ZipArchiveEntry> classes.

The <xref:System.IO.Compression.DeflateStream> class uses the same compression algorithm as the gzip data format used by the <xref:System.IO.Compression.GZipStream> class.

The compression functionality in <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> is exposed as a stream. Data is read on a byte-by-byte basis, so it is not possible to perform multiple passes to determine the best method for compressing entire files or large blocks of data. The <xref:System.IO.Compression.DeflateStream> and <xref:System.IO.Compression.GZipStream> classes are best used on uncompressed sources of data. If the source data is already compressed, using these classes may actually increase the size of the stream.

## Examples

The following example shows how to use the <xref:System.IO.Compression.DeflateStream> class to compress and decompress a directory of files.

[!code-csharp[IO.Compression.Deflate1#1](~/samples/snippets/csharp/VS_Snippets_CLR/IO.Compression.Deflate1/CS/deflatetest.cs#1)]
[!code-vb[IO.Compression.Deflate1#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/IO.Compression.Deflate1/VB/deflatetest.vb#1)]
  