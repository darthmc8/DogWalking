using DogWalksEvents.Repository.DTOs;
using DogWalksEvents.Repository.Queries;
using DogWalksEvents.Repository.Validations;
using DogWalksEvents.UIProcessor;

namespace DogWalksEvents
{
    public partial class EventsManager : Form
    {
        private string _dogWalkEventId;
        private bool _selectByMouse = false;

        public EventsManager()
        {
            InitializeComponent();
        }

        private void EventsManager_Load(object sender, EventArgs e)
        {
            ClearFilterControls();
            LoadWalkEventsData().GetAwaiter().GetResult();
            ClearEventControls();
        }

        private void btnExecuteFilter_Click(object sender, EventArgs e)
        {
            LoadWalkEventsData().GetAwaiter().GetResult();
            ClearEventControls();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            ClearFilterControls();
            LoadWalkEventsData().GetAwaiter().GetResult();
            ClearEventControls();
        }

        private void gridWalkEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (gridWalkEvents.SelectedRows.Count > 0)
            {
                var selectedRow = gridWalkEvents.SelectedRows[0];
                DateOnly walkDate = (DateOnly)selectedRow.Cells["WalkEventDate"].Value;
                _dogWalkEventId = selectedRow.Cells["EventId"].Value.ToString();
                txtClientFirstName.Text = selectedRow.Cells["ClientFirstName"].Value.ToString();
                txtClientLastName.Text = selectedRow.Cells["ClientLastName"].Value.ToString();
                txtClientPhoneNumber.Text = selectedRow.Cells["ClientPhoneNumber"].Value.ToString();
                txtDogName.Text = selectedRow.Cells["DogName"].Value.ToString();
                txtDogBrand.Text = selectedRow.Cells["DogBrand"].Value.ToString();
                numDogAge.Value = Convert.ToInt32(selectedRow.Cells["DogAge"].Value);
                dtpWalkEventDate.Value = walkDate.ToDateTime(TimeOnly.MinValue);
                numWalkEventDuration.Value = Convert.ToInt32(selectedRow.Cells["WalkEventDuration"].Value);
                btnSave.Visible = false;
                btnClear.Visible = true;
                btnDelete.Visible = true;
            }
        }

        private void gridWalkEvents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Clear any default selection
            ((DataGridView)sender).ClearSelection();

            // Ensure no cell is the 'current' cell
            ((DataGridView)sender).CurrentCell = null;
        }

        private void numDogAge_Enter(object sender, EventArgs e)
        {
            NumericUpDown dogAgeControl = sender as NumericUpDown;
            // Select all text when focus is gained via keyboard (e.g., Tab key)
            dogAgeControl.Select(0, dogAgeControl.Value.ToString().Length);

            if (MouseButtons == MouseButtons.Left)
            {
                _selectByMouse = true;
            }
        }

        private void numDogAge_MouseDown(object sender, MouseEventArgs e)
        {
            NumericUpDown dogAgeControl = sender as NumericUpDown;
            // If focus was gained by a mouse click, re-select all text in the MouseDown event
            if (_selectByMouse)
            {
                dogAgeControl.Select(0, dogAgeControl.Value.ToString().Length);
                _selectByMouse = false;
            }
        }

        private void numWalkEventDuration_Enter(object sender, EventArgs e)
        {
            NumericUpDown durationControl = sender as NumericUpDown;
            // Select all text when focus is gained via keyboard (e.g., Tab key)
            durationControl.Select(0, durationControl.Value.ToString().Length);

            if (MouseButtons == MouseButtons.Left)
            {
                _selectByMouse = true;
            }
        }

        private void numWalkEventDuration_MouseDown(object sender, MouseEventArgs e)
        {
            NumericUpDown durationControl = sender as NumericUpDown;
            // If focus was gained by a mouse click, re-select all text in the MouseDown event
            if (_selectByMouse)
            {
                durationControl.Select(0, durationControl.Value.ToString().Length);
                _selectByMouse = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var eventDto = new DogWalkEventDTO
            {
                Id = _dogWalkEventId,
                ClientFirstName = txtClientFirstName.Text.Trim(),
                ClientLastName = txtClientLastName.Text.Trim(),
                ClientPhoneNumber = txtClientPhoneNumber.Text.Trim(),
                DogName = txtDogName.Text.Trim(),
                DogBrand = txtDogBrand.Text.Trim(),
                DogAge = Convert.ToInt32(numDogAge.Value),
                WalkDate = new DateOnly(dtpWalkEventDate.Value.Year, dtpWalkEventDate.Value.Month, dtpWalkEventDate.Value.Day),
                Duration = Convert.ToInt32(numWalkEventDuration.Value)
            };

            var processAdd = new UIProcessorHandler(eventDto);
            var processResult = processAdd.ProcessCreate();

            processAdd.Dispose();

            // Clear Validation errors before handling new ones
            ClearValidationErrors();

            if (!processResult.IsValidated)
            {
                MessageBox.Show("There are validation errors, please enter valid information", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set validation errors in the form controls and highlight them
                HandleValidationErrors(processResult.ValidationResults);

                return;
            }

            // Refresh data after save
            LoadWalkEventsData().GetAwaiter().GetResult();
            ClearEventControls();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadWalkEventsData().GetAwaiter().GetResult();
            ClearValidationErrors();
            ClearEventControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteWalkEvent().GetAwaiter().GetResult();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to close the application?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Resets all filter input controls to their default values, clearing any user-entered filter criteria from the
        /// interface.
        /// </summary>
        /// <remarks>Use this method to clear all active filters and restore the filter controls to their
        /// initial, unfiltered state. This is typically called when the user wants to remove all applied filters and
        /// view the complete, unfiltered data set.</remarks>
        private void ClearFilterControls()
        {
            txtClientFirstNameFilter.Text = string.Empty;
            txtClientLastNameFilter.Text = string.Empty;
            txtDogNameFilter.Text = string.Empty;
            txtDogBrandFilter.Text = string.Empty;
            numDogAgeFilter.Value = 0;
            dtpWalkEventDateFilter.Value = DateTime.Now;
            dtpWalkEventDateFilter.Checked = false;
        }

        /// <summary>
        /// Resets all event control fields to their default values, clearing any user input.
        /// </summary>
        /// <remarks>This method is typically used to prepare the form for a new event entry by ensuring
        /// that all fields are empty and any previous selections are cleared.</remarks>
        private void ClearEventControls()
        {
            _dogWalkEventId = string.Empty;
            txtClientFirstName.Text = string.Empty;
            txtClientLastName.Text = string.Empty;
            txtClientPhoneNumber.Text = string.Empty;
            txtDogName.Text = string.Empty;
            txtDogBrand.Text = string.Empty;
            numDogAge.Value = 0;
            dtpWalkEventDate.Value = DateTime.Now;
            numWalkEventDuration.Value = 0;
            btnSave.Visible = true;
            btnClear.Visible = false;
            btnDelete.Visible = false;

            txtClientFirstName.Focus();
        }

        /// <summary>
        /// Resets the background color and removes validation tooltips from all event input controls, indicating that
        /// any previous validation errors have been cleared.
        /// </summary>
        /// <remarks>Call this method after successful validation or when resetting the form to ensure
        /// that all input controls appear in their default, error-free state. This method affects only the visual state
        /// of the controls and does not modify their values.</remarks>
        private void ClearValidationErrors()
        {
            var eventControls = new List<Control>
            {
                txtClientFirstName,
                txtClientLastName,
                txtClientPhoneNumber,
                txtDogName,
                txtDogBrand,
                numDogAge,
                dtpWalkEventDate,
                numWalkEventDuration
            };

            foreach (Control control in eventControls)
            {
                control.BackColor = Color.White;
                tltEventInputs.SetToolTip(control, string.Empty);
                tltEventInputs.ShowAlways = false;
            }
        }

        /// <summary>
        /// Highlights controls associated with validation errors and displays corresponding error messages as tooltips.
        /// </summary>
        /// <remarks>This method visually indicates validation errors by changing the background color of
        /// affected controls and setting tooltips with error messages. Controls are identified by their names as
        /// specified in the validation results.</remarks>
        /// <param name="validationResults">A list of validation results, each specifying the name of a control and an associated error message to
        /// display.</param>
        private void HandleValidationErrors(List<WalkEventValidationResult> validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                var control = this.Controls.Find(validationResult.ControlName, true).FirstOrDefault();
                if (control != null)
                {
                    var tooltip = new ToolTip();
                    control.BackColor = Color.LightPink;
                    tooltip.SetToolTip(control, validationResult.Message);
                    //tooltip.Show(validationResult.Message, control);
                }
            }
        }

        /// <summary>
        /// Asynchronously loads and displays dog walk event data based on the current filter criteria entered by the
        /// user.
        /// </summary>
        /// <remarks>This method constructs a filter from the user input fields for client and dog
        /// information, retrieves the matching dog walk events, and updates the data grid to reflect the filtered
        /// results. Ensure that the relevant filter fields are populated as needed before invoking this method. The
        /// data grid is refreshed after the data source is updated.</remarks>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task LoadWalkEventsData()
        {
            var filter = new DogWalkEventQueryFilter
            {
                ClientFirstName = txtClientFirstNameFilter.Text.Trim(),
                ClientLastName = txtClientLastNameFilter.Text.Trim(),
                DogName = txtDogNameFilter.Text.Trim(),
                DogBrand = txtDogBrandFilter.Text.Trim(),
                DogAge = numDogAgeFilter.Value > 0 ? Convert.ToInt32(numDogAgeFilter.Value) : null,
                WalkDate = dtpWalkEventDateFilter.Checked ? new DateOnly(dtpWalkEventDateFilter.Value.Year, dtpWalkEventDateFilter.Value.Month, dtpWalkEventDateFilter.Value.Day) : null,
            };

            using (var queryExecutor = new DogWalkEventsQueryHandler())
            {
                gridWalkEvents.AutoGenerateColumns = false;
                gridWalkEvents.DataSource = await queryExecutor.RunQuery(filter);
                gridWalkEvents.Refresh();
            }
        }

        /// <summary>
        /// Deletes the currently selected dog walk event after user confirmation.
        /// </summary>
        /// <remarks>If no walk event is selected, an error message is displayed and the operation is
        /// canceled. The user is prompted to confirm the deletion before the event is removed. After a successful
        /// deletion, the event controls are cleared and the list of walk events is refreshed.</remarks>
        /// <returns>This method does not return a value.</returns>
        private async Task DeleteWalkEvent()
        {
            if (string.IsNullOrEmpty(_dogWalkEventId))
            {
                MessageBox.Show("Please select a walk event to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure you want to delete this walk event?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                // Processing delete action
                var processDelete = new UIProcessorHandler(new DogWalkEventDTO { Id = _dogWalkEventId });
                await processDelete.ProcessDelete();

                processDelete.Dispose();

                await LoadWalkEventsData();
                ClearEventControls();
            }
        }
    }
}
