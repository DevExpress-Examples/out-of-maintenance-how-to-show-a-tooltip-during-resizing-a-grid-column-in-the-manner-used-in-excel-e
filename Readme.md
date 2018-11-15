<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication3/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication3/Form1.vb))
* [Program.cs](./CS/WindowsApplication3/Program.cs) (VB: [Program.vb](./VB/WindowsApplication3/Program.vb))
<!-- default file list end -->
# How to show a tooltip during resizing a grid column in the manner used in Excel  


<p>All you need to achieve the required result is to place  <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressUtilsToolTipControllertopic"><u>ToolTipController</u></a> onto a form, bind it to a grid by setting the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsContainerEditorContainer_ToolTipControllertopic"><u>GridControl.ToolTipController property</u></a> , and handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressUtilsToolTipController_GetActiveObjectInfotopic"><u>ToolTipController.GetActiveObjectInfo event</u></a>.</p><p>This example illustrates how to implement this functionality in action. </p>

<br/>


