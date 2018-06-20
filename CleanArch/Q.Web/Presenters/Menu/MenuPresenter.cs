using Microsoft.AspNetCore.Mvc;
using Q.Service.Interfaces;
using Q.Service.UseCases.Menu;
using System.Collections.Generic;

namespace Q.Web.Presenters.Menu
{
    public class MenuPresenter : IOutputBoundary<List<MenuItemsOutput>>
    {
        public IActionResult ViewModel { get; private set; }
        public List<MenuItemsOutput> Output { get; private set; }

        private readonly IOutputConverter _outputConverter;

        public MenuPresenter(IOutputConverter outputConverter)
        {
            _outputConverter = outputConverter;
        }

        public void Populate(List<MenuItemsOutput> response)
        {
            Output = response;
            if (Output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            var taskListModel = _outputConverter.Map<List<MenuItemsOutput>>(Output);
            ViewModel = new OkObjectResult(taskListModel);
        }
    }
}
