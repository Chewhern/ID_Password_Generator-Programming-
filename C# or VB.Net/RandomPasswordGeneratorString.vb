Imports System.Security.Cryptography
Imports System.Text

Public Class RandomPasswordGeneratorString
    Public Function GenerateUniqueString() As String
        Dim CryptographicSecureData As Byte() = New Byte() {}
        ReDim CryptographicSecureData(240)
        Dim MyRNGCryptoServiceProvider As RNGCryptoServiceProvider = New RNGCryptoServiceProvider
        MyRNGCryptoServiceProvider.GetBytes(CryptographicSecureData)
        Dim LoopCount As Integer = 0
        Dim MyStringBuilder As StringBuilder = New StringBuilder()
        While LoopCount < CryptographicSecureData.Length
            If CryptographicSecureData(LoopCount) >= 33 And CryptographicSecureData(LoopCount) <= 47 And CryptographicSecureData(LoopCount) <> 34 And CryptographicSecureData(LoopCount) <> 39 And CryptographicSecureData(LoopCount) <> 45 Then
                MyStringBuilder.Append(Chr(CryptographicSecureData(LoopCount)))
            ElseIf CryptographicSecureData(LoopCount) >= 48 And CryptographicSecureData(LoopCount) <= 57 Then
                MyStringBuilder.Append(Chr(CryptographicSecureData(LoopCount)))
            ElseIf (CryptographicSecureData(LoopCount) >= 60 And CryptographicSecureData(LoopCount) <= 63 And CryptographicSecureData(LoopCount) <> 60 And CryptographicSecureData(LoopCount) <> 62) Then
                MyStringBuilder.Append(Chr(CryptographicSecureData(LoopCount)))
            ElseIf (CryptographicSecureData(LoopCount) >= 65 And CryptographicSecureData(LoopCount) <= 90) Then
                MyStringBuilder.Append(Chr(CryptographicSecureData(LoopCount)))
            ElseIf (CryptographicSecureData(LoopCount) >= 91 And CryptographicSecureData(LoopCount) <= 95) Then
                MyStringBuilder.Append(Chr(CryptographicSecureData(LoopCount)))
            ElseIf (CryptographicSecureData(LoopCount) >= 97 And CryptographicSecureData(LoopCount) <= 122) Then
                MyStringBuilder.Append(Chr(CryptographicSecureData(LoopCount)))
            ElseIf (CryptographicSecureData(LoopCount) >= 123 And CryptographicSecureData(LoopCount) <= 126) Then
                MyStringBuilder.Append(Chr(CryptographicSecureData(LoopCount)))
            End If
            LoopCount += 1
        End While
        If MyStringBuilder.ToString <> "" Then
            Return MyStringBuilder.ToString
        Else
            Return ""
        End If
    End Function

    Public Function GenerateMinimumAmountOfUniqueString(ByVal Amount As Integer) As String
        Dim TestString As String = GenerateUniqueString()
        While TestString.Length < Amount
            TestString += GenerateUniqueString()
        End While
        Return TestString
    End Function
End Class
