Imports System.Data.SqlClient
Public Class MenuCampeonatos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtCampeonato.TextLength > 1 And txtInicio.TextLength > 1 And txtFim.TextLength > 1 Then

            Try
                Create("INSERT INTO Campeonato (nome, datainicio, datafim) VALUES ('" & txtCampeonato.Text & "', '" & txtInicio.Text & "', '" & txtFim.Text & "') ")
            Catch ex As Exception

            End Try
        Else
            MessageBox.Show("Preencha os campos todos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        txtCampeonato.ResetText()
        txtInicio.ResetText()
        txtFim.ResetText()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection(caminho)

        con.Open()

        Dim nome As String = ""
        Dim sql As String = "select* from campeonato " & "where nome LIKE '%" & nome & "%'"
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

    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Me.Hide()
        Form1.Show()

    End Sub
End Class