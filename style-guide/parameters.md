# Parameters Subsection

The Parameters subsection lists and describes each parameter in the declaration.

## Guidelines

docs.microsoft.com displays a Parameters section automatically if it's required.

- Include an accurate description of what should be passed for the parameter. When you write this description, think about how the parameter is used by the method.
- Don't include a link to the parameter type, because that's added by the build, but you can specify the type in plain text (for example, "a string" for a **System.String** object). This reference should be programming language-neutral.
- Keep the description concise, but provide enough context to make it meaningful. Don't just repeat the parameter name. For example, a *length* parameter for an operation that sets the length of a stream could be described like this: "The desired length of the current stream, in bytes." Avoid meaningless descriptions like this: "The length."
- Include important information such as which enumeration values are supported, whether the value can be null, the unit of measurement, if applicable, and the default value, if one exists. For example: the *bufferSize* parameter for the **System.IO.Stream.CopyTo (Stream, Int32)** method has the following description:<br /><br />*bufferSize*<br />
          Type: System.Int32<br />          The size of the buffer, in bytes. This value must be greater than zero. The default size is 4096.<br />
- Do not bury important information about the parameter in Remarks. Include it in the parameter description, but point to Remarks for a lengthier discussion if necessary.

## How-To

docs.microsoft.com automatically populates the Parameter column of the Parameters table with the name of each parameter, and applies the correct style. However, be sure to apply the **parameterReference** tag to other occurrences of parameter names throughout the documentation, including the Description column in the table.

The guidelines for writing parameter descriptions depend on the kind of type or member that you are documenting, as well as on the type of the parameter itself. Write a description of each parameter, using the wording shown in the tables in the following sections. The sections and tables are organized by topic type.

- [Parameters: Method and Constructor Topics](#method-and-constructor-topics)
- [Parameters: On&lt;Event&gt; Method Topics](#on-event-method-topics)
- [Parameters: Dispose(Boolean) Method Topics](#dispose-boolean-method-topics)
- [Parameters: Event-Handler Delegate Topics](#event-handler-delegate-topics)
- [Parameters: Operator Topics](#operator-topics)

For the phrasing to use for type parameters, see the Type Parameters Subsection.

## Method and Constructor Topics

The following table shows the boilerplate wording for parameter descriptions within most method and constructor topics. The wording varies according to the parameter type. **On&lt;***Event***&gt;** methods and **Dispose(Boolean)** methods have their own specific boilerplate wording, shown in the two topics following this one.

For general guidelines for writing parameter descriptions, see [Parameters Subsection](#parameters-subsection).

> [!NOTE]
> If the type of a parameter is a primitive or string, and you want to refer to it in a generic way, use the language-neutral phrase for it. For more information, see Primitive Data Types.

| Parameter type | Wording | Examples |
|----------------|---------|----------|
| Class, interface, or structure | &lt;*Noun phrase description, without specifying the data type. Begin with an introductory article.*&gt;<br /> **Note:**<br />If the abstraction is not clear from the context, you can use the wording "An object that identifies/specifies/contains *XXX*." However, avoid this unless there is no other way to describe the parameter. | *p*<br />Type: **System.Drawing.Point**<br />The dimensions of the control. <br />*value*<br />Type: **System.Windows.Forms.IMessageFilter**<br />The message filter to remove from the message pump.<br />*credentials*<br />Type: **System.Net.ICredentials**<br />The credentials associated with the authentication request. |
| Flag enum | A bitwise combination of the enumeration values &lt;*additional information, if necessary*&gt;. | *options*<br />Type: **System.Windows.Forms.RichTextBoxFinds**<br />A bitwise combination of the enumeration values that specify how the search is performed. |
| Other enum | One of the enumeration values &lt;*additional information, if necessary*&gt;.<br /> **Note:**<br />If some of the enumeration values are not valid, include that information in the description. |
| *textAlign*<br />Type: **System.Windows.Forms.HorizontalAlignment**<br />One of the enumeration values that specifies how text is aligned in the control. In a single-line **TextBox** control, only **HorizontalAlignment.Left** is valid. |
| Boolean<br /> **Note:**<br />There is special boilerplate wording for parameters of **Dispose(Boolean)** methods. For more information, see [Parameters: Dispose(Boolean) Method Topics](#dispose-boolean-method-topics). | **true** to *XXX*; otherwise, **false**. <br />**true** to *XXX*; **false** to *XXX*.<br /> **Note:**<br />Use the "otherwise" wording unless the second condition must be noted explicitly.<br /> **Note:**<br />The wording for Boolean parameters is "**true** to...," not "**true** if...." | *includePrompt*<br />Type: **System.Boolean**<br />**true** to include prompt characters in the return string; otherwise, **false**. <br /><br />*isChecking*<br />Type: **System.Boolean**<br />**true** to indicate that the object can be frozen (without freezing it); **false** to actually freeze the object. |
| Other primitive or string | &lt;*Noun phrase description, without specifying the data type. Begin with an introductory article.*&gt; | *width*<br />Type: **System.Int32**<br />The width of the control.<br />*fileName*<br />Type: **System.String**<br />The name of an application file to run in the process. |
| Integer parameter of an indexer | The zero-based index of *XXX*. | *rowIndex*<br />Type: **System.Int32**<br />The zero-based index of the row that contains the value. |
| Array | An array *XXX*. | *value*<br />Type: **System.CodeDom.Compiler.CompilerError()**<br />An array that contains the compiler errors to add to the collection. |
| **ref** parameter | The &lt;*generic description of what the parameter does or represents*&gt;, passed by reference.  | *remoteEP*<br />Type: **System.Net.EndPoint**<br />The remote server, passed by reference. |
| **out** parameter | When this method returns, contains a &lt;*generic description of type*&gt; that &lt;*description of what the parameter does or represents*&gt;. This parameter is treated as uninitialized. <br />**Note**Â Â Â If the abstraction is not clear from the context, you can use "an object" instead of &lt;*generic description of type*&gt;. However, avoid this unless there is no other way to describe the parameter. | *responseStream*<br />Type: **System.IO.Stream**<br />When this method returns, contains a stream that is heading back toward the transport sink. This parameter is treated as uninitialized.

## On&lt;Event&gt; Method Topics

The following table shows the boilerplate wording for parameter descriptions within **On***&lt;Event&gt;* method topics. **On***&lt;Event&gt;* methods always have a parameter of type **EventArgs**, typically named *e*.

For general guidelines for writing parameter descriptions, see [Parameters Subsection](#parameters-subsection).

| Parameter type | Wording | Example |
|----------------|---------|---------|
| **EventArgs** | The data for the event. | *e*<<br />Type: **System.Windows.Forms.TreeViewEventArgs**<<br />The data for the event. |

## Dispose(Boolean) Method Topics

The following table shows the boilerplate wording for parameter descriptions within **Dispose(Boolean)** method topics. Boolean **Dispose** methods typically have a parameter named *disposing*; describe it as shown in the table.

For general guidelines for writing parameter descriptions, see [Parameters Subsection](#parameters-subsection).

| Parameter | Wording | Example |
|----------------|---------|---------|
| *disposing* | **true** to release managed and unmanaged resources; **false** to release only unmanaged resources. | *disposing*<<br />Type:*** *System.Boolean**<<br />**true** to release managed and unmanaged resources; **false** to release only unmanaged resources. |

## Event-Handler Delegate Topics

The following table shows the boilerplate wording for parameter descriptions within event-handler delegate topics. Event-handler delegates typically have two parameters named *sender* (of type **Object**) and *e* (of type **EventArgs**). Describe them using the wording in the following table.

For general guidelines for writing parameter descriptions, see [Parameters Subsection](#parameters-subsection).

| Parameter | Wording | Example |
|----------------|---------|---------|
| *sender* | The source of the event. | *sender*<br />Type: **System.Object**<br />The source of the event. |
| *e* | The data for the event. | *e*<br />Type: **System.AssemblyLoadEventArgs**<br />The data for the event. |

## Operator Topics

The following table shows the boilerplate wording for parameter descriptions within operator topics. The wording varies according to the operator type.

For general guidelines for writing parameter descriptions, see [Parameters Subsection](#parameters-subsection).

| Operator type | Parameter Wording | Example |
|---------------|-------------------|---------|
| Unary/binary | A/The *&lt;generic description of type&gt;* to XXX. | *unit*<br />Type: **System.Web.UI.WebControls.Unit**<br />The length measurement to add. |
| Conversion operator | A/The *&lt;generic description of type&gt;* to convert. | *value*<br />Type: **System.Double**<br />The double-precision floating-point number to convert.<br />(You can also shorten this to: <br />The number to convert.) |

> [!NOTE]
> If any of the parameter types in an operator is a primitive, use the language-neutral phrase for it. For more information, see Primitive Data Types.
