# Visual Basic Snippet Reorganization

This document describes the reorganization of Visual Basic code snippets from the legacy `VS_Snippets_CLR` structure to a namespace-based organization that matches the C# snippet structure.

## Overview

Previously, VB snippets were organized under `snippets/visualbasic/VS_Snippets_CLR` with inconsistent naming patterns. They have been reorganized to match the C# snippet organization using namespace and API-based directory structures.

## Reorganization Pattern

### Before (Old Structure)
```
snippets/visualbasic/VS_Snippets_CLR/
├── directoryinforoot/VB/directoryinforoot2.vb
├── List`1_IndexOf/vb/source.vb
├── Generic.SortedDictionary/VB/source.vb
├── environment.FailFast/vb/ff.vb
└── stringbuilder.replace/VB/replace.vb
```

### After (New Structure)
```
snippets/visualbasic/
├── System.IO/DirectoryInfo/Root/directoryinforoot2.vb
├── System.Collections.Generic/ListT/IndexOf/source.vb
├── System.Collections.Generic/SortedDictionaryTKey,TValue/Overview/source.vb
├── System/Environment/FailFast/ff.vb
└── System.Text/StringBuilder/Replace/replace.vb
```

## Naming Conventions

### Namespace Mapping
- `VS_Snippets_CLR` files are mapped to appropriate namespaces:
  - Files starting with `Generic.` → `System.Collections.Generic`
  - Files with `directoryinfo`, `fileinfo`, `path` → `System.IO`
  - Files with `environment`, `console`, `datetime`, `string`, `array`, `math` → `System`
  - Files with `stringbuilder`, `regex` → `System.Text`
  - Files with `thread` → `System.Threading`

### Type Name Mapping
- Generic type names are converted to match C# patterns:
  - `List`1` → `ListT`
  - `Dictionary`2` → `DictionaryTKey,TValue`
  - `SortedDictionary`2` → `SortedDictionaryTKey,TValue`
  - `SortedList`2` → `SortedListTKey,TValue`
  - `Queue`1` → `QueueT`
  - `Stack`1` → `StackT`

### Member/Method Mapping
- Constructor examples → `.ctor`
- Method-specific examples use the method name (e.g., `IndexOf`, `Contains`)
- General class examples → `Overview`

## Project Files

Each snippet directory includes a `Project.vbproj` file for compilation:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>
</Project>
```

## XML Reference Updates

All XML documentation files have been updated to reference the new snippet paths:

### Before
```xml
:::code language="vb" source="~/snippets/visualbasic/VS_Snippets_CLR/List`1_IndexOf/vb/source.vb" id="Snippet1":::
```

### After
```xml
:::code language="vb" source="~/snippets/visualbasic/System.Collections.Generic/ListT/IndexOf/source.vb" id="Snippet1":::
```

## Moved Snippets Summary

The following categories of snippets have been successfully reorganized:

### System.Collections.Generic (13 files)
- `ListT/IndexOf/` - List<T>.IndexOf examples
- `ListT/Ranges/` - List<T> range operations
- `QueueT/Overview/` - Queue<T> general examples
- `StackT/Overview/` - Stack<T> general examples
- `DictionaryTKey,TValue/.ctor/` - Dictionary constructors
- `SortedDictionaryTKey,TValue/Overview/` - SortedDictionary examples
- `SortedListTKey,TValue/IDictionary/` - SortedList as IDictionary
- `IDictionaryTKey,TValue/Overview/` - IDictionary interface examples

### System.IO (9 files)
- `DirectoryInfo/Root/` - DirectoryInfo.Root property
- `DirectoryInfo/GetDirectories/` - DirectoryInfo.GetDirectories method
- `DirectoryInfo/CreateSubdirectory/` - Directory creation
- `DirectoryInfo/Delete/` - Directory deletion
- `DirectoryInfo/MoveTo/` - Directory moving
- `DirectoryInfo/Parent/` - Parent directory access
- `FileInfo/IsReadOnly/` - FileInfo.IsReadOnly property
- `FileInfo/CopyTo/` - File copying
- `FileInfo/GetAccessControl/` - File access control
- `Path/Combine/` - Path.Combine method

### System (7 files)
- `Environment/FailFast/` - Environment.FailFast method
- `Console/KeyAvailable/` - Console.KeyAvailable property
- `Console/ReadKey/` - Console.ReadKey method
- `DateTime/DayOfWeek/` - DateTime.DayOfWeek property
- `Math/Max/` - Math.Max method
- `Math/Min/` - Math.Min method

### System.Collections (1 file)
- `ArrayList/Overview/` - ArrayList general examples

### System.Text (1 file)
- `StringBuilder/Replace/` - StringBuilder.Replace method

### System.Threading (2 files)
- `Thread/Sleep/` - Thread.Sleep method
- `Thread/Abort/` - Thread abortion examples

## Validation

All moved snippets:
1. ✅ Build successfully with their project files
2. ✅ Maintain their original snippet IDs and functionality
3. ✅ Have updated XML references in documentation files
4. ✅ Follow the established C# snippet organization pattern

## Benefits

1. **Consistency**: VB snippets now follow the same organization pattern as C# snippets
2. **Discoverability**: Easier to find snippets by namespace and API
3. **Maintainability**: Clearer structure for adding new snippets
4. **Build Validation**: Each snippet can be independently compiled and validated