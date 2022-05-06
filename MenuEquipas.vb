Imports System.Data.SqlClient
Public Class MenuEquipas
    Public pkEquipa As Integer
    Public teamName As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtEquipa.TextLength > 1 And txtLocal.TextLength > 1 Then
            Try
                Create("INSERT INTO Equipa (nome, local) VALUES ('" & txtEquipa.Text & "', '" & txtLocal.Text & "') ")
            Catch ex As Exception

            End Try
        Else
            MessageBox.Show("Preencha os campos todos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        txtEquipa.Clear()
        txtLocal.Clear()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection(caminho)

        con.Open()

        Dim nome As String = ""
        Dim sql As String = "select* from equipa " & "where nome LIKE '%" & nome & "%'"
        Dim sqlcom As New SqlCommand(sql, con)
        Dim dr As SqlDataReader = sqlcom.ExecuteReader()
        DataGridView2.Columns.Clear()
        Dim n As Integer = dr.FieldCount
        Dim campo As String
        Dim k As Integer


        For k = 0 To n - 1

            campo = dr.GetName(k)
            DataGridView2.Columns.Add(campo, campo)

        Next

        Dim i As Integer = 0

        While dr.Read()
            Dim linha As New DataGridViewRow
            DataGridView2.Rows.Add(linha)
            DataGridView2.Rows(i).Cells(0).Value = dr.Item(0)
            DataGridView2.Rows(i).Cells(1).Value = dr.Item(1)
            DataGridView2.Rows(i).Cells(2).Value = dr.Item(2)

            i = i + 1

        End While
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Rows(1).Cells(1).Selected = True


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim erro As Boolean = False

        Try
            pkEquipa = DataGridView2.CurrentRow.Cells(0).Value
            teamName = DataGridView2.CurrentRow.Cells(1).Value
        Catch ex As Exception
            erro = True

        End Try

        If erro = False Then
            Me.Hide()
            AdicionarJogadores.Show()
        Else
            MessageBox.Show("Para utilizar o visualizar tem de selecionar o nome de uma equipa na tabela.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If


    End Sub

    Private Sub btVoltar_Click(sender As Object, e As EventArgs) Handles btVoltar.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class