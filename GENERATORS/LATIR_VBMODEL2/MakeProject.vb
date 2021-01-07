Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Reflection

Module MakeProject



    Public Sub MakeVBPRJ(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response, ByVal LATIRPath As String, ByVal OutPath As String)
        Dim s As String = String.Empty

        s = "<?xml version=""1.0"" encoding=""utf-8""?>"
        s = s & vbCrLf & "<Project ToolsVersion = ""14.0"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">"

        s = s & vbCrLf & " <Import Project = ""$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props"" Condition=""Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')"" /> "
        s = s & vbCrLf & " <PropertyGroup>"
        s = s & vbCrLf & " <Configuration Condition = "" '$(Configuration)' == '' "">Debug</Configuration>"
        s = s & vbCrLf & "      <Platform Condition = "" '$(Platform)' == '' "">AnyCPU</Platform>"
        s = s & vbCrLf & " <ProjectGuid>" & Guid.NewGuid().ToString() & "</ProjectGuid>"
        s = s & vbCrLf & " <OutputType>Library</OutputType>"
        s = s & vbCrLf & " <RootNamespace>" & ot.Name & "</RootNamespace>"
        s = s & vbCrLf & " <AssemblyName>" & ot.Name & "</AssemblyName>"
        s = s & vbCrLf & " <FileAlignment>512</FileAlignment>"
        s = s & vbCrLf & " <MyType>Windows</MyType>"
        s = s & vbCrLf & " <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>"
        s = s & vbCrLf & " <TargetFrameworkProfile />"
        s = s & vbCrLf & "    </PropertyGroup>"
        s = s & vbCrLf & " <PropertyGroup Condition = "" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">"
        s = s & vbCrLf & " <DebugSymbols>True</DebugSymbols>"
        s = s & vbCrLf & " <DebugType>full</DebugType>"
        s = s & vbCrLf & " <DefineDebug>True</DefineDebug>"
        s = s & vbCrLf & " <DefineTrace>True</DefineTrace>"
        s = s & vbCrLf & " <OutputPath>" & OutPath & "</OutputPath>"
        s = s & vbCrLf & " <DocumentationFile>" & ot.Name & "_doc.xml</DocumentationFile>"
        s = s & vbCrLf & " <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>"
        s = s & vbCrLf & "    </PropertyGroup>"
        s = s & vbCrLf & " <PropertyGroup Condition = "" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">"
        s = s & vbCrLf & "      <DebugType>pdbonly</DebugType>"
        s = s & vbCrLf & " <DefineDebug>False</DefineDebug>"
        s = s & vbCrLf & "      <DefineTrace>true</DefineTrace>"
        s = s & vbCrLf & " <Optimize> True</Optimize>"
        s = s & vbCrLf & "      <OutputPath>" & OutPath & "</OutputPath>"
        s = s & vbCrLf & " <DocumentationFile>" & ot.Name & "_doc.xml</DocumentationFile>"
        s = s & vbCrLf & "      <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>"
        s = s & vbCrLf & "    </PropertyGroup>"
        s = s & vbCrLf & "    <PropertyGroup>"
        s = s & vbCrLf & " <OptionExplicit>On</OptionExplicit>"
        s = s & vbCrLf & "    </PropertyGroup>"
        s = s & vbCrLf & " <PropertyGroup>"
        s = s & vbCrLf & "      <OptionCompare>Binary</OptionCompare>"
        s = s & vbCrLf & "    </PropertyGroup>"
        s = s & vbCrLf & "    <PropertyGroup>"
        s = s & vbCrLf & " <OptionStrict>Off</OptionStrict>"
        s = s & vbCrLf & "    </PropertyGroup>"
        s = s & vbCrLf & " <PropertyGroup>"
        s = s & vbCrLf & "      <OptionInfer>On</OptionInfer>"
        s = s & vbCrLf & "    </PropertyGroup>"



        s = s & vbCrLf & "  <ItemGroup>"
        s = s & vbCrLf & "    <Reference Include=""L2Manager"">"
        s = s & vbCrLf & "      <Name>L2Manager</Name>"
        s = s & vbCrLf & "      <HintPath>" + LATIRPath + "</HintPath>"
        s = s & vbCrLf & "       <SpecificVersion>False</SpecificVersion>"
        s = s & vbCrLf & "    </Reference>"

        s = s & vbCrLf & "    <Reference Include=""System""/>"
        s = s & vbCrLf & "    <Reference Include=""System.Data""/>"
        s = s & vbCrLf & "    <Reference Include=""System.Xml""/>"
        s = s & vbCrLf & "  </ItemGroup>"
        s = s & vbCrLf & "  <ItemGroup>"
        s = s & vbCrLf & "      <Import Include=""System"" />"
        s = s & vbCrLf & "      <Import Include=""System.Collections"" />"
        s = s & vbCrLf & "      <Import Include=""System.Data"" />"
        s = s & vbCrLf & "      <Import Include=""System.Xml"" />"
        s = s & vbCrLf & "    </ItemGroup>"

        s = s & vbCrLf & "  <ItemGroup>"
        s = s & vbCrLf & "    <Compile Include=""Application.vb"">"
        s = s & vbCrLf & "      <SubType>Code</SubType>"
        s = s & vbCrLf & "    </Compile>"
        s = s & vbCrLf & "    <Compile Include=""AssemblyInfo.vb"">"
        s = s & vbCrLf & "      <SubType>Code</SubType>"
        s = s & vbCrLf & "    </Compile>"
        s = s & vbCrLf & FileList(ot)
        s = s & vbCrLf & "  </ItemGroup>"
        s = s & vbCrLf & "  <Import Project=""$(MSBuildToolsPath)\Microsoft.VisualBasic.targets"" />"
        s = s & vbCrLf & "</Project>"
        LATIR2Framework.StringHelper.SetExt(o, ot.Name, "vbproj")
        o.Block = "code"
        o.Out(s)


        LATIR2Framework.StringHelper.SetExt(o, "AssemblyInfo", "vb")
        o.Block = "code"
        o.Out(makeAssemblyInfo((o.Project.Attributes("ID").Value)))
    End Sub
	


    Private Function FileList(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As String
        Dim i As Integer
        Dim s As String = String.Empty
        '    <Compile Include="Application.vb">
        '      <SubType>Code</SubType>
        '    </Compile>
        For i = 1 To ot.PART.Count
            If ot.PART.Item(i).PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                s = s & vbCrLf & "                <Compile Include=""" + ot.PART.Item(i).Name + ".vb"">"
                s = s & vbCrLf & "                    <SubType>Code</SubType>"
                s = s & vbCrLf & "                </Compile>"
                s = s & vbCrLf & "                <Compile Include=""" + ot.PART.Item(i).Name + "_col.vb"">"
                s = s & vbCrLf & "                    <SubType>Code</SubType>"
                s = s & vbCrLf & "                </Compile>"
                s = s & vbCrLf & FileList2(ot.PART.Item(i))
            End If
        Next

        'For i = 1 To ot.PART.Count
        '    s = s & vbCrLf & "                <File"
        '    s = s & vbCrLf & "                    RelPath = """ & ot.PART.Item(i).name & ".vb"""
        '    s = s & vbCrLf & "                    SubType = ""Code"""
        '    s = s & vbCrLf & "                    BuildAction = ""Compile"""
        '    s = s & vbCrLf & "                />"
        '    s = s & vbCrLf & "                <File"
        '    s = s & vbCrLf & "                    RelPath = """ & ot.PART.Item(i).name & "_col.vb"""
        '    s = s & vbCrLf & "                    SubType = ""Code"""
        '    s = s & vbCrLf & "                    BuildAction = ""Compile"""
        '    s = s & vbCrLf & "                />"
        '    s = s & vbCrLf & FileList2(ot.PART.Item(i))
        'Next
        FileList = s
    End Function
	
    Private Function FileList2(ByRef p As MTZMetaModel.MTZMetaModel.PART) As String
        Dim i As Integer
        Dim s As String = String.Empty
        For i = 1 To p.PART.Count
            s = s & vbCrLf & "                <Compile Include=""" & p.PART.Item(i).Name & ".vb"">"
            s = s & vbCrLf & "                    <SubType>Code</SubType>"
            s = s & vbCrLf & "                </Compile>"

            s = s & vbCrLf & "                <Compile Include=""" & p.PART.Item(i).Name & "_col.vb"">"
            s = s & vbCrLf & "                    <SubType>Code</SubType>"
            s = s & vbCrLf & "                </Compile>"

            's = s & vbCrLf & "                <File"
            's = s & vbCrLf & "                    RelPath = """ & p.PART.Item(i).name & ".vb"""
            's = s & vbCrLf & "                    SubType = ""Code"""
            's = s & vbCrLf & "                    BuildAction = ""Compile"""
            's = s & vbCrLf & "                />"
            's = s & vbCrLf & "                <File"
            's = s & vbCrLf & "                    RelPath = """ & p.PART.Item(i).name & "_col.vb"""
            's = s & vbCrLf & "                    SubType = ""Code"""
            's = s & vbCrLf & "                    BuildAction = ""Compile"""
            's = s & vbCrLf & "                />"
            s = s & vbCrLf & FileList2(p.PART.Item(i))
        Next
        FileList2 = s
    End Function
	
	
	
	Private Function makeAssemblyInfo(ByRef guid As String) As String
        Dim s As String = String.Empty
		s = s & vbCrLf & "Imports System"
		s = s & vbCrLf & "Imports System.Reflection"
		s = s & vbCrLf & "Imports System.Runtime.InteropServices"
		s = s & vbCrLf & "<Assembly: AssemblyTitle("""")>"
		s = s & vbCrLf & "<Assembly: AssemblyDescription("""")>"
		s = s & vbCrLf & "<Assembly: AssemblyCompany("""")>"
		s = s & vbCrLf & "<Assembly: AssemblyProduct("""")>"
		s = s & vbCrLf & "<Assembly: AssemblyCopyright("""")>"
		s = s & vbCrLf & "<Assembly: AssemblyTrademark("""")>"
		s = s & vbCrLf & "<Assembly: CLSCompliant(True)>"
        ' s = s & vbCrLf & "<Assembly: Guid(""" & Mid(System.Guid.NewGuid().ToString(), 2, 36) & """)>"
        s = s & vbCrLf & "<Assembly: AssemblyVersion(""1.0.*"")>"
        makeAssemblyInfo = s
	End Function
End Module