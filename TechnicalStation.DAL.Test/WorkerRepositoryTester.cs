using System;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Worker;
using TechnicalStation.DAL.Test.Base;

namespace TechnicalStation.DAL.Test
{
    public class WorkerRepositoryTester : RepositoryTesterBase<IWorkerRepository, Worker>
    {
        protected override void ModifyProperties(Worker worker)
        {
            worker.FirstName = "FirstName1";
            worker.LastName = "FirstName1";
            worker.Address = "FirstName1";
            worker.PhoneNumber = "128901";
            worker.Notes = "FirstName1";
        }

        /// <summary>
        /// Support function to build an object for test processing.
        /// </summary>
        protected override Worker BuildObject()
        {
            Worker worker = new Worker();

            // TODO: Construct an object. Fill up the fields with testing information using acceptance tests.

            worker.Id = 0;
            worker.FirstName = "FirstName";
            worker.LastName = "FirstName";
            worker.Address = "FirstName";
            worker.PhoneNumber = "12890";
            worker.Notes = "FirstName";

            return worker;
        }

	}
}
