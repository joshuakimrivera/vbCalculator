Public Class Form1
    Dim op1 As Double = 0
    Dim overrideInput As Boolean = False
    Dim equation As String = " "
    Dim operationSign As String = " "
    Dim superFlag As String = " "
    Dim operationFlag As Boolean = False


    Private Sub buttonEntry(sender As Object, e As EventArgs) Handles buttonZero.Click, buttonOne.Click, buttonTwo.Click, buttonThree.Click, buttonFour.Click, buttonFive.Click, buttonSix.Click, buttonSeven.Click, buttonEight.Click, buttonNine.Click, periodButton.Click
        If outBox.Text = "0" Or overrideInput Then
            If Not outBox.Text.Contains(".") And sender.Text = "." Then
                If outBox.Text = "0" Then
                    outBox.Text = outBox.Text + sender.Text
                    equation += sender.Text
                Else
                    outBox.Text = "0."
                    equation += "0."
                End If

            Else
                outBox.Text = sender.Text
                equation += sender.Text
            End If
            overrideInput = False
        ElseIf sender.Text = "." Then
            If Not outBox.Text.Contains(".") Then
                outBox.Text += sender.Text
                equation += sender.Text
            End If
        Else

            outBox.Text += sender.Text
            equation += sender.Text
            updateEquation()
        End If
    End Sub

    Private Sub performOperation()
        equation += operationSign
        updateEquation()
        If operationFlag Then
            If superFlag = "+" Then
                op1 += Convert.ToDouble(outBox.Text)
            End If

            If superFlag = "−" Then
                op1 -= Convert.ToDouble(outBox.Text)
            End If

            If superFlag = "✕" Then
                op1 *= Convert.ToDouble(outBox.Text)
            End If

            If superFlag = "÷" Then
                op1 /= Convert.ToDouble(outBox.Text)
            End If

        Else
            op1 = Convert.ToDouble(outBox.Text)
            operationFlag = True
        End If
        superFlag = operationSign
        outBox.Text = op1
        overrideInput = True
    End Sub

    Private Sub updateEquation()
        equationBox.Text = equation
    End Sub


    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click, subButton.Click, mulButton.Click, divButton.Click
        If outBox.Text.Length > 0 Then
            If outBox.Text = "0" Then
                equation += "0"
            End If
            operationSign = sender.Text
            If Strings.Right(equation, 1) = "+" Or Strings.Right(equation, 1) = "−" Or Strings.Right(equation, 1) = "✕" Or Strings.Right(equation, 1) = "÷" Then
                equation = equation.Substring(0, equation.Length - 1) + operationSign
                superFlag = operationSign
                updateEquation()
            Else
                performOperation()
            End If
        End If
    End Sub


    Private Sub performOperation(sender As Object, e As EventArgs) Handles equalButton.Click
        If Strings.Right(equation, 1) = "+" Or Strings.Right(equation, 1) = "−" Or Strings.Right(equation, 1) = "✕" Or Strings.Right(equation, 1) = "÷" Then
            clear()
        Else
            performOperation()
            equation = " "
            operationFlag = False
            superFlag = " "
            overrideInput = True
            equationBox.Text = " "
        End If

    End Sub

    Private Sub clearEntry() Handles ceButton.Click
        If Not superFlag = " " Then
            outBox.Text = 0
            equation = equation.Substring(0, InStrRev(equation, superFlag))
        Else
            clear()
        End If
    End Sub

    Private Sub clear() Handles cButton.Click
        op1 = 0
        operationSign = " "
        overrideInput = False
        operationFlag = False
        superFlag = " "
        equation = " "
        equationBox.Text = equation
        outBox.Text = "0"
        updateEquation()
    End Sub

    Private Sub delBackspace() Handles delButton.Click
        If outBox.Text.Length > 0 Then
            If outBox.Text.Length = 1 Then
                outBox.Text = "0"
                equation = equation.Substring(0, equation.Length - 1)
            Else
                outBox.Text = outBox.Text.Substring(0, outBox.Text.Length - 1)
                equation = equation.Substring(0, equation.Length - 1)
            End If
        Else
            outBox.Text = "0"
            equation = equation.Substring(0, equation.Length - 1)
        End If
    End Sub

    Private Sub negateSign() Handles signButton.Click
        If outBox.Text.Length > 0 Then
            If Not outBox.Text.Substring(0, 1) = "0" Or outBox.Text.Contains(".") Then
                If Not outBox.Text.Substring(0, 1) = "-" Then
                    outBox.Text = "-" & outBox.Text
                    equation = equation.Substring(0, InStrRev(equation, superFlag))
                    equation += outBox.Text
                Else
                    outBox.Text = outBox.Text.Substring(1, outBox.Text.Length - 1)
                    equation = equation.Substring(0, InStrRev(equation, superFlag))
                    equation += outBox.Text
                End If
            End If

        End If


    End Sub
End Class
