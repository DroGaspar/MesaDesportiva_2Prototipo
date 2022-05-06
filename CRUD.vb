Imports System.Data.SqlClient
Module CRUD
    Public caminho As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pedro\source\repos\Prototipo_2\mesadesportiva.mdf;Integrated Security=True;Connect Timeout=30"
    Public strconexao As SqlConnection = Strligacao()
    Public resultado As String
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public dt As New DataTable



    Public Function Strligacao() As SqlConnection
        Return New SqlConnection(caminho)
    End Function

    Public Sub Create(ByVal comando As String)
        Try
            strconexao.Open()
            With cmd
                .Connection = strconexao
                .CommandText = comando
                resultado = cmd.ExecuteNonQuery
            End With
            If resultado = 0 Then
                MessageBox.Show("A operação não foi concluida!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("A operação foi concluida com sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro!" & vbNewLine & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strconexao.Close()
    End Sub

    Public Sub Update(ByVal comando As String)
        Try
            strconexao.Open()
            With cmd
                .Connection = strconexao
                .CommandText = comando
                resultado = cmd.ExecuteNonQuery
                If resultado = 0 Then
                    MessageBox.Show("A operação falhou", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Os registos foram atualizados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Erro!" & vbNewLine & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strconexao.Close()
    End Sub

    Public Sub Delete(ByVal comando As String)
        Try
            strconexao.Open()
            With cmd
                .Connection = strconexao
                .CommandText = comando
                resultado = cmd.ExecuteNonQuery
                If resultado = 0 Then
                    MessageBox.Show("A operação falhou!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Os registos foram eliminados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Erro!" & vbNewLine & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strconexao.Close()
    End Sub

    Public Sub Ler(ByVal comando As String, grelha As Object)
        Try
            dt = New DataTable
            strconexao.Open()
            With cmd
                .Connection = strconexao
                .CommandText = comando
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            grelha.datasource = dt

        Catch ex As Exception
            MessageBox.Show("Erro!" & vbNewLine & ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strconexao.Close()
        da.Dispose()
    End Sub
End Module
