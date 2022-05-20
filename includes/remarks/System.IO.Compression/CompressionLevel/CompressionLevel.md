Compression operations usually involve a tradeoff between the speed and the effectiveness of compression. You use the <xref:System.IO.Compression.CompressionLevel> enumeration to indicate which factor is more important in your development scenario: the time to complete the compression operation or the size of the compressed file. These values do not correspond to specific compression levels; the object that implements compression determines how to handle them.

The following methods of the <xref:System.IO.Compression.DeflateStream>, <xref:System.IO.Compression.GZipStream>, <xref:System.IO.Compression.ZipArchive>, <xref:System.IO.Compression.ZipFile>, and <xref:System.IO.Compression.ZipFileExtensions> classes include a parameter named `compressionLevel` that lets you specify the compression level:

- <xref:System.IO.Compression.DeflateStream.%23ctor%28System.IO.Stream%2CSystem.IO.Compression.CompressionLevel%29?displayProperty=nameWithType>

- <xref:System.IO.Compression.DeflateStream.%23ctor%28System.IO.Stream%2CSystem.IO.Compression.CompressionLevel%2CSystem.Boolean%29?displayProperty=nameWithType>

- <xref:System.IO.Compression.GZipStream.%23ctor%28System.IO.Stream%2CSystem.IO.Compression.CompressionLevel%29?displayProperty=nameWithType>

- <xref:System.IO.Compression.GZipStream.%23ctor%28System.IO.Stream%2CSystem.IO.Compression.CompressionLevel%2CSystem.Boolean%29?displayProperty=nameWithType>

- <xref:System.IO.Compression.ZipArchive.CreateEntry%28System.String%2CSystem.IO.Compression.CompressionLevel%29?displayProperty=nameWithType>

- <xref:System.IO.Compression.ZipFile.CreateFromDirectory%28System.String%2CSystem.String%2CSystem.IO.Compression.CompressionLevel%2CSystem.Boolean%29?displayProperty=nameWithType>

- <xref:System.IO.Compression.ZipFileExtensions.CreateEntryFromFile%28System.IO.Compression.ZipArchive%2CSystem.String%2CSystem.String%2CSystem.IO.Compression.CompressionLevel%29?displayProperty=nameWithType>

## Examples

The following example shows how to set the compression level when creating a zip archive by using the <xref:System.IO.Compression.ZipFile> class.

:::code language="csharp" source="~/snippets/csharp/System.IO.Compression/ZipFile/CreateFromDirectory/program3.cs" id="Snippet3":::
:::code language="vb" source="~/snippets/visualbasic/VS_Snippets_CLR_System/system.io.compression.zipfile/vb/program3.vb" id="Snippet3":::
