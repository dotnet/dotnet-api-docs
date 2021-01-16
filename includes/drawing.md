> [!CAUTION]
> - The `System.Drawing` namespace is not recommended for new development, due to not being supported within a Windows or ASP.NET service. [ImageSharp](https://github.com/SixLabors/ImageSharp) and [SkiaSharp](https://github.com/mono/SkiaSharp) are recommended as alternatives.
> - On Windows, `System.Drawing` depends on the GDI+ native library, which is shipped as part of the OS. Some Windows SKUs, like Windows Server Core or Windows Nano, don't include this native library as part of the OS. Exceptions will be thrown at run time because the library can't be loaded.
