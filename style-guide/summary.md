# Summary Section

The summary succinctly states what a type or member does or represents. All types and members must have summaries, consisting of a short description (optimally one sentence) that conveys the importance of the class or member.

## Guidelines

Begin with a present-tense, third-person verb, except for exception classes, enum members, abstract members, and virtual members (see the links in the next section).

- Do not merely repeat the wording of the member name in the summary; provide a meaningful description and context. For example, instead of describing the **String.Format** method by saying *Formats a string*, you can use a description like this: *Replaces each format item in a specified string with the string representation of a specified object.*
- Use programming language-neutral text. For example, don't include Visual Basic or C#-specific terms in your summary.
- Avoid using special formatting such as lists that might cause problems for IntelliSense builds.
- Avoid using parameter names or self-referential type or member names in the summary. There are exceptions; for example, you can use the type name in summaries for constructors and for dispose methods.
- For overloaded constructors and methods, provide a general summary that is broad enough to apply to all the overloads, and write more specific summaries for the individual overloads. For the individual overloads, use wording that differentiates each overload from the others, and provide enough information to help users select the overload they'd like to call.

## Wording for specific types and members

The wording for Summary sections varies according to the type or member that you are documenting, as described in these topics:

- [Class Topics](#class-topics)
- [Constructor Topics](#constructor-topics)
- [Enum Topics](#enum-topics)
- [Event-related Topics](#event-related-topics)
- [Field Topics](#field-topics)
- [Abstract and Virtual Member Topics](#abstract-and-virtual-member-topics)
- [Method Topics](#method-topics)
- [Operator Topics](#operator-topics)
- [Property Topics](#property-topics)
- [Overloaded Member Topics](#overloaded-member-topics)

## Class Topics

The following table provides wording guidelines, boilerplate text, and examples of Summary sections in class topics. For event-related classes, such as **EventArgs** and event-handler delegates, see [Summary: Event-Related Topics](#event-related-topics).

| Item | Wording | Examples |
|------|---------|----------|
| General class, interface, or structure | &lt;Begin with a present-tense third-person verb.&gt; | ***DataGrid*** *class summary:*<br />Displays XDO data in a scrollable grid.<br />***TimeSpan*** *structure summary*:<br />Represents a time interval. |
| Interface | Defines...,   or Provides..,. or Exposes... | ***IComparable*** *interface summary*:<br />Defines a generalized type-specific comparison method that a value type or class implements to order or sort its instances.<br />***IFormattable*** *interface summary*:<br />Provides functionality to format the value of an object into a string representation. |
| Abstract base class | Defines the core behavior of *&lt;class name or feature&gt;* and provides a base for *&lt;derived classes or derivations&gt;*.  | ***BaseNotificationEventType*** *class summary:*<br />Defines the core behavior of notification events and provides a base for derived classes.<br />***MessageQuery*** *class summary*:<br />Defines the core behavior of classes that are used to search for specific correlating data in a message. |
| Class that represents a standard Windows control (for example, a button or check box) | Represents a Windows *&lt;control&gt;* control. | ***Windows.Forms.Button*** *class*<br />Represents a Windows button control. |
| Exception class | The exception that is thrown when/for/by *&lt;condition&gt;*.<br /> **Note:**<br />This summary does not begin with a verb. |
| ***ArgumentOutOfRangeException*** * class summary: *<br />The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.<br />***ComponentModel.Win32Exception*** *class summary:*<br />The exception that is thrown for a Win32 error code.<br />***Reflection.TargetInvocationException*** * class summary:*<br />The exception that is thrown by methods invoked through reflection. |

## Constructor Topics

The following table provides wording guidelines and boilerplate text for Summary sections in constructor topics. For guidelines on documenting overloaded constructors, see [Summary: Overloaded Member Topics](#overloaded-member-topics).

| Item | Wording | Examples |
|------|---------|----------|
| Constructor, class | Initializes a new instance of the *&lt;Class&gt;* class. | **WebProxy** *constructor summary:*<br />Initializes a new instance of the **WebProxy** class. |
| Constructor, abstract class | Called from constructors in derived classes to initialize the *&lt;Class&gt;* class. | **Aes***constructor summary:*<br />Called from constructors in derived classes to initialize the **Aes** class. |
| Constructor, struct | Initializes a new instance of the *&lt;Struct&gt;* structure. | **SqlInt64** *constructor summary:*<br />Initializes a new instance of the **SqlInt64** structure using the supplied long integer. |

## Enum Topics

The following table provides wording guidelines and boilerplate text for Summary sections in enum and enum member topics.

| Item | Wording | Examples |
|------|---------|----------|
| Enum | &lt;Begin with a present-tense third-person verb, such as *Specifies* or *Describes*.&gt;  | ***FormBorderStyle*** *enum summary:*<br />Specifies the border styles for a form.<br />***MouseButtons*** *enum summary:*<br />Specifies constants that define which mouse button was pressed. |
| Enum member | &lt;Noun phrase. Begin with an introductory article, if appropriate.&gt; | ***BorderStyle.FixedSingle*** *enum member summary:*<br />A single-line border. |
| Enum member used as a mask | A mask used to retrieve &lt;noun phrase&gt;.<br /> **Note:**<br />If the enum member will be used as a mask, call this out, and specify the information to be retrieved using the mask. | ***MethodAttributes.MemberAccessMask*** *enum member summary:*<br />A mask used to retrieve the scope of a method. |

## Event-related Topics

The following table provides wording guidelines and boilerplate text for Summary sections in event and event-related class topics.

| Item | Wording | Examples |
|------|---------|----------|
| Event | Occurs when *&lt;condition&gt;*.  | **Click** event summary:<br />Occurs when the user clicks the control. |
| &lt;EventArgs&gt; class | Provides data for the *&lt;Event&gt;* event. | **ComponentRenameEventArgs** class summary:<br />Provides data for the **ComponentRename** event. |
| Event-handler delegate class, specific to one event on a control | Represents the callback method that will handle the *&lt;Event&gt;* event of a *&lt;Class&gt;*. | **PeekCompletedEventHandler** delegate summary:<br />Represents the callback method that will handle the **PeekCompleted** event of a **MessageQueue**. |
| Event-handler delegate class, specific to multiple events on a control | Represents the callback method that will handle the *&lt;Event1&gt;* event, *&lt;Event2&gt;* event, or *&lt;Event3&gt;* event of a *&lt;Class&gt;*. | **PrintEventHandler** delegate summary:<br />Represents the callback method that will handle the **BeginPrint** event or **EndPrint** event of a **PrintDocument**. |
| Event-handler delegate class, specific to one event on multiple controls | Represents the callback method that will handle the *&lt;Event&gt;* event of a *&lt;Class1&gt;* or a *&lt;Class2&gt;*. | ***MeasureItemEventHandler*** *delegate summary:*<br />Represents the callback method that will handle the **MeasureItem** event of a **ListBox**, **ComboBox**, **CheckedListBox**, or **MenuItem** control. |
| Event-handler delegate class, generic | Represents the callback method that will handle an event of a control. | ***EventHandler Generic*** *delegate summary*<br />Represents the callback method that will handle the event.</p></td></tr><tr><td><p>**On***&lt;Event&gt;* method | Raises the *&lt;Event&gt;* event.<br /> **Note:**<br />In some cases, such as the **WebPart** class, a method named **On***EventName* might not raise the *EventName* event. For example, **WebPart** defines four methods named **OnClosing**, **OnConnectModeChanged**, **OnDeleting**, and **OnEditModeChanged**. Derived classes override these methods and provide special handling for the state transitions named by the methods. Thus, the description of the **OnClosing** method reads, "*Enables derived classes to provide custom handling when* a **WebPart** control is closed on a Web Parts page." The phrase in italics is the appropriate pattern for such summaries. <br />Because this naming pattern violates .NET Framework naming guidelines, the writer should raise the naming issue in the design phase, if the opportunity arises. A name such as **ClosingNotification** or **ClosingCallback** would be more appropriate in this scenario.<br />Other special cases in WPF and Silverlight content use either "Provides class handling for the *EventName* routed eventâ€¦" or "Called before the *EventName* event occurs" for the summary.<p></p></td></tr></table><p></p></div></td><td><p>***Control.OnBackgroundImageChanged*** * method summary: *<br />Raises the **BackgroundImageChanged** event. |

## Field Topics

The following table provides wording guidelines and boilerplate text for Summary sections in field topics.

| Item | Wording | Examples |
|------|---------|----------|
| Field | &lt;Begin with a present-tense third-person verb, such as *Specifies* or *Represents*.&gt; | ***MessageBox.YesNo*** * summary:*<br />Specifies that the message box should display Yes and No buttons.<br />***Registry.CLASSES_ROOT*** * summary:*<br />Represents the HKEY_CLASSES_ROOT registry key. |

## Abstract and Virtual Member Topics

The following table provides wording guidelines and boilerplate text for Summary sections for abstract and virtual members of abstract classes.

| Item | Wording | Examples |
|------|---------|----------|
| Abstract member of an abstract class | When overridden in a derived class, &lt;continue with a present-tense third-person verb stating what the member does&gt;. | ***XmlWriter.Close*** *member summary:*<br />When overridden in a derived class, closes this stream and the underlying stream. |
| Virtual member of an abstract class that does not provide the intended implementation | When overridden in a derived class, &lt;continue with a present-tense third-person verb stating what the member does&gt;.<br /> **Note:**<br />In the Remarks section, include a sentence that explains the default, unintended behavior. | ***Stream.ReadByte*** * summary: *<br />When overridden in a derived class, reads the next byte from this stream, and advances the current position of the stream by one.<br />*Include the following in *** *Stream.ReadByte*** *remarks:*<br />Because the **Stream** class does not support reading, **ReadByte** throws a **NotSupportedException** exception by default. |

## Method Topics

The following table provides wording guidelines and boilerplate text for Summary sections in method topics. For guidelines about **On***&lt;Event&gt;* methods, see [Summary: Event-Related Topics](#event-lrelated-topics). For guidelines about documenting overloaded methods, see [Summary: Overloaded Member Topics](#overloaded-member-topics).

| Item | Wording | Examples |
|------|---------|----------|
| General method  | &lt;Begin with a present-tense third-person verb.&gt; | ***DataGrid*** * class summary: *<br />Displays XDO data in a scrollable grid.<br />***Application.DoEvents*** * method summary:*<br />Processes Windows messages that are currently in the message queue. |
| **Dispose** method, general overload | Releases the resources used by the current instance of the **&lt;class&gt;** class. | ***ComponentDesigner.Dispose*** *method summary:*<br />Releases the resources used by the current instance of the **ComponentDesigner** class. |
| **Dispose()** method | Releases the resources used by the current instance of the **&lt;class&gt;** class. | ***Timer.Dispose*** *method summary:*<br />Releases the resources used by the current instance of the **Timer** class. |
| **Dispose(Boolean)** method | Called by the **Dispose()** and **Finalize()** methods to release the managed and unmanaged resources used by the current instance of the **&lt;class&gt;** class.  | ***DocumentDesigner.Dispose*** *method (Boolean):*<br />Called by the **Dispose()** and **Finalize()** methods to release the managed and unmanaged resources used by the current instance of the **DocumentDesigner** class. |
| **ShouldSerialize** *&lt;Property&gt;* method | Indicates whether the *&lt;Property&gt;* property should be persisted. | ***DataGrid.ShouldSerializeBackgroundColor*** *method summary:*<br />Indicates whether the **BackgroundColor** property should be persisted. |
| **Reset***&lt;Property&gt;* method | Resets the *&lt;Property&gt;* property to its default value. | ***Control.ResetText*** *method summary:*<br />Resets the **Text** property to its default value. |
| Method that always throws an exception | Throws a/an *&lt;ExceptionType&gt;* exception in all cases.<br /> **Note:**<br />In the Remarks section, explain why the member is not supported. |
| ***DataGridViewSelectedRowCollection.Clear*** *method summary:*<br />Throws a **NotSupportedException** exception in all cases. |
| Explicit interface method implementation | &lt;Copy from the interface member if appropriate&gt; |

## Operator Topics

The following table provides wording guidelines and boilerplate text for Summary sections in operator topics. For guidelines about documenting overloaded operators, see [Summary: Overloaded Member Topics](#overloaded-member-topics).

| Item | Wording | Examples |
|------|---------|----------|
| Unary/binary operator; for example, + operator | &lt;Begin with a present-tense verb.&gt; | ***Unit*** *+ operator summary:*<br />Adds a value to a **Unit**. |
| Conversion operator | Converts a *&lt;Type&gt;* to a *&lt;Type&gt;*.<br /> **Note:**<br />If one type is a primitive, use the language-neutral phrase for it. | *Decimal to 32-bit integer conversion summary:*<br />Converts a decimal to a 32-bit signed integer. |

## Property Topics

The following table provides wording guidelines and boilerplate text for Summary sections in property topics.

> [!NOTE]
> An indexer is the C# term for an indexed property. An indexer takes a parameter that indexes the value of the property. In C#, an indexer is defined with the **this** keyword. For example: `public string this[int index]`. In Visual Basic, an indexer is equivalent to a default indexed property named Item.

| Item | Wording | Examples |
|------|---------|----------|
| Read/write property or indexer | *Boolean:*<br />Gets or sets a value that indicates whether *&lt;condition&gt;*.<br />*Other:*<br />Gets or sets *&lt;summary without specifying the type&gt;*.  | ***Control.AllowDrop*** * property summary: *<br />Gets or sets a value that indicates whether the control can accept data that the user drags onto it.<br />***Control.BackColor*** * property summary:*<br />Gets or sets the background color for the control. |
| Read-only property or indexer | *Boolean:*<br />Gets a value that indicates whether *&lt;condition&gt;*.<br />Other:<br />Gets *&lt;summary without specifying the type&gt;*.<br /> **Note:**<br />It is not necessary to say "This property is read-only." | **Type.IsByRef** property summary:<br />Gets a value that indicates whether the **Type** is passed by reference.<br />***Type.DefaultBinder*** *property summary:*<br />Gets the default binder used by the system. |
| Explicit interface property implementation | &lt;Copy from the interface member if appropriate&gt; |

## Overloaded Member Topics

The following information provides guidelines for writing Summary sections for overloaded constructors, operators, and methods.

For overloaded members, docs.microsoft.com creates an overload list page with a general summary as well as individual pages for each overload. The overload list page provides a general summary that applies to all the overloads followed by a table with specific summaries for each overload. (For an example, see the [System.TimeSpan constructors page](https://docs.microsoft.com/dotnet/api/system.timespan.-ctor).) To write the general summary and the individual summaries, follow the guidelines in this section.

### General Summary for an Overloaded Member

When a class explicitly defines multiple overloads, the first overload topic appears in docs.microsoft.com with the **Overload:** preface. This preface is required by the build tools; do not change or delete it. You must write the general summary broadly enough to apply to all the individual overloads. Follow the summary wording guidelines for the particular kind of member you are documenting (for more information, see the relevant subsection in this article), and use text that is programming language-neutral. For an example, see the table in the next section.

The following autogenerated boilerplate appears after the authored general summary:

>> This member is overloaded. For complete information about this member, including syntax, usage, and examples, click a name in the overload list.

### Summaries for Individual Overloads

Provide a separate summary for each individual overload topic in docs.microsoft.com. Use wording that reflects that overload's parameters and distinguishes that overload from the general summary and from the summaries of other overloads. The summary should provide enough information to help users select the overload that they'd like to call.

For example, here's the general summary and individual overload summaries for the overloaded **System.IO.BinaryReader.Read** method.

|   |   |
|---|---|
| General summary (overload list page) | **System.IO.BinaryReader.Read** | Reads bytes from the underlying stream and advances the current position of the stream. |
| Individual overload summary | **System.IO.BinaryReader.Read ()** | Reads characters from the underlying stream and advances the current position of the stream in accordance with the encoding used and the specific character being read from the stream. |
| Individual overload summary | **System.IO.BinaryReader.Read (Byte[], Int32, Int32)** | Reads the specified number of bytes from the stream, starting from a specified point in the byte array. |
| Individual overload summary | **System.IO.BinaryReader.Read (Char[], Int32, Int32)** | Reads the specified number of characters from the stream, starting from a specified point in the character array.
