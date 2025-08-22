# Snippet Validator Tool

This tool validates that code example introductions in XML documentation files accurately match the content of the referenced code snippets.

## Purpose

The tool identifies mismatches where documentation introductions describe functionality that doesn't match what's actually shown in the code snippets. This helps ensure documentation accuracy and consistency.

## How it works

1. **Scans XML files** in the `xml/` directory for snippet references like:
   ```xml
   :::code language="csharp" source="~/snippets/path/to/file.cs" id="Snippet1":::
   ```

2. **Extracts introduction text** from the lines preceding each snippet reference

3. **Reads snippet files** and extracts the specific snippet content using the provided ID

4. **Analyzes mismatches** by checking for:
   - Methods mentioned in introductions but not found in snippets
   - Async/sync operation mismatches  
   - Class references that don't appear in the code
   - Technology-specific inconsistencies

## Usage

### Sample mode (demonstrates issues found)
```bash
cd tools/SnippetValidator
dotnet run -- --sample
```

### Test mode (focuses on specific known files)
```bash
cd tools/SnippetValidator
dotnet run -- --test
```

### Full validation (scans entire repository)
```bash
cd tools/SnippetValidator  
dotnet run
```

## Example Issues Found

### LoadAsync vs Load Method Mismatch
- **File**: System.Media/SoundPlayer.xml
- **Issue**: Introduction mentions `LoadAsync` method but snippet uses synchronous `Load()` method
- **Impact**: Documentation incorrectly describes the demonstrated functionality

### Async/Sync Operation Mismatch  
- **File**: System.Media/SoundPlayer.xml
- **Issue**: Introduction mentions synchronous operations but snippet contains async code
- **Impact**: Users might expect different behavior than what's actually shown

## Output Format

The tool provides detailed reports showing:
- XML file name and line number
- Introduction text excerpt  
- Referenced snippet file and ID
- Specific mismatch description

## False Positives

The tool is designed to minimize false positives by:
- Checking for reasonable alternatives (e.g., event handlers for events)
- Ignoring very generic terms
- Focusing on clear inconsistencies rather than minor variations

## Integration

This tool can be integrated into CI/CD pipelines to automatically detect documentation issues during builds.