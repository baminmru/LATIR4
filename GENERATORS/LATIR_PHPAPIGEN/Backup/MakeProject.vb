Option Strict Off
Option Explicit On
Module MakeProject
	
    Public Sub MakePRJ(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response, ByVal mksnPath As String)
        Dim s As String
        s = "<VisualStudioProject>"
        s = s & vbCrLf & "<CSHARP"
        s = s & vbCrLf & "        ProjectType = ""Web"""
        s = s & vbCrLf & "        ProductVersion = ""7.10.3077"""
        s = s & vbCrLf & "        SchemaVersion = ""2.0"""
        s = s & vbCrLf & "        ProjectGuid = """ & ot.ID.ToString() & """"
        s = s & vbCrLf & "        SccProjectName = ""SAK"""
        s = s & vbCrLf & "        SccLocalPath = ""SAK"""
        s = s & vbCrLf & "        SccAuxPath = ""SAK"""
        s = s & vbCrLf & "        SccProvider = ""SAK"""
        s = s & vbCrLf & "    >"

        s = s & vbCrLf & "  <Build>"
        s = s & vbCrLf & "            <Settings"
        s = s & vbCrLf & "                ApplicationIcon = """""
        s = s & vbCrLf & "                AssemblyKeyContainerName = """""
        s = s & vbCrLf & "                AssemblyName = """ & ot.name & "ASPNET"""
        s = s & vbCrLf & "                AssemblyOriginatorKeyFile = """""
        s = s & vbCrLf & "                DefaultClientScript = ""JScript"""
        s = s & vbCrLf & "                DefaultHTMLPageLayout = ""Grid"""
        s = s & vbCrLf & "                DefaultTargetSchema = ""IE50"""
        s = s & vbCrLf & "                DelaySign = ""false"""
        s = s & vbCrLf & "                OutputType = ""Library"""
        s = s & vbCrLf & "                PreBuildEvent = """""
        s = s & vbCrLf & "                PostBuildEvent = """""
        s = s & vbCrLf & "                RootNamespace = """ & ot.name & ".ASPNET"""
        s = s & vbCrLf & "                RunPostBuildEvent = ""OnBuildSuccess"""
        s = s & vbCrLf & "                StartupObject = """""
        s = s & vbCrLf & "            >"
        s = s & vbCrLf & "                <Config"
        s = s & vbCrLf & "                    name = ""Debug"""
        s = s & vbCrLf & "                    AllowUnsafeBlocks = ""false"""
        s = s & vbCrLf & "                    BaseAddress = ""285212672"""
        s = s & vbCrLf & "                    CheckForOverflowUnderflow = ""false"""
        s = s & vbCrLf & "                    ConfigurationOverrideFile = """""
        s = s & vbCrLf & "                    DefineConstants = ""DEBUG;TRACE"""
        s = s & vbCrLf & "                    DocumentationFile = """""
        s = s & vbCrLf & "                    DebugSymbols = ""true"""
        s = s & vbCrLf & "                    FileAlignment = ""4096"""
        s = s & vbCrLf & "                    IncrementalBuild = ""false"""
        s = s & vbCrLf & "                    NoStdLib = ""false"""
        s = s & vbCrLf & "                    NoWarn = """""
        s = s & vbCrLf & "                    Optimize = ""false"""
        s = s & vbCrLf & "                    OutputPath = ""bin\"""
        s = s & vbCrLf & "                    RegisterForComInterop = ""false"""
        s = s & vbCrLf & "                    RemoveIntegerChecks = ""false"""
        s = s & vbCrLf & "                    TreatWarningsAsErrors = ""false"""
        s = s & vbCrLf & "                    WarningLevel = ""4"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Config"
        s = s & vbCrLf & "                    name = ""Release"""
        s = s & vbCrLf & "                    AllowUnsafeBlocks = ""false"""
        s = s & vbCrLf & "                    BaseAddress = ""285212672"""
        s = s & vbCrLf & "                    CheckForOverflowUnderflow = ""false"""
        s = s & vbCrLf & "                    ConfigurationOverrideFile = """""
        s = s & vbCrLf & "                    DefineConstants = ""TRACE"""
        s = s & vbCrLf & "                    DocumentationFile = """""
        s = s & vbCrLf & "                    DebugSymbols = ""false"""
        s = s & vbCrLf & "                    FileAlignment = ""4096"""
        s = s & vbCrLf & "                    IncrementalBuild = ""false"""
        s = s & vbCrLf & "                    NoStdLib = ""false"""
        s = s & vbCrLf & "                    NoWarn = """""
        s = s & vbCrLf & "                    Optimize = ""true"""
        s = s & vbCrLf & "                    OutputPath = ""bin\"""
        s = s & vbCrLf & "                    RegisterForComInterop = ""false"""
        s = s & vbCrLf & "                    RemoveIntegerChecks = ""false"""
        s = s & vbCrLf & "                    TreatWarningsAsErrors = ""false"""
        s = s & vbCrLf & "                    WarningLevel = ""4"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "            </Settings>"

        s = s & vbCrLf & "            <References>"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    name = ""System"""
        s = s & vbCrLf & "                    AssemblyName = ""System"""
        s = s & vbCrLf & "                    HintPath = ""System.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    name = ""System.Drawing"""
        s = s & vbCrLf & "                    AssemblyName = ""System.Drawing"""
        s = s & vbCrLf & "                    HintPath = ""System.Drawing.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    name = ""System.Data"""
        s = s & vbCrLf & "                    AssemblyName = ""System.Data"""
        s = s & vbCrLf & "                    HintPath = ""System.Data.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    name = ""System.Web"""
        s = s & vbCrLf & "                    AssemblyName = ""System.Web"""
        s = s & vbCrLf & "                    HintPath = ""System.Web.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    name = ""System.XML"""
        s = s & vbCrLf & "                    AssemblyName = ""System.Xml"""
        s = s & vbCrLf & "                    HintPath = ""System.XML.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                name = ""MKSNManager"""
        s = s & vbCrLf & "                AssemblyName = ""MKSNManager"""
        s = s & vbCrLf & "                HintPath = """ & mksnPath & """"
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "            </References>"



        s = s & vbCrLf & "      <Imports>"
        s = s & vbCrLf & "        <Import Namespace = ""System"" />"
        s = s & vbCrLf & "        <Import Namespace = ""System.Data"" />"
        s = s & vbCrLf & "        <Import Namespace = ""System.Collections"" />"
        s = s & vbCrLf & "        <Import Namespace = ""System.Xml"" />"
        s = s & vbCrLf & "      </Imports>"
        s = s & vbCrLf & "        </Build>"


        s = s & vbCrLf & "        <Files>"
        s = s & vbCrLf & "            <Include>"
        s = s & vbCrLf & "                <File"
        s = s & vbCrLf & "                    RelPath = ""AssemblyInfo.vb"""
        s = s & vbCrLf & "                    SubType = ""Code"""
        s = s & vbCrLf & "                    BuildAction = ""Compile"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <File"
        s = s & vbCrLf & "                    RelPath = ""Application.vb"""
        s = s & vbCrLf & "                    SubType = ""Code"""
        s = s & vbCrLf & "                    BuildAction = ""Compile"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & FileList(ot)
        s = s & vbCrLf & "            </Include>"
        s = s & vbCrLf & "        </Files>"
        s = s & vbCrLf & "    </CSHARP>"
        s = s & vbCrLf & "</VisualStudioProject>"

        SetExt(o, ot.name, "csproj")
        o.Block = "code"
        o.out(s)


        SetExt(o, "AssemblyInfo", "cs")
        o.Block = "code"
        o.out(makeAssemblyInfo((o.Project.Attributes("ID").Value)))


    End Sub
	
	
    Private Function FileList(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As String
        Dim i As Integer
        Dim s As String = String.Empty
        For i = 1 To ot.PART.Count

            s = s & vbCrLf & ""
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""uc" & ot.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""UserControl"""
            s = s & vbCrLf & "                    BuildAction = ""Content"""
            s = s & vbCrLf & "                />"
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""uc" & ot.PART.Item(i).name & ".ascx.cs"""
            s = s & vbCrLf & "                    DependentUpon = ""uc" & ot.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""ASPXCodeBehind"""
            s = s & vbCrLf & "                    BuildAction = ""Compile"""
            s = s & vbCrLf & "                />"
            s = s & vbCrLf & ""
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""ucTab" & ot.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""UserControl"""
            s = s & vbCrLf & "                    BuildAction = ""Content"""
            s = s & vbCrLf & "                />"
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""ucTab" & ot.PART.Item(i).name & ".ascx.cs"""
            s = s & vbCrLf & "                    DependentUpon = ""ucTab" & ot.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""ASPXCodeBehind"""
            s = s & vbCrLf & "                    BuildAction = ""Compile"""
            s = s & vbCrLf & "                />"

            s = s & vbCrLf & FileList2(ot.PART.Item(i))
        Next
        FileList = s
    End Function
	
    Private Function FileList2(ByRef p As MTZMetaModel.MTZMetaModel.PART) As String
        Dim i As Integer
        Dim s As String = String.Empty
        For i = 1 To p.PART.Count
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""uc" & p.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""UserControl"""
            s = s & vbCrLf & "                    BuildAction = ""Content"""
            s = s & vbCrLf & "                />"
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""uc" & p.PART.Item(i).name & ".ascx.cs"""
            s = s & vbCrLf & "                    DependentUpon = ""uc" & p.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""ASPXCodeBehind"""
            s = s & vbCrLf & "                    BuildAction = ""Compile"""
            s = s & vbCrLf & "                />"
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""ucTab" & p.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""UserControl"""
            s = s & vbCrLf & "                    BuildAction = ""Content"""
            s = s & vbCrLf & "                />"
            s = s & vbCrLf & "                <File"
            s = s & vbCrLf & "                    RelPath = ""ucTab" & p.PART.Item(i).name & ".ascx.cs"""
            s = s & vbCrLf & "                    DependentUpon = ""ucTab" & p.PART.Item(i).name & ".ascx"""
            s = s & vbCrLf & "                    SubType = ""ASPXCodeBehind"""
            s = s & vbCrLf & "                    BuildAction = ""Compile"""
            s = s & vbCrLf & "                />"
            s = s & vbCrLf & FileList2(p.PART.Item(i))
        Next
        FileList2 = s
    End Function
	
	
	
	Private Function makeAssemblyInfo(ByRef guid As String) As String
        Dim s As String = String.Empty
		s = s & vbCrLf & "using System;"
		s = s & vbCrLf & "using System.Reflection;"
		s = s & vbCrLf & "using System.Runtime.InteropServices;"
		s = s & vbCrLf & "using System.Runtime.CompilerServices;"
		s = s & vbCrLf & "[assembly: AssemblyTitle("""")]"
		s = s & vbCrLf & "[assembly: AssemblyDescription("""")]"
		s = s & vbCrLf & "[assembly: AssemblyConfiguration("""")]"
		s = s & vbCrLf & "[assembly: AssemblyCompany("""")]"
		s = s & vbCrLf & "[assembly: AssemblyProduct("""")]"
		s = s & vbCrLf & "[assembly: AssemblyCopyright("""")]"
		s = s & vbCrLf & "[assembly: AssemblyTrademark("""")]"
		s = s & vbCrLf & "[assembly: AssemblyCulture("""")]"
		s = s & vbCrLf & "[assembly: AssemblyVersion(""1.0.*"")]"
		s = s & vbCrLf & "[assembly: AssemblyDelaySign(false)]"
		s = s & vbCrLf & "[assembly: AssemblyKeyFile("""")]"
		s = s & vbCrLf & "[assembly: AssemblyKeyName("""")]"
		makeAssemblyInfo = s
	End Function
End Module