[Route("api/[controller]")]
[ApiController]
public class MantraController : ControllerBase
{
    private readonly IMantraRepository _repository;
    private readonly IWebHostEnvironment _environment;

    public MantraController(IMantraRepository repository, IWebHostEnvironment environment)
    {
        _repository = repository;
        _environment = environment;
    }

    [HttpPost]
    public async Task<IActionResult> AddMantra([FromForm] MantraModel model)
    {
        if (model.MantraImage != null)
            model.MantraImagePath = await SaveFileAsync(model.MantraImage, "images");

        if (model.MantraAudio != null)
            model.MantraAudioPath = await SaveFileAsync(model.MantraAudio, "audios");

        if (model.LordImage != null)
            model.LordImagePath = await SaveFileAsync(model.LordImage, "images");

        if (model.LordThreed != null)
            model.LordThreedPath = await SaveFileAsync(model.LordThreed, "files");

        await _repository.AddMantraAsync(model);
        return Ok(new { message = "Mantra added successfully!" });
    }

    [HttpGet]
    public async Task<IActionResult> GetMantras()
    {
        var mantras = await _repository.GetMantrasAsync();
        return Ok(mantras);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMantra(int id)
    {
        var mantra = await _repository.GetMantraByIdAsync(id);
        if (mantra == null) return NotFound();
        return Ok(mantra);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMantra(int id, [FromForm] MantraModel model)
    {
        var existingMantra = await _repository.GetMantraByIdAsync(id);
        if (existingMantra == null) return NotFound();

        if (model.MantraImage != null)
            model.MantraImagePath = await SaveFileAsync(model.MantraImage, "images");

        if (model.MantraAudio != null)
            model.MantraAudioPath = await SaveFileAsync(model.MantraAudio, "audios");

        if (model.LordImage != null)
            model.LordImagePath = await SaveFileAsync(model.LordImage, "images");

        if (model.LordThreed != null)
            model.LordThreedPath = await SaveFileAsync(model.LordThreed, "files");

        model.Id = id;
        await _repository.UpdateMantraAsync(model);
        return Ok(new { message = "Mantra updated successfully!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMantra(int id)
    {
        await _repository.DeleteMantraAsync(id);
        return Ok(new { message = "Mantra deleted successfully!" });
    }

    private async Task<string> SaveFileAsync(IFormFile file, string folderName)
    {
        var uploadsFolder = Path.Combine(_environment.WebRootPath, folderName);
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/{folderName}/{fileName}";
    }
}
