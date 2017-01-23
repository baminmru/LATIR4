Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Reflection

Module MakeProject
	
    'Public Sub MakeVBPRJ(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response, ByVal LATIRPath As String)
    '    Dim s As String
    '    s = "<VisualStudioProject>"
    '    s = s & vbCrLf & "    <VisualBasic"
    '    s = s & vbCrLf & "        ProjectType = ""Local"""
    '    s = s & vbCrLf & "        ProductVersion = ""7.10.3077"""
    '    s = s & vbCrLf & "        SchemaVersion = ""2.0"""
    '    s = s & vbCrLf & "        ProjectGuid = """ & Guid.NewGuid().ToString() & """"
    '    s = s & vbCrLf & "    >"
    '    s = s & vbCrLf & "        <Build>"
    '    s = s & vbCrLf & "            <Settings"
    '    s = s & vbCrLf & "        ApplicationIcon = """""
    '    s = s & vbCrLf & "        AssemblyKeyContainerName = """""
    '    s = s & vbCrLf & "        AssemblyName = """ & ot.Name & """"
    '    s = s & vbCrLf & "        AssemblyOriginatorKeyFile = """""
    '    s = s & vbCrLf & "        AssemblyOriginatorKeyMode = ""None"""
    '    s = s & vbCrLf & "        DefaultClientScript = ""JScript"""
    '    s = s & vbCrLf & "        DefaultHTMLPageLayout = ""Grid"""
    '    s = s & vbCrLf & "        DefaultTargetSchema = ""IE50"""
    '    s = s & vbCrLf & "        DelaySign = ""false"""
    '    s = s & vbCrLf & "        OutputType = ""Library"""
    '    s = s & vbCrLf & "        RootNamespace = """ & ot.Name & """"
    '    s = s & vbCrLf & "        OptionCompare = ""Binary"""
    '    s = s & vbCrLf & "        OptionExplicit = ""On"""
    '    s = s & vbCrLf & "        OptionStrict = ""Off"""
    '    s = s & vbCrLf & "        StartupObject = """""
    '    s = s & vbCrLf & "      >"
    '    s = s & vbCrLf & "                <Config"
    '    s = s & vbCrLf & "                    Name = ""Debug"""
    '    s = s & vbCrLf & "                    BaseAddress = ""285212672"""
    '    s = s & vbCrLf & "                    ConfigurationOverrideFile = """""
    '    s = s & vbCrLf & "                    DefineConstants = """""
    '    s = s & vbCrLf & "                    DefineDebug = ""true"""
    '    s = s & vbCrLf & "                    DefineTrace = ""true"""
    '    s = s & vbCrLf & "                    DebugSymbols = ""true"""
    '    s = s & vbCrLf & "                    IncrementalBuild = ""true"""
    '    s = s & vbCrLf & "                    Optimize = ""false"""
    '    s = s & vbCrLf & "                    OutputPath = ""bin\"""
    '    s = s & vbCrLf & "                    RegisterForComInterop = ""false"""
    '    s = s & vbCrLf & "                    RemoveIntegerChecks = ""false"""
    '    s = s & vbCrLf & "                    TreatWarningsAsErrors = ""false"""
    '    s = s & vbCrLf & "                    WarningLevel = ""1"""
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & "                <Config"
    '    s = s & vbCrLf & "                    Name = ""Release"""
    '    s = s & vbCrLf & "                    BaseAddress = ""285212672"""
    '    s = s & vbCrLf & "                    ConfigurationOverrideFile = """""
    '    s = s & vbCrLf & "                    DefineConstants = """""
    '    s = s & vbCrLf & "                    DefineDebug = ""false"""
    '    s = s & vbCrLf & "                    DefineTrace = ""true"""
    '    s = s & vbCrLf & "                    DebugSymbols = ""false"""
    '    s = s & vbCrLf & "                    IncrementalBuild = ""false"""
    '    s = s & vbCrLf & "                    Optimize = ""true"""
    '    s = s & vbCrLf & "                    OutputPath = ""bin\"""
    '    s = s & vbCrLf & "                    RegisterForComInterop = ""false"""
    '    s = s & vbCrLf & "                    RemoveIntegerChecks = ""false"""
    '    s = s & vbCrLf & "                    TreatWarningsAsErrors = ""false"""
    '    s = s & vbCrLf & "                    WarningLevel = ""1"""
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & "            </Settings>"
    '    s = s & vbCrLf & "            <References>"
    '    s = s & vbCrLf & "                <Reference"
    '    s = s & vbCrLf & "                    Name = ""System"""
    '    s = s & vbCrLf & "                    AssemblyName = ""System"""
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & "                <Reference"
    '    s = s & vbCrLf & "                    Name = ""System.Data"""
    '    s = s & vbCrLf & "                    AssemblyName = ""System.Data"""
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & "                <Reference"
    '    s = s & vbCrLf & "                    Name = ""System.XML"""
    '    s = s & vbCrLf & "                    AssemblyName = ""System.Xml"""
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & "                <Reference"
    '    s = s & vbCrLf & "                Name = ""LTOBJMan"""
    '    s = s & vbCrLf & "                AssemblyName = ""LTOBJMan"""
    '    s = s & vbCrLf & "                HintPath = """ & LATIRPath & """"
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & "            </References>"
    '    s = s & vbCrLf & "      <Imports>"
    '    s = s & vbCrLf & "        <Import Namespace = ""System"" />"
    '    s = s & vbCrLf & "        <Import Namespace = ""System.Data"" />"
    '    s = s & vbCrLf & "        <Import Namespace = ""System.Collections"" />"
    '    s = s & vbCrLf & "        <Import Namespace = ""System.Xml"" />"
    '    s = s & vbCrLf & "      </Imports>"
    '    s = s & vbCrLf & "        </Build>"
    '    s = s & vbCrLf & "        <Files>"
    '    s = s & vbCrLf & "            <Include>"
    '    s = s & vbCrLf & "                <File"
    '    s = s & vbCrLf & "                    RelPath = ""AssemblyInfo.vb"""
    '    s = s & vbCrLf & "                    SubType = ""Code"""
    '    s = s & vbCrLf & "                    BuildAction = ""Compile"""
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & "                <File"
    '    s = s & vbCrLf & "                    RelPath = ""Application.vb"""
    '    s = s & vbCrLf & "                    SubType = ""Code"""
    '    s = s & vbCrLf & "                    BuildAction = ""Compile"""
    '    s = s & vbCrLf & "                />"
    '    s = s & vbCrLf & FileList(ot)
    '    s = s & vbCrLf & "            </Include>"
    '    s = s & vbCrLf & "        </Files>"
    '    s = s & vbCrLf & "    </VisualBasic>"
    '    s = s & vbCrLf & "</VisualStudioProject>"

    '    SetExt(o, ot.Name, "vbproj")
    '    o.Block = "code"
    '    o.out(s)


    '    SetExt(o, "AssemblyInfo", "vb")
    '    o.Block = "code"
    '    o.out(makeAssemblyInfo((o.Project.Attributes("ID").Value)))
    'End Sub

    Public Sub MakeVBPRJ(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response, ByVal LATIRPath As String, ByVal OutPath As String)
        Dim s As String = String.Empty

        s = s & vbCrLf & "<Project DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">"
        s = s & vbCrLf & "  <PropertyGroup>"
        s = s & vbCrLf & "    <ProjectType>Local</ProjectType>"
        s = s & vbCrLf & "    <ProductVersion>8.0.50727</ProductVersion>"
        s = s & vbCrLf & "    <SchemaVersion>2.0</SchemaVersion>"
        s = s & vbCrLf & "    <ProjectGuid>""" & Guid.NewGuid().ToString() & """</ProjectGuid>"
        s = s & vbCrLf & "    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>"
        s = s & vbCrLf & "    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>"
        s = s & vbCrLf & "    <ApplicationIcon>"
        s = s & vbCrLf & "    </ApplicationIcon>"
        s = s & vbCrLf & "    <AssemblyKeyContainerName>"
        s = s & vbCrLf & "    </AssemblyKeyContainerName>"
        s = s & vbCrLf & "    <AssemblyName>" & ot.Name & "</AssemblyName>"
        s = s & vbCrLf & "    <AssemblyOriginatorKeyFile>"
        s = s & vbCrLf & "    </AssemblyOriginatorKeyFile>"
        s = s & vbCrLf & "    <AssemblyOriginatorKeyMode>None</AssemblyOriginatorKeyMode>"
        s = s & vbCrLf & "    <DefaultClientScript>JScript</DefaultClientScript>"
        s = s & vbCrLf & "    <DefaultHTMLPageLayout>Grid</DefaultHTMLPageLayout>"
        s = s & vbCrLf & "    <DefaultTargetSchema>IE50</DefaultTargetSchema>"
        s = s & vbCrLf & "    <DelaySign>false</DelaySign>"
        s = s & vbCrLf & "    <OutputType>Library</OutputType>"
        s = s & vbCrLf & "    <RootNamespace>" & ot.Name & "</RootNamespace>"
        s = s & vbCrLf & "    <OptionCompare>Binary</OptionCompare>"
        s = s & vbCrLf & "    <OptionExplicit>On</OptionExplicit>"
        s = s & vbCrLf & "    <OptionStrict>Off</OptionStrict>"
        s = s & vbCrLf & "    <StartupObject>"
        s = s & vbCrLf & "    </StartupObject>"
        s = s & vbCrLf & "    <FileUpgradeFlags>"
        s = s & vbCrLf & "    </FileUpgradeFlags>"
        s = s & vbCrLf & "    <MyType>Windows</MyType>"
        s = s & vbCrLf & "    <UpgradeBackupLocation>"
        s = s & vbCrLf & "    </UpgradeBackupLocation>"
        s = s & vbCrLf & "  </PropertyGroup>"
        s = s & vbCrLf & "  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">"
        s = s & vbCrLf & "    <OutputPath>" & OutPath & "</OutputPath>"
        s = s & vbCrLf & "    <DocumentationFile>" & ot.Name & ".xml</DocumentationFile>"
        s = s & vbCrLf & "    <BaseAddress>285212672</BaseAddress>"
        s = s & vbCrLf & "    <ConfigurationOverrideFile>"
        s = s & vbCrLf & "    </ConfigurationOverrideFile>"
        s = s & vbCrLf & "    <DefineConstants>"
        s = s & vbCrLf & "    </DefineConstants>"
        s = s & vbCrLf & "    <DefineDebug>true</DefineDebug>"
        s = s & vbCrLf & "    <DefineTrace>true</DefineTrace>"
        s = s & vbCrLf & "    <DebugSymbols>true</DebugSymbols>"
        s = s & vbCrLf & "    <Optimize>false</Optimize>"
        s = s & vbCrLf & "    <RegisterForComInterop>false</RegisterForComInterop>"
        s = s & vbCrLf & "    <RemoveIntegerChecks>false</RemoveIntegerChecks>"
        s = s & vbCrLf & "    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>"
        s = s & vbCrLf & "    <WarningLevel>1</WarningLevel>"
        s = s & vbCrLf & "    <NoWarn>42016,42017,42018,42019,42032</NoWarn>"
        s = s & vbCrLf & "    <DebugType>full</DebugType>"
        s = s & vbCrLf & "  </PropertyGroup>"
        s = s & vbCrLf & "  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">"
        s = s & vbCrLf & "    <OutputPath>" & OutPath & "</OutputPath>"
        s = s & vbCrLf & "    <DocumentationFile>" + ot.Name + ".xml</DocumentationFile>"
        s = s & vbCrLf & "    <BaseAddress>285212672</BaseAddress>"
        s = s & vbCrLf & "    <ConfigurationOverrideFile>"
        s = s & vbCrLf & "    </ConfigurationOverrideFile>"
        s = s & vbCrLf & "    <DefineConstants>"
        s = s & vbCrLf & "    </DefineConstants>"
        s = s & vbCrLf & "    <DefineDebug>false</DefineDebug>"
        s = s & vbCrLf & "    <DefineTrace>true</DefineTrace>"
        s = s & vbCrLf & "    <DebugSymbols>false</DebugSymbols>"
        s = s & vbCrLf & "    <Optimize>true</Optimize>"
        s = s & vbCrLf & "    <RegisterForComInterop>false</RegisterForComInterop>"
        s = s & vbCrLf & "    <RemoveIntegerChecks>false</RemoveIntegerChecks>"
        s = s & vbCrLf & "    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>"
        s = s & vbCrLf & "    <WarningLevel>1</WarningLevel>"
        s = s & vbCrLf & "    <NoWarn>42016,42017,42018,42019,42032</NoWarn>"
        s = s & vbCrLf & "    <DebugType>none</DebugType>"
        s = s & vbCrLf & "  </PropertyGroup>"
        s = s & vbCrLf & "  <ItemGroup>"
        s = s & vbCrLf & "    <Reference Include=""LTROBJMan"">"
        s = s & vbCrLf & "      <Name>LTROBJMan</Name>"
        s = s & vbCrLf & "      <HintPath>" + LATIRPath + "</HintPath>"
        s = s & vbCrLf & "       <SpecificVersion>False</SpecificVersion>"
        s = s & vbCrLf & "    </Reference>"
        '' Copy DLL
        'Dim VersionStr As String = "1.0.0.0"
        'Try
        '    Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(LATIRPath)
        '    If (Not assembly Is Nothing) Then
        '        VersionStr = assembly.FullName
        '        VersionStr = VersionStr.Substring(VersionStr.IndexOf("Version=") + 8)
        '        VersionStr = VersionStr.Substring(0, VersionStr.IndexOf(","))
        '    End If
        'Catch ex As Exception

        'End Try
        's = s & vbCrLf & "    <Reference Include=""LTOBJMan, Version=" + VersionStr + ", Culture=neutral, processorArchitecture=MSIL"" />"
        s = s & vbCrLf & "    <Reference Include=""System"">"
        s = s & vbCrLf & "      <Name>System</Name>"
        s = s & vbCrLf & "    </Reference>"
        s = s & vbCrLf & "    <Reference Include=""System.Data"">"
        s = s & vbCrLf & "      <Name>System.Data</Name>"
        s = s & vbCrLf & "    </Reference>"
        s = s & vbCrLf & "    <Reference Include=""System.Xml"">"
        s = s & vbCrLf & "      <Name>System.XML</Name>"
        s = s & vbCrLf & "    </Reference>"
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
        s = s & vbCrLf & "  <Import Project=""$(MSBuildBinPath)\Microsoft.VisualBasic.targets"" />"
        s = s & vbCrLf & "  <PropertyGroup>"
        s = s & vbCrLf & "    <PreBuildEvent>"
        s = s & vbCrLf & "    </PreBuildEvent>"
        s = s & vbCrLf & "    <PostBuildEvent>"
        s = s & vbCrLf & "    </PostBuildEvent>"
        s = s & vbCrLf & "  </PropertyGroup>"
        s = s & vbCrLf & "</Project>"
        LATIRFramework.StringHelper.SetExt(o, ot.Name, "vbproj")
        o.Block = "code"
        o.Out(s)


        LATIRFramework.StringHelper.SetExt(o, "AssemblyInfo", "vb")
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