# Exceptions Section

Exceptions provide a way to notify programs of errors that occur during execution. An exception is thrown from an area of code where a problem has occurred, and is then passed up the stack until the application handles it or the program terminates. Exceptions can be thrown by constructors, properties, indexers, methods, operators, and events.

The Exceptions section lists the exceptions thrown by a member and provides a description of the conditions under which each is thrown.

## Guidelines

- Provide complete and accurate information about exceptions and the conditions under which they are thrown. Because we do not recommend that developers handle the base exception classes (such as **Exception**, **SystemException**, or **ApplicationException**), undocumented exceptions are likely to not be caught. As a result, failure to document an exception can lead directly to crashes in our customers' apps.
- Ideally, document all exceptions that could surface to the programmer for a given member. For example, if an exception for a method is thrown three levels deep, it still appears to the user as if the method throws it, so you should document it for the method (as well as for the member that directly throws it, if that member is public). However, documenting at this level of detail is a difficult and time-consuming task. For that reason, document all exceptions thrown directly by a member, and do the best you can in looking at nested member calls. Ask PM, Dev, and Test which exceptions users are most likely to encounter, and be sure to document at least those.
- Don't document exceptions that are thrown as a result of code access security violations.

## How-To

If the topic for the member you are documenting does not already contain an Exceptions section, you can insert one by placing your cursor right after the **returnValue** end tag and choosing **exceptions** from the **Tags &amp; Attributes** pane.

For each exception, add an **exception** tag and insert a link to the exception type (tagged as **codeEntityReference**, *qualifyHint*=false). Follow this with **content** and **para** tags to describe the condition. Write each condition as if the word "if" precedes it. Write the description in present tense, unless past or future tense is truly necessary to convey the progression of action. In the built topic, the information is displayed in a table with Exception and Condition columns, as shown in the examples below.

Fit the description to the following model:

*&lt;Exception&gt;* is thrown if *&lt;condition&gt;*.

For example:

| Exception | Condition |
|-----------|-----------|
| **T:System.ArgumentOutOfRangeException** | *hour* is less than 0 or greater than 23. |

Here are some variations on phrasing and formatting:

- If a single exception can occur under multiple conditions, you can provide separate paragraphs for each condition. Write each condition as a complete sentence, followed by a period, and separate the conditions with "-or-". For example:

  | Exception | Condition |
  |-----------|-----------|
  | **T:System.Messaging.MessageQueueException** | The **P:System.Messaging.MessageQueue.Path** property is not set. <br />-or-<br />An error occurred when accessing a Message Queuing API. |

- If an exception can occur under the same condition but with multiple arguments, you can describe the condition in one sentence. For example:

  | Exception | Condition |
  |-----------|-----------|
  | **T:System.ArgumentNullException** | The *type*, *target*, or *method* parameter is a null reference (**Nothing** in Visual Basic). |

- If an exception occurs under all conditions (because the member is not implemented or is always invalid, such as an **Add** method on a read-only collection), use "In all cases." as the condition. This is an exception to the "*&lt;Exception&gt;* is thrown if *&lt;condition&gt;*" pattern. For example:

  | Exception | Condition |
  |-----------|-----------|
  | **T:System.NotSupportedException** | In all cases. |

For standard wording for the Summary and Remarks sections of methods that always throw exceptions, see [Summary: Method Topics](summary.md#method-topics) and Remarks: Topics for Members That Always Throw an Exception).
