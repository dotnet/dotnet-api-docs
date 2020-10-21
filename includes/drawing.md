> [!WARNING]
> The `System.Drawing` namespace is not recommended for new development, due to not being supported within a Windows or ASP.NET service and it is not cross-platform. [ImageSharp](https://github.com/SixLabors/ImageSharp) and [SkiaSharp](https://github.com/mono/SkiaSharp) are recommended as alternatives.

> [!CAUTION]
> On Windows `System.Drawing` depends on GDI+ native library, which is shipped as part of the OS. Some Windows SKUs like Windows Server Core or Windows Nano, don't include this native library as part of the OS, so exceptions will be thrown at runtime as we can't load this library.