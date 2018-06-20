using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q.Service.Interfaces;
using Q.Service.UseCases.Menu;
using Q.Web.Models;
using Q.Web.Presenters.Menu;

namespace Q.Web.Controllers.Menu
{
    [Produces("application/json")]
    [Route("api/Menu")]
    public class MenuController : Controller
    {
        private readonly IInputBoundary<CreateMenuItemRequest> _createMenuItemInteractor;
        private readonly IInputExecuteBoundary _getMenuItemsInteractor;
        private readonly IOutputConverter _outputConverter;
        private readonly MenuPresenter _menuPresenter;

        public MenuController(IInputBoundary<CreateMenuItemRequest> createMenuItemInteractor, IInputExecuteBoundary getMenuItemsInteractor, IOutputConverter outputConverter, MenuPresenter menuPresenter)
        {
            _createMenuItemInteractor = createMenuItemInteractor;
            _outputConverter = outputConverter;
            _getMenuItemsInteractor = getMenuItemsInteractor;
            _menuPresenter = menuPresenter;
        }
        // GET: api/Menu
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _getMenuItemsInteractor.Execute();
            return Ok(_menuPresenter.ViewModel);
        }

        // GET: api/Menu/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menu
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MenuItemModel menuItemModel)
        {
            var createMenuItemRequest = _outputConverter.Map<CreateMenuItemRequest>(menuItemModel);
            await _createMenuItemInteractor.Process(createMenuItemRequest);
            return Ok();
        }

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
