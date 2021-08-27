<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128624376/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1502)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [mainForm.cs](./CS/mainForm.cs) (VB: [mainForm.vb](./VB/mainForm.vb))
<!-- default file list end -->
# Drag and drop between detail views when using LINQ to SQL


<p>This example demonstrates how to drag rows between the detail views. When implementing the drag-drop operation on the data source level, it's necessary to made changes in the child view's data source rather than in the GridControl's data source, because LINQ internally caches data, and therefore, the GUI doesn't reflect changes made in another binding context.</p>

<br/>


