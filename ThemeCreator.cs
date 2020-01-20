using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YOURNAMESPACE //Make sure you change this to whichever namespace you are using!
{
    public partial class ThemeCreator : Form
    {
        //defines the premade dark theme colors
        Color darkBackColor = Color.Black;
        Color darkTxtColor = Color.Red;
        Color darkTxtBoxColor = Color.FromArgb(25, 25, 25);
        Color darkButtonColor = Color.FromArgb(30, 30, 30);
        Color darkGridColor = Color.FromArgb(35, 35, 35);
        Color darkGridTxtColor = Color.Red;
        Color darkGridHeaderColor = Color.FromArgb(35, 35, 35);
        Color darkActiveTxtBoxColor = Color.FromArgb(25, 25, 25);
        Color darkInactiveTxtBoxColor = Color.FromArgb(25, 25, 25);
        Color darkGroupBoxColor = Color.Red;
        Color darkSecGridColor = Color.FromArgb(55, 55, 55);
        Color darkSecGridTxtColor = Color.Red;
        Color darkGridSelectColor = Color.Maroon;
        Color darkGridSelectTxtColor = Color.Red;
        Color darkSecGridSelectColor = Color.Maroon;
        Color darkSecGridSelectTxtColor = Color.Red;
        Color darkTabPressed = Color.FromArgb(20, 20, 20);
        Color darkTabTxtPressedColor = Color.Red;
        Color darkTabColor = Color.FromArgb(55, 55, 55);
        Color darkTabTxtColor = Color.Red;
        Color darkTabBorderColor = Color.FromArgb(35, 35, 35);
        Color darkHyperTxtColor = Color.Blue;
        string darkFont = "Arial";
        int darkFontInd = 1;
        float darkFontSize = 8.25f;

        public ThemeCreator()
        {
            InitializeComponent();
            //centers the form
            this.CenterToParent();

            fontCmboBx.DrawItem += ComboBoxFonts_DrawItem;
            fontCmboBx.DataSource = FontFamily.Families.ToList();
            fontCmboBx.DropDownStyle = ComboBoxStyle.DropDownList;

            //checks if the theme is set
            if (Properties.Settings.Default.customThemeSet)
            {
                themeClass.customTheme(this);//Sets the custom theme for the form

                //changes the color buttons to reflect the appropriate colors
                backgroundBtn.BackColor = Properties.Settings.Default.cusBackColor;
                txtBtn.BackColor = Properties.Settings.Default.cusTxtColor;
                txtBoxBtn.BackColor = Properties.Settings.Default.cusTxtBoxColor;
                btnColorButton.BackColor = Properties.Settings.Default.cusButtonColor;
                gridBtn.BackColor = Properties.Settings.Default.cusGridColor;
                gridTxtBtn.BackColor = Properties.Settings.Default.cusGridTxtColor;
                gridHeaderBtn.BackColor = Properties.Settings.Default.cusGridHeaderColor;
                resultTxtBoxBtn.BackColor = Properties.Settings.Default.cusActiveTxtBoxColor;
                inactiveTxtBtn.BackColor = Properties.Settings.Default.cusInactiveTxtBoxColor;
                groupBoxBtn.BackColor = Properties.Settings.Default.cusGroupBoxColor;
                scndGridBtn.BackColor = Properties.Settings.Default.cusSecGridColor;
                secGridTxtBtn.BackColor = Properties.Settings.Default.cusSecGridTxtColor;
                gridSelectedBtn.BackColor = Properties.Settings.Default.cusGridSelectColor;
                gridSelectedTxtBtn.BackColor = Properties.Settings.Default.cusGridSelectTxtColor;
                secGridSelectedBtn.BackColor = Properties.Settings.Default.cusSecGridSelectColor;
                secGridSelectedTxtBtn.BackColor = Properties.Settings.Default.cusSecGridSelectTxtColor;
                tabBtn.BackColor = Properties.Settings.Default.cusTabColor;
                tabTxtBtn.BackColor = Properties.Settings.Default.cusTabTxtColor;
                tabPressedBtn.BackColor = Properties.Settings.Default.cusPressedTabColor;
                tabPressedTxtBtn.BackColor = Properties.Settings.Default.cusPressedTabTxtColor;
                tabBorderBtn.BackColor = Properties.Settings.Default.cusTabBorderColor;
                hyperLinkBtn.BackColor = Properties.Settings.Default.cusHyperLnkColor;
                fontSizeDrpDwn.Value = Convert.ToDecimal(Properties.Settings.Default.cusFontSize);
                fontCmboBx.SelectedIndex = Properties.Settings.Default.cusFontInd;
            }
            else
            {

                //changes the color buttons to reflect the appropriate colors
                backgroundBtn.BackColor = themeClass.originalBackColor;
                txtBtn.BackColor = themeClass.originalTxtColor;
                txtBoxBtn.BackColor = themeClass.originalTxtBoxColor;
                btnColorButton.BackColor = themeClass.originalButtonColor;
                gridBtn.BackColor = themeClass.originalGridColor;
                gridTxtBtn.BackColor = themeClass.originalGridTxtColor;
                gridHeaderBtn.BackColor = themeClass.originalGridHeaderColor;
                resultTxtBoxBtn.BackColor = themeClass.originalActiveTxtBoxColor;
                inactiveTxtBtn.BackColor = themeClass.originalInactiveTxtBoxColor;
                groupBoxBtn.BackColor = themeClass.originalGroupBoxColor;
                scndGridBtn.BackColor = themeClass.originalSecGridColor;
                secGridTxtBtn.BackColor = themeClass.originalSecGridTxtColor;
                gridSelectedBtn.BackColor = themeClass.originalGridSelectColor;
                gridSelectedTxtBtn.BackColor = themeClass.originalGridSelectTxtColor;
                secGridSelectedBtn.BackColor = themeClass.originalSecGridSelectColor;
                secGridSelectedTxtBtn.BackColor = themeClass.originalSecGridSelectTxtColor;
                tabBtn.BackColor = themeClass.originalTabColor;
                tabTxtBtn.BackColor = themeClass.originalTabTxtColor;
                tabPressedBtn.BackColor = themeClass.originalPressedTabColor;
                tabPressedTxtBtn.BackColor = themeClass.originalPressedTabTxtColor;
                tabBorderBtn.BackColor = themeClass.originalTabBorderColor;
                hyperLinkBtn.BackColor = themeClass.originalHyperLinkColor;
                fontSizeDrpDwn.Value = Convert.ToDecimal(themeClass.originalFontSize);
                fontCmboBx.SelectedIndex = 1;
            }



        }

        private void ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, comboBox.Font.SizeInPoints);
            Brush text = new SolidBrush(txtBtn.BackColor);

            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, text, e.Bounds.X, e.Bounds.Y);
        }

        private void setThemeBtn_Click(object sender, EventArgs e)
        {
            //gets the requested font
            string s = fontCmboBx.SelectedItem.ToString();
            int start = s.IndexOf('=') + 1;
            int end = s.IndexOf(']', start);
            string selectedFont = s.Substring(start, end - start);

            //Saves the index of the selected font
            Properties.Settings.Default.cusFontInd = fontCmboBx.SelectedIndex;

            //Sets the custom colors within the global variables of the themeClass based on the background colors of the buttons
            themeClass.SetCustomColors(backgroundBtn.BackColor, txtBtn.BackColor, txtBoxBtn.BackColor, btnColorButton.BackColor, gridBtn.BackColor, gridTxtBtn.BackColor, gridHeaderBtn.BackColor, resultTxtBoxBtn.BackColor, inactiveTxtBtn.BackColor, groupBoxBtn.BackColor, scndGridBtn.BackColor, secGridTxtBtn.BackColor, gridSelectedBtn.BackColor, gridSelectedTxtBtn.BackColor, secGridSelectedBtn.BackColor, secGridSelectedTxtBtn.BackColor, tabBtn.BackColor, tabTxtBtn.BackColor, tabPressedBtn.BackColor, tabPressedTxtBtn.BackColor, tabBorderBtn.BackColor, hyperLinkBtn.BackColor, selectedFont, (float)fontSizeDrpDwn.Value);
            Properties.Settings.Default.customThemeSet = true; //sets the custom theme as on
            Properties.Settings.Default.Save();
            themeClass.customTheme(this); //calls the function to change the colors to the custom theme
            this.Close(); //closes the Theme Creator Form
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            //Saves the index for the default font
            Properties.Settings.Default.cusFontInd = 1;


            Properties.Settings.Default.customThemeSet = false; //sets the custom theme as off
            Properties.Settings.Default.Save();
            themeClass.resetTheme(this); //calls the function to change the colors to default
            this.Close(); //closes the Theme Creator Form
        }

        private void darkThemeBtn_Click(object sender, EventArgs e)
        {

            //Saves the index for the dark Font font
            Properties.Settings.Default.cusFontInd = darkFontInd;

            //Sets the custom colors within the global variables of the themeClass based on the predefined colors
            themeClass.SetCustomColors(darkBackColor, darkTxtColor, darkTxtBoxColor, darkButtonColor, darkGridColor, darkGridTxtColor, darkGridHeaderColor, darkActiveTxtBoxColor, darkInactiveTxtBoxColor, darkGroupBoxColor, darkSecGridColor, darkSecGridTxtColor, darkGridSelectColor, darkGridSelectTxtColor, darkSecGridSelectColor, darkSecGridSelectTxtColor, darkTabColor, darkTabTxtColor, darkTabPressed, darkTabTxtPressedColor, darkTabPressed, darkHyperTxtColor, darkFont, darkFontSize);
            Properties.Settings.Default.customThemeSet = true; //calls the function to change the colors to the custom theme
            Properties.Settings.Default.Save();
            themeClass.customTheme(this); //calls the function to change the colors to the custom theme
            this.Close(); //closes the Theme Creator Form
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the Theme Creator Form
        }

        private void backgroundBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                backgroundBtn.BackColor = colorPicker.Color;
            }
        }

        private void txtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                txtBtn.BackColor = colorPicker.Color;
            }
        }

        private void txtBoxBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                txtBoxBtn.BackColor = colorPicker.Color;
            }
        }

        private void btnColorButton_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                btnColorButton.BackColor = colorPicker.Color;
            }
        }

        private void gridBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                gridBtn.BackColor = colorPicker.Color;
            }
        }

        private void gridTxtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                gridTxtBtn.BackColor = colorPicker.Color;
            }
        }

        private void gridHeaderBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                gridHeaderBtn.BackColor = colorPicker.Color;
            }
        }

        private void resultTxtBoxBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                resultTxtBoxBtn.BackColor = colorPicker.Color;
            }
        }

        private void inactiveTxtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                inactiveTxtBtn.BackColor = colorPicker.Color;
            }
        }

        private void groupBoxBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                groupBoxBtn.BackColor = colorPicker.Color;
            }
        }

        private void scndGridBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                scndGridBtn.BackColor = colorPicker.Color;
            }
        }

        private void secGridTxtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                secGridTxtBtn.BackColor = colorPicker.Color;
            }
        }

        private void gridSelectedBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                gridSelectedBtn.BackColor = colorPicker.Color;
            }
        }

        private void gridSelectedTxtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                gridSelectedTxtBtn.BackColor = colorPicker.Color;
            }
        }

        private void secGridSelectedBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                secGridSelectedBtn.BackColor = colorPicker.Color;
            }
        }

        private void secGridSelectedTxtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                secGridSelectedTxtBtn.BackColor = colorPicker.Color;
            }
        }

        private void tabBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                tabBtn.BackColor = colorPicker.Color;
            }
        }

        private void tabTxtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                tabTxtBtn.BackColor = colorPicker.Color;
            }
        }

        private void tabPressedBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                tabPressedBtn.BackColor = colorPicker.Color;
            }
        }

        private void tabPressedTxtBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                tabPressedTxtBtn.BackColor = colorPicker.Color;
            }
        }

        private void tabBorderBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                tabBorderBtn.BackColor = colorPicker.Color;
            }
        }

        private void hyperLinkBtn_Click(object sender, EventArgs e)
        {
            //enables the Color Dialog tool
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //selecting OK sets the background color of the button to the color selected
                hyperLinkBtn.BackColor = colorPicker.Color;
            }
        }
    }
}
