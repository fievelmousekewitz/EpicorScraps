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

		AddHandler Script.epiButtonC1.Click, AddressOf Script.epiButtonC1_Click

	End Sub 

		
Sub update_comp_message() 'Sets Messagebox for ACTI HR Company Message
     Dim compAdapt As CompanyAdapter = New CompanyAdapter (MESMENU)
	 Dim txtIdBox As EpitextBox = ctype(csm.GetNativeControlReference("fca2b60c-95cf-40b4-adc0-c168fc3a43fc"),EpitextBox)
     compAdapt.BOConnect ()
     dim company as string
     company = "ACT"
     compAdapt.GetByID(company)
     compAdapt.CompanyData.Tables("Company").Rows(0).BeginEdit()
     txtEpiCustom2.Text = compAdapt.CompanyData.Tables("Company").Rows(0)("Character02")
     Dim newFont as New System.Drawing.Font("Tahoma",18,System.Drawing.FontStyle.Bold)
     txtEpiCustom2.Font = newFont
     compAdapt.CompanyData.Tables("Company").Rows(0).EndEdit()
     compAdapt.Update( )
	 txtIdBox.Focus()


     compAdapt.Dispose( )
End Sub



	Sub DestroyCustomCode() 

		RemoveHandler Script.epiButtonC1.Click, AddressOf Script.epiButtonC1_Click 'LOB
		RemoveHandler Script.MESMenu.Keypress, AddressOf Script.Form1_Keypress
	End Sub 

	Private Sub MESMenu_Load(ByVal sender As object, ByVal args As EventArgs) Handles MESMenu.Load

		picEpiCustom1.Image = System.Drawing.Image.FromFile("\\APOLLO\Epicor905\acti.jpg")
		update_comp_message() 'Update the Company message on load
		Dim LogoutBtn As Epibutton = ctype(csm.GetNativeControlReference("d69f285b-eee4-48fd-a6fa-174583fdfbd9"),Epibutton)
		LogoutBtn.UseAppStyling = False
		LogoutBtn.BackColor = System.Drawing.Color.Red
	      MESMenu.Keypreview = true 
 		
		
	'MESMenu.ActiveControl = txtIDBox


	End Sub



Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MESMenu.KeyPress

  Dim txtIdBox As EpitextBox = ctype(csm.GetNativeControlReference("fca2b60c-95cf-40b4-adc0-c168fc3a43fc"),EpitextBox)
  Dim LogoutBtn As Epibutton = ctype(csm.GetNativeControlReference("a2f6e795-4ab3-4121-bce4-e1d5f0881b0a"),Epibutton)
  Dim ClockOutBtn As EpiButton = ctype(csm.GetNativeControlReference("1c55d195-3d9f-4883-8151-3fc15a3d7b8d"),EpiButton)


'This is about to get messy. Watch out.

if (txtIdBox.Focused = False) 

	if (e.KeyChar = Convert.ToString("1") )
		txtIdBox.Select()
		SendKeys.Send("1")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("2") )
		txtIdBox.Select()
		SendKeys.Send("2")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("3") )
		txtIdBox.Select()
		SendKeys.Send("3")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("4") )
		txtIdBox.Select()
		SendKeys.Send("4")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("5") )
		txtIdBox.Select()
		SendKeys.Send("5")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("6") )
		txtIdBox.Select()
		SendKeys.Send("6")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("7") )
		txtIdBox.Select()
		SendKeys.Send("7")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("8") )
		txtIdBox.Select()
		SendKeys.Send("8")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("9") )
		txtIdBox.Select()
		SendKeys.Send("9")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("0") )
		txtIdBox.Select()
		SendKeys.Send("0")
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("L") )
		LogoutBtn.PerformClick()
		e.Handled() = True
		End if
	if (e.KeyChar = Convert.ToString("O") )
		txtIdBox.Focus()
		ClockOutBtn.PerformClick()
		e.Handled() = True
		End if


End if 'focused


End Sub

	Private Sub MESControl_AfterFieldChange(ByVal sender As object, ByVal args As DataColumnChangeEventArgs) Handles MESControl_Column.ColumnChanged
		
		Select Case args.Column.ColumnName
	
			Case "LoggedIn"
               dim edvMESControl as epidataview = CType(oTrans.EpiDataViews("MESControl"), EpiDataView)
               dim edvEmpBasic as epidataview = CType(oTrans.EpiDataViews("EmpBasic"), EpiDataView)
               dim logd as boolean = edvMESControl.dataView(edvMESControl.Row)("LoggedIn")
                 if (logd = false) then 
                   edvEmpBasic.dataview(edvEmpBasic.Row)("EmpID") = "" 'If we dont clear this, MyHours will report last logged in emp while no user is logged in.
                 end if
                 
                 
			Case "EmployeeID"
				update_comp_message() 'Update on each employee scan, so we make sure it's up to date!
			Case Else
	
		End Select
	
	End Sub
	


	Private Sub btnEpiCustom1_Click(ByVal Sender As Object, ByVal Args As System.EventArgs) Handles btnEpiCustom1.Click 'Not really needed anymore, but hey, it's here yo.
		ProcessCaller.LaunchForm(oTrans, "UDLOBPR")
	End Sub



	Private Sub epiButtonC1_Click(ByVal sender As Object, ByVal args As System.EventArgs)
		ProcessCaller.LaunchForm(oTrans, "UDLOBPR")
	End Sub
End Module 
