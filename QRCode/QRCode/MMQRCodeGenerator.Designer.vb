<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MMQRCodeGenerator
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MMQRCodeGenerator))
		txtContent = New TextBox()
		txtBottomText = New TextBox()
		txtTopText = New TextBox()
		txtLogoPath = New TextBox()
		OpenFileDialog1 = New OpenFileDialog()
		ColorDialog1 = New ColorDialog()
		btnGenerate = New Button()
		btnUploadLogo = New Button()
		PictureBox1 = New PictureBox()
		Label1 = New Label()
		Label2 = New Label()
		Label3 = New Label()
		Label4 = New Label()
		Label5 = New Label()
		Button1 = New Button()
		Button2 = New Button()
		ColorDialog2 = New ColorDialog()
		ColorDialog3 = New ColorDialog()
		ColorDialog4 = New ColorDialog()
		Label6 = New Label()
		Label7 = New Label()
		txtHeight = New TextBox()
		Label8 = New Label()
		Button3 = New Button()
		btnSave = New Button()
		cmbFileFormat = New ComboBox()
		CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' txtContent
		' 
		txtContent.Location = New Point(418, 71)
		txtContent.Name = "txtContent"
		txtContent.Size = New Size(417, 31)
		txtContent.TabIndex = 0
		txtContent.Text = "www.mainmanexample.com"
		' 
		' txtBottomText
		' 
		txtBottomText.Location = New Point(418, 167)
		txtBottomText.Name = "txtBottomText"
		txtBottomText.Size = New Size(417, 31)
		txtBottomText.TabIndex = 1
		txtBottomText.Text = "Let's go further"
		' 
		' txtTopText
		' 
		txtTopText.Location = New Point(418, 119)
		txtTopText.Name = "txtTopText"
		txtTopText.Size = New Size(417, 31)
		txtTopText.TabIndex = 2
		txtTopText.Text = "Welcome to Main Manager"
		' 
		' txtLogoPath
		' 
		txtLogoPath.Location = New Point(418, 207)
		txtLogoPath.Name = "txtLogoPath"
		txtLogoPath.Size = New Size(264, 31)
		txtLogoPath.TabIndex = 3
		txtLogoPath.Text = "C:\Users\sujsh\Downloads\images.jpg"
		' 
		' OpenFileDialog1
		' 
		OpenFileDialog1.FileName = "OpenFileDialog1"
		' 
		' btnGenerate
		' 
		btnGenerate.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		btnGenerate.Location = New Point(92, 458)
		btnGenerate.Name = "btnGenerate"
		btnGenerate.Size = New Size(472, 53)
		btnGenerate.TabIndex = 4
		btnGenerate.Text = "Generate QR Code"
		btnGenerate.UseVisualStyleBackColor = True
		' 
		' btnUploadLogo
		' 
		btnUploadLogo.Location = New Point(697, 207)
		btnUploadLogo.Name = "btnUploadLogo"
		btnUploadLogo.Size = New Size(41, 34)
		btnUploadLogo.TabIndex = 5
		btnUploadLogo.Text = "..."
		btnUploadLogo.UseVisualStyleBackColor = True
		' 
		' PictureBox1
		' 
		PictureBox1.Location = New Point(853, 71)
		PictureBox1.Name = "PictureBox1"
		PictureBox1.Size = New Size(932, 884)
		PictureBox1.TabIndex = 6
		PictureBox1.TabStop = False
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Font = New Font("Segoe UI", 12.0F)
		Label1.Location = New Point(90, 70)
		Label1.Name = "Label1"
		Label1.Size = New Size(264, 32)
		Label1.TabIndex = 7
		Label1.Text = "Enter QR Code Content"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Segoe UI", 12.0F)
		Label2.Location = New Point(90, 121)
		Label2.Name = "Label2"
		Label2.Size = New Size(250, 32)
		Label2.TabIndex = 8
		Label2.Text = "Enter the Top Content"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Segoe UI", 12.0F)
		Label3.Location = New Point(90, 164)
		Label3.Name = "Label3"
		Label3.Size = New Size(290, 32)
		Label3.TabIndex = 9
		Label3.Text = "Enter the Bottom Content"
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Font = New Font("Segoe UI", 12.0F)
		Label4.Location = New Point(90, 206)
		Label4.Name = "Label4"
		Label4.Size = New Size(180, 32)
		Label4.TabIndex = 10
		Label4.Text = "Select the Logo"
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Font = New Font("Segoe UI", 12.0F)
		Label5.Location = New Point(90, 249)
		Label5.Name = "Label5"
		Label5.Size = New Size(223, 32)
		Label5.TabIndex = 11
		Label5.Text = "Select the QR Color"
		' 
		' Button1
		' 
		Button1.Location = New Point(418, 249)
		Button1.Name = "Button1"
		Button1.Size = New Size(41, 34)
		Button1.TabIndex = 12
		Button1.Text = "..."
		Button1.UseVisualStyleBackColor = True
		' 
		' Button2
		' 
		Button2.Location = New Point(418, 300)
		Button2.Name = "Button2"
		Button2.Size = New Size(41, 34)
		Button2.TabIndex = 13
		Button2.Text = "..."
		Button2.UseVisualStyleBackColor = True
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.Font = New Font("Segoe UI", 12.0F)
		Label6.Location = New Point(90, 299)
		Label6.Name = "Label6"
		Label6.Size = New Size(320, 32)
		Label6.TabIndex = 14
		Label6.Text = "Select the BackGround Color"
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.Font = New Font("Segoe UI", 12.0F)
		Label7.Location = New Point(92, 402)
		Label7.Name = "Label7"
		Label7.Size = New Size(158, 32)
		Label7.TabIndex = 15
		Label7.Text = "Enter QR Size"
		' 
		' txtHeight
		' 
		txtHeight.Location = New Point(418, 405)
		txtHeight.Name = "txtHeight"
		txtHeight.Size = New Size(146, 31)
		txtHeight.TabIndex = 17
		txtHeight.Text = "250"
		' 
		' Label8
		' 
		Label8.AutoSize = True
		Label8.Font = New Font("Segoe UI", 12.0F)
		Label8.Location = New Point(92, 349)
		Label8.Name = "Label8"
		Label8.Size = New Size(234, 32)
		Label8.TabIndex = 19
		Label8.Text = "Select the Text Color"
		' 
		' Button3
		' 
		Button3.Location = New Point(420, 350)
		Button3.Name = "Button3"
		Button3.Size = New Size(41, 34)
		Button3.TabIndex = 18
		Button3.Text = "..."
		Button3.UseVisualStyleBackColor = True
		' 
		' btnSave
		' 
		btnSave.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		btnSave.Location = New Point(92, 527)
		btnSave.Name = "btnSave"
		btnSave.Size = New Size(184, 53)
		btnSave.TabIndex = 20
		btnSave.Text = "Save QR"
		btnSave.UseVisualStyleBackColor = True
		' 
		' cmbFileFormat
		' 
		cmbFileFormat.FormattingEnabled = True
		cmbFileFormat.Location = New Point(296, 539)
		cmbFileFormat.Name = "cmbFileFormat"
		cmbFileFormat.Size = New Size(182, 33)
		cmbFileFormat.TabIndex = 21
		' 
		' MMQRCodeGenerator
		' 
		AutoScaleDimensions = New SizeF(10.0F, 25.0F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(1869, 999)
		Controls.Add(cmbFileFormat)
		Controls.Add(btnSave)
		Controls.Add(Label8)
		Controls.Add(Button3)
		Controls.Add(txtHeight)
		Controls.Add(Label7)
		Controls.Add(Label6)
		Controls.Add(Button2)
		Controls.Add(Button1)
		Controls.Add(Label5)
		Controls.Add(Label4)
		Controls.Add(Label3)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Controls.Add(PictureBox1)
		Controls.Add(btnUploadLogo)
		Controls.Add(btnGenerate)
		Controls.Add(txtLogoPath)
		Controls.Add(txtTopText)
		Controls.Add(txtBottomText)
		Controls.Add(txtContent)
		Icon = CType(resources.GetObject("$this.Icon"), Icon)
		Name = "MMQRCodeGenerator"
		Text = "Main Manager QR Code Generator"
		CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents txtContent As TextBox
	Friend WithEvents txtBottomText As TextBox
	Friend WithEvents txtTopText As TextBox
	Friend WithEvents txtLogoPath As TextBox
	Friend WithEvents OpenFileDialog1 As OpenFileDialog
	Friend WithEvents ColorDialog1 As ColorDialog
	Friend WithEvents btnGenerate As Button
	Friend WithEvents btnUploadLogo As Button
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents ColorDialog2 As ColorDialog
	Friend WithEvents ColorDialog3 As ColorDialog
	Friend WithEvents ColorDialog4 As ColorDialog
	Friend WithEvents Label6 As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents txtHeight As TextBox
	Friend WithEvents Label8 As Label
	Friend WithEvents Button3 As Button
	Friend WithEvents btnSave As Button
	Friend WithEvents cmbFileFormat As ComboBox

End Class
