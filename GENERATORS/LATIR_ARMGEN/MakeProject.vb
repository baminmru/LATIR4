Option Strict Off
Option Explicit On

Imports MTZMetaModel.MTZMetaModel


Module MakeProject

    Public Sub MakePRJ(ByRef ot As MTZwp.MTZwp.Application, ByRef o As LATIRGenerator.Response, ByVal LATIRPath As String, ByVal GUIPath As String, ByVal ControlPath As String, ByVal Level2 As String, ByVal tid As String)
        Dim s As String = String.Empty
        Dim ot_name As String
        ot_name = LATIRFramework.FieldTypesHelper.MakeValidName(ot.Name)
        s += "<Project DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">"
        s += vbCrLf + "  <PropertyGroup>"
        s += vbCrLf + "  <ProjectType>Local</ProjectType>"
        s += vbCrLf + "    <ProductVersion>8.0.50727</ProductVersion>"
        s += vbCrLf + "    <SchemaVersion>2.0</SchemaVersion>"
        s += vbCrLf + "    <ProjectGuid>""" + Guid.NewGuid().ToString() + """</ProjectGuid>"
        s += vbCrLf + "    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>"
        s += vbCrLf + "    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>"
        s += vbCrLf + "    <ApplicationIcon>"
        s += vbCrLf + "    </ApplicationIcon>"
        s += vbCrLf + "    <AssemblyKeyContainerName>"
        s += vbCrLf + "    </AssemblyKeyContainerName>"
        s += vbCrLf + "    <AssemblyName>" + ot_name+"</AssemblyName>")
        s += vbCrLf + "    <AssemblyOriginatorKeyFile>"
        s += vbCrLf + "    </AssemblyOriginatorKeyFile>"
        s += vbCrLf + "    <DefaultClientScript>JScript</DefaultClientScript>"
        s += vbCrLf + "    <DefaultHTMLPageLayout>Grid</DefaultHTMLPageLayout>"
        s += vbCrLf + "    <DefaultTargetSchema>IE50</DefaultTargetSchema>"
        s += vbCrLf + "    <DelaySign>false</DelaySign>"
        s += vbCrLf + "    <OutputType>WinExe</OutputType>"
        s += vbCrLf + "    <RootNamespace>" + ot_name + "</RootNamespace>"
        s += vbCrLf + "    <OptionCompare>Text</OptionCompare>"
        s += vbCrLf + "    OptionExplicit>On</OptionExplicit>"
        s += vbCrLf + "    <OptionStrict>Off</OptionStrict>"
        s += vbCrLf + "    <RootNamespace>ot_name</RootNamespace>"
        s += vbCrLf + "    <StartupObject>ot_name.My.MyApplication</StartupObject>"
        s += vbCrLf + "    <MyType>WindowsForms</MyType>"
        s += vbCrLf + "    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>"
        s += vbCrLf + "    <FileUpgradeFlags>"
        s += vbCrLf + "    </FileUpgradeFlags>"
        s += vbCrLf + "    <UpgradeBackupLocation>"
        s += vbCrLf + "    </UpgradeBackupLocation>"
        s += vbCrLf + "  </PropertyGroup>"
        s += vbCrLf + "  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">"
        s += vbCrLf + "    <OutputPath>" & Level2 & "</OutputPath>"
        s += vbCrLf + "    <DocumentationFile>" + ot_name + "GUI.xml</DocumentationFile>"
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
        s += vbCrLf + "    <NoWarn>42016,42017,42018,42019,42032</NoWarn>"
        s += vbCrLf + "    <DebugType>full</DebugType>"
        s += vbCrLf + "  </PropertyGroup>"
        s += vbCrLf + "  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">"
        s += vbCrLf + "    <OutputPath>" & Level2 & "</OutputPath>"
        s += vbCrLf + "    <DocumentationFile>" + ot_name + "GUI.xml</DocumentationFile>"
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
        s += vbCrLf + "    <NoWarn>42016,42017,42018,42019,42032</NoWarn>"
        s += vbCrLf + "    <DebugType>none</DebugType>"
        s += vbCrLf + "  </PropertyGroup>"
        s += vbCrLf + "  <ItemGroup>"


        s += vbCrLf + "    <Reference Include=""LTOBJMan"">"
        s += vbCrLf + "      <Name>LTOBJMan</Name>"
        s += vbCrLf + "      <HintPath>" & LATIRPath & "</HintPath>"
        s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "    </Reference>"
 
        s += vbCrLf + "    <Reference Include=""LATIRGuiManager"">"
        s += vbCrLf + "      <Name>LATIRGuiManager</Name>"
        s += vbCrLf + "      <HintPath>" & GUIPath & "</HintPath>"
        s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "    </Reference>"


 
        s += vbCrLf + "    <Reference Include=""LATIRGUIControls"">"
        s += vbCrLf + "      <Name>LATIRGUIControls</Name>"
        s += vbCrLf + "      <HintPath>" & ControlPath & "</HintPath>"
        s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "    </Reference>"

        s += vbCrLf + AddARMTypes(ot, Level2, tid)
        s += vbCrLf + AddIGRef()

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

        LATIRFramework.StringHelper.SetExt(o, ot_name & "GUI", "vbproj")
        o.Block = "code"
        o.Out(s)


        LATIRFramework.StringHelper.SetExt(o, "AssemblyInfo", "vb")
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
        s = s & vbCrLf & "                Name = ""LATIRGUIControls"""
        s = s & vbCrLf & "                AssemblyName = ""LATIRGUIControls"""
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

        LATIRFramework.StringHelper.SetExt(o, ot.Name & "GUI", "vbproj")
        o.Block = "code"
        o.Out(s)


        LATIRFramework.StringHelper.SetExt(o, "AssemblyInfo", "vb")
        o.Block = "code"
        o.Out(makeAssemblyInfo((o.Project.Attributes("ID").Value), ot))


    End Sub

    Private Function AddARMTypes(ByRef ot As MTZwp.MTZwp.Application, ByVal Level2 As String, ByVal tid As String) As String
        Dim ei As MTZMetaModel.MTZMetaModel.OBJECTTYPE = Nothing
        Dim i As Integer
        Dim hash As Collection
        hash = New Collection
        Dim s As String = String.Empty

        For i = 1 To ot.ARMTypes.Count
            ei = ot.ARMTypes.Item(i).TheDocumentType

            If Not ei Is Nothing Then
                Try
                    hash.Add(ei, ei.Name.ToUpper())
                Catch
                End Try
            End If
        Next

        For i = 1 To hash.Count
            ei = hash.Item(i)
            s += vbCrLf + "    <Reference Include=""" + ei.Name + """>"
            s += vbCrLf + "      <Name>" + ei.Name + "</Name>"
            s += vbCrLf + "      <HintPath>" + Level2 + ei.Name + ".dll</HintPath>"
            s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
            s += vbCrLf + "    </Reference>"
            s += vbCrLf + "    <Reference Include=""" + ei.Name + "GUI"">"
            s += vbCrLf + "      <Name>" + ei.Name + "GUI</Name>"
            s += vbCrLf + "      <HintPath>" + Level2 + ei.Name + "GUI.dll</HintPath>"
            s += vbCrLf + "       <SpecificVersion>False</SpecificVersion>"
            s += vbCrLf + "    </Reference>"
        Next
        Return s
    End Function


    Private Function AddIGRef() As String

        Dim s As String = ""
        s += vbCrLf + "   <Reference Include=""Infragistics2.Excel.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "   <Reference Include=""Infragistics2.Shared.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"" />"
        s += vbCrLf + "   <Reference Include=""Infragistics2.Win.UltraWinCalcManager.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "   <Reference Include=""Infragistics2.Win.UltraWinChart.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"" />"
        s += vbCrLf + "   <Reference Include=""Infragistics2.Win.UltraWinGrid.ExcelExport.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb, processorArchitecture=MSIL"" />"
        s += vbCrLf + "   <Reference Include=""Infragistics2.Win.UltraWinGrid.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"" />"
        s += vbCrLf + "   <Reference Include=""Infragistics2.Win.UltraWinTabbedMdi.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"" />"
        s += vbCrLf + "   <Reference Include=""Infragistics2.Win.v6.2, Version=6.2.20062.34, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"" />"
        s += vbCrLf + "   <Reference Include=""Interop.DSOFramer, Version=1.3.0.0, Culture=neutral, processorArchitecture=MSIL"" />"
        s += vbCrLf + "   <Reference Include=""Interop.OWC11, Version=1.0.0.0, Culture=neutral, processorArchitecture=MSIL"" />"
        s += vbCrLf + "   <Reference Include=""JournalIG, Version=1.0.2601.21929, Culture=neutral, processorArchitecture=MSIL"">"
        s += vbCrLf + "     <SpecificVersion>False</SpecificVersion>"
        s += vbCrLf + "   </Reference>"
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



    Private Function makeAssemblyInfo(ByRef guid As String, ByRef ot As MTZwp.MTZwp.Application) As String
        Dim s As String = String.Empty

        s = s & vbCrLf & "Imports System"
        s = s & vbCrLf & "Imports System.Reflection"
        s = s & vbCrLf & "Imports System.Runtime.InteropServices"
        s = s & vbCrLf & "<Assembly: AssemblyTitle(""" & LATIRFramework.StringHelper.NoLF(ot.Name) & """)>"
        s = s & vbCrLf & "<Assembly: AssemblyDescription("" " & LATIRFramework.StringHelper.NoLF(ot.Name) & """)>"
        s = s & vbCrLf & "<Assembly: AssemblyCompany(""Master BAMI "")>"
        s = s & vbCrLf & "<Assembly: AssemblyProduct(""Master BANI"")>"
        s = s & vbCrLf & "<Assembly: AssemblyCopyright(""(c) SoftFabric & ABOL Ltd., 2008"")>"
        s = s & vbCrLf & "<Assembly: AssemblyTrademark(""Master BAMI"")>"
        s = s & vbCrLf & "<Assembly: CLSCompliant(True)>"
        's = s & vbCrLf & "<Assembly: Guid(""" & System.Guid.NewGuid.ToString & """)>"
        s = s & vbCrLf & "<Assembly: AssemblyVersion(""1.0.*"")>"
        makeAssemblyInfo = s
    End Function
End Module