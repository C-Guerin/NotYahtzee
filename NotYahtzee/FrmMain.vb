Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text

Public Class FrmMain
    Dim DiceArray(4) 'Holds the result of 5 random numbers between 1 and 6, parsed from the random number generator via RandomsList.
    Dim RandomsList As ArrayList = New ArrayList() 'Rands get loaded into RandomList then parsed to DiceArray
    Dim PbxArray() = {pbxResult1, pbxResult2, pbxResult3, pbxResult4, pbxResult5} 'Holds the PictureBoxs for the rolls from DiceArray
    Dim DicePic() = {My.Resources.Dice_1, My.Resources.Dice_2, My.Resources.Dice_3, My.Resources.Dice_4, My.Resources.Dice_5, My.Resources.Dice_6} 'Holds the corresponding picture for the rolls from DiceArray to be shown in the Pictureboxes
    Dim DiceLock() = {DiceOneLocked, DiceTwoLocked, DiceThreeLocked, DiceFourLocked, DiceFiveLocked}

    Dim ScoreAces As Integer = 0    'Declares and Initilises the scores of the Upper Categories to 0. For use in UpperScores Array
    Dim ScoreTwos As Integer = 0    'Declares and Initilises the scores of the Upper Categories to 0. For use in UpperScores Array
    Dim ScoreThrees As Integer = 0  'Declares and Initilises the scores of the Upper Categories to 0. For use in UpperScores Array
    Dim ScoreFours As Integer = 0   'Declares and Initilises the scores of the Upper Categories to 0. For use in UpperScores Array
    Dim ScoreFives As Integer = 0   'Declares and Initilises the scores of the Upper Categories to 0. For use in UpperScores Array
    Dim ScoreSixes As Integer = 0   'Declares and Initilises the scores of the Upper Categories to 0. For use in UpperScores Array

    Dim Score3OAK As Integer = 0        'Declares and Initilises the scores of the Lower Categories to 0. For use in LowerScores Array
    Dim Score4OAK As Integer = 0        'Declares and Initilises the scores of the Lower Categories to 0. For use in LowerScores Array
    Dim ScoreFullhouse As Integer = 0   'Declares and Initilises the scores of the Lower Categories to 0. For use in LowerScores Array
    Dim ScoreYahtzee As Integer = 0     'Declares and Initilises the scores of the Lower Categories to 0. For use in LowerScores Array

    Dim UpperScores() = {ScoreAces, ScoreTwos, ScoreThrees, ScoreFours, ScoreFives, ScoreSixes} 'Holds the scores for the Upper Category, ones to sixes.
    Dim LowerScores() = {Score3OAK, Score4OAK, ScoreFullhouse, ScoreYahtzee} 'Holds the scores for the Lower Category, 3-of-a-kind to Yahtzee.
    Dim TotalScore As Integer = 0   'Declares and Initilises the TotalScore as 0. The UpperScores and LowerScores arrays are parsed to this.

    Dim intRoundCount As Integer = 1 'Declares and Initilises the Round Count as 1
    Dim RerollCount As Integer = 0 'Declares and Initialises the Reroll count as 0

    Dim DiceOneLocked As Boolean = False 'Boolean value that corresponds to the 'Locked' status of dice in dice rolls.
    Dim DiceTwoLocked As Boolean = False 'Boolean value that corresponds to the 'Locked' status of dice in dice rolls.
    Dim DiceThreeLocked As Boolean = False 'Boolean value that corresponds to the 'Locked' status of dice in dice rolls.
    Dim DiceFourLocked As Boolean = False 'Boolean value that corresponds to the 'Locked' status of dice in dice rolls.
    Dim DiceFiveLocked As Boolean = False 'Boolean value that corresponds to the 'Locked' status of dice in dice rolls.

    Sub OnStart() Handles MyClass.Load
        btnRoll.Select() 'Sets the focus to the Roll button when the program loads.
    End Sub

    Public Function GetRandom() As Integer
        'Random Number Generator. Generates psuedo-random integers from 1-6.
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(1, 7)
    End Function

    Sub DiceRoller()
        'This subroutine simulates the rolling of a six sided dice.
        'Generally this is used to roll for 5 integers and display them.
        'If the user 'locks-in' any dice, then this subroutine will roll only the dice that are not 'locked-in'
        RandomsList.Clear() 'Clears the RandomsList, so that each time this sub is called, the rolls are fresh.

        For i As Integer = 0 To DiceArray.Length - 1 'Runs the following code 5 times.
            If i = 0 And DiceOneLocked = False Then
                DiceArray(0) = GetRandom()
            ElseIf i = 1 And DiceTwoLocked = False Then
                DiceArray(1) = GetRandom()
            ElseIf i = 2 And DiceThreeLocked = False Then
                DiceArray(2) = GetRandom()
            ElseIf i = 3 And DiceFourLocked = False Then
                DiceArray(3) = GetRandom()
            ElseIf i = 4 And DiceFiveLocked = False Then
                DiceArray(4) = GetRandom()
            End If
            Dim e = DiceArray.ElementAt(i)
            ShowDice(i, e) 'Calls the ShowDice Sub Routine, parsing each position of the DiceArray with the Element at said position.
        Next
    End Sub

    Sub ShowDice(ByVal i As Integer, ByVal e As Integer)
        'This sub routine matches the position and value of each element in the DiceArray with the corresponding visual representation.
        'i = DiceArray Position, e = Element At said position
        'Example: DiceArray = [2, 4, 6, 3, 5]
        'For the first number: i = 0, e = 2 
        'The first number will appear in the first (far left) picture box, with the value of 2
        'For the last number: i = 4, e = 5
        'The last number will appear in the last (far right) picture box, with the value of 5
        Select Case i
            Case 0
                pbxResult1.Image = DicePic(e - 1)
            Case 1
                pbxResult2.Image = DicePic(e - 1)
            Case 2
                pbxResult3.Image = DicePic(e - 1)
            Case 3
                pbxResult4.Image = DicePic(e - 1)
            Case 4
                pbxResult5.Image = DicePic(e - 1)
        End Select
    End Sub

    Sub DiceCombo()
        'Sub routine for determining which categories are valid for scoring based on the current dice roll
        'grp = die face [1-6] | grp.count = number of repitions
        'Example [4, 3, 4, 4, 3]
        '4 appears 3 times | 3 appears 2 times
        'grp(4) with grp.count of 3
        'grp(3) with grp.count of 2
        Dim RepeatingNumbers = DiceArray.GroupBy(Function(intValue) intValue).Where(Function(grp) grp.Count > 1)
        'Groups elements of DiceArray by their intValue (or 'die face') for each time a intValue appears more than once.
        'Example: [1, 2, 3, 4, 5] Has no repeating intValue, and thus cannot be scored in any category
        'Example: [5, 5, 1 ,2 ,3] Has a repeating intValue for '5', and thus can only be scored in the 'Fives' category.
        'Example: [2, 2, 3, 3, 4] Has two repeating IntValues, '2' and '3'.
        '^ Both of these appear twice and give the user the choice of scoring under the 'twos' or 'threes' category.
        'Example: [2, 2, 2, 5, 4] Has a repeating intValue for '2' which repeats three times. This can be scored under either the 'Twos' or 'Three-of-A-Kind' categories.

        For Each grp In RepeatingNumbers
            If grp.Count > 1 Then 'Intended for Upper Categories 'Ace' through 'Sixes'.
                DiceComboMatcher(grp(0), grp.Count)
            End If

            If grp.Count > 2 Then 'Intended for 'Three-of-a-kind'.
                If txtScore3OAK.Text = "" Then
                    btn3OAK.Visible = True
                    LowerScores(0) = 3 * grp(0)
                End If
            End If

            If grp.Count > 3 Then 'Intended for 'Four-of-a-kind'.
                If txtScore4OAK.Text = "" Then
                    btn4OAK.Visible = True
                    LowerScores(1) = 4 * grp(0)
                End If
            End If

            If grp.Count > 4 Then 'Intended for 'Yahtzee'.
                If txtScoreYahtzee.Text = "" Then
                    btnYahtzee.Visible = True
                    LowerScores(3) = 50
                End If
            End If
        Next

        If txtScoreFullHouse.Text = "" Then
            'The following code is a Linq query.
            'This works by reading the elements of DiceArray from (0) through (4). Effectivly reading the 5 dice of any given dice roll.
            'This works by defining the current dice roll of DiceArray as 'n', grouping them into 'Count' and then outputting as an Array.
            'Should there be two elements of the array, 
            Dim CountsByNumber = (From n In New Integer() {DiceArray(0), DiceArray(1), DiceArray(2), DiceArray(3), DiceArray(4)}
                                  Group By n Into Count
                                  Order By Count 'Orders by acending order. Once in an array, (0) will equal 2, and (1) will equal 3.
                                  Select New With {.Number = n, Count}).ToArray()

            If CountsByNumber.Length = 2 AndAlso CountsByNumber(0).Count = 2 Then
                'Checks if the number of elements in CountsByNumber is 2, and if (0) (the smallest) is equal to 2. 
                'Loads '25' into the 3rd position in the LowerScores Array in preperation for scoring.
                btnFullHouse.Visible = True
                LowerScores(2) = 25
            End If
        End If
    End Sub

    Sub DiceComboMatcher(ByVal i As Integer, ByVal b As Integer)
        'parsed intergers are as follows:
        'Subroutine checks if the textbox under the upper categories is empty
        'if empty, it shows the button to score the roll and loads the [die face * no. of repititions]
        'into the corresponding position of the UpperScores array.
        'Example: [2, 2, 2, 5, 4]
        'i = dice face | b = number of repititions
        'i = 2 | b = 3
        'The die face is 2, the no. of repitions is 3
        '
        'If 2 has not yet been scored, the button to score under the Threes category will be visible
        'If the user scores the current dice roll under 3, the score of [2 * 3 = 6] will be loaded into the UpperScores array under [i - 1] or UpperScores(1) in this case.
        'This subroutine does not modify the total score, and even though it is called for each and every repitition of the dice faces.
        'The only way you can score is by clicking the 'Set' button below the category.
        'Clicking this button will load the appropriate element of the UpperScores (or LowerScores) array into the final score.
        Select Case i
            Case 1 'Aces
                If txtScoreAces.Text Is "" Then
                    btnAces.Visible = True
                    UpperScores(0) = 1 * b
                End If
            Case 2 'Twos
                If txtScoreTwos.Text Is "" Then
                    btnTwos.Visible = True
                    UpperScores(1) = 2 * b
                End If
            Case 3 'Threes
                If txtScoreThrees.Text Is "" Then
                    btnThrees.Visible = True
                    UpperScores(2) = 3 * b
                End If
            Case 4 'Fours
                If txtScoreFours.Text Is "" Then
                    btnFours.Visible = True
                    UpperScores(3) = 4 * b
                End If
            Case 5 'Fives
                If txtScoreFives.Text Is "" Then
                    btnFives.Visible = True
                    UpperScores(4) = 5 * b
                End If
            Case 6 'Sixes
                If txtScoreSixes.Text Is "" Then
                    btnSixes.Visible = True
                    UpperScores(5) = 6 * b
                End If
        End Select
    End Sub


    Private Sub BtnRoll_Click(sender As Object, e As EventArgs) Handles btnRoll.Click
        'Generates five pseudo-random numbers and loads them into the DiceArray array via the RandomsList ArrayList.
        'Presents the dice roll in 5 picture boxes above the 'Roll' button.
        'Finds patterns of repeating intergers and allows the user to score the current dice roll under any not yet scored category.
        'Hides the 'Roll' button upon clicking, shows the 'Re-Roll' button to the right, and shows the 'End Turn' button where the 'Roll' button was.
        DiceRoller()
        DiceCombo()

        pbxResult1.Visible = True
        pbxResult2.Visible = True
        pbxResult3.Visible = True
        pbxResult4.Visible = True
        pbxResult5.Visible = True

        btnRoll.Visible = False
        btnEndTurn.Visible = True
        btnReroll.Visible = True
        btnReroll.Select()
    End Sub

    Sub EndTurn()
        'Iterates the Round Count by 1
        'After 10 turns, ends the game, asking the player whether he wants to play again.
        'Resets button, picturebox, and category 'Set' button visibility.
        intRoundCount += 1

        If intRoundCount < 11 Then
            lblRoundCounter.Text = ("Round: " & intRoundCount)
            btnEndTurn.Text = ("End Turn")
        ElseIf intRoundCount >= 10 Then
            btnEndTurn.Text = ("End Game")
            MsgBox("Game Over" & vbCrLf & "Total Score: " & TotalScore)

            Dim ask As MsgBoxResult
            ask = MsgBox("Do you wish to play again?", MsgBoxStyle.YesNo)

            If ask = MsgBoxResult.Yes Then
                Application.Restart()
            ElseIf ask = MsgBoxResult.No Then
                End
            End If
        End If

        RerollCount = 0
        btnRoll.Visible = True
        btnRoll.Select()
        btnReroll.Visible = False
        btnEndTurn.Visible = False

        pbxResult1.Visible = False
        pbxResult2.Visible = False
        pbxResult3.Visible = False
        pbxResult4.Visible = False
        pbxResult5.Visible = False

        HideScoreBoxes()
        HideDiceLock()
    End Sub

    Sub HideScoreBoxes()
        'Sets the visiblity of the 'Set' buttons of each category to hidden.
        btnAces.Visible = False
        btnTwos.Visible = False
        btnThrees.Visible = False
        btnFours.Visible = False
        btnFives.Visible = False
        btnSixes.Visible = False
        btn3OAK.Visible = False
        btn4OAK.Visible = False
        btnFullHouse.Visible = False
        btnYahtzee.Visible = False
    End Sub

    Sub HideDiceLock()
        'Sets the visibility of the 'Dice Locks' and their corresponding booleans to False.
        PbxDiceLock1.Visible = False
        PbxDiceLock2.Visible = False
        PbxDiceLock3.Visible = False
        PbxDiceLock4.Visible = False
        PbxDiceLock5.Visible = False
        DiceOneLocked = False
        DiceTwoLocked = False
        DiceThreeLocked = False
        DiceFourLocked = False
        DiceFiveLocked = False
    End Sub

    Sub AddToTotal(ByVal i As Integer)
        'Parses the score in the textbox of the Upper and Lower categories to the Total Score.
        'Updates the TotalScore textbox and shows the 'End Turn' button
        TotalScore += i
        txtTotalScore.Text = TotalScore
        btnEndTurn.Visible = True
    End Sub

    Private Sub BtnAces_Click(sender As Object, e As EventArgs) Handles btnAces.Click
        txtScoreAces.Text = UpperScores(0) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(UpperScores(0)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnAces.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnTwos_Click(sender As Object, e As EventArgs) Handles btnTwos.Click
        txtScoreTwos.Text = UpperScores(1) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(UpperScores(1)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnTwos.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnThrees_Click(sender As Object, e As EventArgs) Handles btnThrees.Click
        txtScoreThrees.Text = UpperScores(2) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(UpperScores(2)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnThrees.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnFours_Click(sender As Object, e As EventArgs) Handles btnFours.Click
        txtScoreFours.Text = UpperScores(3) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(UpperScores(3)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnFours.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnFives_Click(sender As Object, e As EventArgs) Handles btnFives.Click
        txtScoreFives.Text = UpperScores(4) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(UpperScores(4)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnFives.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnSixes_Click(sender As Object, e As EventArgs) Handles btnSixes.Click
        txtScoreSixes.Text = UpperScores(5) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(UpperScores(5)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnFives.Visible = False
        EndTurn()
    End Sub

    Private Sub Btn3OAK_Click(sender As Object, e As EventArgs) Handles btn3OAK.Click
        txtScore3OAK.Text = LowerScores(0) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(LowerScores(0)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btn3OAK.Visible = False
        EndTurn()
    End Sub

    Private Sub Btn4OAK_Click(sender As Object, e As EventArgs) Handles btn4OAK.Click
        txtScore4OAK.Text = LowerScores(1) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(LowerScores(1)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btn4OAK.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnFullHouse_Click(sender As Object, e As EventArgs) Handles btnFullHouse.Click
        txtScoreFullHouse.Text = LowerScores(2) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(LowerScores(2)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnFullHouse.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnYahtzee_Click(sender As Object, e As EventArgs) Handles btnYahtzee.Click
        txtScoreYahtzee.Text = LowerScores(3) 'Parses the score from the corresponding element of the UpperScores array to the textbox of this category.
        AddToTotal(LowerScores(3)) 'Adds the corresponding element of the UpperScores array to TotalScore via the AddToTotal subroutine.
        btnYahtzee.Visible = False
        EndTurn()
    End Sub

    Private Sub BtnEndTurn_Click(sender As Object, e As EventArgs) Handles btnEndTurn.Click
        'Iterates the Round Count by 1
        'After 10 turns, ends the game, asking the player whether he wants to play again.
        'Resets the Reroll count
        'Resets button, picturebox, and category 'Set' button visibility
        EndTurn()
    End Sub

    Private Sub BtnReroll_Click(sender As Object, e As EventArgs) Handles btnReroll.Click
        'Iterates reroll count when clicked.
        'When reroll count is less than 4: Roll a new set of dice, Refresh the 'set' button visibility to the valid categories in the new dice roll.
        'When reroll count is above 2: Hide the reroll button, Set focus on the End Turn button.
        RerollCount += 1
        Select Case RerollCount
            Case Is < 3
                DiceRoller()
                HideScoreBoxes()
                DiceCombo()

        End Select
        If RerollCount > 1 Then
            btnReroll.Visible = False
            btnEndTurn.Select()
        End If

    End Sub


    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        'Prompts the user to start a new game or not.
        'Restarts the application if the user selects 'Yes'.
        'Does nothing and exits dialog if the user selects 'No'.
        Dim ask As MsgBoxResult
        ask = MsgBox("Do you want to start a new game?", MsgBoxStyle.YesNo)

        Select Case ask
            Case MsgBoxResult.Yes
                Application.Restart()

                If TotalScore > 0 Then
                    MsgBox("Game Over" & vbCrLf & "Total Score: " & TotalScore)
                End If

            Case MsgBoxResult.No
                'do nothing
        End Select
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Using Help
            Help.ShowDialog() 'Opens the Help form.
        End Using
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Using FrmAbout
            FrmAbout.ShowDialog() 'Opens the About form.
        End Using
    End Sub

    Private Sub PbxResult1_Click(sender As Object, e As EventArgs) Handles pbxResult1.Click
        Select Case DiceOneLocked
            Case True
                'do nothing
            Case False
                PbxDiceLock1.Show()
                DiceOneLocked = True
        End Select
    End Sub

    Private Sub PbxResult2_Click(sender As Object, e As EventArgs) Handles pbxResult2.Click
        Select Case DiceTwoLocked
            Case True
                'do nothing
            Case False
                PbxDiceLock2.Show()
                DiceTwoLocked = True
        End Select
    End Sub

    Private Sub PbxResult3_Click(sender As Object, e As EventArgs) Handles pbxResult3.Click
        Select Case PbxDiceLock3.Visible
            Case True
                'do nothing
            Case False
                PbxDiceLock3.Show()
                DiceThreeLocked = True
        End Select
    End Sub

    Private Sub PbxResult4_Click(sender As Object, e As EventArgs) Handles pbxResult4.Click
        Select Case PbxDiceLock4.Visible
            Case True
                'do nothing
            Case False
                PbxDiceLock4.Show()
                DiceFourLocked = True
        End Select
    End Sub

    Private Sub PbxResult5_Click(sender As Object, e As EventArgs) Handles pbxResult5.Click
        Select Case PbxDiceLock5.Visible
            Case True
                'do nothing
            Case False
                PbxDiceLock5.Show()
                DiceFiveLocked = True
        End Select
    End Sub
End Class




