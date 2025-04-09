' Visual Basic .NET Document
Option Strict On

' <Snippet2>
' Enter semaphore by calling one of the Wait or WaitAsync methods.
SemaphoreSlim.Wait()
'
' Execute code protected by the semaphore.
'
SemaphoreSlim.Release()
' </Snippet2>
