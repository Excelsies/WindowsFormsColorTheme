# Windows Forms Color Theme

These 4 files will give the functionality of changing the colors of your application.

There are a few things that need to be done after copying the files to your project to make this work.

- Change the namespace in each of the 4 files appropriately
- Under Properties > Settings you will need Several variables (this is used to store the custom colors on the locally)
  - cusTxtColor
  - cusTxtBoxColor
  - cusButtonColor
  - cusGridColor
  - cusGridTxtColor
  - cusGridHeaderColor
  - cusActiveTxtBoxColor
  - cusInactiveTxtBoxColor
  - cusBackColor
  - cusGroupBoxColor
  - cusSecGridColor
  - cusSecGridTxtColor
  - cusGridSelectColor
  - cusGridSelectTxtColor
  - cusSecGridSelectColor
  - cusSecGridSelectTxtColor
  - cusTabColor
  - cusTabTxtColor
  - cusPressedTabColor
  - cusPressedTabTxtColor
  - cusTabBorderColor
    - Each of the above will be listed in the Name column, each with the Type System.Drawing.Color you can leave the Scope as User and the value doesn't need to be adjusted (this value will be changed when the user selects their colors)
  - customThemeSet
    - This variable will also be listed in the Name column but will have the type bool. Leave the Scope as User and the value should be set to False - this variable is used to determine if the theme has changed or not
- On each form you want to use this custom theme in, you will need to paste the following code right after you Initialize the form.
  -          if (Properties.Settings.Default.customThemeSet)
                themeClass.customTheme(this); //Sets the custom theme for the form
  - This statement calls the customTheme function that is inside the themeClass that you copied over, which will change all of the controls to the specified colors
- You will need to place the following code on the function/event you use to open the form to setup your desired colors (I put this within a button click function)
  -         //creates and opens the themeForm to select and set the desired custom colors
            var themeForm = new ThemeCreator();
            themeForm.ShowDialog(); 

            //checks if the theme is set
            if (Properties.Settings.Default.customThemeSet)
            {
                themeClass.customTheme(this);//calls the function to change the colors to the custom theme
            }
            else
            {
                themeClass.resetTheme(this);//calls the function to change the colors to default
            }
            Refresh();
- 
