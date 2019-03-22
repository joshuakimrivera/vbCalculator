Public Class Form1
    Dim op1 As Double = 0
    Dim op2 As Double = 0
    Dim operationSelected As Boolean = False
    Dim equation As String = " "
    Dim operationSign As String = " "
    Dim stringContainer As String


    Private Sub buttonEntry(sender As Object, e As EventArgs) Handles buttonZero.Click, buttonOne.Click, buttonTwo.Click, buttonThree.Click, buttonFour.Click, buttonFive.Click, buttonSix.Click, buttonSeven.Click, buttonEight.Click, buttonNine.Click, periodButton.Click




        If outBox.Text = "0" Or operationSelected Then
            If Not outBox.Text.Contains(".") And sender.Text = "." Then
                stringContainer = outBox.Text + sender.Text
                MessageBox.Show(stringContainer)
                outBox.Text = " "
                outBox.Text = stringContainer
            Else
                outBox.Text = sender.Text
            End If
            operationSelected = False
        ElseIf sender.Text = "." Then
            If Not outBox.Text.Contains(".") Then
                outBox.Text += sender.Text
            End If
        Else
            outBox.Text += sender.Text
        End If


    End Sub

    Private Sub performOperation(sender As Button)
        If sender.Text = "+" Then
            op1 += Convert.ToDouble(outBox.Text)
        End If
        If sender.Text = "-" Then
            op1 -= Convert.ToDouble(outBox.Text)
        End If
        equation += sender.Text + outBox.Text
        equationBox.Text = equation
        outBox.Text = op1
        operationSelected = True

    End Sub



    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click, subButton.Click
        performOperation(sender)

    End Sub


    Private Sub performOperation(sender As Object, e As EventArgs) Handles equalButton.Click
        If operationSign = "+" Then
            op1 += Convert.ToDouble(outBox.Text)
            operationSelected = True
            equation = " "
            equationBox.Text = " "
            outBox.Text = op1
            op1 = 0
        End If
    End Sub

    Private Sub clearEntry(sender As Object, e As EventArgs) Handles ceButton.Click
        outBox.Text = 0
    End Sub

    Private Sub clear(sender As Object, e As EventArgs) Handles cButton.Click
        op1 = 0
        operationSelected = False
        equation = " "
        equationBox.Text = equation
        outBox.Text = "0"
    End Sub

    Private Sub delBackspace(sender As Object, e As EventArgs) Handles delButton.Click
        If outBox.Text.Length > 0 Then
            If outBox.Text.Length = 1 Then
                outBox.Text = "0"
            Else
                outBox.Text = outBox.Text.Substring(0, outBox.Text.Length - 1)
            End If
        Else
            outBox.Text = "0"
        End If
    End Sub


End Class
