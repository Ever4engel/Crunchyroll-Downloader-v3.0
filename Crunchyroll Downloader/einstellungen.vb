﻿Imports Gecko.Events
Imports Microsoft.Win32
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading
Imports MetroFramework.Forms
Imports MetroFramework
Imports MetroFramework.Components

Public Class Einstellungen
    Inherits MetroForm
    Private Sub Einstellungen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Text = "Version " + Application.ProductVersion.ToString
        MetroStyleManager1.Style = MetroColorStyle.Orange
        'MetroStyleManager1.Theme = MetroThemeStyle.Dark
        TabControl1.SelectedIndex = 0
        Me.StyleManager = MetroStyleManager1
        For i As Integer = 0 To Main.SoftSubs.Count - 1
            If Main.SoftSubs(i) = "deDE" Then
                CBdeDE.Checked = True
            ElseIf Main.SoftSubs(i) = "enUS" Then
                CBenUS.Checked = True
            ElseIf Main.SoftSubs(i) = "ptBR" Then
                CBptBR.Checked = True
            ElseIf Main.SoftSubs(i) = "esLA" Then
                CBesLA.Checked = True
            ElseIf Main.SoftSubs(i) = "frFR" Then
                CBfrFR.Checked = True
            ElseIf Main.SoftSubs(i) = "arME" Then
                CBarME.Checked = True
            ElseIf Main.SoftSubs(i) = "ruRU" Then
                CBruRU.Checked = True
            ElseIf Main.SoftSubs(i) = "itIT" Then
                CBitIT.Checked = True
            ElseIf Main.SoftSubs(i) = "esES" Then
                CBesES.Checked = True
            End If
        Next
        For i As Integer = 0 To Main.SubFunimation.Count - 1
            If Main.SubFunimation(i) = "en" Then
                CB_fun_eng.Checked = True
            ElseIf Main.SubFunimation(i) = "es" Then
                CB_fun_es.Checked = True
            ElseIf Main.SubFunimation(i) = "pt" Then
                CB_fun_ptbr.Checked = True
            End If
            'If Main.SubFunimation(i) = "en" Then
            '    RB_eng.Checked = True
            'ElseIf Main.SubFunimation(i) = "es" Then
            '    RB_es.Checked = True
            'ElseIf Main.SubFunimation(i) = "pt" Then
            '    RB_pt.Checked = True
            'End If
        Next
        If Main.CR_NameMethode = 0 Then
            CR_Filename.SelectedIndex = 0
        ElseIf Main.CR_NameMethode = 1 Then
            CR_Filename.SelectedIndex = 1
        ElseIf Main.CR_NameMethode = 2 Then
            CR_Filename.SelectedIndex = 2
        Else
            CR_Filename.SelectedIndex = 0
        End If
        Me.Location = New Point(Main.Location.X + Main.Width / 2 - Me.Width / 2, Main.Location.Y + Main.Height / 2 - Me.Height / 2)
        Try
            Me.Icon = My.Resources.icon
        Catch ex As Exception

        End Try

        If Main.MergeSubstoMP4 = True Then
            MergeMP4.Checked = True
        End If
        If Main.HybridMode = True Then
            HybridMode_CB.Checked = True
        End If

        If Main.Funimation_srt = True Then
            CB_srt.Checked = True
        Else
            CB_srt.Checked = False
        End If

        If Main.Funimation_vtt = True Then
            CB_vtt.Checked = True
        Else
            CB_vtt.Checked = False
        End If

        If Main.Funimation_dfxp = True Then
            CB_dfxp.Checked = True
        Else
            CB_dfxp.Checked = False
        End If

        If Main.HardSubFunimation = "en" Then
            CB_Fun_HardSubs.SelectedItem = "English"

        ElseIf Main.HardSubFunimation = "pt" Then
            CB_Fun_HardSubs.SelectedItem = "Português (Brasil)"

        ElseIf Main.HardSubFunimation = "es" Then
            CB_Fun_HardSubs.SelectedItem = "Español (LA)"

        Else
            CB_Fun_HardSubs.SelectedItem = "Disabled"
            'FunimationHardsub.Checked = True
        End If

        If Main.DubFunimation = "english" Then
            Fun_Dub_Over.SelectedItem = "english"

        ElseIf Main.DubFunimation = "japanese" Then
            Fun_Dub_Over.SelectedItem = "japanese"

        ElseIf Main.DubFunimation = "portuguese(Brazil)" Then
            Fun_Dub_Over.SelectedItem = "portuguese(Brazil)"

        ElseIf Main.DubFunimation = "spanish(Mexico)" Then
            Fun_Dub_Over.SelectedItem = "spanish(Mexico)"

        Else
            Fun_Dub_Over.SelectedItem = "Disabled"
        End If

        If Main.SaveLog = True Then
            CB_Log.Checked = True
        End If
        Try
            GB_Resolution.Text = Main.GB_Resolution_Text
            GB_SubLanguage.Text = Main.GB_SubLanguage_Text
            DL_Count_simultaneous.Text = Main.DL_Count_simultaneousText
        Catch ex As Exception

        End Try

        If Main.Reso = 1080 Then
            A1080p.Checked = True
        ElseIf Main.Reso = 720 Then
            A720p.Checked = True
        ElseIf Main.Reso = 480 Then
            A480p.Checked = True
        ElseIf Main.Reso = 360 Then
            A360p.Checked = True
        ElseIf Main.Reso = 42 Then
            AAuto.Checked = True
        End If
        If Main.AoD_Reso = 1080 Then
            AoD_1080_Plus.Checked = True
        ElseIf Main.AoD_Reso = 576 Then
            AoD_576p.Checked = True
        ElseIf Main.AoD_Reso = 0 Then
            AoD_0p.Checked = True
        End If

        If Check_CB() = False Then
            ComboBox1.Items.Add(Main.CB_SuB_Nothing)
        End If
        If Main.SubSprache = "deDE" Then
            ComboBox1.SelectedItem = "Deutsch"
        ElseIf Main.SubSprache = "enUS" Then
            ComboBox1.SelectedItem = "English"
        ElseIf Main.SubSprache = "ptBR" Then
            ComboBox1.SelectedItem = "Português (Brasil)"
        ElseIf Main.SubSprache = "esLA" Then
            ComboBox1.SelectedItem = "Español (LA)"
        ElseIf Main.SubSprache = "frFR" Then
            ComboBox1.SelectedItem = "Français (France)"
        ElseIf Main.SubSprache = "arME" Then
            ComboBox1.SelectedItem = "العربية (Arabic)"
        ElseIf Main.SubSprache = "ruRU" Then
            ComboBox1.SelectedItem = "Русский (Russian)"
        ElseIf Main.SubSprache = "itIT" Then
            ComboBox1.SelectedItem = "Italiano (Italian)"
        ElseIf Main.SubSprache = "esES" Then
            ComboBox1.SelectedItem = "Español (España)"
        Else
            ComboBox1.SelectedItem = Main.CB_SuB_Nothing
        End If


        NumericUpDown2.Value = Main.ErrorTolerance
        NumericUpDown1.Value = Main.MaxDL
        TextBox1.Text = Main.Startseite

        If InStr(Main.ffmpeg_command, "-c copy") Then
            FFMPEG_CommandP1.Text = "-c copy"
            FFMPEG_CommandP4.Text = "-bsf:a aac_adtstoasc"
        Else
            Dim ffmpegDisplayCurrent As String() = Main.ffmpeg_command.Split(New String() {" "}, System.StringSplitOptions.RemoveEmptyEntries)
            FFMPEG_CommandP1.Text = ffmpegDisplayCurrent(0) + " " + ffmpegDisplayCurrent(1)
            FFMPEG_CommandP2.Text = ffmpegDisplayCurrent(2) + " " + ffmpegDisplayCurrent(3)
            FFMPEG_CommandP3.Text = ffmpegDisplayCurrent(4) + " " + ffmpegDisplayCurrent(5)
        End If


        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            ListViewAdd_True.Checked = CBool(Integer.Parse(rkg.GetValue("QueueMode").ToString))
        Catch ex As Exception
        End Try
        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            Server.Checked = CBool(Integer.Parse(rkg.GetValue("StartServer").ToString))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles pictureBox4.Click
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\CRDownloader")
        If InStr(TextBox1.Text, "https://") Then
            Main.Startseite = TextBox1.Text
            rk.SetValue("Startseite", Main.Startseite, RegistryValueKind.String)
        ElseIf TextBox1.Text = Nothing Then
            Main.Startseite = "https://www.crunchyroll.com/"
            rk.SetValue("Startseite", Main.Startseite, RegistryValueKind.String)
        Else

        End If
        If A1080p.Checked Then
            Main.Reso = 1080
            rk.SetValue("Resu", 1080, RegistryValueKind.String)
        ElseIf A720p.Checked Then
            Main.Reso = 720
            rk.SetValue("Resu", 720, RegistryValueKind.String)
        ElseIf A360p.Checked Then
            Main.Reso = 360
            rk.SetValue("Resu", 360, RegistryValueKind.String)
        ElseIf A480p.Checked Then
            Main.Reso = 480
            rk.SetValue("Resu", 480, RegistryValueKind.String)
        ElseIf AAuto.Checked Then
            Main.Reso = 42
            rk.SetValue("Resu", 42, RegistryValueKind.String)
        End If
        If AoD_1080_Plus.Checked Then
            Main.AoD_Reso = 1080
            rk.SetValue("AoD_Reso", 1080, RegistryValueKind.String)
        ElseIf AoD_576p.Checked Then
            Main.AoD_Reso = 576
            rk.SetValue("AoD_Reso", 576, RegistryValueKind.String)
        ElseIf AoD_0p.Checked Then
            Main.AoD_Reso = 0
            rk.SetValue("AoD_Reso", 0, RegistryValueKind.String)

        End If
        If ComboBox1.SelectedItem.ToString = "English" Then
            Main.SubSprache = "enUS"
            rk.SetValue("Sub", "enUS", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "Deutsch" Then
            Main.SubSprache = "deDE"
            rk.SetValue("Sub", "deDE", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "Português (Brasil)" Then
            Main.SubSprache = "ptBR"
            rk.SetValue("Sub", "ptBR", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "Español (LA)" Then
            Main.SubSprache = "esLA"
            rk.SetValue("Sub", "esLA", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "Français (France)" Then
            Main.SubSprache = "frFR"
            rk.SetValue("Sub", "frFR", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "العربية (Arabic)" Then
            Main.SubSprache = "arME"
            rk.SetValue("Sub", "arME", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "Русский (Russian)" Then
            Main.SubSprache = "ruRU"
            rk.SetValue("Sub", "ruRU", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "Italiano (Italian)" Then
            Main.SubSprache = "itIT"
            rk.SetValue("Sub", "itIT", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = "Español (España)" Then
            Main.SubSprache = "esES"
            rk.SetValue("Sub", "esES", RegistryValueKind.String)

        ElseIf ComboBox1.SelectedItem.ToString = Main.CB_SuB_Nothing Then
            Main.SubSprache = "None"
            rk.SetValue("Sub", "None", RegistryValueKind.String)

        End If

        If CR_Filename.Text = "[episode number]" Then
            Main.CR_NameMethode = 0
            rk.SetValue("CR_NameMethode", 0, RegistryValueKind.String)
        ElseIf CR_Filename.Text = "[episode name]" Then
            Main.CR_NameMethode = 1
            rk.SetValue("CR_NameMethode", 1, RegistryValueKind.String)
        ElseIf CR_Filename.Text = "[episode number] [episode name]" Then
            Main.CR_NameMethode = 2
            rk.SetValue("CR_NameMethode", 2, RegistryValueKind.String)

        End If

        If MergeMP4.Checked = True Then
            Main.MergeSubstoMP4 = True
            rk.SetValue("MergeMP4", "1", RegistryValueKind.String)
        Else
            Main.MergeSubstoMP4 = False
            rk.SetValue("MergeMP4", "0", RegistryValueKind.String)
        End If
        If HybridMode_CB.Checked = True Then
            Main.HybridMode = True
            rk.SetValue("HybridMode", "1", RegistryValueKind.String)
        Else
            Main.HybridMode = False
            rk.SetValue("HybridMode", "0", RegistryValueKind.String)
        End If
#Region "funimation"

        If CB_srt.Checked = True Then
            Main.Funimation_srt = True
            rk.SetValue("Funimation_srt", "1", RegistryValueKind.String)
        Else
            Main.Funimation_srt = False
            rk.SetValue("Funimation_srt", "0", RegistryValueKind.String)
        End If
        If CB_vtt.Checked = True Then
            Main.Funimation_vtt = True
            rk.SetValue("Funimation_vtt", "1", RegistryValueKind.String)
        Else
            Main.Funimation_vtt = False
            rk.SetValue("Funimation_vtt", "0", RegistryValueKind.String)
        End If
        If CB_dfxp.Checked = True Then
            Main.Funimation_dfxp = True
            rk.SetValue("Funimation_dfxp", "1", RegistryValueKind.String)
        Else
            Main.Funimation_dfxp = False
            rk.SetValue("Funimation_dfxp", "0", RegistryValueKind.String)
        End If


        Main.DubFunimation = Fun_Dub_Over.SelectedItem.ToString

        rk.SetValue("FunimationDub", Fun_Dub_Over.SelectedItem.ToString, RegistryValueKind.String)


        If CB_Fun_HardSubs.SelectedItem.ToString = "Disabled" Then
            Main.HardSubFunimation = "Disabled"
            rk.SetValue("FunimationHardsub", "Disabled", RegistryValueKind.String)

        ElseIf CB_Fun_HardSubs.SelectedItem.ToString = "English" Then
            Main.HardSubFunimation = "en"
            rk.SetValue("FunimationHardsub", "en", RegistryValueKind.String)

        ElseIf CB_Fun_HardSubs.SelectedItem.ToString = "Português (Brasil)" Then
            Main.HardSubFunimation = "pt"
            rk.SetValue("FunimationHardsub", "pt", RegistryValueKind.String)

        ElseIf CB_Fun_HardSubs.SelectedItem.ToString = "Español (LA)" Then
            Main.HardSubFunimation = "es"
            rk.SetValue("FunimationHardsub", "es", RegistryValueKind.String)

        End If

        Main.SubFunimation.Clear()
        If CB_fun_eng.Checked = True Then
            Main.SubFunimation.Add("en")
        End If
        If CB_fun_es.Checked = True Then
            Main.SubFunimation.Add("es")

        End If
        If CB_fun_ptbr.Checked = True Then
            Main.SubFunimation.Add("pt")
        End If

        Dim FunimationSaveString As String = Nothing
        For ii As Integer = 0 To Main.SubFunimation.Count - 1
            If FunimationSaveString = Nothing Then
                FunimationSaveString = Main.SubFunimation(ii)
            Else
                FunimationSaveString = FunimationSaveString + "," + Main.SubFunimation(ii)
            End If
        Next
        If FunimationSaveString = Nothing Then
            FunimationSaveString = "none"
        End If
        rk.SetValue("Fun_Sub", FunimationSaveString, RegistryValueKind.String)
#End Region



        If CB_Log.Checked = True Then
            Main.SaveLog = True
            rk.SetValue("SaveLog", "1", RegistryValueKind.String)
        Else
            Main.SaveLog = False
            rk.SetValue("SaveLog", "0", RegistryValueKind.String)
        End If

        If CheckBox1.Enabled = False Then

        Else
            Dim ffpmeg_cmd As String = Nothing
            If FFMPEG_CommandP1.Text = "-c copy" Then
                ffpmeg_cmd = " " + FFMPEG_CommandP1.Text + " " + FFMPEG_CommandP4.Text
            Else

                ffpmeg_cmd = " " + FFMPEG_CommandP1.Text + " " + FFMPEG_CommandP2.Text + " " + FFMPEG_CommandP3.Text + " " + FFMPEG_CommandP4.Text

            End If
            rk.SetValue("ffmpeg_command", ffpmeg_cmd, RegistryValueKind.String)
            Main.ffmpeg_command = ffpmeg_cmd
        End If

        If InStr(FFMPEG_CommandP1.Text, "nvenc") Then
            If NumericUpDown1.Value > 2 Then
                NumericUpDown1.Value = 2
            End If

        ElseIf InStr(FFMPEG_CommandP1.Text, "libx26") Then
            If NumericUpDown1.Value > 1 Then
                NumericUpDown1.Value = 1
            End If
        End If
        rk.SetValue("SL_DL", NumericUpDown1.Value, RegistryValueKind.String)
        Main.MaxDL = NumericUpDown1.Value

        rk.SetValue("ErrorTolerance", NumericUpDown2.Value, RegistryValueKind.String)
        Main.ErrorTolerance = NumericUpDown2.Value

        If ListViewAdd_True.Checked = True Then
            rk.SetValue("QueueMode", 1, RegistryValueKind.String)

        ElseIf ListViewAdd_True.Checked = False Then
            rk.SetValue("QueueMode", 0, RegistryValueKind.String)
            Main.UseQueue = False
        End If
        If Server.Checked = True Then
            rk.SetValue("StartServer", 1, RegistryValueKind.String)
            Main.StartServer = True
            'Dim t As New Thread(AddressOf Main.ServerStart)
            't.Priority = ThreadPriority.Normal
            't.IsBackground = True
            't.Start()
        ElseIf Server.Checked = False Then
            rk.SetValue("StartServer", 0, RegistryValueKind.String)
            Main.StartServer = False
        End If

#Region "sof subs"
        Main.SoftSubs.Clear()
        If CBdeDE.Checked = True Then
            Main.SoftSubs.Add("deDE")
        End If
        If CBenUS.Checked = True Then
            Main.SoftSubs.Add("enUS")
        End If
        If CBptBR.Checked = True Then
            Main.SoftSubs.Add("ptBR")
        End If
        If CBesLA.Checked = True Then
            Main.SoftSubs.Add("esLA")
        End If
        If CBfrFR.Checked = True Then
            Main.SoftSubs.Add("frFR")
        End If
        If CBarME.Checked = True Then
            Main.SoftSubs.Add("arME")
        End If
        If CBruRU.Checked = True Then
            Main.SoftSubs.Add("ruRU")
        End If
        If CBitIT.Checked = True Then
            Main.SoftSubs.Add("itIT")
        End If
        If CBesES.Checked = True Then
            Main.SoftSubs.Add("esES")
        End If

        Dim SaveString As String = Nothing
        For ii As Integer = 0 To Main.SoftSubs.Count - 1
            If SaveString = Nothing Then
                SaveString = Main.SoftSubs(ii)
            Else
                SaveString = SaveString + "," + Main.SoftSubs(ii)
            End If
        Next
        If SaveString = Nothing Then
            SaveString = "none"
        End If
        rk.SetValue("AddedSubs", SaveString, RegistryValueKind.String)
#End Region
        Me.Close()
    End Sub

    Private Function Check_CB() As Boolean
        Dim C As Boolean = False
        For i As Integer = 0 To ComboBox1.Items.Count - 1
            If ComboBox1.Items.Item(i).ToString = Main.CB_SuB_Nothing Then
                C = True
                Exit For
            End If
        Next
        Return C
    End Function



    Public Function GeräteID() As String
        Dim rnd As New Random
        Dim possible As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim HWID As String = Nothing

        For i As Integer = 0 To 15
            Dim ZufallsZahl As Integer = rnd.Next(1, 33)
            HWID = HWID + possible(ZufallsZahl)
        Next
        Return "CRD-Temp-File-" + HWID
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pictureBox1.Click
        Me.Close()
    End Sub
#Region "UI"
    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles pictureBox1.MouseEnter
        pictureBox1.BackColor = SystemColors.Control
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles pictureBox1.MouseLeave
        pictureBox1.BackColor = Color.Transparent
    End Sub

    Private Sub PictureBox4_MouseEnter(sender As Object, e As EventArgs) Handles pictureBox4.MouseEnter
        pictureBox4.Image = My.Resources.crdSettings_Button_SafeExit_hover
    End Sub

    Private Sub PictureBox4_MouseLeave(sender As Object, e As EventArgs) Handles pictureBox4.MouseLeave
        pictureBox4.Image = My.Resources.crdSettings_Button_SafeExit
    End Sub


    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox1.DrawItem, ComboBox2.DrawItem, comboBox3.DrawItem, comboBox4.DrawItem, CB_Fun_HardSubs.DrawItem, Fun_Dub_Over.DrawItem, CR_Filename.DrawItem
        Dim CB As ComboBox = sender
        CB.BackColor = Color.White
        If e.Index >= 0 Then
            Using st As New StringFormat With {.Alignment = StringAlignment.Center}
                ' e.DrawBackground()
                ' e.DrawFocusRectangle()
                e.Graphics.FillRectangle(SystemBrushes.ControlLightLight, e.Bounds)
                e.Graphics.DrawString(CB.Items(e.Index).ToString, e.Font, Brushes.Black, e.Bounds, st)

            End Using
        End If
    End Sub






    Private Sub AAuto_Click(sender As Object, e As EventArgs) Handles AAuto.Click
        If MergeMP4.Checked = True Then
            If AAuto.Checked = True Then
                If MessageBox.Show("Resolution '[Auto]' and merge the subtitle with the video file will download all resolutions!" + vbNewLine + "Press 'Yes' to enable it anyway", "Prepare for unforeseen consequences.", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Else
                    AAuto.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub MergeMP4_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If MergeMP4.Checked = True Then
            If AAuto.Checked = True Then
                If MessageBox.Show("Resolution '[Auto]' and merge the subtitle with the video file will download all resolutions!" + vbNewLine + "Press 'Yes' to enable it anyway", "Prepare for unforeseen consequences.", MessageBoxButtons.YesNo) = DialogResult.Yes Then

                Else
                    MergeMP4.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If Main.SoftSubs.Count > 0 Then
            If CBool(InStr(TextBox2.Text, "crunchyroll.com")) Then
                GeckoFX.WebBrowser1.Navigate(TextBox2.Text)
                StatusLabel.Text = "Status: looking for subtitles"
                Main.d = False
                Main.b = False
            End If
        Else
            Main.TempSoftSubs.Clear()
            If CBdeDE.Checked = True Then
                Main.TempSoftSubs.Add("deDE")
            End If
            If CBenUS.Checked = True Then
                Main.TempSoftSubs.Add("enUS")
            End If
            If CBptBR.Checked = True Then
                Main.TempSoftSubs.Add("ptBR")
            End If
            If CBesLA.Checked = True Then
                Main.TempSoftSubs.Add("esLA")
            End If
            If CBfrFR.Checked = True Then
                Main.TempSoftSubs.Add("frFR")
            End If
            If CBarME.Checked = True Then
                Main.TempSoftSubs.Add("arME")
            End If
            If CBruRU.Checked = True Then
                Main.TempSoftSubs.Add("ruRU")
            End If
            If CBitIT.Checked = True Then
                Main.TempSoftSubs.Add("itIT")
            End If
            If CBesES.Checked = True Then
                Main.TempSoftSubs.Add("esES")
            End If
            If Main.TempSoftSubs.Count > 0 Then

                If CBool(InStr(TextBox2.Text, "crunchyroll.com")) Then
                    GeckoFX.WebBrowser1.Navigate(TextBox2.Text)
                    StatusLabel.Text = "Status: looking for subtitles"
                    Main.d = False
                    Main.b = False
                End If
            Else
                StatusLabel.Text = "Status: No language selected"
                Pause(3)
                StatusLabel.Text = "Status: idle"
            End If

        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Main.MassSubsDL()
    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.Image = My.Resources.softsubs_download_hover
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = My.Resources.softsubs_download
    End Sub
    Private Sub PictureBox5_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox5.MouseEnter
        PictureBox5.Image = My.Resources.softsubs_download_hover
    End Sub

    Private Sub PictureBox5_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.Image = My.Resources.softsubs_download
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        If TextBox2.Text = "URL" Then
            TextBox2.Text = Nothing
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        comboBox3.Items.Clear()
        comboBox4.Items.Clear()
        Dim SeasonDropdownAnzahl As String() = Main.WebbrowserText.Split(New String() {"season-dropdown content-menu block"}, System.StringSplitOptions.RemoveEmptyEntries)
        Array.Reverse(SeasonDropdownAnzahl)
        Dim SDV As Integer = 0
        For i As Integer = 0 To SeasonDropdownAnzahl.Count - 1
            If InStr(SeasonDropdownAnzahl(i), Chr(34) + ">" + ComboBox2.SelectedItem.ToString + "</a>") Then
                SDV = i
            End If
        Next
        Dim Anzahl As String() = SeasonDropdownAnzahl(SDV).Split(New String() {"wrapper container-shadow hover-classes"}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim c As Integer = Anzahl.Count - 1
        Array.Reverse(Anzahl)
        For i As Integer = 0 To Anzahl.Count - 2
            Dim URLGrapp As String() = Anzahl(i).Split(New String() {"title=" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)

            Dim URLGrapp2 As String() = URLGrapp(1).Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)

            comboBox3.Items.Add(URLGrapp2(0))
            comboBox4.Items.Add(URLGrapp2(0))
        Next
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        GroupBox2.Enabled = CheckBox1.CheckState
        If FFMPEG_CommandP1.Text = "-c copy" Then
            FFMPEG_CommandP2.Enabled = False
            FFMPEG_CommandP3.Enabled = False
        Else
            FFMPEG_CommandP2.Enabled = True
            FFMPEG_CommandP3.Enabled = True
        End If
    End Sub

    Private Sub ListC1_Click(sender As Object, e As EventArgs) Handles ListC1.Click, ListC2.Click, ListC3.Click, ListC4.Click, ListC5.Click
        Dim Button As ToolStripMenuItem = sender
        If Button.Text = "-c copy" Then
            FFMPEG_CommandP1.Text = "-c copy"
            FFMPEG_CommandP2.Enabled = False
            FFMPEG_CommandP3.Enabled = False
        Else
            FFMPEG_CommandP1.Text = Button.Text
            FFMPEG_CommandP2.Enabled = True
            FFMPEG_CommandP3.Enabled = True
        End If

    End Sub

    Private Sub ListP1_Click(sender As Object, e As EventArgs) Handles ListP1.Click, ListP2.Click
        Dim Button As ToolStripMenuItem = sender
        FFMPEG_CommandP2.Text = Button.Text
        FFMPEG_CommandP2.Enabled = True
        FFMPEG_CommandP3.Enabled = True
    End Sub

    Private Sub ListBit1_Click(sender As Object, e As EventArgs) Handles ListBit1.Click, ListBit2.Click, ListBit3.Click, ListBit4.Click, ListBit5.Click, ListBit6.Click, ListBit7.Click
        Dim Button As ToolStripMenuItem = sender
        FFMPEG_CommandP3.Text = Button.Text
        FFMPEG_CommandP2.Enabled = True
        FFMPEG_CommandP3.Enabled = True
    End Sub


    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        GeckoFX.Show()
        Main.LoginOnly = "US_UnBlock"

        GeckoFX.WebBrowser1.Navigate("https://api.criater-stiftung.org/us-unlock.php")
    End Sub

    Private Sub PictureBox2_Enter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.Image = My.Resources.crdsettings_setUScookie_button_hover
    End Sub

    Private Sub PictureBox2_Leave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = My.Resources.crdsettings_setUScookie_button

    End Sub

    Private Sub FunimationHardsub_Click(sender As Object, e As EventArgs)

        If FFMPEG_CommandP1.Text = "-c copy" Then
            If CB_Fun_HardSubs.SelectedItem = "Disabled" Then
            Else

                If MessageBox.Show("This feature does not work with the current output setting." + vbNewLine + "Do you want to ignore the output settings?", "Settings incompatible", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    'FunimationHardsub.Checked = True
                Else
                    CB_Fun_HardSubs.SelectedItem = "Disabled"
                End If
            End If
        Else
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Process.Start("https://bitbucket.org/geckofx/geckofx-60.0/src/default/")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Process.Start("https://www.ffmpeg.org/about.html")
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Process.Start("https://github.com/hama3254/metroframework-modern-ui")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim rnd As New Random
        Dim ZufallsZahl As Integer = rnd.Next(1, 33)

        If ZufallsZahl > 30 Then
            MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Blue
            Debug.WriteLine("Blue")
        ElseIf ZufallsZahl > 25 Then
            MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime
            Debug.WriteLine("Lime")
        ElseIf ZufallsZahl > 20 Then
            MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Magenta
            Debug.WriteLine("Magenta")
        ElseIf ZufallsZahl > 15 Then
            MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Green
            Debug.WriteLine("Green")
        ElseIf ZufallsZahl > 10 Then
            MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Brown
            Debug.WriteLine("Brown")
        ElseIf ZufallsZahl > 5 Then
            MetroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple
            Debug.WriteLine("Purple")
        End If
    End Sub








#End Region
End Class