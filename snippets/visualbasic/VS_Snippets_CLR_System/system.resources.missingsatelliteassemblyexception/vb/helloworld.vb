﻿' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Resources
Imports System.Threading

<assembly:NeutralResourcesLanguageAttribute("en", UltimateResourceFallbackLocation.Satellite)>

Module Example
   Public Sub Main()
      Dim rm As New ResourceManager("GreetResources", GetType(Example).Assembly) 
      Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR")
      Console.WriteLine("The current UI culture is {0}", Thread.CurrentThread.CurrentUICulture.Name)
      Console.WriteLine(rm.GetString("Greet"))
      
      Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-RU")
      Console.WriteLine("The current UI culture is {0}", Thread.CurrentThread.CurrentUICulture.Name)
      Console.WriteLine(rm.GetString("Greet"))
   End Sub
End Module
' The example displays the following output:
'    The current UI culture is fr-FR
'    Bonjour
'    The current UI culture is ru-RU
'    
'    Unhandled Exception: System.Resources.MissingSatelliteAssemblyException: 
'    The satellite assembly named "HelloWorld.resources.dll, PublicKeyToken=" for fallback culture 
'    "en" either could not be found or could not be loaded. This is generally a setup problem. 
'    Please consider reinstalling or repairing the application.
'       at System.Resources.ManifestBasedResourceGroveler.HandleSatelliteMissing()
'       at System.Resources.ManifestBasedResourceGroveler.GrovelForResourceSet(CultureInfo cult
'    ure, Dictionary`2 localResourceSets, Boolean tryParents, Boolean createIfNotExists, StackC
'    rawlMark& stackMark)
'       at System.Resources.ResourceManager.InternalGetResourceSet(CultureInfo requestedCulture
'    , Boolean createIfNotExists, Boolean tryParents, StackCrawlMark& stackMark)
'       at System.Resources.ResourceManager.InternalGetResourceSet(CultureInfo culture, Boolean
'     createIfNotExists, Boolean tryParents)
'       at System.Resources.ResourceManager.GetString(String name, CultureInfo culture)
'       at Example.Main()
' The example displays the following output when created using BuildDefault.bat:
'    The current UI culture is fr-FR
'    Bonjour
'    The current UI culture is ru-RU
'    Hello
' </Snippet1>   
