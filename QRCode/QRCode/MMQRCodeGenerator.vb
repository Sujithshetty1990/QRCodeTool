Imports QRCoder
Imports Svg
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Reflection.Metadata
Public Class MMQRCodeGenerator
	Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
		Dim content = txtContent.Text
		Dim logoPath = txtLogoPath.Text
		Dim topText = txtTopText.Text
		Dim bottomText = txtBottomText.Text
		Dim qrColor1 = ColorDialog1.Color
		Dim textColor = ColorDialog3.Color
		Dim qrColor2 = Color.White

		If ColorDialog2.Color <> Color.White AndAlso ColorDialog2.Color <> Color.Black Then
			qrColor2 = ColorDialog2.Color
		End If

		Dim qrWidth = Integer.Parse(txtHeight.Text)
		Dim qrHeight = Integer.Parse(txtHeight.Text)

		'Dim qrCodeImage = GenerateQRCode(content, logoPath, topText, bottomText, qrColor1, qrColor2, qrWidth, qrHeight)
		Dim qrCodeImage = GenerateQRCode(content, logoPath, topText, bottomText, qrColor1, qrColor2, qrWidth, qrHeight)
		PictureBox1.Image = qrCodeImage
		PictureBox1.Width = qrCodeImage.Width
		PictureBox1.Height = qrCodeImage.Height
		PictureBox1.Image = qrCodeImage
	End Sub

	Public Function FindDuplicateValues(items As List(Of Integer)) As List(Of Integer)
    Dim duplicates As New List(Of Integer)

    For i As Integer = 0 To items.Count - 1
        For j As Integer = i + 1 To items.Count - 1
            If items(i) = items(j) AndAlso Not duplicates.Contains(items(i)) Then
                duplicates.Add(items(i))
            End If
        Next
    Next

    Return duplicates
End Function

	Public Sub WriteLog(message As String)
    Dim logFile As String = "C:\Temp\Application.log"

    Try
        Using writer As New System.IO.StreamWriter(logFile, True)
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}")
        End Using
    Catch ex As Exception
        Console.WriteLine("Logging failed: " & ex.Message)
    End Try
	End Sub

	Private Function GenerateQRCode(content As String, logoPath As String, topText As String, bottomText As String, qrColor1 As Color, qrColor2 As Color, qrWidth As Integer, qrHeight As Integer) As Bitmap
		Dim qrGenerator As New QRCodeGenerator()
		Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.H)
		Dim qrCode As New QRCoder.QRCode(qrCodeData)

		' Generate QR code image
		Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20, qrColor1, qrColor2, GetLogoBitmap(logoPath), 15)
		Dim resizedQRCodeImage As New Bitmap(qrCodeImage, New Size(qrWidth, qrHeight))
		' Apply gradient to QR code image
		Dim gradientQRCode As New Bitmap(resizedQRCodeImage.Width, resizedQRCodeImage.Height)

		Dim destPoints As New PointF(0, 0)
		' Create a color matrix
		Dim colorMatrixElements As Single()() = {
		New Single() {1, 0, 0, 0, 0},
		New Single() {0, 1, 0, 0, 0},
		New Single() {0, 0, 1, 0, 0},
		New Single() {0, 0, 0, 1, 0}, ' Apply 100% opacity
		New Single() {0, 0, 0, 0, 1}
}
		Dim colorMatrix As New Imaging.ColorMatrix(colorMatrixElements)

		' Create an ImageAttributes object and set the color matrix
		Dim imageAttributes As New Imaging.ImageAttributes()
		imageAttributes.SetColorMatrix(colorMatrix, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)

		Using g As Graphics = Graphics.FromImage(gradientQRCode)
			' Apply gradient only to the QR code drawing area
			Dim rect As New Rectangle(0, 0, resizedQRCodeImage.Width, resizedQRCodeImage.Height)
			Using gradientBrush As New LinearGradientBrush(rect, qrColor1, qrColor2, LinearGradientMode.BackwardDiagonal)
				g.FillRectangle(gradientBrush, rect)
				g.CompositingMode = CompositingMode.SourceOver
				g.DrawImage(resizedQRCodeImage, rect, 0, 0, resizedQRCodeImage.Width, resizedQRCodeImage.Height, GraphicsUnit.Pixel, imageAttributes)
			End Using
		End Using

		' Add top and bottom text
		Dim finalImage As Bitmap = AddTextToImage(gradientQRCode, topText, bottomText, qrWidth, qrHeight)
		SaveQRCodeImage(finalImage)
		Return finalImage
	End Function

    Public Function ExecuteWithRetry(action As Action) As Boolean
    Dim maxRetries As Integer = 3

    For i As Integer = 1 To maxRetries
        Try
            action.Invoke()
            Return True
        Catch ex As Exception
            Threading.Thread.Sleep(1000)
        End Try
    Next

    Return False
	End Function
	
	Private Function GenerateQRCode_Latest(content As String, logoPath As String, topText As String, bottomText As String, qrColor1 As Color, qrColor2 As Color) As Bitmap
		Dim qrGenerator As New QRCodeGenerator()
		Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.H)
		'Dim qrCode As New ArtQRCode(qrCodeData)

		Dim qrCode As New QRCoder.QRCode(qrCodeData)

		' Generate QR code image
		Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20, qrColor1, qrColor2, GetLogoBitmap(logoPath), 15)
		Dim gradientQRCode As New Bitmap(qrCodeImage.Width, qrCodeImage.Height)
		'Dim g As Graphics = Graphics.FromImage(gradientQRCode)

		' Apply gradient
		'Dim rect As New Rectangle(0, 0, qrCodeImage.Width, qrCodeImage.Height)
		'Dim gradientBrush As New LinearGradientBrush(rect, qrColor1, qrColor2, LinearGradientMode.ForwardDiagonal)
		'g.FillRectangle(gradientBrush, rect)
		'g.DrawImage(qrCodeImage, 0, 0, rect, GraphicsUnit.Pixel)

		Dim destPoints As New PointF(0, 0)
		' Create a color matrix
		Dim colorMatrixElements As Single()() = {
		New Single() {1, 0, 0, 0, 0},
		New Single() {0, 1, 0, 0, 0},
		New Single() {0, 0, 1, 0, 0},
		New Single() {0, 0, 0, 1, 0}, ' Apply 50% opacity
		New Single() {0, 0, 0, 0, 1}
}
		Dim colorMatrix As New Imaging.ColorMatrix(colorMatrixElements)

		' Create an ImageAttributes object and set the color matrix
		Dim imageAttributes As New Imaging.ImageAttributes()
		imageAttributes.SetColorMatrix(colorMatrix, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)

		Using g As Graphics = Graphics.FromImage(gradientQRCode)
			' Apply gradient only to the QR code drawing area
			Dim rect As New Rectangle(0, 0, qrCodeImage.Width, qrCodeImage.Height)
			Using gradientBrush As New LinearGradientBrush(rect, qrColor1, qrColor2, LinearGradientMode.BackwardDiagonal)
				g.FillRectangle(gradientBrush, rect)
				g.CompositingMode = CompositingMode.SourceOver
				g.DrawImage(qrCodeImage, rect, 0, 0, qrCodeImage.Width, qrCodeImage.Height, GraphicsUnit.Pixel, imageAttributes)
			End Using
		End Using



		' Add top and bottom text
		Dim finalImage As Bitmap = AddTextToImage(gradientQRCode, topText, bottomText, 100, 100)
		SaveQRCodeImage(finalImage)
		Return finalImage
	End Function
	Private Sub SaveQRCodeImage(image As Bitmap)
		Try
			If image IsNot Nothing Then

				' Save the image
				'Dim fullPath = IO.Path.Combine(directory, filePath)
				'image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)
			Else
				Throw New ArgumentNullException(NameOf(image), "Image cannot be null.")
			End If
		Catch ex As Exception
			' Handle the exception (e.g., log it)
		End Try
	End Sub

	Private Sub btnUploadLogo_Click(sender As Object, e As EventArgs) Handles btnUploadLogo.Click
		If OpenFileDialog1.ShowDialog = DialogResult.OK Then
			txtLogoPath.Text = OpenFileDialog1.FileName
		End If
	End Sub

	Private Function GetLogoBitmap(logoPath As String) As Bitmap
		If String.IsNullOrEmpty(logoPath) Then
			Return Nothing
		End If
		Dim logo As Bitmap = CType(Bitmap.FromFile(logoPath), Bitmap)
		'	logo.MakeTransparent(Color.White)
		Return logo
	End Function

	Private Function AddTextToImage(image As Bitmap, topText As String, bottomText As String, qrWidth As Integer, qrHeight As Integer) As Bitmap
		Dim newImage As New Bitmap(qrWidth, qrHeight)
		Using g As Graphics = Graphics.FromImage(newImage)
			g.Clear(Color.White)
			g.DrawImage(image, 0, 0)
			'Dim font As New Font("Arial", 4)
			Dim fontSize As Single = Math.Max(4, qrWidth / 25)



			Dim Font As New Font("Arial", fontSize)
			Dim brush As New SolidBrush(ColorDialog3.Color)
			Dim format As New StringFormat()
			format.Alignment = StringAlignment.Center
			g.DrawString(topText, Font, brush, CSng(newImage.Width / 2), 0, format)
			'g.DrawString(bottomText, font, brush, CSng(newImage.Width / 2), CSng(image.Height + 20), format)
			' Measure the bottom text size
			Dim bottomTextSize As SizeF = g.MeasureString(bottomText, Font)

			' Adjust the bottom text position to ensure it fits within the image
			Dim bottomTextY As Single = CSng(image.Height)
			If bottomTextY + bottomTextSize.Height > newImage.Height Then
				bottomTextY = newImage.Height - bottomTextSize.Height
			End If

			' Draw bottom text
			g.DrawString(bottomText, Font, brush, CSng(newImage.Width / 2), bottomTextY, format)

		End Using
		Return newImage
	End Function

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		If ColorDialog1.ShowDialog = DialogResult.OK Then

		End If
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		If ColorDialog2.ShowDialog = DialogResult.OK Then
		Else
			ColorDialog2.Color = Color.White
		End If
	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
		If ColorDialog3.ShowDialog = DialogResult.OK Then
		Else
			ColorDialog3.Color = Color.Black
		End If
	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		cmbFileFormat.Items.Add("Base64")
		cmbFileFormat.Items.Add("PNG")
		cmbFileFormat.Items.Add("JPEG")
		cmbFileFormat.Items.Add("SVG")
		cmbFileFormat.Items.Add("PDF")
		cmbFileFormat.SelectedIndex = 0
	End Sub

	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
		If PictureBox1.Image IsNot Nothing Then
			Using saveFileDialog As New SaveFileDialog()
				saveFileDialog.Title = "Save QR Code"
				saveFileDialog.FileName = "QRCode"

				' Set the filter based on the selected file format
				Select Case cmbFileFormat.SelectedItem.ToString()
					Case "Base64"
						saveFileDialog.Filter = "TXT Document|*.txt"
					Case "PNG"
						saveFileDialog.Filter = "PNG Image|*.png"
					Case "JPEG"
						saveFileDialog.Filter = "JPEG Image|*.jpg"
					Case "PDF"
						saveFileDialog.Filter = "PDF Document|*.pdf"
					Case "SVG"
						saveFileDialog.Filter = "SVG Image|*.svg"
					Case Else
						MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
						Return
				End Select

				If saveFileDialog.ShowDialog() = DialogResult.OK Then
					Dim filePath As String = saveFileDialog.FileName
					Dim fileExtension As String = IO.Path.GetExtension(filePath).ToLower()

					Select Case fileExtension
						Case ".txt"
							SaveImageAsBase64(PictureBox1.Image, filePath)
						Case ".png"
							PictureBox1.Image.Save(filePath, ImageFormat.Png)
						Case ".jpg"
							PictureBox1.Image.Save(filePath, ImageFormat.Jpeg)
						Case ".svg"
							SaveImageAsSvg(PictureBox1.Image, filePath)
						Case ".pdf"
							'	SaveImageAsPdf(PictureBox1.Image, filePath)
						Case Else
							MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
					End Select
				End If
			End Using
		Else
			MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub SaveImageAsBase64(image As Image, filePath As String)
		Dim base64String As String
		Using ms As New IO.MemoryStream()
			image.Save(ms, ImageFormat.Png)
			Dim imageBytes As Byte() = ms.ToArray()
			base64String = Convert.ToBase64String(imageBytes)
		End Using

		' Save the Base64 content to the specified file path
		IO.File.WriteAllText(filePath, base64String)
	End Sub

	Private Sub SaveImageAsSvg(image As Image, filePath As String)
		Dim base64String As String
		Using ms As New IO.MemoryStream()
			image.Save(ms, ImageFormat.Png)
			Dim imageBytes As Byte() = ms.ToArray()
			base64String = Convert.ToBase64String(imageBytes)
		End Using

		' Create the SVG content with the embedded base64 image
		Dim svgContent As String = $"<svg xmlns='http://www.w3.org/2000/svg' width='{image.Width}' height='{image.Height}'>" &
															 $"<image href='data:image/png;base64,{base64String}' width='{image.Width}' height='{image.Height}' />" &
															 "</svg>"

		' Save the SVG content to the specified file path
		IO.File.WriteAllText(filePath, svgContent)
	End Sub




	'Private Sub SaveImageAsPdf(image As Image, filePath As String)
	'	Dim document As New Document(PageSize.A4)
	'	Try
	'		PdfWriter.GetInstance(document, New IO.FileStream(filePath, IO.FileMode.Create))
	'		document.Open()
	'		Dim pdfImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(image, ImageFormat.Png)
	'		pdfImage.ScaleToFit(document.PageSize.Width - 50, document.PageSize.Height - 50)
	'		pdfImage.Alignment = Element.ALIGN_CENTER
	'		document.Add(pdfImage)
	'	Catch ex As Exception
	'		MessageBox.Show($"Error saving PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
	'	Finally
	'		document.Close()
	'	End Try
	'End Sub
End Class
