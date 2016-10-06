Public Class Tool
    Public Shared Sub Main()
        Dim tool = New SimplSerialTool(Nothing)
        Application.EnableVisualStyles()
        Application.Run(tool)
    End Sub
End Class
