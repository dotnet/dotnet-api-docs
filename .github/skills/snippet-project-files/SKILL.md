---
name: snippet-project-files
description: Add or consolidate .NET snippet project files so every snippet directory builds as one project.
---

# Snippet project files

When adding or fixing project files under `snippets/`:

1. Keep exactly one project file in each directory.
2. Use SDK-style projects and the default compile includes. Don't add explicit `<Compile Include="...">` items.
3. Set `OutputType` to `Exe` when the directory contains an entry point or top-level statements. Otherwise, use `Library`.
4. If multiple source files define `Main`, rename each method to `Run`.
5. Give duplicate types in the same directory unique names.
6. Add one `Program.cs` file that calls every `Run` method, passing `args` to methods that accept command-line arguments.
7. Build the consolidated project and fix all compile errors.
