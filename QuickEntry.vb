' **************************************************
' Custom code for TagCountForm
' Created: 4/1/2013 9:09:21 AM
' **************************************************
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Epicor.Mfg.BO
Imports Epicor.Mfg.UI
Imports Epicor.Mfg.UI.Adapters
Imports Epicor.Mfg.UI.Customization
Imports Epicor.Mfg.UI.ExtendedProps
Imports Epicor.Mfg.UI.FormFunctions
Imports Epicor.Mfg.UI.FrameWork
Imports Epicor.Mfg.UI.Searches

Public Class Script

  ' ** Wizard Insert Location - Do Not Remove 'Begin/End Wizard Added Module Level Variables' Comments! **
	' Begin Wizard Added Module Level Variables **

	' End Wizard Added Module Level Variables **

	' Add Custom Module Level Variables Here **

	Public Sub InitializeCustomCode()
		' ** Wizard Insert Location - Do not delete 'Begin/End Wizard Added Variable Initialization' lines **
		' Begin Wizard Added Variable Initialization

		' End Wizard Added Variable Initialization

		' Begin Wizard Added Custom Method Calls

		' End Wizard Added Custom Method Calls
    TagCountForm.Keypreview = True
	End Sub

	Public Sub DestroyCustomCode()
		' ** Wizard Insert Location - Do not delete 'Begin/End Wizard Added Object Disposal' lines **
		' Begin Wizard Added Object Disposal

		' End Wizard Added Object Disposal

		' Begin Custom Code Disposal

		' End Custom Code Disposal
	End Sub




Private Sub TagCountForm_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TagCountForm.KeyPress
	Dim TagLabelbox As EpitextBox = ctype(csm.GetNativeControlReference("702631b5-afc8-4bdf-b455-170853770c55"),EpiTextBox)

	Select Case e.KeyChar
		Case "`"
			e.Handled = true
		TagLabelbox.Focus()
		TagLabelbox.Select()
	End Select
End Sub


End Class
