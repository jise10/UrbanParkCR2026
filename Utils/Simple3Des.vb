Imports System.Security.Cryptography
Imports System.Text

Namespace Utils
    Public Class Simple3Des

        ' "EncryptData" ahora genera HASH (NO reversible)
        Public Function EncryptData(ByVal plaintext As String) As String
            ' Generar salt
            Dim salt(15) As Byte
            Using rng As New RNGCryptoServiceProvider()
                rng.GetBytes(salt)
            End Using

            ' Combinar password + salt
            Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(plaintext)
            Dim passwordWithSalt(passwordBytes.Length + salt.Length - 1) As Byte

            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length)
            Buffer.BlockCopy(salt, 0, passwordWithSalt, passwordBytes.Length, salt.Length)

            ' Crear hash
            Dim hash As Byte()
            Using sha256 As SHA256 = SHA256.Create()
                hash = sha256.ComputeHash(passwordWithSalt)
            End Using

            ' Combinar hash + salt
            Dim hashBytes(hash.Length + salt.Length - 1) As Byte
            Buffer.BlockCopy(hash, 0, hashBytes, 0, hash.Length)
            Buffer.BlockCopy(salt, 0, hashBytes, hash.Length, salt.Length)

            Return Convert.ToBase64String(hashBytes)
        End Function

        '  "DecryptData" ahora verifica (NO desencripta)
        Public Function DecryptData(ByVal plaintext As String, ByVal storedHash As String) As Boolean
            Dim hashBytes As Byte() = Convert.FromBase64String(storedHash)

            ' Extraer salt
            Dim salt(15) As Byte
            Buffer.BlockCopy(hashBytes, hashBytes.Length - salt.Length, salt, 0, salt.Length)

            ' Recalcular hash con el mismo salt
            Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(plaintext)
            Dim passwordWithSalt(passwordBytes.Length + salt.Length - 1) As Byte

            Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, 0, passwordBytes.Length)
            Buffer.BlockCopy(salt, 0, passwordWithSalt, passwordBytes.Length, salt.Length)

            Dim hashToCompare As Byte()
            Using sha256 As SHA256 = SHA256.Create()
                hashToCompare = sha256.ComputeHash(passwordWithSalt)
            End Using

            ' Comparar
            For i As Integer = 0 To hashToCompare.Length - 1
                If hashBytes(i) <> hashToCompare(i) Then
                    Return False
                End If
            Next

            Return True
        End Function

    End Class
End Namespace