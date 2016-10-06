Imports System.CodeDom.Compiler
Imports System.Windows.Forms

Public Class CodeExecutor

    Public Property Template As String =
        "" +
        "'imports" +
        "Public Class TestProgram" +
        "'code" +
        "End Class"

    Public Shared Property Logger As Logger = New Logger

    Public Shared Sub Wait(secs As Single)
        Dim time = Now
        Do While (Now - time).TotalSeconds < secs
            Threading.Thread.Sleep(1)
            Application.DoEvents()
        Loop
    End Sub

    Public Shared Sub Output(ParamArray objs() As Object)
        Dim result As String = ""
        For i = 0 To objs.Length - 1
            result += objs(i).ToString + " "
        Next
        Logger.AddMessage(result)

    End Sub

    Public Property SourceText As String
        Set(value As String)
            sourceTextbox.Text = value
        End Set
        Get
            Return sourceTextbox.Text
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bRun.Click
        Dim thread As New Threading.Thread(AddressOf TestProgramSub)
        thread.IsBackground = True
        Dim imps = ""
        For Each ref In ReferencesList
            imps += "Imports " + ref.Replace(".dll", "") + vbCrLf
        Next
        For Each ref In ImportsList
            imps += "Imports " + ref.Replace(".dll", "") + vbCrLf
        Next
        thread.Start(_Template.Replace("'code", vbCrLf + sourceTextbox.Text + vbCrLf).Replace("'imports", vbCrLf + imps + vbCrLf))
        '   IO.File.WriteAllText("test.vb", sourceTextbox.Text)
    End Sub

    Public Property ReferencesList As List(Of String) = New List(Of String)({"system.dll",
    "System.Windows.Forms.dll", "Microsoft.VisualBasic.dll", "Bwl.Hardware.Serial.dll", "Bwl.Hardware.SimplSerial.dll"})

    Public Property ImportsList As List(Of String) = New List(Of String)({})

    Public Event CompilationStarting()

    Sub TestProgramSub(text As String)
        Dim vbc As New VBCodeProvider
        Dim parameters As New CompilerParameters
        RaiseEvent CompilationStarting()
        '   Me.Invoke(Sub() logWriter.Clear())
        _Logger.AddMessage("Compiling...")
        parameters.GenerateInMemory = True
        For Each ref In ReferencesList
            parameters.ReferencedAssemblies.Add(ref)
        Next
        Dim results = vbc.CompileAssemblyFromSource(parameters, text)
        If results.Errors.HasErrors Then
            For Each er As CompilerError In results.Errors
                If er.IsWarning = False Then _Logger.AddError(er.ErrorText + " (" + er.Line.ToString + ")")
            Next
        Else
            _Logger.AddInformation("Start")
            Dim assembly = results.CompiledAssembly
            Dim inst = assembly.CreateInstance("TestProgram")
            Dim type = inst.GetType()
            Try
                Dim m = type.GetMethod("Main")
                m.Invoke(inst, {})
                _Logger.AddInformation("End")
            Catch ex As Exception
                _Logger.AddWarning("End with error: " + ex.Message)
            End Try
        End If
    End Sub

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Private Sub CodeExecutor_Load(sender As Object, e As EventArgs) Handles Me.Load
        If ImportsList.Contains(Me.GetType.FullName) = False Then ImportsList.Add(Me.GetType.FullName)
    End Sub
End Class
