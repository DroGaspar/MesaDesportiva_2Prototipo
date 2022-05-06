Imports System.Data.SqlClient
Public Class AdicionarJogadores
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtNome.TextLength > 1 And txtNacionalidade.TextLength > 1 And txtNascimento.TextLength > 1 Then
            Try
                Create("INSERT INTO Jogador (idequipa, nome, nacionalidade, data_nascimento) VALUES ('" & MenuEquipas.pkEquipa & "', '" & txtNome.Text & "', '" & txtNacionalidade.Text & "', '" & txtNascimento.Text & "') ")
            Catch ex As Exception

            End Try
        Else
            MessageBox.Show("Preencha os campos todos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim con As New SqlConnection(caminho)

        con.Open()


        Dim sql As String = "select* from Jogador where idequipa = " & MenuEquipas.pkEquipa
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
            DataGridView2.Rows(i).Cells(3).Value = dr.Item(3)
            DataGridView2.Rows(i).Cells(4).Value = dr.Item(4)
            i = i + 1

        End While
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).Visible = False
        con.Close()




    End Sub

    Private Sub AdicionarJogadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbEquipa.Text = MenuEquipas.teamName
        Dim con As New SqlConnection(caminho)

        con.Open()


        Dim sql As String = "select* from Jogador where idequipa = " & MenuEquipas.pkEquipa
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
            DataGridView2.Rows(i).Cells(3).Value = dr.Item(3)
            DataGridView2.Rows(i).Cells(4).Value = dr.Item(4)
            i = i + 1

        End While
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).Visible = False
        con.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MenuEquipas.Show()
        Me.Close()


    End Sub
End Class