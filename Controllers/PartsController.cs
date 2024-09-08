using AutoMapper;
using Auxo.Models;
using Auxo.Models.Dtos.Requests;
using Auxo.Models.Dtos.Responses;
using Auxo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Auxo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        public readonly IPartsService _partService;

        public readonly IMapper _mapper;

        public PartsController(IPartsService partService, IMapper mapper)
        {
            _partService = partService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<PartsResponse>> GetParts()
        {
            List<Parts> partsFromDb = await _partService.GetParts();
            return _mapper.Map<List<PartsResponse>>(partsFromDb);
        }

        [HttpPost]
        public async Task<ActionResult<PartsResponse>> PostParts([FromBody] PartsRequest partsRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Parts parts = await _partService.PostParts(partsRequest);
                    return _mapper.Map<PartsResponse>(parts);
                }

                throw new Exception("Mandatory fields are invalid.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
