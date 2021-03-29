When you set the `mode` parameter to <xref:System.IO.Compression.ZipArchiveMode.Read>, the archive is opened with <xref:System.IO.FileMode.Open?displayProperty=nameWithType> as the file mode value. If the archive does not exist, a <xref:System.IO.FileNotFoundException> exception is thrown. Setting the `mode` parameter to <xref:System.IO.Compression.ZipArchiveMode.Read> is equivalent to calling the <xref:System.IO.Compression.ZipFile.OpenRead%2A> method.

When you set the `mode` parameter to <xref:System.IO.Compression.ZipArchiveMode.Create>, the archive is opened with <xref:System.IO.FileMode.CreateNew?displayProperty=nameWithType> as the file mode value. If the archive already exists, an <xref:System.IO.IOException> is thrown.

When you set the `mode` parameter to <xref:System.IO.Compression.ZipArchiveMode.Update>,  the archive is opened with <xref:System.IO.FileMode.OpenOrCreate?displayProperty=nameWithType> as the file mode value. If the archive exists, it is opened. The existing entries can be modified and new entries can be created. If the archive does not exist, a new archive is created; however, creating a zip archive in <xref:System.IO.Compression.ZipArchiveMode.Update> mode is not as efficient as creating it in <xref:System.IO.Compression.ZipArchiveMode.Create> mode.

When you open a zip archive file for reading and `entryNameEncoding` is set to `null`, entry names are decoded according to the following rules:

-   When the language encoding flag (in the general-purpose bit flag of the local file header) is not set, the current system default code page is used to decode the entry name.

-   When the language encoding flag is set, UTF-8 is used to decode the entry name.

When you open a zip archive file for reading and `entryNameEncoding` is set to a value other than `null`, entry names are decoded according to the following rules:

-   When the language encoding flag is not set, the specified `entryNameEncoding` is used to decode the entry name.

-   When the language encoding flag is set, UTF-8 is used to decode the entry name.

When you write to archive files and `entryNameEncoding` is set to `null`, entry names are encoded according to the following rules:

-   For entry names that contain characters outside the ASCII range, the language encoding flag is set, and entry names are encoded by using UTF-8.

-   For entry names that contain only ASCII characters, the language encoding flag is not set, and entry names are encoded by using the current system default code page.

When you write to archive files and `entryNameEncoding` is set to a value other than `null`, the specified `entryNameEncoding` is used to encode the entry names into bytes. The language encoding flag (in the general-purpose bit flag of the local file header) is set only when the specified encoding is a UTF-8 encoding.
