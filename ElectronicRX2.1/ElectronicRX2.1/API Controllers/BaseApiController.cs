using ElectronicRX2._1.DataAccess;
using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElectronicRX2._1.API_Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private IPrescriptionService _service;
        private IModelFactory _modelFactory;

        protected BaseApiController(IPrescriptionService prescriptionService)
        {
            _service = prescriptionService;
        }
        protected IModelFactory ModelFactory
        {
            get
            {
                if(_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request);
                }
                return _modelFactory;
            }
        }

        protected IPrescriptionService PrescriptionService
        {
            get
            {
                return _service;
            }
        }
    }
}
