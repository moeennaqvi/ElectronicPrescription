using ElectronicRX2._1.DataAccess;
using ElectronicRX2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ElectronicRX2._1.Controllers
{
    public abstract class BaseController : Controller
    {
        private IPrescriptionService _service;
        private IModelFactory _modelFactory;

        protected BaseController(IPrescriptionService prescriptionService)
        {
            _service = prescriptionService;
        }
        protected IModelFactory ModelFactory
        {
            get
            {
                if(_modelFactory == null)
                {                    
                    _modelFactory = new ModelFactory();
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