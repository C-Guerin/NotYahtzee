Imports System.Drawing.Size
Imports System.Windows.Forms

Public Class Help

    Sub Main() Handles MyClass.Load
        TreeView1.ExpandAll()
        Panel1.Visible = False
        Panel2.Visible = False
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim fntRegular As New Font(RichTextBox1.Font, FontStyle.Regular)
        Dim fntBold As New Font(RichTextBox1.Font, FontStyle.Bold)
        TreeView1.SelectedNode.Expand()

        Select Case e.Node.Name
            Case "Node0" 'How to play
                Panel1.Hide()
                Panel2.Hide()
                RichTextBox1.Clear()
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("'Not Yahtzee' is a dice based game that can be played solo or against friends.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("The player rolls 5 dice, and scores the outcome in the appropriate category, ")
                RichTextBox1.AppendText("such as scoring two 3s in the Threes category for 6 points")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("The game is over when 10 rounds have passed." & vbCrLf)
                RichTextBox1.AppendText("If you're playing against friends, the person with the highest score wins.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("The Categories are split into two sections: Upper and Lower.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("Categories and Scoring will be explain further under: ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Scoring")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText(" and ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Lower Categories.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)

            Case "Node1" 'Scoring
                Panel1.Show()
                Panel2.Show()
                RichTextBox1.Clear()
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("Scoring in 'Not Yahtzee' is broken up into categories.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Upper Categories ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("correspond to the faces of the dice, one through six:" & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Lower Categories ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("correspond to patterns in the dice roll, such as 3-of-a-Kind.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Total Score ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("is the sum of the ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Upper")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText(" and ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Lower ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("Scores")
                RichTextBox1.AppendText(vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf)
                RichTextBox1.AppendText("The above roll can be scored only in the Fives category." & vbCrLf)
                RichTextBox1.AppendText("The score of the Fives category will be 10. [2 x 5 = 10]")
                RichTextBox1.AppendText(vbCrLf & vbCrLf & vbCrLf & vbCrLf)
                RichTextBox1.AppendText("The above roll can be scored either in the Fives category," & vbCrLf)
                RichTextBox1.AppendText("3-of-a-Kind, or 4-of-a-Kind." & vbCrLf)
                RichTextBox1.AppendText("The score will be the same regardless for which category it is scored in.")

            Case "Node2" 'Lower Categories
                Panel1.Hide()
                Panel2.Hide()
                RichTextBox1.Clear()
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Lower Categories ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("are hard to achieve and rewarding categories.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("Lower Categories are as follows: ")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Three-of-a-Kind ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("A pattern of ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("three ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("of the same number.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Four-of-a-Kind ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("A pattern of ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("four ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("of the same number.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Full House ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("A pattern of ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("three ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("of a kind and ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("two ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("of another kind. Scoring a Full House always equals ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("25 points.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Yahtzee ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("is a pattern of ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("five ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("of a kind. Scoring a Yahtzee always equals ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("50 points.")

            Case "Node3" 'Changes From Yahtzee
                Panel1.Hide()
                Panel2.Hide()
                RichTextBox1.Clear()
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("You may roll once per turn, and re-roll two times.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("The player may select any of the dice by clicking on them to lock them in.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("Rerolling dice generates random dice rolls for all dice, bar those that have been locked.")

                RichTextBox1.AppendText("")
                RichTextBox1.AppendText("")

            Case "Node4" 'Changes From Yahtzee
                Panel1.Hide()
                Panel2.Hide()
                RichTextBox1.Clear()
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("This section highlights the differences made to the mechanics of Yahtzee in this adaptation.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("Not Yahtzee has 10 Categories and Rounds as opposed to the 13 Categories and Rounds of Yahtzee.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("Not Yahtzee does not include the following categories: ")
                RichTextBox1.AppendText(vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Small Straight, Large Straight ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("or ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Chance.")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("The category of ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Yahtzee ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("can only be scored in once, and is worth ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("50 points ")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Yahtzee ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("required the player to ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("score in a category each turn, ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("if the score would be ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("invalid ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("(such as scoring five 2's in the 'sixes' category) the ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("score equals 0." & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Not Yahtzee ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("however, allows the player to ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("skip his turn ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("if he so chooses.")
                RichTextBox1.AppendText("This is comparable to the original game, in that it reduces the score of that turn to 0, but it ")
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("does not lock out any category from scoring.")
            Case "Node5" 'Controls
                Panel1.Hide()
                Panel2.Hide()
                RichTextBox1.Clear()
                RichTextBox1.AppendText("The following shortcuts exist in Not Yahtzee." & vbCrLf & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("Ctrl + N ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("for New Game." & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("F1 ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("for Help." & vbCrLf)
                RichTextBox1.SelectionFont = fntBold
                RichTextBox1.AppendText("F2 ")
                RichTextBox1.SelectionFont = fntRegular
                RichTextBox1.AppendText("for About.")
                RichTextBox1.AppendText(vbCrLf & vbCrLf)
                RichTextBox1.AppendText("Clicking on one of the Five dice that you have rolled allows you to lock-in that die.")
                RichTextBox1.AppendText(vbCrLf)
                RichTextBox1.AppendText("For more information, please read the 'Rerolling' section.")
        End Select
    End Sub


End Class