using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WinFormsApiTestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await LoadCustomerDataAsync();
        }

        private async Task LoadCustomerDataAsync()
        {
            HttpClient client = new HttpClient();
            string ServiceUrl = "https://dummy.restapiexample.com/api/v1/employees";

            List<Employee> AllEmployees;
            client.BaseAddress = new Uri(ServiceUrl);
            HttpResponseMessage response =  await client.GetAsync(ServiceUrl);

            if(response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var employeeResponse = JsonConvert.DeserializeObject<EmployeeResponse>(result);

                MainApiDataTextBox.Clear();

                foreach(var emp in employeeResponse.data)
                {
                    MainApiDataTextBox.Text +=
                         $"ID: {emp.id} \r\n" +
                         $"Salary: {emp.employee_salary} \r\n" +
                         $"Age: {emp.employee_age} \r\n" +
                         $"Image: {emp.profile_image} \r\n"+
                         $"--------------------------\r\n \r\n";
                }
                MainApiDataTextBox.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                MainApiDataTextBox.Text = "Failed to load data.";
            }
        }
    }
}
