[HttpPost]
public async Task<ActionResult> CreateMantrasAsync([FromForm] MantraModelCreateDto mantraModelCreateDto)
{
    // Validate input
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    // File handling logic
    string mantraImagePath = null;
    string mantraAudioPath = null;
    string lordImagePath = null;
    string lordThreedPath = null;

    if (mantraModelCreateDto.MantraImage != null)
    {
        mantraImagePath = await SaveFileAsync(mantraModelCreateDto.MantraImage, "mantras/images");
    }

    if (mantraModelCreateDto.MantraAudio != null)
    {
        mantraAudioPath = await SaveFileAsync(mantraModelCreateDto.MantraAudio, "mantras/audio");
    }

    if (mantraModelCreateDto.LordImage != null)
    {
        lordImagePath = await SaveFileAsync(mantraModelCreateDto.LordImage, "mantras/images");
    }

    if (mantraModelCreateDto.LordThreed != null)
    {
        lordThreedPath = await SaveFileAsync(mantraModelCreateDto.LordThreed, "mantras/3d");
    }

    // Map DTO to Entity
    var mantras = new MantraModel
    {
        MantraName = mantraModelCreateDto.MantraName,
        MantraImagePath = mantraImagePath,
        MantraAudioPath = mantraAudioPath,
        MantraDescription = mantraModelCreateDto.MantraDescription,
        LordImagePath = lordImagePath,
        LordThreedPath = lordThreedPath,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
    };

    // Save data using repository
    await _mantraRepository.CreateMantrasAsync(mantras);

    // Map Entity to Response DTO
    var response = new MantraModelCreateDto
    {
        MantraName = mantras.MantraName,
        MantraImagePath = mantras.MantraImagePath,
        MantraAudioPath = mantras.MantraAudioPath,
        MantraDescription = mantras.MantraDescription,
        LordImagePath = mantras.LordImagePath,
        LordThreedPath = mantras.LordThreedPath,
        CreatedAt = mantras.CreatedAt,
        UpdatedAt = mantras.UpdatedAt,
    };

    return Ok(response);
}

// Helper method to save files
private async Task<string> SaveFileAsync(IFormFile file, string folderPath)
{
    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath);
    Directory.CreateDirectory(uploadPath); // Ensure the folder exists

    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
    string filePath = Path.Combine(uploadPath, fileName);

    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await file.CopyToAsync(stream);
    }

    return Path.Combine(folderPath, fileName).Replace("\\", "/"); // Return relative path
}
