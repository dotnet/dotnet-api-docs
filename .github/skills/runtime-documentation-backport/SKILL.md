---
name: runtime-documentation-backport
description: Backport .NET API reference documentation from dotnet-api-docs ECMAXML to dotnet/runtime source XML comments and tested examples.
---

# Runtime documentation backport

Use this skill when moving API documentation from this repository into `///`
comments in `dotnet/runtime`. Follow the guidance in
[dotnet-api-docs#10722](https://github.com/dotnet/dotnet-api-docs/issues/10722).

## Establish the scope

1. Resolve the requested types or assembly. If the scope isn't specified, ask
   before editing.
2. Locate a writable `dotnet/runtime` checkout and read its contributor and agent
   instructions. If the session can't write to that repository, explain the
   access limitation rather than attempting an unauthorized write.
3. Inspect existing changes in both checkouts and preserve unrelated work.
4. Read the source documentation at `xml/<Namespace>/<Type>.xml` on
   `dotnet-api-docs`'s `main` branch. If using a local copy, confirm its revision
   and account for local changes rather than silently treating it as `main`.
5. Match every requested public type and member to its implementation, including
   overloads, generic parameters, and framework-specific variants. Inventory the
   existing comments, included documentation, and referenced snippets before
   editing.

Don't modify the ECMAXML source as part of a backport. The .NET Framework-specific
and unsupported-version documentation removals described in the issue are
already complete; don't repeat those cleanup passes.

## Choose the destination

- Document source implementation files, not reference assembly files under `ref`.
- Prefer shared or CoreCLR files. Don't duplicate comments in Mono-specific
  partials unless the behavior differs.
- For runtime-specific, OS-specific, or architecture-specific implementations,
  keep common documentation in a neutral file. Where applicable, use partial
  method declarations in that file, as suggested in the issue. Verify that the
  declaration works with every implementation and build configuration; don't
  introduce unrelated API or behavior changes.
- Preserve accurate existing comments. Reconcile differences against the
  implementation instead of blindly overwriting newer information. Ask when a
  substantive conflict can't be resolved from the source.

## Port the documentation

Port the applicable content from each type and member's `<Docs>` element,
including summaries, parameters, type parameters, return or property values,
exceptions, examples, and related API links. Don't copy generated signatures,
assembly metadata, or framework-alternate metadata into comments.

- Backport all remarks, including notes and paragraphs. Don't omit content
  merely because it's long.
- Convert ECMAXML and Markdown wrappers into content appropriate for source XML
  documentation. Resolve reusable includes and snippet references so no
  repository-relative `~/includes/` or `~/snippets/` links remain unresolved.
- Decode XML entities when extracting text, for example `&lt;` to `<` and
  `&gt;` to `>`. When emitting XML comments, escape literal text again where XML
  requires it. Don't turn literal angle brackets or ampersands into invalid XML.
- Use `<see langword="null"/>`, `<see langword="true"/>`,
  `<see langword="false"/>`, and `<see langword="void"/>` for keywords.
- Use `<see cref="Type"/>` for types and members, adapting ECMAXML DocIDs to
  compiler-resolvable C# references. Preserve the intended overload.
- Use `<paramref>` and `<typeparamref>` for parameter references.
- Use `<c>code</c>` for inline code, not Markdown backticks.
- Use `<note type="note">` for notes and `<para>` for paragraph breaks in remarks.
- In retained Markdown sections, replace `<xref:...>` API links with fully
  qualified HTML links to the API at `https://learn.microsoft.com/dotnet/api/...`.
  The xref syntax doesn't render in IntelliSense. Resolve the actual API URL
  rather than guessing it from the DocID.

For very lengthy remarks, port the full content to a separate `docs` directory
in the target library and link to it from the `///` comments. Follow existing
runtime conventions for the file format and link syntax, and verify that the
link resolves.

## Port and test examples

Use
[CustomReflectionContext.Examples.cs](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Reflection.Context/tests/CustomReflectionContext.Examples.cs)
as a reference for the target repository's example pattern.

1. Create `src/libraries/<Library>/tests/<Type>.Examples.cs` or extend the
   existing examples file.
2. Port each example without changing the documented API, behavior, or output.
   Mark each included example with a distinct `#region RegionName` and matching
   `#endregion`.
3. Wire examples into the library's existing test project and test framework so
   they execute, not merely compile.
4. Use `Assert` to verify the example's stated output or results. Keep assertions
   and test-only scaffolding outside the region included in the docs.
5. Reference the example with a path relative to the source file containing the
   comment:

   ```xml
   <code lang="cs" source="../../tests/Type.Examples.cs" region="RegionName" />
   ```

   Calculate the actual relative path for each source file; the path above is
   illustrative. In Markdown, use
   `[!code-csharp[](relative/path/Type.Examples.cs#RegionName)]`.
6. Confirm every referenced file and region exists and contains the intended
   sample.

Don't assume the documentation publishing pipeline copies example files back to
this repository. Track that separate dependency through
[dotnet/docs-tools#805](https://github.com/dotnet/docs-tools/issues/805).

## Complete the assembly migration

Only after all public types and members in the assembly are documented, remove
`<UseCompilerGeneratedDocXmlFile>false</UseCompilerGeneratedDocXmlFile>` from its
project file. Don't remove the setting for a partial backport.

Track the following as separate migration follow-ups; don't silently expand a
type-level backport into a publishing or policy change:

- In this repository's `docfx.json`, set `open_to_public_contributors` to `false`
  for the migrated namespace or individual types.
- Update `.github/policies/disallow-edits.yml` to protect the same XML scope.
  Use individual types when an assembly doesn't encompass the entire namespace.
- Determine shared-framework membership from
  `dotnet/runtime/src/libraries/NetCoreAppLibrary.props`.
- For a standalone NuGet package outside the shared framework, remove its package
  name from `dotnet/docs-tools/PackageIndexer/PlatformPackageDefinition.cs`.
- For a shared-framework assembly, arrange for its XML documentation file to be
  added to the internal API-generation list of files pushed to the binaries
  repository for docs CI ingestion. The issue links to that internal checklist.
  Report inaccessible or manual steps explicitly; don't claim they're complete.

## Validate and report

1. Compare the requested public API inventory against the ported documentation.
   Account for every remarks block, include, example, and member.
2. Build the affected runtime library using its documented commands. Check XML
   documentation diagnostics, including invalid markup, unresolved references,
   and parameter mismatches.
3. Run the affected example tests with the library's existing test commands.
4. Check relative file links, example regions, and API links.
5. Run `git diff --check` in each changed checkout and inspect the scoped diffs
   for unintended implementation, generated-file, or reference-assembly changes.
6. Report the backported scope, any unresolved conflicts or validation blockers,
   and outstanding assembly-migration follow-ups. Distinguish completed changes
   from work that requires another repository or manual publishing access.
