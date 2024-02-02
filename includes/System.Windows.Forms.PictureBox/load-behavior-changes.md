Starting with .NET 8, the behavior of how a `PictureBox` control loads a remote image changed. By default, the <xref:System.Net.ServicePointManager.CheckCertificateRevocationList?displayProperty=fullName> property is set to `true` before a remote image is downloaded through <xref:System.Net.WebClient>. This setting ensures that servers with certificates have those certificates checked against the certificate authority revocation list (CRL) as part of the validation process.

> [!WARNING]
> As soon as a remote image is loaded, `CheckCertificateRevocationList` is changed to `true` for the lifetime of the app. You can revert back to `false` manually if required, but as soon as another remote image is loaded, `CheckCertificateRevocationList` is set to `true`.

A previously working remote resource might fail to load when the locally cached CRL is out-of-date and an update can't be retrieved. This can happen when the network the app is running on is restricted and the CRL location isn't on the allowlist.

It's also possible that the delay in checking the CRL negatively affects the app's ability to function.

You can opt out of this behavior by setting the `System.Windows.Forms.ServicePointManagerCheckCrl` option for the app, in one of the following ways:

- Set the property to `false` in the [_\[app\].runtimeconfig.json_](/dotnet/core/runtime-config/#runtimeconfigjson) configuration file:

  ```json
  {
    "configProperties": {
      "System.Windows.Forms.ServicePointManagerCheckCrl": false
    }
  }
  ```

- Add a `<RuntimeHostConfigurationOption>` item in the project file to disable it:

  ```xml
  <ItemGroup>
    <RuntimeHostConfigurationOption Include="System.Windows.Forms.ServicePointManagerCheckCrl" Value="false" />
  </ItemGroup>
  ```
