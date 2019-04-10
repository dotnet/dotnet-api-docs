# Return Value Subsection

The Return Value subsection describes the return value of a method or operator.

## Guidelines

DxEditor displays a Return Value section automatically for methods that return values. After the **returnValue** tag, add a paragraph that describes the return value.

- Provide a clear description of the return value. Keep the description concise, but provide enough context to make it meaningful.
- Use wording that is programming language-neutral.
- In the description, refer to the method's parameters by name if it's helpful. Because the Return Value section appears right below the parameters, it's easy for users to refer back to parameter names if they're unclear.
- In Return Value descriptions for overloaded members, differentiate between the overloads if necessary. For example, the return value for the **String.Format** method that accepts an array of objects is this: "A copy of *format* in which the format items have been replaced by the string representations of the corresponding objects in the *args* array." The overload that accepts three objects is differentiated in the return value description as follows: "A copy of *format* in which the format items have been replaced by the string representations of *art0*, *arg1*, and *arg2*."
- Don't include a link to the return value type, because that's added by the build, but you can specify the type in plain text (for example, "a 32-bit signed integer" for a **System.Int32** object). For Boolean, enum, and array return types, follow the phrasing guidelines in [Return Value: Method Topics (DevDiv Style Guide)](#method-topics).
- If you need to document multiple return values that cannot be described in a single paragraph, use a table with the headings "Return value" and "Description". Introduce the table with the sentence "One of the following values:".
- Do not bury important information about the return value in Remarks. Include it in the description, but point to Remarks for a lengthier discussion if necessary.

## How-To

When a method returns a value, you can use DxReflector to add a Return Value section for the method. </p><p xmlns="">

The guidelines for writing return value descriptions depend on whether you are documenting a method or an operator, and on the type that is returned. Write a description of each return value, using the wording shown in the tables in the following sections.

- [Return Value: Method Topics (DevDiv Style Guide)](#method-topics)
- [Return Value: Operator Topics (DevDiv Style Guide)](#operator-topics)

## Method Topics

The following table shows the boilerplate wording for return value descriptions within method topics. The wording varies according to the type that is returned.

| Return type | Wording | Examples |
|-------------|---------|----------|
| Class, interface, or structure | &lt;*Noun phrase description without specifying the data type. Begin with an introductory article.*&gt;
  > [!NOTE]
  > If the abstraction is not clear from the context, you can use the wording "An object that identifies/specifies/contains *XXX*." However, avoid this unless there is no other way to describe the return value. | Type: **System.Threading.Thread**<br />The new thread. <br />Type: **System.IAsyncResult**<br />The posted asynchronous request. |
| Flag enum | A bitwise combination of the enumeration values &lt;*additional information, if necessary*&gt;. | Type: **System.IO.FileAccess**<br />A bitwise combination of the enumeration values. |
| Other enum | One of the enumeration values &lt;*additional information, if necessary*&gt;. | Type: **System.Windows.Forms.DialogResult**<br />One of the enumeration values that indicates the return value of a dialog box. |
| Boolean | **true** if *XXX*; otherwise, **false**.<br />**true** if *XXX*; **false** if *XXX*.
  > [!NOTE]
  > Use the "otherwise" wording unless the second condition must be noted explicitly.

  > [!NOTE]
  > The wording for Boolean return values is "**true** if...," not "**true** to...." (The wording "**true** to...." is for parameters.) | Type:** System.Boolean**<br />**true** if the specified path refers to a file; otherwise, **false**. <br /><br />Type:** System.Boolean**<br />**true** if the enumerator was successfully advanced to the next element; **false** if the enumerator has passed the end of the collection.<br /><br />For **ShouldSerialize***&lt;Property&gt;* methods, use this phrasing:<br />Type:** System.Boolean**<br />**true** if the **InputBindings** property value should be serialized; otherwise, **false**. | 
| Other primitive or string | &lt;*Noun phrase description, without specifying the data type. Begin with an introductory article.*&gt; | Type: **System.String**<br />The string being read.<br />Type: **System.Int32**<br />The hash code for the current **SortDescription** object. |
| Array | An array *XXX*. | Type: **System.Reflection.FieldInfo()**<br />An array that contains the fields implemented by a type.

## Operator Topics

The following table shows the boilerplate wording for return value descriptions within operator topics. The wording varies according to the operator type.

| Operator type | Return value wording | Examples |
|---------------|----------------------|----------|
| Unary/binary operator | A/The *&lt;generic description of type&gt;*. | Type: **System.Windows.Point**<br />The point to translate. |
| Conversion operator | A/The *&lt;generic description of type&gt;* that represents the converted *&lt;Type&gt;*. | Type:****System.Single**<br />The single-precision floating-point number that represents the converted **Decimal**.<br />(You can also say:<br />The converted **Decimal**.) |

> [!NOTE]
> If any of the return types in an operator is a primitive type, use the language-neutral phrase for it. For more information, see Primitive Data Types