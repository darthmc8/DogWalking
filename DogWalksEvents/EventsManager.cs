using DogWalksEvents.Repository.Queries;

namespace DogWalksEvents
{
    public partial class EventsManager : Form
    {
        public EventsManager()
        {
            InitializeComponent();
        }

        private void EventsManager_Load(object sender, EventArgs e)
        {
            LoadWalkEventsData().GetAwaiter().GetResult();
        }

        private void btnExecuteFilter_Click(object sender, EventArgs e)
        {
            LoadWalkEventsData().GetAwaiter().GetResult();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void gridWalkEvents_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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
