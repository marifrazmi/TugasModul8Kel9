Imports TempConv

Public Class Form1
    Private currentIndex As Integer = 0

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Get the selected item from the ComboBox
        Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

        ' Split the selected item into words
        Dim words As String() = selectedItem.Split(" "c)

        ' Display the second word in Label1
        If words.Length >= 2 Then
            Label1.Text = words(1)
            Label5.Text = words(1)
        Else
            Label1.Text = "N/A"
        End If

        ' Display the first word in Label2
        If words.Length >= 1 Then
            Label2.Text = words(3)
            Label6.Text = words(3)
        Else
            Label2.Text = "N/A"
        End If

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Text = String.Empty
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Temperature Conversion Calculator"
        RadioButton1.Checked = True
        TextBox3.ReadOnly = True
        TextBox3.Enabled = False
        TextBox1.ReadOnly = True
        TextBox1.Enabled = False
        ComboBox1.Items.AddRange({
            "Konversi Celcius - Reamur",
            "Konversi Celcius - Fahrenheit",
            "Konversi Celcius - Kelvin",
            "Konversi Reamur - Fahrenheit",
            "Konversi Reamur - Kelvin",
            "Konversi Fahrenheit - Kelvin"
        })

        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
        Dim objConv As New TempConv.TempConvComp
        ' Convert the input value based on the selected item
        Dim inputValue As Double
        Dim result As Double
        If Double.TryParse(TextBox2.Text, inputValue) Then
            TextBox1.Text = inputValue
            If TextBox2.Enabled AndAlso Not TextBox2.ReadOnly Then
                Select Case selectedItem
                    Case "Konversi Celcius - Reamur"
                        TextBox4.Text = objConv.cTor(inputValue).ToString()
                        TextBox3.Text = objConv.cTor(inputValue).ToString()
                    Case "Konversi Celcius - Fahrenheit"
                        TextBox4.Text = objConv.cToF(inputValue).ToString()
                        TextBox3.Text = objConv.cToF(inputValue).ToString()
                    Case "Konversi Celcius - Kelvin"
                        TextBox4.Text = objConv.cTok(inputValue).ToString()
                        TextBox3.Text = objConv.cTok(inputValue).ToString()

                    Case "Konversi Reamur - Fahrenheit"
                        TextBox4.Text = objConv.rToF(inputValue).ToString()
                        TextBox3.Text = objConv.rToF(inputValue).ToString()
                    Case "Konversi Reamur - Kelvin"
                        TextBox4.Text = objConv.rToK(inputValue).ToString()
                        TextBox3.Text = objConv.rToK(inputValue).ToString()

                    Case "Konversi Fahrenheit - Kelvin"
                        TextBox4.Text = objConv.fToK(inputValue).ToString()
                        TextBox3.Text = objConv.fToK(inputValue).ToString()

                    Case Else
                        ' Handle additional conversion cases if needed
                End Select
            End If
        End If


        If Double.TryParse(TextBox4.Text, inputValue) Then
            TextBox3.Text = inputValue
            If TextBox4.Enabled AndAlso Not TextBox4.ReadOnly Then
                Select Case selectedItem
                    Case "Konversi Celcius - Reamur"
                        TextBox2.Text = objConv.rToc(inputValue).ToString()
                        TextBox1.Text = objConv.rToc(inputValue).ToString()
                    Case "Konversi Celcius - Fahrenheit"
                        TextBox2.Text = objConv.fToC(inputValue).ToString()
                        TextBox1.Text = objConv.fToC(inputValue).ToString()
                    Case "Konversi Celcius - Kelvin"
                        TextBox2.Text = objConv.kToc(inputValue).ToString()
                        TextBox1.Text = objConv.kToc(inputValue).ToString()

                    Case "Konversi Reamur - Fahrenheit"
                        TextBox2.Text = objConv.fTor(inputValue).ToString()
                        TextBox1.Text = objConv.fTor(inputValue).ToString()
                    Case "Konversi Reamur - Kelvin"
                        TextBox2.Text = objConv.kTor(inputValue).ToString()
                        TextBox1.Text = objConv.kTor(inputValue).ToString()

                    Case "Konversi Fahrenheit ke Kelvin"
                        TextBox2.Text = objConv.kTof(inputValue).ToString()
                        TextBox1.Text = objConv.kTof(inputValue).ToString()

                    Case Else
                        ' Handle additional conversion cases if needed
                End Select
            End If
        End If

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        ' Allow only digits and control characters (like Backspace)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox4.ReadOnly = True
        TextBox4.Enabled = False
        TextBox2.ReadOnly = False
        TextBox2.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox2.ReadOnly = True
        TextBox2.Enabled = False
        TextBox4.ReadOnly = False
        TextBox4.Enabled = True
    End Sub
End Class
