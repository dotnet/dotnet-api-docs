# .NET API Reference Docs

This repository contains documentation for the .NET API reference. We track all work for this repository using [GitHub issues](https://github.com/dotnet/dotnet-api-docs/issues). The documentation for APIs is built from the text and code snippets in this repo, and from the samples in the [dotnet/samples](https://github.com/dotnet/samples) repository.

The repository for conceptual .NET documentation is the [dotnet/docs repository](https://github.com/dotnet/docs).

## :purple_heart: Contribute

We welcome contributions to help us improve and complete the .NET API reference docs.

To contribute, see:

- The [.NET Contributor Guide :ledger:](https://learn.microsoft.com/contribute/dotnet/dotnet-contribute) for instructions on procedures we use.
- Issues labeled [`help wanted` :label:](https://github.com/dotnet/dotnet-api-docs/issues?q=is%3Aopen+is%3Aissue+label%3A%22help+wanted%22+) for ideas.
- The API reference docs for some assemblies are maintained in the assembly's source code outside this repo. For those assemblies, edits to the XML here are auto-generated and ported, so docs for APIs in those assemblies should be updated by editing the source code comments. For more information, see [here](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/adding-api-guidelines.md#documentation).

  Namespaces and types whose docs are maintained in the assembly's source code repo set the [`open_to_public_contributors`](https://github.com/dotnet/dotnet-api-docs/blob/0ddbf94c587e7bdbbadc813a8b58fc4160a47b1f/docfx.json#L164) metadata to `false`. (That metadata disables the Edit button on the published docs.)

## :bookmark_tabs: Code of conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).
