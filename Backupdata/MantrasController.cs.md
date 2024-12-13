using meditation.Core.Models.Domain;
using meditation.Core.Models.Dto.CreateDto;
using meditation.Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace meditation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantrasController : ControllerBase
    {
        private readonly IMantraRepository _mantraRepository;

        public MantrasController(IMantraRepository mantraRepository)
        {
            _mantraRepository = mantraRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMantrasAsync(MantraModelCreateDto mantraModelCreateDto)
        {
            //mapp mantrasdto to mantras
            var mantras = new MantraModel
            {
                 MantraName = mantraModelCreateDto.MantraName,
                 MantraImage = mantraModelCreateDto.MantraImage,
                 MantraAudio = mantraModelCreateDto.MantraAudio,
                 MantraDescription = mantraModelCreateDto.MantraDescription,
                 LordImage = mantraModelCreateDto.LordImage,
                 LordThreed = mantraModelCreateDto.LordThreed,
                 CreatedAt = DateTime.Now,
                 UpdatedAt = DateTime.Now,
            };

            //save data
            _mantraRepository.CreateMantrasAsync(mantras);

            // mapp user to mantrascreatedto
            var response = new MantraModelCreateDto
            {
                MantraName = mantras.MantraName,
                MantraImage = mantras.MantraImage,
                MantraAudio = mantras.MantraAudio,
                MantraDescription = mantras.MantraDescription,
                LordImage = mantras.LordImage,
                LordThreed = mantras.LordThreed,
                CreatedAt = mantras.CreatedAt,
                UpdatedAt = mantras.UpdatedAt,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMantras()
        {
            var mantras = await _mantraRepository.GetAllMantrasAsync();
            var response = new List<MantraModelCreateDto>();

            foreach (var mantra in mantras)
            {
                response.Add(new MantraModelCreateDto
                {
                    Id = mantra.Id,
                    MantraName = mantra.MantraName,
                    MantraImage = mantra.MantraImage,
                    MantraAudio = mantra.MantraAudio,
                    MantraDescription = mantra.MantraDescription,
                    LordImage = mantra.LordImage,
                    LordThreed = mantra.LordThreed,
                    CreatedAt = mantra.CreatedAt,
                    UpdatedAt = mantra.UpdatedAt,
                });
            }
            return Ok(response);
        }
    }
}
