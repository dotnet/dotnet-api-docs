<%@WebService Language="c#" Class="MimeXmlBinding_Part_3_Service"%>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

public class MimeXmlBinding_Part_3_Service: System.Web.Services.WebService
{
   [WebMethod]
   public int AddNumbers(int firstNumber,int secondNumber)
   {
      return firstNumber+secondNumber;
   }
}
