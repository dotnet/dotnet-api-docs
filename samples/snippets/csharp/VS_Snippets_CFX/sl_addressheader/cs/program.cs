﻿// File name: Program.cs
// Snippets  for Silverlight 2 RTM
// Copyright (c) Microsoft Corporation.  All Rights Reserved.

// NSs automatically added to a SL App
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
// using System.Windows.Controls;
// using System.Windows.Documents;
// using System.Windows.Input;
// using System.Windows.Media;
// using System.Windows.Media.Animation;
// using System.Windows.Shapes;

// Namespaces added
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
// using System.Runtime.Serialization.Json;
// using System.ServiceModel.Syndication;
using System.Xml.Serialization;
// using System.Json;
using System.Text;

namespace SL_AddressHeader
{
    public class Snippets
    {
        public static void Main()
        {
            // <Snippet0>

            // <Snippet1>
            // Name property
            AddressHeader addressHeaderWithName = AddressHeader.CreateAddressHeader("MyServiceName", "http://localhost:8000/service",1);
            string addressHeaderName = addressHeaderWithName.Name;
            // </Snippet1>

            // <Snippet2>
            //Put snippet here.
            // Namespace property
            AddressHeader addressHeaderWithNS = AddressHeader.CreateAddressHeader("MyServiceName", "http://localhost:8000/service",1);
            string addressHeaderNS = addressHeaderWithNS.Namespace;
            // </Snippet2>

            // <Snippet3>
            // Obsolete
            // </Snippet3>

            // <Snippet4>
            // Obsolete
            // </Snippet4>

            // <Snippet5>
            // Create address headers for special services and add them to an array
            AddressHeader addressHeader1 = AddressHeader.CreateAddressHeader("specialservice1", "http://localhost:8000/service", 1);
            AddressHeader addressHeader2 = AddressHeader.CreateAddressHeader("specialservice2", "http://localhost:8000/service", 2);
            AddressHeader[] addressHeaders = new AddressHeader[2] { addressHeader1, addressHeader2 };

            // Endpoint address constructor with URI and address headers
            EndpointAddress endpointAddressWithHeaders = new EndpointAddress(
                new Uri("http://localhost/silverlightsamples/service1"), addressHeaders
                );

            // Confirm adddressHeader1 is in endpointAddressWithHeaders - boolHeaders returns True.
            AddressHeaderCollection addressHeaderCollection = endpointAddressWithHeaders.Headers;
            bool boolHeaders = addressHeaderCollection.Contains(addressHeader1);
            // </Snippet5>

            // <Snippet10>
            // <Snippet6>
            //Create address headers with XmlObjectSerializer specified
            XmlObjectSerializer serializer = new DataContractSerializer(typeof(int));
            AddressHeader addressHeaderWithObjSer = AddressHeader.CreateAddressHeader("MyServiceName", "http://localhost:8000/service", 1, serializer);
            int value = addressHeaderWithObjSer.GetValue<int>();
            // </Snippet6>
            // </Snippet10>

            // </Snippet0>
        }
    }
}