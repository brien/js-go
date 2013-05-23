Imports System.Drawing.Drawing2D

''' <summary>
''' Adds an easy to use Gantt Chart to your application
''' 
''' Created by Adrian "Adagio" Grau
''' 
''' Version 0.55
''' </summary>
''' <remarks></remarks>

Public Class GanttChart
    Inherits Control


#Region "Private Variables"
    Private mouseHoverPart As MouseOverPart = MouseOverPart.Empty
    Private mouseHoverBarIndex As Integer = -1

    Private bars As New List(Of ChartBarDate)
    Private headerFromDate As Date = Nothing
    Private headerToDate As Date = Nothing

    Private barIsChanging As Integer = -1
    Private IsChanged As Boolean = False

    Private barStartRight As Integer = 20
    Private barStartLeft As Integer = 100
    Private headerTimeStartTop As Integer = 30
    Private shownHeaderList As List(Of Header)

    Private barStartTop As Integer = 50
    Private barHeight As Integer = 9
    Private barSpace As Integer = 5

    Private widthPerItem As Integer

    Private _mouseOverColumnValue As Date = Nothing
    Private _mouseOverRowText As String = ""
    Private _mouseOverRowValue As Object = Nothing
    Private _mouseOverRowIndex As Integer = -1
    Private _mouseOverDBIndex As Integer = -1

    'holds a list of bars that are selected using the shift or control keys
    Private SelectedBars As New List(Of Integer)

    Private mouseDownTime As Date = Nothing
    Private alreadyDrug As TimeSpan = Nothing

    Private lineColor As Pen = Pens.Bisque
    Private dateTextFont As Font = New Font("VERDANA", 8.0, FontStyle.Regular, GraphicsUnit.Point)
    Private timeTextFont As Font = New Font("VERDANA", 8.0, FontStyle.Regular, GraphicsUnit.Point)
    Private rowTextFont As Font = New Font("VERDANA", 8.0, FontStyle.Regular, GraphicsUnit.Point)

    Friend WithEvents ToolTip As New System.Windows.Forms.ToolTip()

    Private _allowEditBarWithMouse As Boolean = False
    Private objBmp As Bitmap
    Private objGraphics As Graphics

    Private _selectedColor As Color = Color.DodgerBlue
#End Region

#Region "Public Variables"

    Public Event MouseDragged(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'Public Event BarChanged(ByVal sender As Object, ByRef barValue As Object)
    Public Event BarChanged(ByVal sender As Object, ByRef ChangedBars As List(Of ChartBarDate))


#End Region

#Region "Public properties"

    Public ReadOnly Property MouseOverDBIndex() As Integer
        Get
            Return _mouseOverDBIndex
        End Get
    End Property

    ''' <summary>
    ''' Sets to true if the user should be able to manually edit bars
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property AllowManualEditBar() As Boolean
        Get
            Return _allowEditBarWithMouse
        End Get
        Set(ByVal value As Boolean)
            _allowEditBarWithMouse = value
        End Set
    End Property

    ''' <summary>
    ''' The start date/time of the chart
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property FromDate() As Date
        Get
            Return headerFromDate
        End Get
        Set(ByVal value As Date)
            headerFromDate = value
        End Set
    End Property

    ''' <summary>
    ''' The end date/time of the chart
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property ToDate() As Date
        Get
            Return headerToDate
        End Get
        Set(ByVal value As Date)
            headerToDate = value
        End Set
    End Property

    ''' <summary>
    ''' The text for the current row the mouse hovers above
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property MouseOverRowText() As String
        Get
            Return _mouseOverRowText
        End Get
    End Property
    ''' <summary>
    ''' Zero based integer index of the current row the mouse hovers above
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property MouseOverRowIndex() As Integer
        Get
            Return _mouseOverRowIndex
        End Get
    End Property

    ''' <summary>
    ''' The value for the current bar the mouse hovers above
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property MouseOverRowValue() As Object
        Get
            Return _mouseOverRowValue
        End Get
    End Property

    ''' <summary>
    ''' The date/time the mouse hovers above
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public ReadOnly Property MouseOverColumnDate() As Date
        Get
            Return _mouseOverColumnValue
        End Get
    End Property

    ''' <summary>
    ''' The color of the grid
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property GridColor() As System.Drawing.Pen
        Get
            Return lineColor
        End Get
        Set(ByVal value As System.Drawing.Pen)
            lineColor = value
        End Set
    End Property

    ''' <summary>
    ''' The font used for the row text
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property RowFont() As Font
        Get
            Return rowTextFont
        End Get
        Set(ByVal value As Font)
            rowTextFont = value
        End Set
    End Property

    ''' <summary>
    ''' The font used for the "date" text in the columns
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property DateFont() As Font
        Get
            Return dateTextFont
        End Get
        Set(ByVal value As Font)
            dateTextFont = value
        End Set
    End Property

    ''' <summary>
    ''' The font used for the "time" text in the colums)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property TimeFont() As Font
        Get
            Return timeTextFont
        End Get
        Set(ByVal value As Font)
            timeTextFont = value
        End Set
    End Property

#End Region

#Region "Constructor"

    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub New()
        ToolTip.AutoPopDelay = 15000
        ToolTip.InitialDelay = 250
        ToolTip.OwnerDraw = True

        objBmp = New Bitmap(1280, 1024, Imaging.PixelFormat.Format24bppRgb)
        objGraphics = Graphics.FromImage(objBmp)

        ' Flicker free drawing

        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

#End Region

#Region "Bars"

    Private Sub SetBarStartLeft(ByVal rowText As String)
        Dim gfx As Graphics = Me.CreateGraphics

        Dim length As Integer = gfx.MeasureString(rowText, rowTextFont, 500).Width

        If length > barStartLeft Then
            barStartLeft = length
        End If
    End Sub

    ''' <summary>
    ''' Adds a bar to the list
    ''' </summary>
    ''' <param name="rowText">Text for the row</param>
    ''' <param name="barValue">Value for the row</param>
    ''' <param name="fromTime">The date/time the bar starts</param>
    ''' <param name="toTime">The date/time the bar ends</param>
    ''' <param name="color">The color of the bar</param>
    ''' <param name="hoverColor">The hover color of the bar</param>
    ''' <param name="rowIndex">The rowindex of the bar (useful if you want several bars on the same row)</param>
    ''' <remarks></remarks>

    Public Sub AddChartBar(ByVal rowText As String, ByVal barValue As Object, ByVal fromTime As Date, ByVal toTime As Date, ByVal color As Color, ByVal hoverColor As Color, ByVal rowIndex As Integer, ByVal DatasetIndex As Integer, _
                           ByVal IsSetup As Boolean, ByVal IsConstraintViolation As Boolean)
        Dim bar As New ChartBarDate
        bar.Text = rowText
        bar.Value = barValue
        bar.StartValue = fromTime
        bar.EndValue = toTime
        bar.Color = color
        bar.HoverColor = hoverColor
        bar.RowIndex = rowIndex
        bar.DataSetIndex = DatasetIndex
        bar.IsSetup = IsSetup
        bar.IsConstraintViolation = IsConstraintViolation
        bars.Add(bar)
        SetBarStartLeft(rowText)
    End Sub

    ''' <summary>
    ''' Adds a bar to the list
    ''' </summary>
    ''' <param name="rowText">Text for the row</param>
    ''' <param name="barValue">Value for the row</param>
    ''' <param name="fromTime">The date/time the bar starts</param>
    ''' <param name="toTime">The date/time the bar ends</param>
    ''' <param name="color">The color of the bar</param>
    ''' <param name="hoverColor">The hover color of the bar</param>
    ''' <param name="rowIndex">The rowindex of the bar (useful if you want several bars on the same row)</param>
    ''' <param name="hideFromMouseMove">If you want to "hide" the bar from mousemove event</param>
    ''' <remarks></remarks>

    Public Sub AddChartBar(ByVal rowText As String, ByVal barValue As Object, ByVal fromTime As Date, ByVal toTime As Date, ByVal color As Color, ByVal hoverColor As Color, ByVal rowIndex As Integer, ByVal hideFromMouseMove As Boolean)
        Dim bar As New ChartBarDate
        bar.Text = rowText
        bar.Value = barValue
        bar.StartValue = fromTime
        bar.EndValue = toTime
        bar.Color = color
        bar.HoverColor = hoverColor
        bar.RowIndex = rowIndex
        bar.HideFromMouseMove = hideFromMouseMove
        bars.Add(bar)
        SetBarStartLeft(rowText)
    End Sub

    ''' <summary>
    ''' Removes all bars from the chart
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearChartBars()
        bars.Clear()
    End Sub

    ''' <summary>
    ''' Gets the next index
    ''' </summary>
    ''' <param name="rowText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function GetIndexChartBar(ByVal rowText As String) As Integer
        Dim index As Integer = -1

        For Each bar As ChartBarDate In bars
            If bar.Text.Equals(rowText) = True Then
                Return bar.RowIndex
            End If
            If bar.RowIndex > index Then
                index = bar.RowIndex
            End If
        Next

        Return index + 1
    End Function

    Public Sub NudgeSelectionEarlier()
        Dim bi As Integer
        Dim ts As TimeSpan = TimeSpan.FromMinutes(1.0)
        Dim ChangedBars As New List(Of ChartBarDate)
        For Each bi In SelectedBars
            bars(bi).StartValue -= ts
            bars(bi).EndValue -= ts
            'add the changed bars to the changed bars list
            ChangedBars.Add(bars(bi))
        Next
        'need to raise the bars changed event
        RaiseEvent BarChanged(Me, ChangedBars)
    End Sub

    Public Sub DeleteSelection()
        Dim bi As Integer
        Dim ChangedBars As New List(Of ChartBarDate)
        For Each bi In SelectedBars
            bars(bi).IsDeleted = True
            ChangedBars.Add(bars(bi))
        Next
        'SelectedBars.Sort()
        'SelectedBars.Reverse()
        'For Each bi In SelectedBars
        '    bars.RemoveAt(bi)
        'Next
        'SelectedBars.Clear()
        RaiseEvent BarChanged(Me, ChangedBars)
    End Sub

    Public Sub NudgeSelectionLater()
        Dim bi As Integer
        Dim ts As TimeSpan = TimeSpan.FromMinutes(1.0)
        Dim ChangedBars As New List(Of ChartBarDate)
        For Each bi In SelectedBars
            bars(bi).StartValue += ts
            bars(bi).EndValue += ts
            'add the changed bars to the changed bars list
            ChangedBars.Add(bars(bi))
        Next
        'need to raise the bars changed event
        RaiseEvent BarChanged(Me, ChangedBars)

    End Sub

    ''' <summary>
    ''' Removes all bars from list
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub RemoveBars()
        bars = New List(Of ChartBarDate)

        barStartLeft = 100
    End Sub

#End Region

#Region "Draw"

    ''' <summary>
    ''' Redraws the Gantt chart
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub PaintChart()
        Me.Invalidate()
    End Sub

    ''' <summary>
    ''' Redraws the Gantt chart
    ''' </summary>
    ''' <param name="gfx"></param>
    ''' <remarks></remarks>

    Private Sub PaintChart(ByVal gfx As Graphics)
        gfx.Clear(Me.BackColor)

        If headerFromDate = Nothing Or headerToDate = Nothing Then Exit Sub

        DrawScrollBar(gfx)
        DrawHeader(gfx, Nothing)
        DrawNetHorizontal(gfx)
        DrawNetVertical(gfx)
        DrawBars(gfx)

        objBmp = New Bitmap(Me.Width - barStartRight, lastLineStop, Imaging.PixelFormat.Format24bppRgb)
        objGraphics = Graphics.FromImage(objBmp)
    End Sub

    ''' <summary>
    ''' Redraws the Gantt chart
    ''' </summary>
    ''' <param name="pe"></param>
    ''' <remarks></remarks>

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)

        PaintChart(pe.Graphics)
    End Sub

    ''' <summary>
    ''' Draws the list of headers. Automatically shows which headers to draw, based on the width of the Gantt Chart
    ''' </summary>
    ''' <param name="gfx"></param>
    ''' <param name="headerList"></param>
    ''' <remarks></remarks>

    Private Sub DrawHeader(ByVal gfx As Graphics, ByVal headerList As List(Of Header))
        If headerList Is Nothing Then
            headerList = GetFullHeaderList()
        End If

        If headerList.Count = 0 Then Exit Sub

        Dim availableWidth = Me.Width - 10 - barStartLeft - barStartRight
        widthPerItem = availableWidth / headerList.Count

        If widthPerItem < 40 Then
            Dim newHeaderList As New List(Of Header)

            Dim showNext As Boolean = True

            ' If there's not enough room for all headers remove 50%

            For Each header As Header In headerList
                If showNext = True Then
                    newHeaderList.Add(header)
                    showNext = False
                Else
                    showNext = True
                End If
            Next

            DrawHeader(gfx, newHeaderList)
            Exit Sub
        End If

        Dim index As Integer = 0
        Dim headerStartPosition As Integer = -1
        Dim lastHeader As Header = Nothing

        For Each header As Header In headerList
            Dim startPos As Integer = barStartLeft + (index * widthPerItem)
            Dim showDateHeader As Boolean = False

            header.StartLocation = startPos

            ' Checks whether to show the date or not

            If lastHeader Is Nothing Then
                showDateHeader = True
            ElseIf header.Time.Hour < lastHeader.Time.Hour Then
                showDateHeader = True
            ElseIf header.Time.Minute = lastHeader.Time.Minute Then
                showDateHeader = False
            End If

            ' Show date

            If showDateHeader = True Then
                Dim str As String = ""

                If header.HeaderTextInsteadOfTime.Length > 0 Then
                    str = header.HeaderTextInsteadOfTime
                Else
                    str = header.Time.ToString("d-MMM")
                End If
                gfx.DrawString(str, dateTextFont, Brushes.Black, startPos, 0)
            End If

            ' Show time

            gfx.DrawString(header.HeaderText, timeTextFont, Brushes.Black, startPos, headerTimeStartTop)
            index += 1

            lastHeader = header
        Next

        shownHeaderList = headerList
        widthPerItem = (Me.Width - 10 - barStartLeft - barStartRight) / shownHeaderList.Count
    End Sub

    ''' <summary>
    ''' Draws the bars
    ''' </summary>
    ''' <param name="grfx"></param>
    ''' <remarks></remarks>

    Private Sub DrawBars(ByVal grfx As Graphics, Optional ByVal ignoreScrollAndMousePosition As Boolean = False)
        If shownHeaderList Is Nothing Then Exit Sub
        If shownHeaderList.Count = 0 Then Exit Sub

        Dim index As Integer = 0

        ' Finds pixels per minute

        Dim timeBetween As TimeSpan = shownHeaderList(1).Time - shownHeaderList(0).Time
        Dim minutesBetween As Integer = CInt(timeBetween.TotalMinutes) '(timeBetween.Days * 1440) + (timeBetween.Hours * 60) + timeBetween.Minutes
        Dim widthBetween = (shownHeaderList(1).StartLocation - shownHeaderList(0).StartLocation)
        Dim perMinute As Decimal = widthBetween / minutesBetween

        ' Draws each bar

        For Each bar As ChartBarDate In bars
            index = bar.RowIndex

            Dim startLocation As Integer
            Dim width As Integer
            Dim startMinutes As Integer ' Number of minutes from start of the gantt chart
            Dim startTimeSpan As TimeSpan
            Dim lengthMinutes As Integer ' Number of minutes from bar start to bar end
            Dim lengthTimeSpan As TimeSpan

            Dim scrollPos As Integer = 0

            If ignoreScrollAndMousePosition = False Then
                scrollPos = scrollPosition
            End If

            ' Calculates where the bar should be located

            startTimeSpan = bar.StartValue - FromDate
            startMinutes = (startTimeSpan.Days * 1440) + (startTimeSpan.Hours * 60) + startTimeSpan.Minutes

            startLocation = perMinute * startMinutes

            Dim endValue As Date = bar.EndValue

            If endValue = Nothing Then
                endValue = Date.Now
            End If

            lengthTimeSpan = endValue - bar.StartValue
            lengthMinutes = (lengthTimeSpan.Days * 1440) + (lengthTimeSpan.Hours * 60) + lengthTimeSpan.Minutes

            width = perMinute * lengthMinutes

            Dim a As Integer = barStartLeft + startLocation
            Dim b As Integer = barStartTop + (barHeight * (index - scrollPos)) + (barSpace * (index - scrollPos)) + 2
            Dim c As Integer = width
            Dim d As Integer = barHeight

            If c = 0 Then c = 1

            ' Stops a bar from going into the row-text area

            If a - barStartLeft < 0 Then
                a = barStartLeft
            End If

            Dim color As System.Drawing.Color

            ' If mouse is over bar, set the color to be hovercolor

            If MouseOverRowText = bar.Text And bar.StartValue <= _mouseOverColumnValue And bar.EndValue >= _mouseOverColumnValue Then
                color = bar.HoverColor
            Else
                color = bar.Color
            End If

            ' Set the location for the graphics
            bar.TopLocation.Left = New Point(a, b)
            bar.TopLocation.Right = New Point(a + c, b)
            bar.BottomLocation.Left = New Point(a, b + d)
            bar.BottomLocation.Right = New Point(a, b + d)


            Dim obBrush As LinearGradientBrush
            Dim obRect As New Rectangle(a, b, c, d)

            If bar.StartValue <> Nothing And endValue <> Nothing Then
                If (index >= scrollPos And index < barsViewable + scrollPos) Or ignoreScrollAndMousePosition = True Then

                    ' Makes the bar gradient

                    obBrush = New LinearGradientBrush(obRect, color, color.Gray, LinearGradientMode.Vertical)

                    ' Draws the bar

                    grfx.DrawRectangle(Pens.Black, obRect)
                    grfx.FillRectangle(obBrush, obRect)

                    ' Draws the rowtext

                    grfx.DrawString(bar.Text, rowTextFont, Brushes.Black, 0, barStartTop + (barHeight * (index - scrollPos)) + (barSpace * (index - scrollPos)))

                    obBrush = Nothing
                    obRect = Nothing
                    obBrush = Nothing
                End If
            End If

            color = Nothing
        Next
    End Sub

    ''' <summary>
    ''' Draws the vertical lines
    ''' </summary>
    ''' <param name="grfx"></param>
    ''' <remarks></remarks>

    Public Sub DrawNetVertical(ByVal grfx As Graphics)
        If shownHeaderList Is Nothing Then Exit Sub
        If shownHeaderList.Count = 0 Then Exit Sub

        Dim index As Integer = 0
        Dim availableWidth As Integer = Me.Width - 10 - barStartLeft - barStartRight
        Dim lastHeader As Header = Nothing

        For Each header As Header In shownHeaderList
            Dim headerLocationY As Integer = 0

            If lastHeader Is Nothing Then
                headerLocationY = 0
            ElseIf header.Time.Hour < lastHeader.Time.Hour Then
                headerLocationY = 0
            Else
                headerLocationY = headerTimeStartTop
            End If

            grfx.DrawLine(Pens.Bisque, barStartLeft + (index * widthPerItem), headerLocationY, barStartLeft + (index * widthPerItem), lastLineStop)
            index += 1

            lastHeader = header
        Next

        grfx.DrawLine(lineColor, barStartLeft + (index * widthPerItem), headerTimeStartTop, barStartLeft + (index * widthPerItem), lastLineStop)
    End Sub

    ''' <summary>
    ''' Draws the horizontal lines
    ''' </summary>
    ''' <param name="grfx"></param>
    ''' <remarks></remarks>

    Public Sub DrawNetHorizontal(ByVal grfx As Graphics)
        If shownHeaderList Is Nothing Then Exit Sub
        If shownHeaderList.Count = 0 Then Exit Sub

        Dim index As Integer = 0
        Dim width As Integer = (widthPerItem * shownHeaderList.Count) + barStartLeft

        For index = 0 To GetIndexChartBar("QQQQQQ") ' Last used index. Hopefully nobody will make a row named QQQ :o)
            For Each bar As ChartBarDate In bars
                grfx.DrawLine(lineColor, 0, barStartTop + (barHeight * index) + (barSpace * index), width, barStartTop + (barHeight * index) + (barSpace * index))
            Next
        Next

        lastLineStop = barStartTop + (barHeight * (index - 1)) + (barSpace * (index - 1))
    End Sub

    ' This is the position (in pixels, from top) of the last line. Used for drawing lines

    Private lastLineStop As Integer = 0

#End Region

#Region "Header list"

    ''' <summary>
    ''' Gets the full header list, consisting of hours between the two dates set
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Function GetFullHeaderList() As List(Of Header)
        Dim result As New List(Of Header)
        Dim newFromTime As New Date(FromDate.Year, FromDate.Month, FromDate.Day)
        Dim item As String

        Dim interval As TimeSpan = ToDate - FromDate

        If interval.TotalDays < 1 Then
            With newFromTime
                newFromTime = .AddHours(FromDate.Hour)

                If headerFromDate.Minute < 59 And headerFromDate.Minute > 29 Then
                    newFromTime = .AddMinutes(30)
                Else
                    newFromTime = .AddMinutes(0)
                End If
            End With

            While newFromTime <= ToDate
                item = newFromTime.Hour & ":"
                If newFromTime.Minute < 10 Then
                    item += "0" & newFromTime.Minute
                Else
                    item += "" & newFromTime.Minute
                End If

                Dim header As New Header

                header.HeaderText = item
                header.HeaderTextInsteadOfTime = ""
                header.Time = New Date(newFromTime.Year, newFromTime.Month, newFromTime.Day, newFromTime.Hour, newFromTime.Minute, 0)
                result.Add(header)
                'Modified from 5 by NB
                newFromTime = newFromTime.AddMinutes(30) ' The minimum interval of time between the headers
            End While
        ElseIf interval.TotalDays < 60 Then
            While newFromTime <= ToDate
                Dim header As New Header

                header.HeaderText = ""
                header.HeaderTextInsteadOfTime = ""
                header.Time = New Date(newFromTime.Year, newFromTime.Month, newFromTime.Day, 0, 0, 0)
                result.Add(header)

                newFromTime = newFromTime.AddDays(1) ' The minimum interval of time between the headers
            End While
        Else
            While newFromTime <= ToDate
                Dim header As New Header

                header.HeaderText = ""
                header.Time = New Date(newFromTime.Year, newFromTime.Month, newFromTime.Day, 0, 0, 0)
                header.HeaderTextInsteadOfTime = newFromTime.ToString("MMM")
                result.Add(header)

                newFromTime = newFromTime.AddMonths(1) ' The minimum interval of time between the headers
            End While
        End If

        Return result
    End Function

#End Region

#Region "Mouse Move"


    ''' <summary>
    ''' Finds the current row and column based on mouse position
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub GanttChart_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If shownHeaderList Is Nothing Then Exit Sub
        If shownHeaderList.Count = 0 Then Exit Sub

        If e.Button <> Windows.Forms.MouseButtons.Left Then
            mouseHoverPart = MouseOverPart.Empty

            ' If bar has changed manually, but left mouse button is no longer pressed the BarChanged event will be raised

            If AllowManualEditBar = True Then
                If barIsChanging >= 0 Then
                    Dim bi As Integer
                    Dim ChangedBars As New List(Of ChartBarDate)
                    For Each bi In SelectedBars
                        ChangedBars.Add(bars(bi))
                    Next
                    RaiseEvent BarChanged(Me, ChangedBars)

                    barIsChanging = -1
                End If
            End If
        End If

        mouseHoverBarIndex = -1

        Dim LocalMousePosition As Point

        LocalMousePosition = Me.PointToClient(Cursor.Position)

        ' Finds pixels per minute

        Dim timeBetween As TimeSpan = shownHeaderList(1).Time - shownHeaderList(0).Time
        Dim minutesBetween As Integer = (timeBetween.Days * 1440) + (timeBetween.Hours * 60) + timeBetween.Minutes
        Dim widthBetween = (shownHeaderList(1).StartLocation - shownHeaderList(0).StartLocation)
        Dim perMinute As Decimal = widthBetween / minutesBetween

        ' Finds the time at mousepointer

        Dim minutesAtCursor As Integer = 0

        If LocalMousePosition.X > barStartLeft Then
            minutesAtCursor = (LocalMousePosition.X - barStartLeft) / perMinute
            _mouseOverColumnValue = FromDate.AddMinutes(minutesAtCursor)
        Else
            _mouseOverColumnValue = Nothing
        End If

        ' Finds the row at mousepointer

        Dim rowText As String = ""
        Dim rowValue As Object = Nothing
        Dim rowIndex As Integer = -1
        Dim columnText As String = ""

        ' Tests to see if the mouse pointer is hovering above the scrollbar

        Dim scrollBarStatusChanged As Boolean = False

        ' Tests to see if the mouse is hovering over the scroll-area bottom-arrow

        If LocalMousePosition.X > BottomPart.Left And LocalMousePosition.Y < BottomPart.Right And LocalMousePosition.Y < BottomPart.Bottom And LocalMousePosition.Y > BottomPart.Top Then
            If mouseOverBottomPart = False Then
                scrollBarStatusChanged = True
            End If

            mouseOverBottomPart = True
        Else
            If mouseOverBottomPart = False Then
                scrollBarStatusChanged = True
            End If

            mouseOverBottomPart = False
        End If

        ' Tests to see if the mouse is hovering over the scroll-area top-arrow

        If LocalMousePosition.X > topPart.Left And LocalMousePosition.Y < topPart.Right And LocalMousePosition.Y < topPart.Bottom And LocalMousePosition.Y > topPart.Top Then
            If mouseOverTopPart = False Then
                scrollBarStatusChanged = True
            End If

            mouseOverTopPart = True
        Else
            If mouseOverTopPart = False Then
                scrollBarStatusChanged = True
            End If

            mouseOverTopPart = False
        End If

        ' Tests to see if the mouse is hovering over the scroll

        If LocalMousePosition.X > scroll.Left And LocalMousePosition.Y < scroll.Right And LocalMousePosition.Y < scroll.Bottom And LocalMousePosition.Y > scroll.Top Then
            If mouseOverScrollBar = False Then
                scrollBarStatusChanged = True
            End If

            mouseOverScrollBar = True
            mouseOverScrollBarArea = True
        Else
            If mouseOverScrollBar = False Then
                scrollBarStatusChanged = True
            End If

            mouseOverScrollBar = False
            mouseOverScrollBarArea = False
        End If

        ' If the mouse is not above the scroll, test if it's over the scroll area (no need to test if it's not above the scroll)

        If mouseOverScrollBarArea = False Then
            If LocalMousePosition.X > scrollBarArea.Left And LocalMousePosition.Y < scrollBarArea.Right And LocalMousePosition.Y < scrollBarArea.Bottom And LocalMousePosition.Y > scrollBarArea.Top Then
                mouseOverScrollBarArea = True
            End If
        End If


        ' Tests to see if the mouse pointer is hovering above a bar

        Dim index As Integer = 0

        For Each bar As ChartBarDate In bars

            ' If the bar is set to be hidden from mouse move, the current bar will be ignored

            If bar.HideFromMouseMove = False Then
                If bar.EndValue = Nothing Then
                    bar.EndValue = Date.Now
                End If

                ' Mouse pointer needs to be inside the X and Y positions of the bar

                If LocalMousePosition.Y > bar.TopLocation.Left.Y And LocalMousePosition.Y < bar.BottomLocation.Left.Y Then
                    If LocalMousePosition.X > bar.TopLocation.Left.X And LocalMousePosition.X < bar.TopLocation.Right.X Then

                        ' If the current bar is the one where the mouse is above, the rowText and rowValue needs to be set correctly

                        rowText = bar.Text
                        rowValue = bar.Value
                        rowIndex = bar.RowIndex
                        mouseHoverBarIndex = index
                        _mouseOverDBIndex = bars(index).DataSetIndex


                        If mouseHoverPart <> MouseOverPart.BarLeftSide And mouseHoverPart <> MouseOverPart.BarRightSide Then
                            mouseHoverPart = MouseOverPart.Bar
                        End If
                    End If

                    ' If mouse pointer is near the edges of the bar it will open up for editing the bar

                    If AllowManualEditBar = True Then
                        Dim areaSize As Integer = 5

                        If e.Button = Windows.Forms.MouseButtons.Left Then
                            areaSize = 50
                        End If

                        'If LocalMousePosition.X > bar.TopLocation.Left.X - areaSize And LocalMousePosition.X < bar.TopLocation.Left.X + areaSize And mouseHoverPart <> MouseOverPart.BarRightSide Then
                        '    Me.Cursor = Cursors.NoMoveHoriz
                        '    mouseHoverPart = MouseOverPart.BarLeftSide
                        '    mouseHoverBarIndex = index
                        '    _mouseOverDBIndex = bars(index).DataSetIndex
                        'ElseIf LocalMousePosition.X > bar.TopLocation.Right.X - areaSize And LocalMousePosition.X < bar.TopLocation.Right.X + areaSize And mouseHoverPart <> MouseOverPart.BarLeftSide Then
                        '    Me.Cursor = Cursors.NoMoveHoriz
                        '    mouseHoverPart = MouseOverPart.BarRightSide
                        '    mouseHoverBarIndex = index
                        '    _mouseOverDBIndex = bars(index).DataSetIndex
                        'Else
                        '    Me.Cursor = Cursors.Default
                        'End If

                    End If
                End If
            End If

            index += 1
        Next

        ' Sets the mouseover row value and text

        _mouseOverRowText = rowText
        _mouseOverRowValue = rowValue
        _mouseOverRowIndex = rowIndex

        If e.Button = Windows.Forms.MouseButtons.Left Then
            RaiseEvent MouseDragged(sender, e)
        Else

            ' A simple test to see if the mousemovement has caused any changes to how it should be displayed 
            ' It only redraws if mouse moves from a bar to blank area or from blank area to a bar
            ' This increases performance compared to having a redraw every time a mouse moves

            If (_mouseOverRowValue Is Nothing And Not rowValue Is Nothing) Or (Not _mouseOverRowValue Is Nothing And rowValue Is Nothing) Or scrollBarStatusChanged = True Then
                PaintChart()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Mouse leave event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub GanttChart_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        _mouseOverRowText = Nothing
        _mouseOverRowValue = Nothing
        _mouseOverRowIndex = -1
        mouseHoverPart = MouseOverPart.Empty

        PaintChart()
    End Sub

    ''' <summary>
    ''' Mouse drag event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub GanttChart_MouseDragged(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDragged
        If mouseOverScrollBarArea = True Then
            ScrollPositionY = e.Location.Y
        End If

        If barIsChanging > -1 Then
            IsChanged = True
            Dim ts As TimeSpan = _mouseOverColumnValue - mouseDownTime
            Dim Offset As TimeSpan = ts - alreadyDrug
            alreadyDrug += Offset
            Dim bi As Integer
            For Each bi In SelectedBars
                bars(bi).StartValue += Offset
                bars(bi).EndValue += Offset
            Next
            PaintChart()

        End If
    End Sub

    Private Sub GanttChart_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'MessageBox.Show("IsCntrlPressed=" & IsCntrlPressed.ToString, "Key Click Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        If AllowManualEditBar = True Then
            If mouseHoverBarIndex > -1 Then
                Select Case Control.ModifierKeys
                    Case Keys.Shift
                        If SelectedBars.Count = 0 Then
                            'SelectedBars.Add(mouseHoverBarIndex)
                            AddBarToSelection(mouseHoverBarIndex)
                        Else
                            Dim iCurrent As Integer = mouseHoverBarIndex
                            Dim iStart As Integer = SelectedBars(0)
                            Dim i As Integer
                            'SelectedBars.Clear()
                            ClearSelection()
                            For i = iStart To iCurrent
                                'SelectedBars.Add(i)
                                AddBarToSelection(i)
                            Next

                        End If
                    Case Keys.Control
                        If SelectedBars.Contains(mouseHoverBarIndex) Then
                            'item is already selected, so deselect
                            SelectedBars.Remove(mouseHoverBarIndex)
                            bars(mouseHoverBarIndex).Color = Color.Azure

                        Else
                            'SelectedBars.Add(mouseHoverBarIndex)
                            AddBarToSelection(mouseHoverBarIndex)
                        End If
                    Case Else
                        'if the existing bar is already selected, anticipate starting a drag drop
                        mouseDownTime = _mouseOverColumnValue
                        barIsChanging = mouseHoverBarIndex
                        alreadyDrug = New TimeSpan(0)

                        'if the existing bar is already selected, anticipate starting a drag drop
                        'otherwise clear the selection bars and add the new bar
                        If Not SelectedBars.Contains(mouseHoverBarIndex) Then
                            'clear the selected bars and then add the bar to the selected bars list
                            ClearSelection()
                            'SelectedBars.Add(barIsChanging)
                            AddBarToSelection(barIsChanging)
                        End If
                End Select
            Else
                ClearSelection()
            End If
        End If
    End Sub
    Private Sub GanttChart_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If barIsChanging > -1 And IsChanged Then
            Dim bi As Integer
            Dim ChangedBars As New List(Of ChartBarDate)
            For Each bi In SelectedBars
                ChangedBars.Add(bars(bi))
            Next
            RaiseEvent BarChanged(Me, ChangedBars)
        End If
        mouseDownTime = Nothing
        barIsChanging = -1
        IsChanged = False
        alreadyDrug = Nothing
        'Make sure selected bars are displayed
        If SelectedBars.Count > 0 Then
            Dim bi As Integer
            For Each bi In SelectedBars
                bars(bi).Color = _selectedColor
            Next
        End If
        PaintChart()
    End Sub

    Public Sub ClearSelection()
        Dim bi As Integer
        'If the detail chart changes, there is no need to reverse the individual bar colors
        'This inequality may occur if the detail is changing. Just skip the bar recoloration
        If SelectedBars.Count <= bars.Count Then
            For Each bi In SelectedBars
                If bars(bi).IsSetup Then
                    bars(bi).Color = Color.DarkRed
                Else
                    bars(bi).Color = Color.Aqua
                End If
            Next
        End If
        SelectedBars.Clear()
        PaintChart()
    End Sub

    Private Sub AddBarToSelection(ByVal index As Integer)
        'ignore setup bars
        If bars(index).IsSetup Then
            Exit Sub
        End If
        'ignore already selected bars
        If SelectedBars.Contains(index) Then
            Exit Sub
        End If

        'add the selected bar
        SelectedBars.Add(index)

        'add the attached setup if there is one to keep the bars together
        If index > 0 Then
            If bars(index - 1).IsSetup Then
                SelectedBars.Add(index - 1)
            End If
        End If
    End Sub


#End Region

#Region "ToolTipText"

    Private _toolTipText As New List(Of String)
    Private _toolTipTextTitle As String = ""

    Private MyPoint As New Point(0, 0)

    ''' <summary>
    ''' The title to draw
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property ToolTipTextTitle() As String
        Get
            Return _toolTipTextTitle
        End Get
        Set(ByVal value As String)
            _toolTipTextTitle = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the ToolTipText lines
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Don not use the add function directly on this, use ToolTipText = value</remarks>

    Public Property ToolTipText() As List(Of String)
        Get
            If _toolTipText Is Nothing Then _toolTipText = New List(Of String)
            Return _toolTipText
        End Get
        Set(ByVal value As List(Of String))
            _toolTipText = value

            Dim LocalMousePosition As Point

            LocalMousePosition = Me.PointToClient(Cursor.Position)


            If LocalMousePosition = MyPoint Then Exit Property

            MyPoint = LocalMousePosition

            ToolTip.SetToolTip(Me, ".")
        End Set
    End Property

    ''' <summary>
    ''' Draws the ToolTip window
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ToolTipText_Draw(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawToolTipEventArgs) Handles ToolTip.Draw
        If ToolTipText Is Nothing Then
            ToolTipText = New List(Of String)
            Exit Sub
        End If

        If ToolTipText.Count = 0 Then
            Exit Sub
        ElseIf ToolTipText(0).Length = 0 Then
            Exit Sub
        End If

        Dim x As Integer
        Dim y As Integer

        e.Graphics.FillRectangle(Brushes.AntiqueWhite, e.Bounds)
        e.DrawBorder()

        Dim titleHeight As Integer = 14
        Dim fontHeight As Integer = 12

        ' Draws the line just below the title

        e.Graphics.DrawLine(Pens.Black, 0, titleHeight, e.Bounds.Width, titleHeight)

        Dim lines As Integer = 1
        Dim text As String = ToolTipTextTitle

        ' Draws the title

        Using font As New Font(e.Font, FontStyle.Bold)
            x = (e.Bounds.Width - e.Graphics.MeasureString(text, font).Width) \ 2
            y = (titleHeight - e.Graphics.MeasureString(text, font).Height) \ 2
            e.Graphics.DrawString(text, font, Brushes.Black, x, y)
        End Using

        ' Draws the lines

        For Each str As String In ToolTipText
            Dim font As New Font(e.Font, FontStyle.Regular)

            If str.Contains("[b]") Then
                font = New Font(font.FontFamily, font.Size, FontStyle.Bold, font.Unit)
                str = str.Replace("[b]", "")
            End If

            Using font
                x = 5
                y = (titleHeight - fontHeight - e.Graphics.MeasureString(str, font).Height) \ 2 + 10 + (lines * 14)
                e.Graphics.DrawString(str, font, Brushes.Black, x, y)
            End Using

            lines += 1
        Next
    End Sub

    ''' <summary>
    ''' Automatically resizes the ToolTip window
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub ToolTipText_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip.Popup
        If ToolTipText Is Nothing Then
            ToolTipText = New List(Of String)
        End If

        If ToolTipText.Count = 0 Then
            e.ToolTipSize = New Size(0, 0)
            Exit Sub
        ElseIf ToolTipText(0).Length = 0 Then
            e.ToolTipSize = New Size(0, 0)
            Exit Sub
        End If

        ' resizes the ToolTip window

        Dim height As Integer = 18 + (ToolTipText.Count * 15)
        e.ToolTipSize = New Size(200, height)
    End Sub

#End Region

#Region "ChartBar"

    'Private Class ChartBarDate

    '    Friend Class Location

    '        Private _right As New Point(0, 0)
    '        Private _left As New Point(0, 0)

    '        Public Property Right() As Point
    '            Get
    '                Return _right
    '            End Get
    '            Set(ByVal value As Point)
    '                _right = value
    '            End Set
    '        End Property

    '        Public Property Left() As Point
    '            Get
    '                Return _left
    '            End Get
    '            Set(ByVal value As Point)
    '                _left = value
    '            End Set
    '        End Property

    '    End Class

    '    Private _startValue As Date
    '    Private _endValue As Date

    '    Private _color As Color
    '    Private _hoverColor As Color

    '    Private _text As String
    '    Private _value As Object

    '    Private _rowIndex As Integer

    '    Private _topLocation As New Location
    '    Private _bottomLocation As New Location

    '    Private _hideFromMouseMove As Boolean = False

    '    Public Property StartValue() As Date
    '        Get
    '            Return _startValue
    '        End Get
    '        Set(ByVal value As Date)
    '            _startValue = value
    '        End Set
    '    End Property

    '    Public Property EndValue() As Date
    '        Get
    '            Return _endValue
    '        End Get
    '        Set(ByVal value As Date)
    '            _endValue = value
    '        End Set
    '    End Property

    '    Public Property Color() As Color
    '        Get
    '            Return _color
    '        End Get
    '        Set(ByVal value As Color)
    '            _color = value
    '        End Set
    '    End Property

    '    Public Property HoverColor() As Color
    '        Get
    '            Return _hoverColor
    '        End Get
    '        Set(ByVal value As Color)
    '            _hoverColor = value
    '        End Set
    '    End Property

    '    Public Property Text() As String
    '        Get
    '            Return _text
    '        End Get
    '        Set(ByVal value As String)
    '            _text = value
    '        End Set
    '    End Property

    '    Public Property Value() As Object
    '        Get
    '            Return _value
    '        End Get
    '        Set(ByVal value As Object)
    '            _value = value
    '        End Set
    '    End Property

    '    Public Property RowIndex() As Integer
    '        Get
    '            Return _rowIndex
    '        End Get
    '        Set(ByVal value As Integer)
    '            _rowIndex = value
    '        End Set
    '    End Property

    '    Public Property HideFromMouseMove() As Boolean
    '        Get
    '            Return _hideFromMouseMove
    '        End Get
    '        Set(ByVal value As Boolean)
    '            _hideFromMouseMove = value
    '        End Set
    '    End Property

    '    Friend Property TopLocation() As Location
    '        Get
    '            Return _topLocation
    '        End Get
    '        Set(ByVal value As Location)
    '            _topLocation = value
    '        End Set
    '    End Property

    '    Friend Property BottomLocation() As Location
    '        Get
    '            Return _bottomLocation
    '        End Get
    '        Set(ByVal value As Location)
    '            _bottomLocation = value
    '        End Set
    '    End Property

    'End Class

#End Region

#Region "Headers"

    Private Class Header

        Private _headerText As String
        Private _startLocation As Integer
        Private _headerTextInsteadOfTime As String = ""
        Private _time As Date = Nothing

        Public Property HeaderText() As String
            Get
                Return _headerText
            End Get
            Set(ByVal value As String)
                _headerText = value
            End Set
        End Property

        Public Property StartLocation() As Integer
            Get
                Return _startLocation
            End Get
            Set(ByVal value As Integer)
                _startLocation = value
            End Set
        End Property

        ''' <summary>
        ''' If this string is larger than 0, this will be used instead of Time
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Property HeaderTextInsteadOfTime() As String
            Get
                Return _headerTextInsteadOfTime
            End Get
            Set(ByVal value As String)
                _headerTextInsteadOfTime = value
            End Set
        End Property

        ''' <summary>
        ''' Time to display
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Property Time() As Date
            Get
                Return _time
            End Get
            Set(ByVal value As Date)
                _time = value
            End Set
        End Property

    End Class

#End Region

#Region "Resize"

    ''' <summary>
    ''' On resize the Gantt Chart is redrawn
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)

        scrollPosition = 0

        ' Used for when the Gantt Chart is saved as an image

        If lastLineStop > 0 Then
            objBmp = New Bitmap(Me.Width - barStartRight, lastLineStop, Imaging.PixelFormat.Format24bppRgb)
            objGraphics = Graphics.FromImage(objBmp)
        End If

        PaintChart()
    End Sub

#End Region

#Region "Scrollbar"

    Private barsViewable As Integer = -1
    Private scrollPosition As Integer = 0
    Private topPart As Rectangle = Nothing
    Private BottomPart As Rectangle = Nothing
    Private scroll As Rectangle = Nothing
    Private scrollBarArea As Rectangle = Nothing

    Private mouseOverTopPart As Boolean = False
    Private mouseOverBottomPart As Boolean = False
    Private mouseOverScrollBar As Boolean = False
    Private mouseOverScrollBarArea As Boolean = False

    ''' <summary>
    ''' Draws a scrollbar to the component, if there's a need for it
    ''' </summary>
    ''' <param name="grfx"></param>
    ''' <remarks></remarks>

    Private Sub DrawScrollBar(ByVal grfx As Graphics)
        barsViewable = (Me.Height - barStartTop) / (barHeight + barSpace)
        Dim barCount As Integer = GetIndexChartBar("QQQWWW")
        If barCount = 0 Then Exit Sub

        Dim maxHeight As Integer = Me.Height - 30
        Dim scrollHeight As Decimal = (maxHeight / barCount) * barsViewable

        ' If the scroll area is filled there's no need to show the scrollbar

        If scrollHeight >= maxHeight Then Exit Sub

        Dim scrollSpeed As Decimal = (maxHeight - scrollHeight) / (barCount - barsViewable)

        scrollBarArea = New Rectangle(Me.Width - 20, 19, 12, maxHeight)
        scroll = New Rectangle(Me.Width - 20, 19 + (scrollPosition * scrollSpeed), 12, scrollHeight)

        topPart = New Rectangle(Me.Width - 20, 10, 12, 8)
        BottomPart = New Rectangle(Me.Width - 20, Me.Height - 10, 12, 8)

        Dim colorTopPart As Brush
        Dim colorBottomPart As Brush
        Dim colorScroll As Brush

        If mouseOverTopPart = True Then
            colorTopPart = Brushes.Black
        Else
            colorTopPart = Brushes.Gray
        End If

        If mouseOverBottomPart = True Then
            colorBottomPart = Brushes.Black
        Else
            colorBottomPart = Brushes.Gray
        End If

        If mouseOverScrollBar = True Then
            colorScroll = New LinearGradientBrush(scroll, Color.Bisque, Color.Gray, LinearGradientMode.Horizontal)
        Else
            colorScroll = New LinearGradientBrush(scroll, Color.White, Color.Gray, LinearGradientMode.Horizontal)
        End If

        ' Draws the top and bottom part of the scrollbar

        grfx.DrawRectangle(Pens.Black, topPart)
        grfx.FillRectangle(Brushes.LightGray, topPart)

        grfx.DrawRectangle(Pens.Black, BottomPart)
        grfx.FillRectangle(Brushes.LightGray, BottomPart)

        ' Draws arrows

        Dim points(2) As PointF
        points(0) = New PointF(topPart.Left, topPart.Bottom - 1)
        points(1) = New PointF(topPart.Right, topPart.Bottom - 1)
        points(2) = New PointF((topPart.Left + topPart.Right) / 2, topPart.Top + 1)

        grfx.FillPolygon(colorTopPart, points)

        points(0) = New PointF(BottomPart.Left, BottomPart.Top + 1)
        points(1) = New PointF(BottomPart.Right, BottomPart.Top + 1)
        points(2) = New PointF((BottomPart.Left + BottomPart.Right) / 2, BottomPart.Bottom - 1)

        grfx.FillPolygon(colorBottomPart, points)

        ' Draws the scroll area

        grfx.DrawRectangle(Pens.Black, scrollBarArea)
        grfx.FillRectangle(Brushes.DarkGray, scrollBarArea)

        ' Draws the actual scrollbar

        grfx.DrawRectangle(Pens.Black, scroll)
        grfx.FillRectangle(colorScroll, scroll)
    End Sub

    ''' <summary>
    ''' The Y-position of the center of the scroll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Property ScrollPositionY() As Integer
        Get
            If scroll = Nothing Then Return -1
            Return ((scroll.Height / 2) + scroll.Location.Y) + 19
        End Get
        Set(ByVal value As Integer)
            Dim barCount As Integer = GetIndexChartBar("QQQWWW")
            Dim maxHeight As Integer = Me.Height - 30
            Dim scrollHeight As Decimal = (maxHeight / barCount) * barsViewable
            Dim scrollSpeed As Decimal = (maxHeight - scrollHeight) / (barCount - barsViewable)
            Dim index As Integer = 0
            Dim distanceFromLastPosition = 9999

            ' Tests to see what scrollposition is the closest to the set position

            While index < barCount
                Dim newPositionTemp As Integer = (index * scrollSpeed) + (scrollHeight / 2) + (30 / 2)
                Dim distanceFromCurrentPosition = newPositionTemp - value

                If distanceFromLastPosition < 0 Then
                    If distanceFromCurrentPosition < distanceFromLastPosition Then
                        scrollPosition = index - 1
                        PaintChart()
                        Exit Property
                    End If
                Else
                    If distanceFromCurrentPosition > distanceFromLastPosition Then
                        scrollPosition = index - 1

                        ' A precaution to make sure the scroll bar doesn't go too far down

                        If scrollPosition + barsViewable > GetIndexChartBar("QQQWWW") Then
                            scrollPosition = GetIndexChartBar("QQQWWW") - barsViewable
                        End If

                        PaintChart()
                        Exit Property
                    End If
                End If

                distanceFromLastPosition = distanceFromCurrentPosition

                index += 1
            End While
        End Set
    End Property

    ''' <summary>
    ''' Scrolls one row up
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub ScrollOneup()
        If scrollPosition = 0 Then Exit Sub

        scrollPosition -= 1

        PaintChart()
    End Sub

    ''' <summary>
    ''' Scrolls one row down
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub ScrollOneDown()
        If scrollPosition + barsViewable >= GetIndexChartBar("QQQWWW") Then Exit Sub

        scrollPosition += 1

        PaintChart()
    End Sub

    ''' <summary>
    ''' If the user clicks on the scrollbar, scrolling functions will be called
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub GanttChart_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If mouseOverBottomPart = True Then
                ScrollOneDown()
            ElseIf mouseOverTopPart = True Then
                ScrollOneup()
            End If
        End If
    End Sub

    ''' <summary>
    ''' When mousewheel is used, the scrollbar will scroll
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub GanttChart_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            ScrollOneup()
        Else
            ScrollOneDown()
        End If
    End Sub

#End Region

#Region "Save"

    ''' <summary>
    ''' Saves the GanttChart to specified image file
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <remarks></remarks>

    Public Sub SaveImage(ByVal filePath As String)
        objGraphics.SmoothingMode = SmoothingMode.HighSpeed
        objGraphics.Clear(Me.BackColor)

        If headerFromDate = Nothing Or headerToDate = Nothing Then Exit Sub

        DrawHeader(objGraphics, Nothing)
        DrawNetHorizontal(objGraphics)
        DrawNetVertical(objGraphics)
        DrawBars(objGraphics, True)

        objBmp.Save(filePath)
    End Sub

#End Region

    Private Enum MouseOverPart

        Empty
        Bar
        BarLeftSide
        BarRightSide

    End Enum


End Class