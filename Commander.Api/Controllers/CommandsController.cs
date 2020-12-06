using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Api.Dtos;
using Commander.Logic.Core.Abstractions;
using Commander.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
// using System.Xml;

namespace Commander.Api.Controllers
{
    [ApiController]
    [Route("api/Commands")]
    public class CommandsController : Controller
    {
        private readonly ILogger<CommandsController> _logger;
        private readonly ICommandsRepository _commanderRepository;
        private readonly IMapper _autoMapper;
        public CommandsController(ILogger<CommandsController> logger,
     
        ICommandsRepository commanderRepository, IMapper autoMapper)
        {
            _autoMapper = autoMapper;
            _logger = logger;
            _commanderRepository = commanderRepository;
        }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAll()
    {
        var commands = _commanderRepository.GetAppCommands();
        return Ok(_autoMapper.Map<IEnumerable<CommandReadDto>>(commands));
    }

    [HttpGet("{id}", Name = "GetCommandById")]
    public ActionResult<IEnumerable<Command>> GetCommandById([FromRoute] int id)
    {
        var command = _commanderRepository.GetCommandById(id);

        if (command == null)
          return NotFound();

        return Ok(_autoMapper.Map<CommandReadDto>(command));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CommandCreate([FromBody]CommandCreateDto commandDto)
    {
        var command = _autoMapper.Map<Command>(commandDto);

        if (string.IsNullOrEmpty(commandDto.HowTo) || string.IsNullOrEmpty(commandDto.Line) ||
        string.IsNullOrEmpty(commandDto.Platform))
            return BadRequest("Erro de validação, por favor verifique os dados preenchidos.");

        _commanderRepository.AddCommand(command);
        _commanderRepository.SaveChanges();

        return CreatedAtRoute(nameof(GetCommandById), new {Id = command.Id }, _autoMapper.Map<CommandReadDto>(command));
    }

    [HttpPut("{id}")]
    public ActionResult CommandUpdate([FromRoute] int id, [FromBody]CommandCreateDto commandDto)
    {
        var command = _commanderRepository.GetCommandById(id);

        if (command == null)
          return NotFound();

   if (string.IsNullOrEmpty(commandDto.HowTo) || string.IsNullOrEmpty(commandDto.Line) ||
        string.IsNullOrEmpty(commandDto.Platform))
            return BadRequest("Erro de validação, por favor verifique os dados preenchidos.");

        command.HowTo = commandDto.HowTo;
        command.Line = commandDto.Line;
        command.Platform = commandDto.Platform;

        _commanderRepository.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult CommandDelete([FromRoute]int id)
    {
        var command = _commanderRepository.GetCommandById(id);

        if (command == null)
          return NotFound();

        _commanderRepository.DeleteCommand(command);
        _commanderRepository.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialCommandUpdate([FromRoute] int id, JsonPatchDocument<CommandCreateDto> patchDoc)
    {
     var command = _commanderRepository.GetCommandById(id);

        if (command == null)
          return NotFound();

        _logger.LogInformation(JsonConvert.SerializeObject(patchDoc, Formatting.Indented));
        
        var commandToPatch = _autoMapper.Map<CommandCreateDto>(command);

        patchDoc.ApplyTo(commandToPatch);

        _autoMapper.Map(commandToPatch, command);

        if (string.IsNullOrEmpty(command.HowTo) || string.IsNullOrEmpty(command.Line) ||
        string.IsNullOrEmpty(command.Platform))
            return BadRequest("Erro de validação, por favor verifique os dados preenchidos.");

        _commanderRepository.SaveChanges();

        return NoContent();
    }


}
}
