'//**************************************************
'// Custom VB.NET code for UD02Form
'// Created: 8/15/2011 12:12:13 PM
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

'Updates Character field in Company table. Used for custom message at bottom of MES screen

Module Script 

   	 Private WithEvents edvUD09 As EpiDataView
  	'// ** Wizard Insert Location - Do Not Remove 'Begin/End Wizard Added Module Level Variables' Comments! ** 
	'// Begin Wizard Added Module Level Variables ** 
	'// End Wizard Added Module Level Variables ** 
	'// Add Custom Module Level Variables Here ** 
	
	Sub InitializeCustomCode() 
		'// ** Wizard Insert Location - Do not delete 'Begin/End Wizard Added Variable Intialization' lines ** 
		'// Begin Wizard Added Variable Intialization 
		'// End Wizard Added Variable Intialization 
		'// Begin Custom Method Calls 
		'// End Custom Method Calls 
	End Sub 


	Sub DestroyCustomCode() 
		'// ** Wizard Insert Location - Do not delete 'Begin/End Wizard Added Object Disposal' lines ** 
		'// Begin Wizard Added Object Disposal 
		'// End Wizard Added Object Disposal 
		'// Begin Custom Code Disposal 
		'// End Custom Code Disposal 
	End Sub 


	Private Sub UD02Form_Load(ByVal sender As object, ByVal args As EventArgs) Handles UD02Form.Load
		'//
		'// Add Event Handler Code
		'//
		Dim compAdapt As CompanyAdapter = New CompanyAdapter (UD02Form)
		compAdapt.BOConnect ()
		dim company as string
		company = "ACT"
		compAdapt.GetByID(company)
		compAdapt.CompanyData.Tables("Company").Rows(0).BeginEdit()
		txtEpiCustom1.Text = compAdapt.CompanyData.Tables("Company").Rows(0)("Character02")
        	txtEpiCustom2.Text = compAdapt.CompanyData.Tables("Company").Rows(0)("Character02")
		compAdapt.CompanyData.Tables("Company").Rows(0).EndEdit()
		compAdapt.Update( )
	        
		compAdapt.Dispose( )
		End Sub


	Private Sub btnEpiCustom1_MouseDown(ByVal Sender As Object, ByVal Args As System.Windows.Forms.MouseEventArgs) Handles btnEpiCustom1.MouseDown
		'// ** Place Event Handling Code Here ** 
	
		Dim view As EpiDataView = CType(oTrans.EpiDataViews("UD02"), EpiDataView)
		Dim compAdapt As CompanyAdapter = New CompanyAdapter (UD02Form)
	    	if (txtEpiCustom2.Text = "") then
	    	    MessageBox.Show("Please enter a value.")
	        	return
	    	end if
	    	Dim message As String = txtEpiCustom2.Text
		compAdapt.BOConnect ()
		dim company as string
	    	company = "ACT"
	    	compAdapt.GetByID(company)
		compAdapt.CompanyData.Tables("Company").Rows(0).BeginEdit()
		compAdapt.CompanyData.Tables("Company").Rows(0)("Character02") = message
		compAdapt.CompanyData.Tables("Company").Rows(0).EndEdit()
		compAdapt.Update( )
	    	txtEpiCustom1.Text = compAdapt.CompanyData.Tables("Company").Rows(0)("Character02")
		compAdapt.Dispose( )
		End Sub


End Module 
