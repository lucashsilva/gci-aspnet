# GCI Request Interceptor for ASP.NET

Exposes an API for collecting the heap usage and forcing the GC. Meant to be a runtime-specific counterpart of gci-proxy, implemented in C# made for ASP.NET applications.

Usage (C#):

1. Build the project library class or download release library class.
1. Import library class file.
1. Add reference to namespace GCI with `using GCI;` 
1. Add `app.UseMiddleware<GCI.GCIMiddleware>();` to your application's configuration method.


