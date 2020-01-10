using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YOURNAMESPACE //Make sure you change this to whichever namespace you are using!
{
    class themeClass
    {
        //defines the default application colors
        public static Color originalBackColor = SystemColors.Control;
        public static Color originalTxtColor = SystemColors.ControlText;
        public static Color originalTxtBoxColor = SystemColors.AppWorkspace;
        public static Color originalButtonColor = SystemColors.Control;
        public static Color originalGridColor = SystemColors.Window;
        public static Color originalGridTxtColor = SystemColors.ControlText;
        public static Color originalGridHeaderColor = SystemColors.Window;
        public static Color originalActiveTxtBoxColor = SystemColors.Window;
        public static Color originalInactiveTxtBoxColor = SystemColors.Control;
        public static Color originalGroupBoxColor = SystemColors.ControlLight;
        public static Color originalSecGridColor = SystemColors.Control;
        public static Color originalSecGridTxtColor = SystemColors.ControlText;
        public static Color originalGridSelectColor = SystemColors.Highlight;
        public static Color originalGridSelectTxtColor = SystemColors.HighlightText;
        public static Color originalSecGridSelectColor = SystemColors.Highlight;
        public static Color originalSecGridSelectTxtColor = SystemColors.HighlightText;
        public static Color originalTabColor = SystemColors.Control;
        public static Color originalTabTxtColor = SystemColors.ControlText;
        public static Color originalPressedTabColor = SystemColors.Control;
        public static Color originalPressedTabTxtColor = SystemColors.ControlText;
        public static Color originalTabBorderColor = SystemColors.Control;

        //call this function to set the custom theme colors
        public static void SetCustomColors(Color backColor, Color txtColor, Color txtBoxColor, Color buttonColor, Color gridColor, Color gridTxtColor, Color gridHeaderColor, Color activeTxtBoxColor, Color inactiveTxtBoxColor, Color groupBoxColor, Color secGridColor, Color secGridTxtColor, Color gridSelectColor, Color gridSelectTxtColor, Color secGridSelectColor, Color secGridSelectTxtColor, Color tabColor, Color tabTxtColor, Color pressedTabColor, Color pressedTabTxtColor, Color tabBorderColor)
        {
            //Saves the custom colors to the computer (see Properties Settings.settings)
            Properties.Settings.Default.cusBackColor = backColor;
            Properties.Settings.Default.cusTxtColor = txtColor;
            Properties.Settings.Default.cusTxtBoxColor = txtBoxColor;
            Properties.Settings.Default.cusButtonColor = buttonColor;
            Properties.Settings.Default.cusGridColor = gridColor;
            Properties.Settings.Default.cusSecGridColor = secGridColor;
            Properties.Settings.Default.cusGridTxtColor = gridTxtColor;
            Properties.Settings.Default.cusSecGridTxtColor = secGridTxtColor;
            Properties.Settings.Default.cusGridHeaderColor = gridHeaderColor;
            Properties.Settings.Default.cusActiveTxtBoxColor = activeTxtBoxColor;
            Properties.Settings.Default.cusInactiveTxtBoxColor = inactiveTxtBoxColor;
            Properties.Settings.Default.cusGroupBoxColor = groupBoxColor;
            Properties.Settings.Default.cusGroupBoxColor = groupBoxColor;
            Properties.Settings.Default.cusGridSelectColor = gridSelectColor;
            Properties.Settings.Default.cusGridSelectTxtColor = gridSelectTxtColor;
            Properties.Settings.Default.cusSecGridSelectColor = secGridSelectColor;
            Properties.Settings.Default.cusSecGridSelectTxtColor = secGridSelectTxtColor;
            Properties.Settings.Default.cusTabColor = tabColor;
            Properties.Settings.Default.cusTabTxtColor = tabTxtColor;
            Properties.Settings.Default.cusPressedTabColor = pressedTabColor;
            Properties.Settings.Default.cusPressedTabTxtColor = pressedTabTxtColor;
            Properties.Settings.Default.cusTabBorderColor = tabBorderColor;
            Properties.Settings.Default.Save();
        }

        //Call this to change the theme to the custom colors
        public static void customTheme(Control control)
        {

            SetAllControlsColor(control, Properties.Settings.Default.cusBackColor, Properties.Settings.Default.cusTxtColor, Properties.Settings.Default.cusTxtBoxColor, Properties.Settings.Default.cusButtonColor, Properties.Settings.Default.cusGridColor, Properties.Settings.Default.cusGridTxtColor, Properties.Settings.Default.cusGridHeaderColor, Properties.Settings.Default.cusActiveTxtBoxColor, Properties.Settings.Default.cusInactiveTxtBoxColor, Properties.Settings.Default.cusGroupBoxColor, Properties.Settings.Default.cusSecGridColor, Properties.Settings.Default.cusSecGridTxtColor, Properties.Settings.Default.cusGridSelectColor, Properties.Settings.Default.cusGridSelectTxtColor, Properties.Settings.Default.cusSecGridSelectColor, Properties.Settings.Default.cusSecGridSelectTxtColor, Properties.Settings.Default.cusTabColor, Properties.Settings.Default.cusTabTxtColor, Properties.Settings.Default.cusPressedTabColor, Properties.Settings.Default.cusPressedTabTxtColor, Properties.Settings.Default.cusTabBorderColor);
        }

        //Call this to reset the theme to the original colors
        public static void resetTheme(Control control)
        {
            SetAllControlsColor(control, originalBackColor, originalTxtColor, originalTxtBoxColor, originalButtonColor, originalGridColor, originalGridTxtColor, originalGridHeaderColor, originalActiveTxtBoxColor, originalInactiveTxtBoxColor, originalGroupBoxColor, originalSecGridColor, originalSecGridTxtColor, originalGridSelectColor, originalGridSelectTxtColor, originalSecGridSelectColor, originalSecGridSelectTxtColor, originalTabColor, originalTabTxtColor, originalPressedTabColor, originalPressedTabTxtColor, originalTabBorderColor);

        }


        //Sets all of the controls' colors
        private static void SetAllControlsColor(Control control, Color backColor, Color txtColor, Color multiLineBoxColor, Color buttonColor, Color gridColor, Color gridTxtColor, Color gridHeaderColor, Color activeTxtBoxColor, Color inactiveTxtBoxColor, Color groupBoxColor, Color secGridColor, Color secGridTxtColor, Color gridSelectColor, Color gridSelectTxtColor, Color secGridSelectColor, Color secGridSelectTxtColor, Color tabColor, Color tabTxtColor, Color pressedTabColor, Color pressedTabTxtColor, Color tabBorderColor)
        {
            //checks if the control is a TextBox
            if (control is TextBox)
            {
                //creates a TextBox variable to check whether or not it's a read only, multiline, or a regular box then sets appropriately
                TextBox box = control as TextBox;

                box.BorderStyle = BorderStyle.FixedSingle; //Sets the BorderStyle to FixedSingle to remove a white border around the textbox

                if (!box.ReadOnly)
                    control.BackColor = activeTxtBoxColor; //If the box is not read only, it will set the active text box color
                else if (box.Multiline)
                    control.BackColor = multiLineBoxColor; //If the box is read only and is a multiline box, it will set as the multiline txt box color
                else
                    control.BackColor = inactiveTxtBoxColor; //If the box is read only and is not a multiline textbox, it will set as the inactive textbox color 
            }
            //checks if the control is a button and sets the color appropriately
            else if (control is Button)
            {
                Button button = control as Button;
                button.FlatStyle = FlatStyle.Flat; //Sets the FlatStyle to Flat to remove a white border around the button

                control.BackColor = buttonColor;
            }
            //checks if the control is a datagrid
            else if (control is DataGridView)
            {
                //Creates a DataGrid Variable in order to set the colors appropriately
                DataGridView grid = control as DataGridView;
                grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single; //Sets the RowHeadersBorderStyle to single to remove the white border around the row headers
                grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single; //Sets the ColumnHeadersBorderStyle to single to remove the white border around the Column headers

                grid.BackColor = multiLineBoxColor;
                grid.BackgroundColor = multiLineBoxColor;
                grid.DefaultCellStyle.BackColor = gridColor;
                grid.DefaultCellStyle.SelectionBackColor = gridColor;
                grid.DefaultCellStyle.SelectionForeColor = gridTxtColor;
                grid.DefaultCellStyle.ForeColor = gridTxtColor;
                grid.DefaultCellStyle.SelectionBackColor = gridSelectColor;
                grid.DefaultCellStyle.SelectionForeColor = gridSelectTxtColor;
                grid.AlternatingRowsDefaultCellStyle.BackColor = secGridColor;
                grid.AlternatingRowsDefaultCellStyle.ForeColor = secGridTxtColor;
                grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = secGridSelectColor;
                grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = secGridSelectTxtColor;
                grid.ColumnHeadersDefaultCellStyle.BackColor = gridHeaderColor;
                grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = gridHeaderColor;
                grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = gridTxtColor;
                grid.ColumnHeadersDefaultCellStyle.ForeColor = gridTxtColor;
                grid.RowHeadersDefaultCellStyle.BackColor = gridHeaderColor;
                grid.RowHeadersDefaultCellStyle.SelectionBackColor = gridHeaderColor;
                grid.RowHeadersDefaultCellStyle.SelectionForeColor = gridTxtColor;
                grid.RowHeadersDefaultCellStyle.ForeColor = gridTxtColor;
                grid.GridColor = gridTxtColor;

                grid.EnableHeadersVisualStyles = false;

            }
            //if the control is not a datagrid, button, or textbox, it'll set the color appropriately
            else
            {
                control.BackColor = backColor;
            }

            //Checks if the control is a group box so it can adjust the border appropriately
            if (control is GroupBox)
            {
                
                GroupBox group = control as GroupBox; // Creates a groupbox variable to adjust the border
                SolidBrush brush = new SolidBrush(groupBoxColor); //creates a brush variable for the group box color

                group.Paint += delegate (object o, PaintEventArgs p)
                {
                    p.Graphics.Clear(group.Parent.BackColor); //resets the background color of the groupbox
                    p.Graphics.DrawString(group.Text, group.Font, brush, 0, 0); //resets the groupbox text to the group box color

                    ControlPaint.DrawBorder(p.Graphics, group.ClientRectangle, groupBoxColor, ButtonBorderStyle.Solid); //re-draws the border for the group box
                };
            }

            //Checks if the control is a toolstrip
            if (control is ToolStrip)
            {
                ToolStrip strip = control as ToolStrip; //creates a toolstrip variable to adjust appropriately
                SolidBrush brush = new SolidBrush(backColor); //creates a brush for the background color of the toolstrip
                strip.Renderer = new MySR(brush, txtColor, buttonColor); //calls the MySR class to change the colors (see class below)
            }

            //Checks if the control is a tab control
            if (control is TabControl)
            {
                TabControl tab = control as TabControl; //creates a tabcontrol variable to adjust appropriately

                //Calls the MyTab class to adjust the colors (see class below)
                tab = new MyTab(tab, pressedTabColor, tabColor, pressedTabTxtColor, tabTxtColor, tabBorderColor);
                
            }

            //Sets the text color
            control.ForeColor = txtColor;

            //checks if the control has children
            if (control.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    //for the child control, it calls the SetAllControlsColor function to set the colors appropriately
                    SetAllControlsColor(childControl, backColor, txtColor, multiLineBoxColor, buttonColor, gridColor, gridTxtColor, gridHeaderColor, activeTxtBoxColor, inactiveTxtBoxColor, groupBoxColor, secGridColor, secGridTxtColor, gridSelectColor, gridSelectTxtColor, secGridSelectColor, secGridSelectTxtColor, tabColor, tabTxtColor, pressedTabColor, pressedTabTxtColor, tabBorderColor);
                }
            }
        }
        

    }


    public class MyTab : TabControl
    { 
        // Define the variables
        TabControl tabControl1;
        Brush selectedBackground;
        Brush Background;
        Brush Text;
        Brush selectedText;
        Color tabBorder;
        bool borderSet = false;

        //call this to set the variables appropriately
        public MyTab(TabControl tab, Color sBackground, Color uBackground, Color sText, Color uText, Color border)
        {
            tabControl1 = tab;
            selectedBackground = new SolidBrush(sBackground);
            Background = new SolidBrush(uBackground);
            Text = new SolidBrush(uText);
            selectedText = new SolidBrush(sText);
            tabBorder = border;
            tabControl1.Appearance = TabAppearance.Normal;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed; //Needs the draw mode set to OwnerDrawFixed in order to customarily adjust the colors
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem); //Sets a custom function that is called when the tab control is 'drawn' to the form
            borderSet = false;
        }
        
            private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // This event is called once for each tab button in your tab control
            // e.Index is the index of the tab in the TabPages collection.

            //checks if the border has been painted, if so paints the border
            if (borderSet == false)
            {
                PaintTransparentBackground(sender, e);
                borderSet = true;
            }
            //paint the background with a color based on the current tab
            //if the tab is pressed
            if (e.State == DrawItemState.Selected) {
                
                //fills the background of the tab
                e.Graphics.FillRectangle(selectedBackground, e.Bounds);

                // Then draws the pressed tab button's text 
                Rectangle paddedBounds = e.Bounds;
                paddedBounds.Inflate(-2, -2);
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, selectedText, paddedBounds);
            }
            else {
                
               
                //fills the background of the tab
                e.Graphics.FillRectangle(Background, e.Bounds);

                // Then draw the current tab button text 
                Rectangle paddedBounds = e.Bounds;
                paddedBounds.Inflate(-2, -2);
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, Text, paddedBounds);
            }
        }
        
        protected void PaintTransparentBackground(object sender, DrawItemEventArgs a)
        {
            Graphics graphics = a.Graphics;
            Rectangle clipRect = this.Bounds;
            //clears the graphics then sets the color for it
            graphics.Clear(tabBorder);
            if ((this.Parent != null))
            {
                //manually draws the rectangle with the previously defined color
                clipRect.Offset(this.Location);
                PaintEventArgs e = new PaintEventArgs(graphics, clipRect);
                GraphicsState state = graphics.Save();
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                try
                {
                    graphics.TranslateTransform((float)-this.Location.X, (float)-this.Location.Y);
                    this.InvokePaintBackground(this.Parent, e);
                    this.InvokePaint(this.Parent, e);
                }
                finally
                {
                    graphics.Restore(state);
                    clipRect.Offset(-this.Location.X, -this.Location.Y);
                }
            }
        }

    } 

    //Call this class to adjust how a toolstrip renders itself
    public class MySR : ToolStripSystemRenderer
    {
        //creates the appropriate color variables
        SolidBrush brush;
        Color textColor;
        SolidBrush backGroundColor;
        Pen outColor;

        //call this to set the colors for the renderer
        public MySR(SolidBrush b, Color t, Color h) { brush = b; textColor = t; backGroundColor = new SolidBrush(h); outColor = new Pen(h); }
        
        //removes the toolstrip border (that way there will not be a line underneath the toolstrip when the background is changed)
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

        //changes the toolstrip background color
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStripDropDown dr = e.ToolStrip as ToolStripDropDown; //creates a dropdown variable to make sure it doesn't cover the menu

            //checks if the dropdown is visible
            if (dr != null)
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds); //ignores the area the dropdown is touching
            }
        }

        //Changes the color of the text on the toolstrip
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = textColor;
            base.OnRenderItemText(e);
        }

        //Changes the color of dropdown arrows)
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = textColor;
            base.OnRenderArrow(e);
        }

        //changes the background color of the toolstrip dropdown menu
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            outColor.Brush = backGroundColor; //sets the color for outcolor

            //checks if the toolstrip dropdown is selected
            if (!e.Item.Selected) base.OnRenderMenuItemBackground(e); //render like the other items if it isn't open
            else
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size); //creates a rectangle variable to the size of the dropdown menu
                e.Graphics.FillRectangle(backGroundColor, rc); //fills the rectangle to the background color
                e.Graphics.DrawRectangle(outColor, 1, 0, rc.Width - 2, rc.Height - 1); //draws the rectangle over the drop down menu
            }
        }
    }
    
}


