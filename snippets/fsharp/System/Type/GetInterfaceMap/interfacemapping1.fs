// <Snippet1>
open System
open System.Globalization

let showInterfaceMapping (intType: Type) (implType: Type) =
    let map = implType.GetInterfaceMap intType
    printfn $"Mapping of {map.InterfaceType} to {map.TargetType}: "
    for i = 0 to map.InterfaceMethods.Length - 1 do
        let im = map.InterfaceMethods[i]
        let tm = map.TargetMethods[i]
        printfn $"   {im.Name} --> {tm.Name}"
    printfn ""

let interf = [| typeof<IFormatProvider>; typeof<IAppDomainSetup> |]
let impl = [| typeof<CultureInfo>; typeof<AppDomainSetup> |]

for i = 0 to interf.Length - 1 do
    showInterfaceMapping interf[i] impl[i]

// The example displays the following output:
//    Mapping of System.IFormatProvider to System.Globalization.CultureInfo:
//       GetFormat --> GetFormat
//
//    Mapping of System.IAppDomainSetup to System.AppDomainSetup:
//       get_ApplicationBase --> get_ApplicationBase
//       set_ApplicationBase --> set_ApplicationBase
//       get_ApplicationName --> get_ApplicationName
//       set_ApplicationName --> set_ApplicationName
//       get_CachePath --> get_CachePath
//       set_CachePath --> set_CachePath
//       get_ConfigurationFile --> get_ConfigurationFile
//       set_ConfigurationFile --> set_ConfigurationFile
//       get_DynamicBase --> get_DynamicBase
//       set_DynamicBase --> set_DynamicBase
//       get_LicenseFile --> get_LicenseFile
//       set_LicenseFile --> set_LicenseFile
//       get_PrivateBinPath --> get_PrivateBinPath
//       set_PrivateBinPath --> set_PrivateBinPath
//       get_PrivateBinPathProbe --> get_PrivateBinPathProbe
//       set_PrivateBinPathProbe --> set_PrivateBinPathProbe
//       get_ShadowCopyDirectories --> get_ShadowCopyDirectories
//       set_ShadowCopyDirectories --> set_ShadowCopyDirectories
//       get_ShadowCopyFiles --> get_ShadowCopyFiles
//       set_ShadowCopyFiles --> set_ShadowCopyFiles
// </Snippet1>