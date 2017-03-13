/*
 * Todos:
 *  -allow windows to be saved with only a pos to allow for positioning without resizing
 *  -change collection storage from binaryformatter to xml
 *  -create custom combobox component to eliminate lastkey shenanigans
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WindowScrape.Types;

namespace WindowPositioner
{
    public partial class WindowPositioner : Form
    {
        private string saveFilePath = @"collections.dat";
        private bool populateOnChange = true;
        private char wildcard = '%';
        private WindowCollectionContainer container;
        private SaveManager saveManager;
        private HwndObject handle;
        private HwndRefreshTimer refreshTimer;

        #region constructor
        public WindowPositioner()
        {
            InitializeComponent();
            // load
            saveManager = new SaveManager(saveFilePath);
            container = saveManager.SaveExists() 
                ? saveManager.LoadContainer() 
                : new WindowCollectionContainer();

            if (container.Collections.Count > 0)
            {
                RefreshCollectionComboBox();
            }

            EvaluateControls();

            RefreshHwndAutocomplete();
            refreshTimer = new HwndRefreshTimer(this);
            refreshTimer.hwndRefresh += new HwndRefreshTimer.hwndRefreshHandler(RefreshHwndAutocomplete);
            refreshTimer.Go();


            #region tooltips
            // window combobox tooltip.  unfortunately refreshing the autocompletesource causes the component/tooltip to 
            // flicker.  known bug since 2007
            ToolTip baseToolTip = new ToolTip();
            //baseToolTip.IsBalloon = true;
            baseToolTip.ShowAlways = false;
            baseToolTip.InitialDelay = 600;
            baseToolTip.SetToolTip(windowsComboBox, 
                "Start typing the window name, or surround a section of the title with % signs\n e.g. 'Steam' or '%google chrome%'");

            baseToolTip.SetToolTip(translateCheckbox, 
                "Checking this will take the size of the border and titlebar into consideration\n and resize just the interior");

            baseToolTip.SetToolTip(newLayoutButton,
                "Click to create a new collection of windows and rules");

            baseToolTip.SetToolTip(refreshWindowButton,
                "Click here if the window has changed or moved and you want to get & save the new values");

            baseToolTip.SetToolTip(applyLayoutButton,
                "Click to apply your rules to all the windows contained in this layout");

            baseToolTip.SetToolTip(removeWindowButton,
                "Remove the selected window from the layout collection");
            

            #endregion

        }
        #endregion

        #region button handlers
        private void newLayoutButton_Click(object sender, EventArgs e)
        {
            string value = "My Collection";
            if (DialogBox.InputBox("Collection name", "New collection name:", ref value) == DialogResult.OK)
            {
                if (layoutsComboBox.Items.Contains(value))
                {
                    MessageBox.Show("Sorry, a collection with that name already exists.");
                    newLayoutButton_Click(sender, e);
                }

                container.Collections.Add(new WindowCollection(value));
                saveManager.SaveContainer(container);
                RefreshCollectionComboBox((container.Collections.Count - 1));
                windowsComboBox.ResetText();
                EvaluateControls();
            }

        }

        private void applyLayoutButton_Click(object sender, EventArgs e)
        {
            MoveLayoutWindows(container.Collections[layoutsComboBox.SelectedIndex]);
        }

        private void deleteLayoutButton_Click(object sender, EventArgs e)
        {
            string name = layoutsComboBox.Items[layoutsComboBox.SelectedIndex].ToString();
            if (MessageBox.Show("Permanently delete '" + name + "'?", "Confirm Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                container.Collections.RemoveAt(layoutsComboBox.SelectedIndex);
                saveManager.SaveContainer(container);
                RefreshCollectionComboBox();
                refreshWindowListBox();
                EvaluateControls();
            }
        }


        private void saveWindowButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (widthField.Text.Length > 0 && heightField.Text.Length > 0 && xField.Text.Length > 0 && yField.Text.Length > 0)
                {
                    bool exists = false;
                    Window w = new Window(
                        int.Parse(xField.Text),
                        int.Parse(yField.Text),
                        int.Parse(widthField.Text),
                        int.Parse(heightField.Text),
                        windowsComboBox.Text,
                        translateCheckbox.Checked);

                    // if the window already exists in the collection, update it.
                    for (int i = 0; i < container.Collections[layoutsComboBox.SelectedIndex].Windows.Count; i++)
                    {
                        if (container.Collections[layoutsComboBox.SelectedIndex].Windows[i].title == w.title)
                        {
                            container.Collections[layoutsComboBox.SelectedIndex].Windows[i] = w;
                            exists = true;
                            break;
                        }
                    }
                    // otherwise just add it
                    if (!exists)
                    {
                        container.Collections[layoutsComboBox.SelectedIndex].Windows.Add(w);
                    }

                    saveManager.SaveContainer(container);

                    // move the window
                    w.MoveAndResize(handle);

                    // update the windows list
                    refreshWindowListBox(container.Collections[layoutsComboBox.SelectedIndex].Windows.Count - 1);

                    windowsComboBox.ResetText();
                    xField.ResetText(); yField.ResetText(); widthField.ResetText(); heightField.ResetText(); translateCheckbox.Checked = false;
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("One of the fields is NULL");
            }
            catch (FormatException)
            {
                MessageBox.Show("Something is not a number");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Something is too big or too small");
            }

        }


        private void refreshWindowButton_Click(object sender, EventArgs e)
        {
            handle = HwndObject.GetWindowByTitle(windowsComboBox.Text);
            widthField.Text = handle.Size.Width.ToString();
            heightField.Text = handle.Size.Height.ToString();
            xField.Text = handle.Location.X.ToString();
            yField.Text = handle.Location.Y.ToString();
        }


        private void removeWindowButton_Click(object sender, EventArgs e)
        {
            try
            {
                container.Collections[layoutsComboBox.SelectedIndex].Windows.RemoveAt(windowsListBox.SelectedIndex);
                saveManager.SaveContainer(container);

                refreshWindowListBox(container.Collections[layoutsComboBox.SelectedIndex].Windows.Count - 1);
            }
            catch (ArgumentOutOfRangeException are)
            {

            }
        }

        #endregion

        #region layouts combobox
        private void RefreshCollectionComboBox(int index = 0)
        {
            layoutsComboBox.Items.Clear();

            foreach (WindowCollection coll in container.Collections)
            {
                layoutsComboBox.Items.Add(coll.title);
            }

            layoutsComboBox.Text = "";

            if (layoutsComboBox.Items.Count > index)
            {
                layoutsComboBox.SelectedIndex = index;
            }

        }


        private void layoutsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;

            foreach (WindowCollection coll in container.Collections)
            {
                // load the collection
                if (coll.title == box.Items[box.SelectedIndex].ToString())
                {
                    LoadCollection(coll);
                    //MoveLayoutWindows(coll);  // functionality now moved to 'Apply' layout button
                    break;
                }
            }

        }

        #endregion

        #region windows list
        private void refreshWindowListBox(int index = 0)
        {
            windowsListBox.Items.Clear();

            if (container.Collections.Count > layoutsComboBox.SelectedIndex && container.Collections.Count > 0)
            {
                foreach (Window w in container.Collections[layoutsComboBox.SelectedIndex].Windows)
                {
                    windowsListBox.Items.Add(w.title);
                }

                if (windowsListBox.Items.Count > index)
                {
                    windowsListBox.SelectedIndex = index;
                }
            }

        }


        private void windowsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Window w = container.Collections[layoutsComboBox.SelectedIndex].Windows[windowsListBox.SelectedIndex];

            windowsComboBox.Text = w.title;

            widthField.Text = w.width.ToString();
            heightField.Text = w.height.ToString();
            xField.Text = w.x.ToString();
            yField.Text = w.y.ToString();
            translateCheckbox.Checked = w.translate;
        }


        private void windowsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = windowsListBox.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                // apply the saved settings for selected window
                Window w = container.Collections[layoutsComboBox.SelectedIndex].Windows[index];
                //MessageBox.Show(w.title);
                //w.MoveAndResize();
            }
        }
        #endregion

        #region windows combobox
        private void windowsComboBox_TextChanged(object sender, EventArgs e)
        {
            
            if (windowsComboBox.Text.Length == 0)
            {
                xField.ResetText(); yField.ResetText(); widthField.ResetText(); heightField.ResetText();
            }
            else
            {
                handle = HwndObject.GetWindowByTitle(windowsComboBox.Text);

                if (populateOnChange && windowsComboBox.Text[0] != wildcard)
                {
                    widthField.Text = handle.Size.Width.ToString();
                    heightField.Text = handle.Size.Height.ToString();
                    xField.Text = handle.Location.X.ToString();
                    yField.Text = handle.Location.Y.ToString();
                    translateCheckbox.Checked = false;
                }

            }

        }


        // will eventually refactor; make the windows combobox it's own class
        private void windowsComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            // % and backspace will not trigger re-population of the pos/size fields
            populateOnChange = (e.KeyCode == Keys.Back || ((e.Modifiers & Keys.Shift) == Keys.Shift && e.KeyCode == Keys.D5))
                ? false
                : true;
        }

        #endregion

        #region general functionality


        private void EvaluateControls()
        {
            if (layoutsComboBox.Items.Count == 0)
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }
                newLayoutButton.Enabled = true;
            }
            else
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = true;
                }
            }

            // always enabled
            //groupBox1.Enabled = true;
            //windowSettingsBox.Enabled = true;
            authorLabel.Enabled = true;            
        }
        
        // if combobox is empty, refresh the window titles autocomplete source
        public void RefreshHwndAutocomplete()
        {
            if (windowsComboBox.Text.Length == 0)
            {
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                foreach (HwndObject o in HwndObject.GetWindows())
                {
                    data.Add(o.Title);
                }
                windowsComboBox.AutoCompleteCustomSource = data;
            }
        }


        private void LoadCollection(WindowCollection coll)
        {
            windowsListBox.Items.Clear();

            if (coll.Windows.Count > 0)
            {
                foreach (Window win in coll.Windows)
                {
                    windowsListBox.Items.Add(win.title);
                }
            }

        }


        // ideally this should utilize the find/move single window function, however
        // the Hwnd library i'm using does not really allow for that :/
        private void MoveLayoutWindows(WindowCollection coll)
        {
            foreach (HwndObject o in HwndObject.GetWindows())
            {
                foreach (Window w in coll.Windows)
                {
                    if (TitlesMatch(w, o)) w.MoveAndResize(o);
                }
            }
        }


        private bool TitlesMatch(Window w, HwndObject o)
        {
            return ((w.title[0] == wildcard && o.Title.ToLower().IndexOf(w.title.Trim(wildcard).ToLower()) != -1)
                || o.Title.ToLower() == w.title.ToLower());
        }


        private void authorLabel_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("-rhemz", "Author");
        }

        #endregion       

    }
}
