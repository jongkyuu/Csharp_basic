using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            this.logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            //return base.GetCustomerInfo(request, context);
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.FirstName = "Jamie";
                output.LastName = "Smith";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Jane";
                output.LastName = "Doe";
            }
            else
            {
                output.FirstName = "Greg";
                output.LastName = "Thomas";
            }

            return Task.FromResult(output);
        }


        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Tim",
                    LastName = "Corey",
                    EmailAddress = "Tim@gmail.com"
                },
                new CustomerModel
                {
                    FirstName = "Sue",
                    LastName = "Storm",
                    EmailAddress = "Sue@gmail.com"
                },
                new CustomerModel
                {
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "Bilbo@gmail.com"
                }
            };

            foreach (var customer in customers)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(customer);
            }
        }
    }
}
