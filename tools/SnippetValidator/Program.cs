using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace SnippetValidator;

public class Program
{
    private static readonly string BaseDirectory = "/home/runner/work/dotnet-api-docs/dotnet-api-docs";
    private static readonly string XmlDirectory = Path.Combine(BaseDirectory, "xml");
    private static readonly string SnippetsDirectory = Path.Combine(BaseDirectory, "snippets");

    public static void Main(string[] args)
    {
        Console.WriteLine("Snippet Validator Tool");
        Console.WriteLine("======================");
        Console.WriteLine();

        var validator = new SnippetValidator();
        List<ValidationIssue> issues;

        // Allow testing on specific files
        if (args.Length > 0 && args[0] == "--test")
        {
            // Test on specific files for debugging
            var testFiles = new[]
            {
                "System.Media/SoundPlayer.xml",
                "System/String.xml"
            };
            
            issues = validator.ValidateSpecificFiles(testFiles);
        }
        else if (args.Length > 0 && args[0] == "--sample")
        {
            // Test on a small sample for demonstration
            var sampleFiles = new[]
            {
                "System.Media/SoundPlayer.xml",
                "System.CodeDom/CodeMethodReferenceExpression.xml",
                "System.Media/SystemSound.xml"
            };
            
            issues = validator.ValidateSpecificFiles(sampleFiles);
        }
        else
        {
            issues = validator.ValidateSnippets();
        }

        Console.WriteLine($"Found {issues.Count} potential issues:");
        Console.WriteLine();

        foreach (var issue in issues.Take(20)) // Limit output for readability
        {
            Console.WriteLine($"File: {Path.GetFileName(issue.XmlFile)}");
            Console.WriteLine($"Line: {issue.LineNumber}");
            Console.WriteLine($"Introduction: {issue.Introduction.Substring(0, Math.Min(150, issue.Introduction.Length))}...");
            Console.WriteLine($"Snippet: {Path.GetFileName(issue.SnippetPath)} (ID: {issue.SnippetId})");
            Console.WriteLine($"Issue: {issue.Description}");
            Console.WriteLine(new string('-', 80));
        }

        if (issues.Count > 20)
        {
            Console.WriteLine($"... and {issues.Count - 20} more issues");
        }
    }
}

public class ValidationIssue
{
    public string XmlFile { get; set; } = "";
    public int LineNumber { get; set; }
    public string Introduction { get; set; } = "";
    public string SnippetPath { get; set; } = "";
    public string SnippetId { get; set; } = "";
    public string Description { get; set; } = "";
}

public class SnippetReference
{
    public string Language { get; set; } = "";
    public string SourcePath { get; set; } = "";
    public string SnippetId { get; set; } = "";
    public int LineNumber { get; set; }
}

public class SnippetValidator
{
    private static readonly string BaseDirectory = "/home/runner/work/dotnet-api-docs/dotnet-api-docs";
    private static readonly string XmlDirectory = Path.Combine(BaseDirectory, "xml");
    private static readonly string SnippetsDirectory = Path.Combine(BaseDirectory, "snippets");

    // Pattern to match snippet references like: :::code language="csharp" source="~/snippets/..." id="Snippet1":::
    private static readonly Regex SnippetRefPattern = new Regex(
        @":::code\s+language=""(?<lang>\w+)""\s+source=""(?<path>[^""]+)""\s+id=""(?<id>[^""]+)"":::",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public List<ValidationIssue> ValidateSnippets()
    {
        var issues = new List<ValidationIssue>();
        
        Console.WriteLine($"Scanning XML files in {XmlDirectory}...");
        
        var xmlFiles = Directory.GetFiles(XmlDirectory, "*.xml", SearchOption.AllDirectories);
        
        var processedCount = 0;
        foreach (var xmlFile in xmlFiles)
        {
            try
            {
                var fileIssues = ValidateXmlFile(xmlFile);
                issues.AddRange(fileIssues);
                
                processedCount++;
                if (processedCount % 100 == 0)
                {
                    Console.WriteLine($"Processed {processedCount}/{xmlFiles.Length} files, found {issues.Count} issues so far...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing {xmlFile}: {ex.Message}");
            }
        }

        Console.WriteLine($"Completed processing {processedCount} files.");
        return issues;
    }

    public List<ValidationIssue> ValidateSpecificFiles(string[] filePatterns)
    {
        var issues = new List<ValidationIssue>();
        
        Console.WriteLine($"Testing specific files...");
        
        foreach (var pattern in filePatterns)
        {
            var xmlFile = Path.Combine(XmlDirectory, pattern);
            if (File.Exists(xmlFile))
            {
                Console.WriteLine($"Processing {xmlFile}...");
                try
                {
                    var fileIssues = ValidateXmlFile(xmlFile);
                    issues.AddRange(fileIssues);
                    Console.WriteLine($"Found {fileIssues.Count} issues in {pattern}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {xmlFile}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"File not found: {xmlFile}");
            }
        }

        return issues;
    }

    private List<ValidationIssue> ValidateXmlFile(string xmlFilePath)
    {
        var issues = new List<ValidationIssue>();
        var lines = File.ReadAllLines(xmlFilePath);

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var matches = SnippetRefPattern.Matches(line);

            foreach (Match match in matches)
            {
                var snippetRef = new SnippetReference
                {
                    Language = match.Groups["lang"].Value,
                    SourcePath = match.Groups["path"].Value,
                    SnippetId = match.Groups["id"].Value,
                    LineNumber = i + 1
                };

                // Look for introduction text in preceding lines
                var introduction = FindIntroductionText(lines, i);
                
                // Validate the snippet
                var issue = ValidateSnippetContent(xmlFilePath, snippetRef, introduction);
                if (issue != null)
                {
                    issues.Add(issue);
                }
            }
        }

        return issues;
    }

    private string FindIntroductionText(string[] lines, int snippetLineIndex)
    {
        // Look backward from the snippet reference to find introduction text
        // Typically it's within the same paragraph or a few lines before
        
        var introLines = new List<string>();
        
        // Start from the line before the snippet reference and go backwards
        for (int i = snippetLineIndex - 1; i >= Math.Max(0, snippetLineIndex - 10); i--)
        {
            var line = lines[i].Trim();
            
            // Skip empty lines and XML formatting
            if (string.IsNullOrWhiteSpace(line) || 
                line.StartsWith(":::") || 
                line.StartsWith("##") ||
                line.StartsWith("</") ||
                line.StartsWith("]]>"))
            {
                continue;
            }
            
            // If we hit another snippet reference or major section, stop
            if (line.Contains(":::code") || line.Contains("## "))
            {
                break;
            }
            
            introLines.Insert(0, line);
            
            // If this looks like the start of a sentence or paragraph, we found our intro
            if (line.Contains("example") && (line.Contains("demonstrates") || line.Contains("shows")))
            {
                break;
            }
        }

        return string.Join(" ", introLines).Trim();
    }

    private ValidationIssue? ValidateSnippetContent(string xmlFile, SnippetReference snippetRef, string introduction)
    {
        try
        {
            // Convert the path from XML reference to actual file system path
            var snippetPath = ConvertToFileSystemPath(snippetRef.SourcePath);
            
            if (!File.Exists(snippetPath))
            {
                return new ValidationIssue
                {
                    XmlFile = xmlFile,
                    LineNumber = snippetRef.LineNumber,
                    Introduction = introduction,
                    SnippetPath = snippetPath,
                    SnippetId = snippetRef.SnippetId,
                    Description = "Referenced snippet file does not exist"
                };
            }

            var snippetContent = ExtractSnippetContent(snippetPath, snippetRef.SnippetId);
            
            if (string.IsNullOrEmpty(snippetContent))
            {
                return new ValidationIssue
                {
                    XmlFile = xmlFile,
                    LineNumber = snippetRef.LineNumber,
                    Introduction = introduction,
                    SnippetPath = snippetPath,
                    SnippetId = snippetRef.SnippetId,
                    Description = $"Snippet ID '{snippetRef.SnippetId}' not found in file"
                };
            }

            // Analyze if introduction matches snippet content
            var mismatchDescription = AnalyzeIntroductionMatch(introduction, snippetContent, snippetRef);
            
            if (!string.IsNullOrEmpty(mismatchDescription))
            {
                return new ValidationIssue
                {
                    XmlFile = xmlFile,
                    LineNumber = snippetRef.LineNumber,
                    Introduction = introduction,
                    SnippetPath = snippetPath,
                    SnippetId = snippetRef.SnippetId,
                    Description = mismatchDescription
                };
            }

            return null; // No issues found
        }
        catch (Exception ex)
        {
            return new ValidationIssue
            {
                XmlFile = xmlFile,
                LineNumber = snippetRef.LineNumber,
                Introduction = introduction,
                SnippetPath = snippetRef.SourcePath,
                SnippetId = snippetRef.SnippetId,
                Description = $"Error validating snippet: {ex.Message}"
            };
        }
    }

    private string ConvertToFileSystemPath(string xmlPath)
    {
        // Convert paths like "~/snippets/csharp/System.Media/..." to full file system paths
        var relativePath = xmlPath.Replace("~/snippets/", "").Replace("~/", "");
        return Path.Combine(SnippetsDirectory, relativePath);
    }

    private string ExtractSnippetContent(string filePath, string snippetId)
    {
        var lines = File.ReadAllLines(filePath);
        var snippetLines = new List<string>();
        bool inSnippet = false;
        
        // Look for snippet markers like <snippet1> or <Snippet1> (case insensitive)
        var startMarker = $"<{snippetId.ToLower()}>";
        var endMarker = $"</{snippetId.ToLower()}>";
        
        foreach (var line in lines)
        {
            var lowerLine = line.ToLower();
            
            if (lowerLine.Contains(startMarker))
            {
                inSnippet = true;
                continue;
            }
            
            if (lowerLine.Contains(endMarker))
            {
                inSnippet = false;
                break;
            }
            
            if (inSnippet)
            {
                snippetLines.Add(line);
            }
        }

        return string.Join(Environment.NewLine, snippetLines);
    }

    private string? AnalyzeIntroductionMatch(string introduction, string snippetContent, SnippetReference snippetRef)
    {
        if (string.IsNullOrWhiteSpace(introduction) || string.IsNullOrWhiteSpace(snippetContent))
        {
            return null; // Can't analyze without content
        }

        var issues = new List<string>();
        
        // Basic checks for common mismatches
        var introLower = introduction.ToLower();
        var contentLower = snippetContent.ToLower();

        // Check if introduction mentions specific classes that aren't in the snippet
        var classMatches = Regex.Matches(introLower, @"\b(\w+)\s+class\b");
        foreach (Match match in classMatches)
        {
            var className = match.Groups[1].Value;
            if (!contentLower.Contains(className.ToLower()) && className != "system")
            {
                issues.Add($"Introduction mentions '{className}' class but it's not found in snippet");
            }
        }

        // Check for specific method mentions in introductions - more precise parsing
        var methodMatches = Regex.Matches(introduction, @"<xref:[\w\.]+\.(\w+)(?:%2A|\(\))?[^>]*>");
        foreach (Match match in methodMatches)
        {
            var methodName = match.Groups[1].Value.ToLower();
            // Skip very generic terms
            if (methodName == "system" || methodName == "media" || methodName == "soundplayer")
                continue;
                
            if (!contentLower.Contains(methodName))
            {
                // Check for reasonable alternatives (e.g., event handlers)
                var alternativeFound = false;
                if (methodName.Contains("load") && contentLower.Contains("load"))
                    alternativeFound = true;
                if (methodName.Contains("play") && contentLower.Contains("play"))
                    alternativeFound = true;
                    
                if (!alternativeFound)
                {
                    issues.Add($"Introduction mentions method '{methodName}' but it's not found in snippet");
                }
            }
        }

        // Check for clear async/sync mismatches
        if (introLower.Contains("asynchronously") && !contentLower.Contains("async") && !contentLower.Contains("loadcompleted"))
        {
            issues.Add("Introduction mentions asynchronous operations but no async code found in snippet");
        }

        if (introLower.Contains("synchronously") && (contentLower.Contains("async") && !contentLower.Contains("playsync")))
        {
            issues.Add("Introduction mentions synchronous operations but snippet contains async code");
        }

        // Check for very specific mismatches
        if (introLower.Contains("loadasync") && contentLower.Contains("player.load()") && !contentLower.Contains("loadasync"))
        {
            issues.Add("Introduction mentions LoadAsync but snippet uses synchronous Load method");
        }

        if (introLower.Contains("playsync") && contentLower.Contains("loadasync") && !contentLower.Contains("playsync"))
        {
            issues.Add("Introduction mentions PlaySync but snippet contains async loading code");
        }

        return issues.Any() ? string.Join("; ", issues) : null;
    }
}