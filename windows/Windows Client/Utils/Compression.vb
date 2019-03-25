Imports System.IO

Namespace Utils
    Public Class Compression

        Public Shared Function Zip(ByVal [String] As String) As Byte()
            Dim R As Byte() = Nothing

            Try
                Dim Buffer As Byte() = System.Text.Encoding.Unicode.GetBytes([String])
                Dim Compressed As Byte() = New Byte(1) {}
                Using MS As New MemoryStream()
                    Using ZipStream As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Compress, True)
                        ZipStream.Write(Buffer, 0, Buffer.Length)
                    End Using
                    MS.Position = 0
                    Compressed = New Byte(MS.Length - 1) {}
                    MS.Read(Compressed, 0, Compressed.Length)
                End Using

                Dim gzBuffer As Byte() = New Byte(Compressed.Length + 3) {}
                System.Buffer.BlockCopy(Compressed, 0, gzBuffer, 4, Compressed.Length)
                System.Buffer.BlockCopy(BitConverter.GetBytes(Buffer.Length), 0, gzBuffer, 0, 4)
                R = gzBuffer
            Catch ex As Exception

            End Try

            Return R
        End Function

        Public Shared Function UnZip(ByVal StringData As Byte()) As String
            Dim R As String = ""

            Try
                Dim gzBuffer As Byte() = StringData
                Using MS As New MemoryStream()
                    Dim Length As Integer = BitConverter.ToInt32(gzBuffer, 0)
                    MS.Write(gzBuffer, 4, gzBuffer.Length - 4)

                    Dim buffer As Byte() = New Byte(Length - 1) {}

                    MS.Position = 0
                    Using zipStream As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Decompress)
                        zipStream.Read(buffer, 0, buffer.Length)
                    End Using
                    R = Text.Encoding.Unicode.GetString(buffer, 0, buffer.Length)
                End Using
            Catch ex As Exception

            End Try

            Return R

        End Function

    End Class
End Namespace