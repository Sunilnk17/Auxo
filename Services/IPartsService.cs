using System;
using Auxo.Models;
using Auxo.Models.Dtos.Requests;

namespace Auxo.Services;

public interface IPartsService
{
    Task<List<Parts>> GetParts();

    Task<Parts> PostParts(PartsRequest partsRequest);
}
