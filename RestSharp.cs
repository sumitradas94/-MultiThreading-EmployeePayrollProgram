using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
namespace RestSharpTestCase
{
    public class Employee
    {
        public int id { get; set; }

        public string name { get; set; }

        public string email { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employees", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void onCallingGetAPI_ReturnEmployeeList()

        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);
        }



        [TestMethod]
        public void givenEmployee_OnPost_ShouldReturnAddEmployee()
        {
            RestRequest request = new RestRequest("/employees", Method.POST);
            System.Text.Json.Nodes.JsonObject jsonObject = new System.Text.Json.Nodes.JsonObject();

            jsonObject.Add("name", "Clark");
            jsonObject.Add("email", "clk123@gmail.com");

            request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);

            Employee dataresponse = JsonConvert.DeserializeObject<Employee>(response.Content);

            Assert.AreEqual("Clark", dataresponse.name);
            Assert.AreEqual("clk123@gmail.com", dataresponse.email);

            Console.WriteLine(response.Content);
        }

        [TestMethod]
        public void deleteEmployee()
        {
            RestRequest request = new RestRequest("/employees/11", Method.DELETE);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Console.WriteLine(response.Content);
        }

        [TestMethod]
        public void givenEmployee_OnPut_ShouldReturnAddEmployee()
        {
            RestRequest request = new RestRequest("/employees/12", Method.PUT);
            System.Text.Json.Nodes.JsonObject jsonObject = new System.Text.Json.Nodes.JsonObject();

            jsonObject.Add("name", "praveen");
            jsonObject.Add("email", "prav123@gmail.com");

            request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            Employee dataresponse = JsonConvert.DeserializeObject<Employee>(response.Content);

            Assert.AreEqual("praveen", dataresponse.name);
            Assert.AreEqual("prav123@gmail.com", dataresponse.email);

            Console.WriteLine(response.Content);
        }

    }
}