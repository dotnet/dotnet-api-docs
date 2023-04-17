---
author: kyracatwork
ms.author: kyrachurney
ms.date: 4/5/2023
title: CSOM methods for applying retention labels (setting ComplianceTags)
description: CSOM methods are available to apply (set) a retention label (ComplianceTag) on one or many items (ListItems) in SharePoint. 
---

# CSOM methods for applying retention labels (setting ComplianceTags)

Retention labels let you apply retention settings for governance control at the item level, and are part of the Microsoft Purview compliance solutions. [Learn more about retention labels.](/microsoft-365/compliance/retention?view=o365-worldwide#retention-labels)

Retention labels may classify contents as records, which place restrictions on what actions are allowed or blocked. [Learn more about declaring records by using retention labels](/microsoft-365/compliance/declare-records)

CSOM methods are available to apply (set) a retention label (ComplianceTag) on one or many items (ListItems) in SharePoint. 

> [!IMPORTANT]
> Some information relates to prerelease product that may be substantially modified before it’s released. Microsoft makes no warranties, express or implied, with respect to the information provided here.

## SetComplianceTagOnBulkItems
This method can be used to set a ComplianceTag on one or many ListItems. It is strongly recommended to use this method for this purpose.

<!-- {
  "blockType": "ignored"
}
-->
```c#
public List<int> SetComplianceTagOnBulkItems( 
             List<int> itemIds, 
             string listUrl, 
             string complianceTagValue)
```

### Parameters
'List' [Int](/en-us/dotnet/api/system.int32)

'ItemsIds' [String](/dotnet/api/system.string)

'ListURL' [String](/dotnet/api/system.string)

'ComplianceTagValue' [String](/dotnet/api/system.string)

Attribute [RemoteAttribute](/dotnet/api/microsoft.sharepoint.client.remoteattribute)

### Applies to

|Product|Versions|
|:---|:---|
|SharePoint CSOM|latest|



## Other
> [!NOTE] It is strongly recommended to use SetComplianceTagOnBulkItems instead of these methods.

The following methods are also available, but are no longer updated and may be subject to deprecation in the future. If you are using these methods, we strongly recommend use of the SetComplianceTagOnBulkItems method instead.

* [SetComplianceTag](/dotnet/api/microsoft.sharepoint.client.listitem.setcompliancetag?view=sharepoint-csom)

* [SetComplianceTagWithExplicitMetaInfo](/dotnet/api/microsoft.sharepoint.client.listitem.setcompliancetagwithexplicitmetainfo?view=sharepoint-csom)

* [SetComplianceTagWithExplicitMetasUpdate](https://learn.microsoft.com/en-us/dotnet/api/microsoft.sharepoint.client.listitem.setcompliancetagwithexplicitmetasupdate?view=sharepoint-csom)

* [SetComplianceTagWithHold](/dotnet/api/microsoft.sharepoint.client.listitem.setcompliancetagwithhold?view=sharepoint-csom)

* [SetComplianceTagWithMetaInfo](/dotnet/api/microsoft.sharepoint.client.listitem.setcompliancetagwithmetainfo?view=sharepoint-csomtnet/api/microsoft.sharepoint.client.listitem.setcompliancetagwithhold?view=sharepoint-csom)

* [SetComplianceTagWithNoHold](/dotnet/api/microsoft.sharepoint.client.listitem.setcompliancetagwithnohold?view=sharepoint-csom)

* [SetComplianceTagWithRecord](/dotnet/api/microsoft.sharepoint.client.listitem.setcompliancetagwithrecord?view=sharepoint-csom)













