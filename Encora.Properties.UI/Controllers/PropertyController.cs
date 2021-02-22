using AutoMapper;
using Encora.Properties.Contracts.Dtos;
using Encora.Properties.Services.Interfaces;
using Encora.Properties.UI.Infrastructure;
using Encora.Properties.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encora.Properties.UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyManager _propertyManager;
        private readonly IMapper _mapper;
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(
            IPropertyManager propertyManager,
            IMapper mapper,
            ILogger<PropertyController> logger)
        {
            _propertyManager = propertyManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {            
            var listOfPropertiesDTO = await _propertyManager.GetAllPropertiesAsync();
            var listofPropertiesModel = _mapper.Map<ICollection<PropertyModel>>(listOfPropertiesDTO);
            return View(listofPropertiesModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(
            PropertyModel propertyModel)
        {            
            var propertyDto = _mapper.Map<PropertyDto>(propertyModel);
            var wasAdded = await _propertyManager.AddPropertyAsync(propertyDto);
            if (!wasAdded)
                SetMessage(string.Format(Constants.ErrorPropertyAlreadyCreated, propertyModel.Id));
            else
                SetMessage(string.Format(Constants.SucessPropertyCreated, propertyModel.Id));
            
            return RedirectToAction(nameof(Index));                 
        }

        public void SetMessage(string message) =>
            TempData[Constants.TempDataResultMessage] = message;
        
    }
}
