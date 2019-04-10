# Property Value Subsection

The Property Value subsection describes the value of a property. 

## Guidelines

In DxEditor, use the Return Value section (**returnValue** tag) for the property value description; DxEditor doesn't have a special tag for this subsection.

- Provide a clear description of the property value. Keep the description concise, but provide enough context.
- Use wording that is programming language-neutral.
- If the property type is an enum member, briefly specify what the enum defines. The wording should distinguish between single enum values and flag enums, as shown in the following table.
- If the property type is an array, indicate what the array contains.
- If there is a default value that the user should be aware of, describe it in a second sentence.
- Include measurement units (for example, "in bytes" or "in pixels") if applicable.
- Don't include a link to the property value type in your descriptions. The build tools include this link automatically.
- Do not bury important information about the property value in Remarks. Include it in the description, but point to Remarks for a lengthier discussion if necessary.

The following table shows the boilerplate wording for property value descriptions. The wording varies according to the property type.

| Property type | Wording | Examples |
|---------------|---------|----------|
| Class, interface, or structure | A/An/The &lt;*description, without specifying the data type*&gt;. The default is *default value*.
  > [!NOTE]
  > Information the user should notice even if skimmingIf the abstraction is not clear from the context, you can use the wording "An object that identifies/specifies/contains...". However, avoid this unless there is no other way to describe the property value. | Type: **System.Windows.Forms.Cursor**<br />The current default cursor.<br />Type: **System.Net.ICredentials**<br />The authentication credentials associated with this request. The default is **null**. |
| Flag enum | A bitwise combination of the enumeration values that &lt;*additional information*&gt;. The default is *&lt;EnumMember&gt;*. | Type: **System.AppDomainManagerInitializationOptions**<br />A bitwise combination of the enumeration values that describe the initialization action to perform. The default is **None**.<br />*Example of flag enum with a combination of default values:*<br />Type: **System.IO.NotifyFilters**<br />A bitwise combination of the enumeration values that specify the changes. The default is the bitwise OR combination of **NotifyFilters.LastWrite**, **NotifyFilters.FileName**, and **NotifyFilters.DirectoryName**. | 
| Other enum | One of the enumeration values that &lt;*additional information*&gt;. The default is *&lt;EnumMember&gt;*. | Type: **System.Windows.Forms.BorderStyle**<br />One of the enumeration values that specifies the border style for a control. The default is **BorderStyle.FixedSingle**. |
| Boolean</p></td><td><p>**true** if XXX; otherwise, **false**. The default is XXX. <br />**true** if XXX; **false** if XXX. The default is XXX.<br />&lt;**true**/**false**&gt; in all cases.
  > [!NOTE]
  > Use the "otherwise" wording unless the second condition must be noted explicitly.

  > [!NOTE]
  > The wording for Boolean property values is "true if...," not "true to...." (The wording "true to...." is for parameters.) | | Type: **System.Boolean**<br />**true** if rows can be deleted from the grid; otherwise, **false**. The default is **true**. <br />Type: **System.Boolean**<br />**true** if the stream supports writing; **false** if the stream is closed or was opened with read-only access. The default is **true**.<br />Type: **System.Boolean**<br />**false** in all cases. |
| Other primitive or string | &lt;*Noun phrase description, without specifying the data type.*&gt; The default is XXX. | Type: **System.Int32**<br />The width, in pixels, of the columns in the grid. The default is 75. |
| Array | An array that contains *XXX*. | Type: **System.Attribute()**<br />An array that contains the attributes of this member.<br />Type: **System.Byte()**<br />An array that contains the originator of the key pair.