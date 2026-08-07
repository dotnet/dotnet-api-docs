---
name: dotnet-snippet-modernization
description: Modernize C# API-reference snippets while preserving the documented API, output, and snippet structure.
---

# .NET API Snippet Modernization

Modernize C# files in the requested `snippets/csharp` scope. Apply current C#
syntax and repository formatting conventions without changing what an API sample
teaches.

## Establish the scope

1. Resolve the exact namespace, type, or snippet-project path requested.
2. Don't include sibling namespaces unless the user explicitly requests them.
3. Inspect existing changes and preserve work that isn't yours.
4. Inventory the source files and projects before a large batch operation.
5. Read and follow `snippets/.editorconfig`.

## Preferred modernizations

Apply these changes when they preserve behavior and sample clarity:

- Use top-level statements where possible.
- Use C# built-in aliases, such as `string`, `int`, and `bool`, instead of
  framework type names.
- Use target-typed `new` when the target type is evident.
- Use string interpolation instead of composite formatting, unless it makes the code harder to read
  or the composite-format overload is the subject of the snippet. For example, keep composite
  formatting when the arguments are complex:
  ```csharp
  Console.WriteLine("{0}: {1:G}",
      timeZoneTime.TimeZone == null ? "<null>" : timeZoneTime.TimeZone.ToString(),
      timeZoneTime.DateTime);
  ```
- Use raw string literals (or interpolated raw string literals) for paragraph-style output.
- Use object and collection initializers when evaluation order and behavior
  remain unchanged.
- Convert eligible value-producing `switch` statements to switch expressions.
- Use auto-implemented properties instead of defining a separate field.
- Use expression-bodied members for simple single-expression members. If the line gets too long, for example, a method signature with a type parameter constraint, place the expression body on a new line, for example:
  ```csharp
  public static T Factory<T>() where T : new()
      => new T();
  ```
- Remove unused using directives and sort the remaining directives with
  `System` namespaces first.
- Put curly braces on their own lines.
- Normalize indentation, spacing, trailing whitespace, and final newlines.

Don't introduce `var`; this repository prefers explicit types.

## Preserve the documented API

The directory and file names often identify the API being demonstrated. Don't
replace an API call when that replacement would remove the subject of the
sample.

Examples:

- Preserve `String.Format` in snippets documenting `String.Format`.
- Preserve composite-format overloads in snippets documenting
  `Console.Write` or `Console.WriteLine`.
- Preserve constructor syntax when the constructor invocation itself is the
  focus and target-typed `new` would make the example unclear.
- Preserve a `switch` statement when the sample demonstrates control flow,
  fall-through behavior, labels, or statement-specific side effects.

When the intent is ambiguous, prefer preserving the existing API call over
applying a stylistic transformation.

## Behavioral safeguards

- Preserve snippet markers, including `// <SnippetName>` and
  `// </SnippetName>`. However, if the markers (and possibly output comments) can be moved closer together to exclude scaffolding that doesn't directly pertain to the API being demonstrated, do so.
- Preserve observable output, exception behavior, culture-sensitive formatting,
  evaluation order, and disposal behavior.
- Preserve comments that describe expected output.
- Don't edit generated files, including designer files, or files under `.vs`,
  `bin`, or `obj`.
- Don't add architecture, dependency injection, logging, testing, or XML
  documentation patterns to standalone snippets unless explicitly requested.
- Don't make unrelated naming or structural changes.
- Code comments must end with a period.

## Tooling

Prefer syntax-aware Roslyn tooling over textual replacement.

For `dotnet format`, restrict fixes to diagnostics relevant to the requested
modernization. Useful diagnostics include:

- `IDE0049` for built-in type aliases.
- `IDE0090` for target-typed `new`.
- `IDE0066` for switch expressions.
- `IDE0021` through `IDE0027`, and `IDE0061`, for expression-bodied members.
- `IDE0017` for object initializers.
- `IDE0028` for collection initializers.
- `IDE0005` for unused using directives.

Use formatting tools for whitespace and indentation. Don't enable broad,
unrelated analyzer fixes. Don't use global regular-expression replacements for
syntax transformations.

Place temporary solutions, scripts, and Roslyn tools outside the repository.

## Validation

1. Build every affected snippet project with its existing project file. If no project file exists, add one.
2. Treat warnings as pre-existing only after confirming the modernization
   didn't introduce them.
3. Run `git diff --check` for the exact scope.
4. Confirm no files outside the requested scope changed.
5. Inspect the diff for damaged snippet markers, generated artifacts, and
   replacements of the documented API.

There's no repository-wide build command. Validate the affected snippet
projects individually or in controlled batches.
