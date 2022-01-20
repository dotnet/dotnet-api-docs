﻿//<Snippet1>
using System;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;

public class Example
{
    public static void Main()
    {
        // Create a string representing the current user.
        string user = Environment.UserDomainName + "\\" + 
            Environment.UserName;

        // Create a security object that grants no access.
        EventWaitHandleSecurity mSec = new EventWaitHandleSecurity();

        // Add a rule that grants the current user the 
        // right to wait on or signal the event.
        EventWaitHandleAccessRule rule = new EventWaitHandleAccessRule(user, 
            EventWaitHandleRights.Synchronize | EventWaitHandleRights.Modify, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        // Add a rule that denies the current user the 
        // right to change permissions on the event.
        rule = new EventWaitHandleAccessRule(user, 
            EventWaitHandleRights.ChangePermissions, 
            AccessControlType.Deny);
        mSec.AddAccessRule(rule);

        // Display the rules in the security object.
        ShowSecurity(mSec);

        // Add a rule that allows the current user the 
        // right to read permissions on the event. This rule
        // is merged with the existing Allow rule.
        rule = new EventWaitHandleAccessRule(user, 
            EventWaitHandleRights.ReadPermissions, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        ShowSecurity(mSec);
    }

    private static void ShowSecurity(EventWaitHandleSecurity security)
    {
        Console.WriteLine("\r\nCurrent access rules:\r\n");

        foreach(EventWaitHandleAccessRule ar in 
            security.GetAccessRules(true, true, typeof(NTAccount)))
        {
            Console.WriteLine("        User: {0}", ar.IdentityReference);
            Console.WriteLine("        Type: {0}", ar.AccessControlType);
            Console.WriteLine("      Rights: {0}", ar.EventWaitHandleRights);
            Console.WriteLine();
        }
    }
}

/*This code example produces output similar to following:

Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: ChangePermissions

        User: TestDomain\TestUser
        Type: Allow
      Rights: Modify, Synchronize


Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: ChangePermissions

        User: TestDomain\TestUser
        Type: Allow
      Rights: Modify, ReadPermissions, Synchronize
 */
//</Snippet1>
