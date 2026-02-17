using DogWalksEvents.Repository.DTOs;
using DogWalksEvents.Repository.Queries;
using DogWalksEvents.UIProcessor;

namespace DogWalksEvents
{
    public partial class EventsManager : Form
    {
        private string _dogWalkEventId;

        public EventsManager()
        {
            InitializeComponent();
        }

        private void EventsManager_Load(object sender, EventArgs e)
        {
            ClearFilterControls();
            ClearEventControls();
            LoadWalkEventsData().GetAwaiter().GetResult();
        }

        private void btnExecuteFilter_Click(object sender, EventArgs e)
        {
            LoadWalkEventsData().GetAwaiter().GetResult();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearEventControls();
            gridWalkEvents.ClearSelection();
            txtClientFirstName.Focus();
        }

        private void gridWalkEvents_SelectionChanged(object sender, EventArgs e)
        {

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

            if (!processResult.IsValidated)
            {
                MessageBox.Show("There are validation errors, please enter valid information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Refresh data after save
            ClearEventControls();
            LoadWalkEventsData().GetAwaiter().GetResult();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void ClearFilterControls()
        {
            txtClientFirstNameFilter.Text = string.Empty;
            txtClientLastNameFilter.Text = string.Empty;
            txtDogNameFilter.Text = string.Empty;
            txtDogBrandFilter.Text = string.Empty;
            numDogAge.Value = 0;
        }

        private void ClearEventControls()
        {
            _dogWalkEventId = string.Empty;
            txtClientFirstName.Text = string.Empty;
            txtClientFirstName.BackColor = Color.White;
            txtClientLastName.Text = string.Empty;
            txtClientLastName.BackColor = Color.White;
            txtClientPhoneNumber.Text = string.Empty;
            txtClientPhoneNumber.BackColor = Color.White;
            txtDogName.Text = string.Empty;
            txtDogName.BackColor = Color.White;
            txtDogBrand.Text = string.Empty;
            txtDogBrand.BackColor = Color.White;
            numDogAge.Value = 0;
            numDogAge.BackColor = Color.White;
            dtpWalkEventDate.Value = DateTime.Now;
            dtpWalkEventDate.BackColor = Color.White;
            numWalkEventDuration.Value = 0;
            numWalkEventDuration.BackColor = Color.White;
            btnClear.Visible = false;
            btnDelete.Visible = false;
        }

        private async Task LoadWalkEventsData()
        {
            var filter = new DogWalkEventQueryFilter
            {
                ClientFirstName = txtClientFirstNameFilter.Text.Trim(),
                ClientLastName = txtClientLastNameFilter.Text.Trim(),
                DogName = txtDogNameFilter.Text.Trim(),
                DogBrand = txtDogBrandFilter.Text.Trim(),
                DogAge = numDogAge.Value > 0 ? Convert.ToInt32(numDogAge.Value) : null,
            };

            using (var queryExecutor = new DogWalkEventsQueryHandler())
            {
                gridWalkEvents.AutoGenerateColumns = false;
                gridWalkEvents.DataSource = await queryExecutor.RunQuery(filter);
                gridWalkEvents.Refresh();
            }
        }
    }
}
