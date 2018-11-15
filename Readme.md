<!-- default file list -->
*Files to look at*:

* [mainForm.cs](./CS/mainForm.cs) (VB: [mainForm.vb](./VB/mainForm.vb))
<!-- default file list end -->
# Drag and drop between detail views when using LINQ to SQL


<p>This example demonstrates how to drag rows between the detail views. When implementing the drag-drop operation on the data source level, it's necessary to made changes in the child view's data source rather than in the GridControl's data source, because LINQ internally caches data, and therefore, the GUI doesn't reflect changes made in another binding context.</p>

<br/>


