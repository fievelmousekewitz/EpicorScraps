'//**************************************************
'// Custom VB.NET code for MESMenu
'// Created: 8/12/2011 11:48:29 AM
'//**************************************************
Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports Epicor.Mfg.UI
Imports Epicor.Mfg.UI.FrameWork
Imports Epicor.Mfg.UI.ExtendedProps
Imports Epicor.Mfg.UI.FormFunctions
Imports Epicor.Mfg.UI.Customization
Imports Epicor.Mfg.UI.Adapters
Imports Epicor.Mfg.UI.Searches
Imports Epicor.Mfg.BO





Module Script 

	Sub InitializeCustomCode() 
	End Sub 

	Sub DestroyCustomCode() 
	End Sub 

	Private Sub MESMenu_Load(ByVal sender As object, ByVal args As EventArgs) Handles MESMenu.Load

		picEpiCustom1.Image = System.Drawing.Image.FromFile("\\APOLLO\Epicor905\acti.jpg")
		Dim LogoutBtn As Epibutton = ctype(csm.GetNativeControlReference("d69f285b-eee4-48fd-a6fa-174583fdfbd9"),Epibutton)
		LogoutBtn.UseAppStyling = False
		LogoutBtn.BackColor = System.Drawing.Color.Red

	End Sub


End Module 
