Option Strict Off
Option Explicit On

Imports MTZMetaModel.MTZMetaModel


Module MakeProject

    Public Sub MakePRJ(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response, ByVal LATIRPath As String, ByVal GUIPath As String, ByVal ControlPath As String, ByVal Level2 As String, ByVal tid As String)
        Dim s As String = String.Empty
        s = "<?xml version=""1.0"" encoding=""utf-8""?>"
        s += "<Project DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003""  ToolsVersion=""14.0"" >"
        s += vbCrLf + "  <PropertyGroup>"
        s += vbCrLf + "  <ProjectType>Local</ProjectType>"
        s += vbCrLf + "    <ProductVersion>9.0.21022</ProductVersion>"
        s += vbCrLf + "    <SchemaVersion>2.0</SchemaVersion>"
        s += vbCrLf + "    <ProjectGuid>""" + Guid.NewGuid().ToString() + """</ProjectGuid>"
        s += vbCrLf + "    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>"
        s += vbCrLf + "    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>"
        s += vbCrLf + "    <ApplicationIcon>"
        s += vbCrLf + "    </ApplicationIcon>"
        s += vbCrLf + "    <AssemblyKeyContainerName>"
        s += vbCrLf + "    </AssemblyKeyContainerName>"
        s += vbCrLf + "    <AssemblyName>" + ot.Name + "GUI</AssemblyName>"
        s += vbCrLf + "    <AssemblyOriginatorKeyFile>"
        s += vbCrLf + "    </AssemblyOriginatorKeyFile>"
        s += vbCrLf + "    <DefaultClientScript>JScript</DefaultClientScript>"
        s += vbCrLf + "    <DefaultHTMLPageLayout>Grid</DefaultHTMLPageLayout>"
        s += vbCrLf + "    <DefaultTargetSchema>IE50</DefaultTargetSchema>"
        s += vbCrLf + "    <DelaySign>false</DelaySign>"
        s += vbCrLf + "    <OutputType>Library</OutputType>"
        s += vbCrLf + "    <RootNamespace>" + ot.Name + "GUI</RootNamespace>"
        s += vbCrLf + "    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>"
        s += vbCrLf + "    <StartupObject>"
        s += vbCrLf + "    </StartupObject>"
        s += vbCrLf + "    <FileUpgradeFlags>"
        s += vbCrLf + "    </FileUpgradeFlags>"
        s += vbCrLf + "    <MyType>Windows</MyType>"
        s += vbCrLf + "    <UpgradeBackupLocation>"
        s += vbCrLf + "    </UpgradeBackupLocation>"
        s += vbCrLf + "<TargetFrameworkVersion>v4.8</TargetFrameworkVersion>"
        s += vbCrLf + "<OldToolsVersion>3.5</OldToolsVersion>"
        s += vbCrLf + "<TargetFrameworkProfile />"
        s += vbCrLf + "<PublishUrl>publish\</PublishUrl>"
        s += vbCrLf + "<Install>true</Install>"
        s += vbCrLf + "<InstallFrom>Disk</InstallFrom>"
        s += vbCrLf + "<UpdateEnabled>false</UpdateEnabled>"
        s += vbCrLf + "<UpdateMode>Foreground</UpdateMode>"
        s += vbCrLf + "<UpdateInterval>7</UpdateInterval>"
        s += vbCrLf + "<UpdateIntervalUnits>Days</UpdateIntervalUnits>"
        s += vbCrLf + "<UpdatePeriodically>false</UpdatePeriodically>"
        s += vbCrLf + "<UpdateRequired>false</UpdateRequired>"
        s += vbCrLf + "<MapFileExtensions>true</MapFileExtensions>"
        s += vbCrLf + "<ApplicationRevision>0</ApplicationRevision>"
        s += vbCrLf + "<ApplicationVersion>1.0.0.%2a</ApplicationVersion>"
        s += vbCrLf + "<IsWebBootstrapper>false</IsWebBootstrapper>"
        s += vbCrLf + "<UseApplicationTrust>false</UseApplicationTrust>"
        s += vbCrLf + "<BootstrapperEnabled>true</BootstrapperEnabled>"
        s += vbCrLf + "  </PropertyGroup>"
        s += vbCrLf + "  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">"
        s += vbCrLf + "    <OutputPath>" & Level2 & "</OutputPath>"
        s += vbCrLf + "    <DocumentationFile>" + ot.Name + "GUI.xml</DocumentationFile>"
        s += vbCrLf + "    <BaseAddress>285212672</BaseAddress>"
        s += vbCrLf + "    <ConfigurationOverrideFile>"
        s += vbCrLf + "    </ConfigurationOverrideFile>"
        s += vbCrLf + "    <DefineConstants>"
        s += vbCrLf + "    </DefineConstants>"
        s += vbCrLf + "    <DefineDebug>true</DefineDebug>"
        s += vbCrLf + "    <DefineTrace>true</DefineTrace>"
        s += vbCrLf + "    <DebugSymbols>true</DebugSymbols>"
        s += vbCrLf + "    <Optimize>false</Optimize>"
        s += vbCrLf + "    <RegisterForComInterop>false</RegisterForComInterop>"
        s += vbCrLf + "    <RemoveIntegerChecks>false</RemoveIntegerChecks>"
        s += vbCrLf + "    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>"
        s += vbCrLf + "    <WarningLevel>1</WarningLevel>"
        s += vbCrLf + "    <NoWarn>42016,42017,42018,42019,42032,42353,42354,42355</NoWarn>"
        s += vbCrLf + "    <DebugType>full</DebugType>"
        s += vbCrLf + "  </PropertyGroup>"
        s += vbCrLf + "  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">"
        s += vbCrLf + "    <OutputPath>" & Level2 & "</OutputPath>"
        s += vbCrLf + "    <DocumentationFile>" + ot.Name + "GUI.xml</DocumentationFile>"
        s += vbCrLf + "    <BaseAddress>285212672</BaseAddress>"
        s += vbCrLf + "    <ConfigurationOverrideFile>"
        s += vbCrLf + "    </ConfigurationOverrideFile>"
        s += vbCrLf + "    <DefineConstants>"
        s += vbCrLf + "    </DefineConstants>"
        s += vbCrLf + "    <DefineDebug>false</DefineDebug>"
        s += vbCrLf + "    <DefineTrace>true</DefineTrace>"
        s += vbCrLf + "    <DebugSymbols>false</DebugSymbols>"
        s += vbCrLf + "    <Optimize>true</Optimize>"
        s += vbCrLf + "    <RegisterForComInterop>false</RegisterForComInterop>"
        s += vbCrLf + "    <RemoveIntegerChecks>false</RemoveIntegerChecks>"
        s += vbCrLf + "    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>"
        s += vbCrLf + "    <WarningLevel>1</WarningLevel>"
        s += vbCrLf + "    <NoWarn>42016,42017,42018,42019,42032,42353,42354,42355</NoWarn>"
        s += vbCrLf + "    <DebugType>none</DebugType>"
        s += vbCrLf + "  </PropertyGroup>"
        s += vbCrLf + "  <ItemGroup>"


        s += vbCrLf + "    <Reference Include=""L2Manager"">"
        s += vbCrLf + "      <Name>L2Manager</Name>"
        s += vbCrLf + "      <HintPath>" & LATIRPath & "</HintPath>"
        s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "    </Reference>"
        ' '' Copy DLL
        ''Dim VersionStr As String = "1.0.0.0"
        ''Try
        ''    Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(LATIRPath)
        ''    If (Not assembly Is Nothing) Then
        ''        VersionStr = assembly.FullName
        ''        VersionStr = VersionStr.Substring(VersionStr.IndexOf("Version=") + 8)
        ''        VersionStr = VersionStr.Substring(0, VersionStr.IndexOf(","))
        ''    End If
        ''Catch ex As Exception

        ''End Try
        ''s = s & vbCrLf & "  <Reference Include=""LTOBJMan, Version=" + VersionStr + ", Culture=neutral, processorArchitecture=MSIL"" />"
        ''Try
        'Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(GUIPath)
        'If (Not assembly Is Nothing) Then
        '    VersionStr = assembly.FullName
        '    VersionStr = VersionStr.Substring(VersionStr.IndexOf("Version=") + 8)
        '    VersionStr = VersionStr.Substring(0, VersionStr.IndexOf(","))
        'End If
        'Catch ex As Exception

        'End Try
        's = s & vbCrLf & "  <Reference Include=""LATIRGuiManager, Version=" + VersionStr + ", Culture=neutral, processorArchitecture=MSIL"" />"

        s += vbCrLf + "    <Reference Include=""LATIRGuiManager"">"
        s += vbCrLf + "      <Name>LATIRGuiManager</Name>"
        s += vbCrLf + "      <HintPath>" & GUIPath & "</HintPath>"
        s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "    </Reference>"


        'Try
        '    Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(ControlPath)
        '    If (Not assembly Is Nothing) Then
        '        VersionStr = assembly.FullName
        '        VersionStr = VersionStr.Substring(VersionStr.IndexOf("Version=") + 8)
        '        VersionStr = VersionStr.Substring(0, VersionStr.IndexOf(","))
        '    End If
        'Catch ex As Exception

        'End Try
        's = s & vbCrLf & "  <Reference Include=""LATIR2GUIManager.I, Version=" + VersionStr + ", Culture=neutral, processorArchitecture=MSIL"" />"

        s += vbCrLf + "    <Reference Include=""LATIR2GUIControls"">"
        s += vbCrLf + "      <Name>LATIR2GUIControls</Name>"
        s += vbCrLf + "      <HintPath>" & ControlPath & "</HintPath>"
        s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "    </Reference>"


        'Try
        '    Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(Level2 + ot.Name + ".dll")
        '    If (Not assembly Is Nothing) Then
        '        VersionStr = assembly.FullName
        '        VersionStr = VersionStr.Substring(VersionStr.IndexOf("Version=") + 8)
        '        VersionStr = VersionStr.Substring(0, VersionStr.IndexOf(","))
        '    End If
        'Catch ex As Exception

        'End Try
        's = s & vbCrLf & "  <Reference Include=""" + ot.Name + ", Version=" + VersionStr + ", Culture=neutral, processorArchitecture=MSIL"" />"

        s += vbCrLf + "    <Reference Include=""" + ot.Name + """>"
        s += vbCrLf + "      <Name>" + ot.Name + "</Name>"
        s += vbCrLf + "      <HintPath>" & Level2 + ot.Name + ".dll" & "</HintPath>"
        s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "    </Reference>"

        s += vbCrLf + AddExtentionRef(ot, Level2, tid)
        ' s += vbCrLf + AddIG()

        s += vbCrLf + "    <Reference Include=""System"">"
        s += vbCrLf + "      <Name>System</Name>"
        s += vbCrLf + "      <HintPath>System.dll</HintPath>"
        s += vbCrLf + "    </Reference>"
        s += vbCrLf + "    <Reference Include=""System.Data"">"
        s += vbCrLf + "      <Name>System.Data</Name>"
        s += vbCrLf + "      <HintPath>System.Data.dll</HintPath>"
        s += vbCrLf + "    </Reference>"
        s += vbCrLf + "    <Reference Include=""System.Drawing"">"
        s += vbCrLf + "      <Name>System.Drawing</Name>"
        s += vbCrLf + "      <HintPath>System.Drawing.dll</HintPath>"
        s += vbCrLf + "    </Reference>"
        s += vbCrLf + "    <Reference Include=""system.windows.forms"">"
        s += vbCrLf + "      <Name>System.Windows.Forms</Name>"
        s += vbCrLf + "      <HintPath>system.windows.forms.dll</HintPath>"
        s += vbCrLf + "    </Reference>"
        s += vbCrLf + "    <Reference Include=""System.Xml"">"
        s += vbCrLf + "      <Name>System.XML</Name>"
        s += vbCrLf + "      <HintPath>System.XML.dll</HintPath>"
        s += vbCrLf + "    </Reference>"
        s += vbCrLf + "  </ItemGroup>"

        s += vbCrLf + "  <ItemGroup>"
        s += vbCrLf + "    <Import Include=""System"" />"
        s += vbCrLf + "    <Import Include=""System.Collections"" />"
        s += vbCrLf + "    <Import Include=""System.Data"" />"
        s += vbCrLf + "    <Import Include=""System.Xml"" />"
        s += vbCrLf + "    <Import Include=""LATIR"" />"
        s += vbCrLf + "    <Import Include=""LATIR2.Document"" />"
        s += vbCrLf + "    <Import Include=""LATIR2GUIControls"" />"
        s += vbCrLf + "    <Import Include=""LATIRGuiManager"" />"
        s += vbCrLf + "    <Import Include=""" + ot.Name + """ />"
        s += vbCrLf + "    <Import Include=""" + ot.Name + "." + ot.Name + """ />"
        s += vbCrLf + "  </ItemGroup>"


        s += vbCrLf + "  <ItemGroup>"
        s += vbCrLf + "    <Compile Include=""AssemblyInfo.vb"">"
        s += vbCrLf + "      <SubType>Code</SubType>"
        s += vbCrLf + "    </Compile>"
        s += vbCrLf + "    <Compile Include=""GUI.vb"">"
        s += vbCrLf + "      <SubType>Code</SubType>"
        s += vbCrLf + "    </Compile>"
        s += vbCrLf + FileList(ot)
        s += vbCrLf + "  </ItemGroup>"
        s += vbCrLf + "  <ItemGroup>"
        s += vbCrLf + "    <Folder Include=""My Project\"" />"
        s += vbCrLf + "  </ItemGroup>"
        s += vbCrLf + "  <Import Project=""$(MSBuildBinPath)\Microsoft.VisualBasic.targets"" />"
        s += vbCrLf + "  <PropertyGroup>"
        s += vbCrLf + "    <PreBuildEvent>"
        s += vbCrLf + "    </PreBuildEvent>"
        s += vbCrLf + "    <PostBuildEvent>"
        s += vbCrLf + "    </PostBuildEvent>"
        s += vbCrLf + "  </PropertyGroup>"
        s += vbCrLf + "</Project>"

        LATIR2Framework.StringHelper.SetExt(o, ot.Name & "GUI", "vbproj")
        o.Block = "code"
        o.Out(s)


        LATIR2Framework.StringHelper.SetExt(o, "AssemblyInfo", "vb")
        o.Block = "code"
        o.Out(makeAssemblyInfo((o.Project.Attributes("ID").Value), ot))
    End Sub

    Public Sub MakePRJ2(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef o As LATIRGenerator.Response, ByVal LATIRPath As String, ByVal GUIPath As String, ByVal ControlPath As String, ByVal Level2 As String)
        Dim s As String
        s = "<VisualStudioProject>"
        s = s & vbCrLf & "<VisualBasic"
        s = s & vbCrLf & "      ProjectType = ""Local"""
        s = s & vbCrLf & "      ProductVersion = ""7.10.3077"""
        s = s & vbCrLf & "      SchemaVersion = ""2.0"""
        s = s & vbCrLf & "      ProjectGuid = ""{" & System.Guid.NewGuid.ToString & """"
        s = s & vbCrLf & "    >"
        s = s & vbCrLf & "  <Build>"
        s = s & vbCrLf & "            <Settings"
        s = s & vbCrLf & "                ApplicationIcon = """""
        s = s & vbCrLf & "                AssemblyKeyContainerName = """""
        s = s & vbCrLf & "                AssemblyName = """ & ot.Name & "GUI"""
        s = s & vbCrLf & "                AssemblyOriginatorKeyFile = """""
        s = s & vbCrLf & "                DefaultClientScript = ""JScript"""
        s = s & vbCrLf & "                DefaultHTMLPageLayout = ""Grid"""
        s = s & vbCrLf & "                DefaultTargetSchema = ""IE50"""
        s = s & vbCrLf & "                DelaySign = ""false"""
        s = s & vbCrLf & "                OutputType = ""Library"""
        s = s & vbCrLf & "                PreBuildEvent = """""
        s = s & vbCrLf & "                PostBuildEvent = """""
        s = s & vbCrLf & "                RootNamespace = """ & ot.Name & "GUI"""
        s = s & vbCrLf & "                RunPostBuildEvent = ""OnBuildSuccess"""
        s = s & vbCrLf & "                StartupObject = """""
        s = s & vbCrLf & "            >"

        s = s & vbCrLf & "                      <Config"
        s = s & vbCrLf & "                            Name = ""Debug"""
        s = s & vbCrLf & "                            BaseAddress = ""285212672"""
        s = s & vbCrLf & "                            ConfigurationOverrideFile = """""
        s = s & vbCrLf & "                            DefineConstants = """""
        s = s & vbCrLf & "                            DefineDebug = ""true"""
        s = s & vbCrLf & "                            DefineTrace = ""true"""
        s = s & vbCrLf & "                            DebugSymbols = ""true"""
        s = s & vbCrLf & "                            IncrementalBuild = ""true"""
        s = s & vbCrLf & "                            Optimize = ""false"""
        s = s & vbCrLf & "                            OutputPath = ""bin\"""
        s = s & vbCrLf & "                            RegisterForComInterop = ""false"""
        s = s & vbCrLf & "                            RemoveIntegerChecks = ""false"""
        s = s & vbCrLf & "                            TreatWarningsAsErrors = ""false"""
        s = s & vbCrLf & "                            WarningLevel = ""1"""
        s = s & vbCrLf & "                        />"
        s = s & vbCrLf & "                        <Config"
        s = s & vbCrLf & "                            Name = ""Release"""
        s = s & vbCrLf & "                            BaseAddress = ""285212672"""
        s = s & vbCrLf & "                            ConfigurationOverrideFile = """""
        s = s & vbCrLf & "                            DefineConstants = """""
        s = s & vbCrLf & "                            DefineDebug = ""false"""
        s = s & vbCrLf & "                            DefineTrace = ""true"""
        s = s & vbCrLf & "                            DebugSymbols = ""false"""
        s = s & vbCrLf & "                            IncrementalBuild = ""false"""
        s = s & vbCrLf & "                            Optimize = ""true"""
        s = s & vbCrLf & "                            OutputPath = ""bin\"""
        s = s & vbCrLf & "                            RegisterForComInterop = ""false"""
        s = s & vbCrLf & "                            RemoveIntegerChecks = ""false"""
        s = s & vbCrLf & "                            TreatWarningsAsErrors = ""false"""
        s = s & vbCrLf & "                            WarningLevel = ""1"""
        s = s & vbCrLf & "                        />"
        s = s & vbCrLf & "            </Settings>"

        s = s & vbCrLf & "            <References>"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    Name = ""System"""
        s = s & vbCrLf & "                    AssemblyName = ""System"""
        s = s & vbCrLf & "                    HintPath = ""System.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    Name = ""System.Drawing"""
        s = s & vbCrLf & "                    AssemblyName = ""System.Drawing"""
        s = s & vbCrLf & "                    HintPath = ""System.Drawing.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    Name = ""System.Data"""
        s = s & vbCrLf & "                    AssemblyName = ""System.Data"""
        s = s & vbCrLf & "                    HintPath = ""System.Data.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    Name = ""System.Windows.Forms"""
        s = s & vbCrLf & "                    AssemblyName = ""system.windows.forms"""
        s = s & vbCrLf & "                    HintPath = ""system.windows.forms.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                    Name = ""System.XML"""
        s = s & vbCrLf & "                    AssemblyName = ""System.Xml"""
        s = s & vbCrLf & "                    HintPath = ""System.XML.dll"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                Name = ""LTOBJMan"""
        s = s & vbCrLf & "                AssemblyName = ""LTOBJMan"""
        s = s & vbCrLf & "                HintPath = """ & LATIRPath & """"
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                Name = ""LATIR2GUIControls"""
        s = s & vbCrLf & "                AssemblyName = ""LATIR2GUIControls"""
        s = s & vbCrLf & "                HintPath = """ & ControlPath & """"
        s = s & vbCrLf & "                />"

        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                Name = ""LATIRGuiManager"""
        s = s & vbCrLf & "                AssemblyName = ""LATIRGuiManager"""
        s = s & vbCrLf & "                HintPath = """ & GUIPath & """"
        s = s & vbCrLf & "                />"

        s = s & vbCrLf & "                <Reference"
        s = s & vbCrLf & "                Name = """ & ot.Name & """"
        s = s & vbCrLf & "                AssemblyName = """ & ot.Name & """"

        If Right(Level2, 1) = "\" Then
            s = s & vbCrLf & "                HintPath = """ & Level2 & ot.Name & "\bin\" & ot.Name & ".dll"""
        Else
            s = s & vbCrLf & "                HintPath = """ & Level2 & "\" & ot.Name & "\bin\" & ot.Name & ".dll"""
        End If

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
        s = s & vbCrLf & "                    RelPath = ""GUI.vb"""
        s = s & vbCrLf & "                    SubType = ""Code"""
        s = s & vbCrLf & "                    BuildAction = ""Compile"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <File"
        s = s & vbCrLf & "                  RelPath = ""Tabview.vb"""
        s = s & vbCrLf & "                  SubType = ""UserControl"""
        s = s & vbCrLf & "                  BuildAction = ""Compile"""
        s = s & vbCrLf & "                />"
        s = s & vbCrLf & "                <File"
        s = s & vbCrLf & "                RelPath = ""frm" & ot.Name & ".vb"""
        s = s & vbCrLf & "                SubType = ""Form"""
        s = s & vbCrLf & "                BuildAction = ""Compile"""
        s = s & vbCrLf & "                />"

        s = s & vbCrLf & FileList(ot)
        s = s & vbCrLf & "            </Include>"
        s = s & vbCrLf & "        </Files>"
        s = s & vbCrLf & "    </VisualBasic>"
        s = s & vbCrLf & "</VisualStudioProject>"

        LATIR2Framework.StringHelper.SetExt(o, ot.Name & "GUI", "vbproj")
        o.Block = "code"
        o.Out(s)


        LATIR2Framework.StringHelper.SetExt(o, "AssemblyInfo", "vb")
        o.Block = "code"
        o.Out(makeAssemblyInfo((o.Project.Attributes("ID").Value), ot))


    End Sub

    Private Function AddExtentionRef(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByVal Level2 As String, ByVal tid As String) As String
        Dim ei As ExtenderInterface = Nothing
        Dim tp As GENERATOR_TARGET
        Dim i As Integer
        Dim hash As Collection
        hash = New Collection
        Dim s As String = String.Empty

        Dim idx As Integer
        For i = 1 To ot.PART.Count
            If ot.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                For idx = 1 To ot.PART.Item(i).ExtenderInterface.Count
                    tp = ot.PART.Item(i).ExtenderInterface.Item(idx).TargetPlatform
                    If tp.ID.ToString() = tid Then
                        ei = ot.PART.Item(i).ExtenderInterface.Item(idx)
                        Exit For
                    End If
                Next
                If Not ei Is Nothing Then
                    Try
                        hash.Add(ei, ei.TheName.ToUpper())
                    Catch
                    End Try
                End If
            End If

        Next

        For i = 1 To hash.Count
            ei = hash.Item(i)
            s += vbCrLf + "    <Reference Include=""" + ei.TheObject + """>"
            s += vbCrLf + "      <Name>" + ei.TheObject + "</Name>"
            s += vbCrLf + "      <HintPath>" + Level2 + ei.TheObject + ".dll</HintPath>"
            s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
            s += vbCrLf + "    </Reference>"
        Next
        Return s
    End Function


    Private Function FileList(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As String
        Dim i As Integer
        Dim j As Integer
        Dim s As String = String.Empty
        Dim mode As String
        For j = 0 To ot.OBJECTMODE.Count
            If j = 0 Then
                mode = ""
            Else
                mode = ot.OBJECTMODE.Item(j).Name
            End If
            s += vbCrLf + "    <Compile Include=""Tabview" & mode & ".vb"">"
            s += vbCrLf + "      <SubType>UserControl</SubType>"
            s += vbCrLf + "    </Compile>"

            s += vbCrLf + "    <Compile Include=""frm" & ot.Name & mode & ".vb"">"
            s += vbCrLf + "      <SubType>Form</SubType>"
            s += vbCrLf + "    </Compile>"

            ot.PART.Sort = "sequence"
            For i = 1 To ot.PART.Count
                If ot.PART.Item(i).PartType <> enumPartType.PartType_Rassirenie Then
                    s += vbCrLf + "    <Compile Include=""edit" & ot.PART.Item(i).Name & mode & ".vb"">"
                    s += vbCrLf + "      <SubType>UserControl</SubType>"
                    s += vbCrLf + "    </Compile>"

                    s += vbCrLf + "    <Compile Include=""frm" & ot.PART.Item(i).Name & mode & ".vb"">"
                    s += vbCrLf + "      <SubType>Form</SubType>"
                    s += vbCrLf + "    </Compile>"
                End If
                s += vbCrLf + "    <Compile Include=""view" & ot.PART.Item(i).Name & mode & ".vb"">"
                s += vbCrLf + "      <SubType>UserControl</SubType>"
                s += vbCrLf + "    </Compile>"

                's = s & vbCrLf & "                <File"
                's = s & vbCrLf & "                    RelPath = ""edit" & ot.PART.Item(i).Name & ".vb"""
                's = s & vbCrLf & "                    SubType = ""UserControl"""
                's = s & vbCrLf & "                    BuildAction = ""Compile"""
                's = s & vbCrLf & "                />"

                's = s & vbCrLf & "                <File"
                's = s & vbCrLf & "                    RelPath = ""frm" & ot.PART.Item(i).Name & ".vb"""
                's = s & vbCrLf & "                    SubType = ""Form"""
                's = s & vbCrLf & "                    BuildAction = ""Compile"""
                's = s & vbCrLf & "                />"

                's = s & vbCrLf & "                <File"
                's = s & vbCrLf & "                    RelPath = ""view" & ot.PART.Item(i).Name & ".vb"""
                's = s & vbCrLf & "                    SubType = ""UserControl"""
                's = s & vbCrLf & "                    BuildAction = ""Compile"""
                's = s & vbCrLf & "                />"

                If ot.PART.Item(i).PartType <> enumPartType.PartType_Rassirenie Then
                    s = s & vbCrLf & FileList2(ot.PART.Item(i), mode)
                End If
            Next
        Next
        FileList = s
    End Function

    Private Function FileList2(ByRef ot As MTZMetaModel.MTZMetaModel.PART, ByVal mode As String) As String
        Dim i As Integer
        Dim s As String = String.Empty
        For i = 1 To ot.PART.Count
            s += vbCrLf + "    <Compile Include=""edit" & ot.PART.Item(i).Name & mode & ".vb"">"
            s += vbCrLf + "      <SubType>UserControl</SubType>"
            s += vbCrLf + "    </Compile>"

            s += vbCrLf + "    <Compile Include=""frm" & ot.PART.Item(i).Name & mode & ".vb"">"
            s += vbCrLf + "      <SubType>Form</SubType>"
            s += vbCrLf + "    </Compile>"

            's = s & vbCrLf & "                <File"
            's = s & vbCrLf & "                    RelPath = ""edit" & ot.PART.Item(i).Name & ".vb"""
            's = s & vbCrLf & "                    SubType = ""UserControl"""
            's = s & vbCrLf & "                    BuildAction = ""Compile"""
            's = s & vbCrLf & "                />"

            's = s & vbCrLf & "                <File"
            's = s & vbCrLf & "                    RelPath = ""frm" & ot.PART.Item(i).Name & ".vb"""
            's = s & vbCrLf & "                    SubType = ""Form"""
            's = s & vbCrLf & "                    BuildAction = ""Compile"""
            's = s & vbCrLf & "                />"

            s = s & vbCrLf & FileList2(ot.PART.Item(i), mode)
        Next
        FileList2 = s
    End Function

    Private Function AddIG() As String
        Dim s As String
        s = ""

        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.Core.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.Excel.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.IO.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.Reports.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.TextDocument.CSharp.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.TextDocument.TSql.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.TextDocument.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.TextDocument.VisualBasic.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Documents.Word.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Math.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.Core.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataProvider.Adomd.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataProvider.Flat.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataProvider.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataProvider.Xmla.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataSource.Flat.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataSource.Mdx.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataSource.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Olap.DataSource.Xmla.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Services.Schedules.WcfConnectorService.v15.1, Version=15.1.20151.2251, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Shared.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Undo.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.AppStylistSupport.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.DataVisualization.Shared.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.DataVisualization.UltraDataChart.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.Misc.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.Portable.Core.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.SupportDialogs.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraChart.v15.1.Design, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraGauge.v15.1.Design, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinCalcManager.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinCalcManager.v15.1.FormulaBuilder, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinCarousel.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinChart.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinDataSource.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinDock.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinEditors.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinExplorerBar.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinFormattedText.WordWriter.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinGanttView.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinGauge.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinGrid.DocumentExport.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinGrid.ExcelExport.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinGrid.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinGrid.WordWriter.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinInkProvider.Ink17.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinListBar.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinListView.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinLiveTileView.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinMaskedEdit.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinPivotGrid.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinPrintPreviewDialog.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinRadialMenu.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinSchedule.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinSpellChecker.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinStatusBar.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinTabbedMdi.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinTabControl.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinToolbars.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.UltraWinTree.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.v15.1, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "<Reference Include=""Infragistics4.Win.v15.1.Design, Version=15.1.20151.2230, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"


        Return s
    End Function

    Private Function makeAssemblyInfo(ByRef guid As String, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As String
        Dim s As String = String.Empty

        s = s & vbCrLf & "Imports System"
        s = s & vbCrLf & "Imports System.Reflection"
        s = s & vbCrLf & "Imports System.Runtime.InteropServices"
        s = s & vbCrLf & "<Assembly: AssemblyTitle(""" & LATIR2Framework.StringHelper.NoLF(ot.the_Comment) & """)>"
        s = s & vbCrLf & "<Assembly: AssemblyDescription("" " & LATIR2Framework.StringHelper.NoLF(ot.the_Comment) & """)>"
        s = s & vbCrLf & "<Assembly: AssemblyCompany(""ABOL & Softfabric"")>"
        s = s & vbCrLf & "<Assembly: AssemblyProduct(""Master.BAMI"")>"
        s = s & vbCrLf & "<Assembly: AssemblyCopyright(""(c) ABOL & Softfabric, 2007 - 2009"")>"
        s = s & vbCrLf & "<Assembly: AssemblyTrademark(""Master.BAMI"")>"
        s = s & vbCrLf & "<Assembly: CLSCompliant(True)>"
        's = s & vbCrLf & "<Assembly: Guid(""" & System.Guid.NewGuid.ToString & """)>"
        s = s & vbCrLf & "<Assembly: AssemblyVersion(""1.0.*"")>"
        makeAssemblyInfo = s
    End Function
End Module